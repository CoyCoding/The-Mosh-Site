using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        public ActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int? Id)
        {       
            var customer = GetCustomers().SingleOrDefault(c => c.Id == Id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
        
        private IEnumerable<Customer> GetCustomers()
        {
            //temp data until database connection implemented
            return new List<Customer>
            {
               new Customer{Id = 1, Name = "Joe Somebody"},
               new Customer{Id = 2, Name = "Jane Somebody"},
               new Customer{Id = 3, Name = "Albert Pipes"},
            };
        }
    }
}
