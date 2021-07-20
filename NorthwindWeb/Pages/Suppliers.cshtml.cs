using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindContextLib;

namespace NorthwindWeb.Pages
{
    public class SuppliersModel : PageModel
    {
        public IEnumerable<string> Suppliers { get; set; }
        private readonly Northwind db;

        public SuppliersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            Suppliers = db.Suppliers.Select(s => s.City).ToArray();
        }
    }
}
