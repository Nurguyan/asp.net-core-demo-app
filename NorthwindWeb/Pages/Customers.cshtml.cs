using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindContextLib;

namespace NorthwindWeb.Pages
{
    public class CustomersModel : PageModel
    {
        public IEnumerable<string> Countries { get; set; }
        public IEnumerable<string> CustomerNames { get; set; }
        private readonly Northwind db;

        public CustomersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Customers";
            Countries = db.Customers.Select(s => s.Country).ToArray();
            CustomerNames = db.Customers.Select(s => s.CompanyName).ToArray();
        }
    }
}
