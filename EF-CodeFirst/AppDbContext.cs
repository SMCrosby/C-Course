using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirst {

    public class AppDbContext : DbContext {         //inheriting from DbContext
      
        //---Framework only looks at classes within the context class so must add tables into conext class for them to be migrated/updated---
        public virtual DbSet<Customer> Customers { get; set; }      //Generic list for Customer Table
        public virtual DbSet<Order> Orders { get; set; }            //Generic list for Order Table
        public virtual DbSet<OrderLine> OrderLines { get; set; }


        public AppDbContext(DbContextOptions options) : base(options) { }    //Constructor lets us connect to sql Db
        public AppDbContext() : base() { }                                  // :base()  = calls upon default constructor


         //protected is only related to inheritance -- override means method exists in inherited class but we want the program to do this instead
         //block needed if you don't have a startup class. Needed when not doing a web app
        protected override void OnConfiguring(DbContextOptionsBuilder options) {       
            if(!options.IsConfigured) {         //if we haven't configured it before
                options.UseSqlServer("server=localhost\\sqlexpress;database=CustOrdDb;trusted_connection=true;");       //Connection string

            }
        }


        protected override void OnModelCreating(ModelBuilder builder) {     //Tables without FKey's go first //fluent-api's go here
            
            //start with variable name
            builder.Entity<Customer>(e => {
                e.HasIndex(x => x.Code).IsUnique();
            });

            builder.Entity<Order>(e => {
                e.Property(x => x.Description).IsRequired().HasMaxLength(50);
            });

        }

    }
}
