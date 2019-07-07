using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuchhaltungRazor.Models;

namespace BuchhaltungRazor.Pages.Ladens
{
    public class DetailsModel : PageModel
    {
        private readonly BuchhaltungRazor.Models.BuchhaltungRazorContext _context;

        public DetailsModel(BuchhaltungRazor.Models.BuchhaltungRazorContext context)
        {
            _context = context;
        }

        public Laden Laden { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Laden = await _context.Ladens.FirstOrDefaultAsync(m => m.ID == id);

            if (Laden == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
