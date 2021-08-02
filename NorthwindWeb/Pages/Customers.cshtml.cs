using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindContextLib;
using NorthwindEntitiesLib;

namespace NorthwindWeb.Pages
{
    public class CustomersModel : PageModel
    {
        public IDictionary<string, List<Customer>> CustomerGroups{ get; set; }
    
        private readonly Northwind db;

        public CustomersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Customers";

            var query = db.Customers
                        .AsEnumerable()
                        .GroupBy(c => c.Country);

            CustomerGroups = query.ToDictionary(group => group.Key, group => group.ToList());
        }
    }
}
