using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkProject;

namespace EntityFrameworkLibrary {

    public class UsersController {

        private readonly  prsContext _context;

        public UsersController(prsContext context) {
            _context = context;
        }

        /// <summary>
        /// Returns a user if the username and password are found
        /// in the users table of the database
        /// </summary>
        /// <param name="username">The username as a string</param>
        /// <param name="password">The password as a string</param>
        /// <returns>
        /// A user instance if the username and password combination is found. Else returns null.</returns>
        public Users Login(string username, string password) {
           var user = _context.Users
                    .SingleOrDefault(u => u.Username == username && u.Password == password);      //u = instance of class/Collection
            return user;
            
            //  --another syntax
            // return _context.Users
            //        .SingleOrDefault(u => u.Username == username && u.Password == password);      //u = instance of class/Collection
            


            //.Find -- only works with primary keys
        }

    }
}
