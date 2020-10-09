using System;
using System.Linq;
using EntityFrameworkLibrary;
using EntityFrameworkLibrary.Controllers;

namespace EntityFrameworkProject {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Project using EntityFramework\n==============================");

            var _context = new prsContext();

            var UserCtrl = new UsersController(_context);
            var ReqCtrl = new RequestsController(_context);
            var VenCtrl = new VendorsController(_context);

            var vend1 = VenCtrl.GetVendorByCode("2");               //locates a specidic vendor by it's vendor.code


            var requestInReview = ReqCtrl.GetRequestsInReview();

            //test the login function
            var user = UserCtrl.Login("xx", "xx");
            var userz = UserCtrl.Login("zz", "zz");


            var updTotal = ReqCtrl.RecalculateRequestTotal(1);

            var req1 = _context.Request.Find(3);        // check if request total <=50 and set status accordingly 
            ReqCtrl.ReviewRequest(req1);
            var ok = ReqCtrl.ReviewRequest(req1);

            var req2 = _context.Request.Find(2);        //Find is used to look up by primary key
            ReqCtrl.SetToApproved(req2);
            var isWorked = ReqCtrl.SetToApproved(req2);


            /*
            var users = _context.Users.ToList();        //Gets data from Users Table
            var user1 = _context.Users.Find(1);         //Selects user by primary key
                                                        //_context.collection.command
            user1.PhoneNumber = "513-555-1212";
            user1.IsAdmin = true;
            user1.IsReviewer = true;
            _context.SaveChanges();
            */

        }
    }
}
