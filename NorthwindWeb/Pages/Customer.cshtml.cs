using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindContextLib;
using NorthwindEntitiesLib;

namespace NorthwindWeb.Pages
{
    public class CustomerModel : PageModel
    {
        private readonly NorthwindContextLib.Northwind _context;

        public CustomerModel(NorthwindContextLib.Northwind context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers.Include(c => c.Orders).FirstOrDefaultAsync(m => m.CustomerID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
