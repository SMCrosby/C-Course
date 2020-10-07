using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using PRSLibrary.Models;

namespace PRSLibrary.Controllers {
    
    class VendorsController {

        public PrsConnection PrsConnection { get; set; } = null;

        public VendorsController(PrsConnection prsconnection) {
            this.PrsConnection = prsconnection;
        }

        /*

        public List(Vendor) GetVendors() {
            var sql = "Select * from Vendors;";
            var cmd = new SqlCommand(sql, PrsConnection.sqlConnection);

        var vendors = new List<Vendor>();

           
        }
        */

    }
}

/*

public List<User> GetUsers() {
            var sql = "Select * From Users;";
            var cmd = new SqlCommand(sql, PrsConnection.sqlConnection);     //parameters = (string cmdtext, sqlconnection connection) 
                                                                            //using sqlConnection property from PrsConnection class
            var users = new List<User>();

            var reader = cmd.ExecuteReader();       //storing the sql data read as a variable

            while (reader.Read()) {
                var user = new User();
                user.Id = Convert.ToInt32(reader["Id"]);
                user.Username = Convert.ToString(reader["Username"]);
                user.Password = Convert.ToString(reader["Password"]);
                user.FirstName = Convert.ToString(reader["FirstName"]);
                user.LastName = Convert.ToString(reader["LastName"]);
                user.Phone = Convert.ToString(reader["PhoneNumber"]);
                user.Email = Convert.ToString(reader["Email"]);
                user.IsReviewer = Convert.ToBoolean(reader["IsReviewer"]);
                user.IsAdmin = Convert.ToBoolean(reader["IsAdmin"]);

                users.Add(user);

            }
            
            reader.Close();
            return users;

        }

*/