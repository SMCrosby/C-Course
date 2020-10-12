using System;
using System.Linq;

namespace EF_CodeFirst {

    class Program {
        public static string Name { get; private set; }
        public static bool Active { get; private set; }

        static void Main(string[] args) {
            Console.WriteLine("Entity Framework - Code First\n==============================");


            var _context = new AppDbContext();

            var cust = new Customer() {
                Name = "MAX Technical Training",
                Code = "MAX",
                Active = true,
                Sales = 1000,
                Created = DateTime.Now
            };

          //  _context.Customers.Add(cust);
          //  _context.SaveChanges();

            var custs = _context.Customers.ToList();
            foreach(var c in custs) {
                Console.WriteLine($"\n{c.Id} | {c.Name} | {c.Code} | {c.Active} | {c.Sales} | {c.Created}");
            }


            var ord = new Order() {
                Description = "First order", Total = 1000, Created = DateTime.Now, CustomerId = 1
            };

            _context.Orders.Add(ord);
            _context.SaveChanges();

            var order = _context.Orders
                                .Find(1);                                //Find order by Id = 1
                                //.Include(x => x.Customer)
                                //.SingleOrDefault(o. => o.Id ==1);

            Console.WriteLine($"{order.Id} | {order.Description} | {order.Total} | {order.Created} | {order.CustomerId}");


            var ordline = new OrderLine() {
                Product = "Echo", Price = 100, Quantity = 3, OrderId = 1
            };

            _context.OrderLines.Add(ordline);
            _context.SaveChanges();

            var ordALL = from o in _context.Orders              //Joining tables Customers and Orderlines on the table Orders
                         join c in _context.Customers
                            on o.CustomerId equals c.Id
                         join l in _context.OrderLines
                            on o.Id equals l.OrderId
                         select new {
                             OrderId = o.Id, Desc = o.Description, Customer = c.Name,
                             Product = l.Product, Price = l.Price, Quantity = l.Quantity,

                             LineTotal = l.Price * l.Quantity
                         };



        }
    }
}
