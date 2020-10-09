using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkProject;

namespace EntityFrameworkLibrary.Controllers {

    public class VendorsController {

        private readonly prsContext _context;

        public VendorsController(prsContext context) {
            _context = context;

        }


        public Vendor GetVendorByCode(string code) {

              var vendors = _context.Vendor.ToList();
              var specVend = _context.Vendor.SingleOrDefault(v => v.Code == code);      //"" is linked to the Code data
                        //Specific Vendor
              return specVend;
        }

    }
 
}





/*
public Users Login(string username, string password) {
    var user = _context.Users
             .SingleOrDefault(u => u.Username == username && u.Password == password);      //u = instance of class/Collection
    return user;

            //  --another syntax
            // return _context.Users
            //        .SingleOrDefault(u => u.Username == username && u.Password == password);      //u = instance of class/Collection
*/