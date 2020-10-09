using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkProject;

namespace EntityFrameworkLibrary.Controllers {

    public class RequestsController {

        private readonly prsContext _context;

        public RequestsController(prsContext context) {
            _context = context;
        }

        public bool RecalculateRequestTotal(int Id) {
            var request = _context.Request.Find(Id);
            var reqTotal = (from li in _context.LineItem.ToList()
                            join pr in _context.Product.ToList()         //joining products 
                            on li.ProductId equals pr.Id
                            where li.RequestId == Id     //only lineitems who's foreign key(RequestId) matches our Id
                            select new {
                                LineTotal = li.Quantity * pr.Price       //Creating new column called LineTotal
                            }).Sum(t => t.LineTotal);

            request.Total = reqTotal;
            _context.SaveChanges();
            return true;
        }




        /// <summary>
        /// Sets the status of the request to APPROVED
        /// </summary>
        /// <param name="request">A single request</param>
        /// <returns>True if successful; else false<returns>
        public bool SetToApproved(Request request) {
            request.Status = "APPROVED";
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Sets the status of the request to REJECTED
        /// </summary>
        /// <param name="request">A single request</param>
        /// <returns>True if successful; else false<returns>
        public bool SetToRejected(Request request) {
            request.Status = "REJECTED";
            request.ReasonForRejection = "N/A";
            _context.SaveChanges();
            return true;
        }



        /// <summary>
        /// Reviews the request for the owner(user)
        /// Status is set to APPROVED if Total <= 50
        /// else status is set to REVIEW
        /// </summary>
        /// <param name="request">A request</param>
        /// <returns>True if successful; else false</returns>
        public bool ReviewRequest(Request request) {
            //if (request.Total <= 50) {                    -- line below replaces commented out portion
            //    request.Status = "APPROVED";
            //} 
            //else { 
            //    request.Status = "REVIEW";
            //}
            request.Status = (request.Total <= 50) ? "APPROVED " : "REVIEW";
            _context.SaveChanges();
            return true;

            }


        }
}

