using System;

using PRSLibrary;
using PRSLibrary.Controllers;
using PRSLibrary.Models;

namespace PRSConnect {

    class Program {

        static void Main(string[] args) {
            Console.WriteLine("Connecting to and updating PRS Database.\n========================================");

            var prsconn = new PrsConnection("localhost", "PRS");
            prsconn.Connect();

            var user = new User() {
                Id = 0, Username = "zz", Password = "zz", FirstName = "zz", LastName = "zz",
                Phone = "zz", Email = "zz", IsReviewer = true, IsAdmin = true
            };

            var usersCtrl = new UsersController(prsconn);

            //var recsAffected = usersCtrl.Insert(user);      //inserting user --RecordsAffected

            var users = usersCtrl.GetUsers();

            var user1 = usersCtrl.GetUser(7);
            user1.FirstName = "Noah";
            user1.LastName = "Phence";

            var recsAffected = usersCtrl.Update(user1);


            prsconn.Disconnect();
        }

        
    }
}
