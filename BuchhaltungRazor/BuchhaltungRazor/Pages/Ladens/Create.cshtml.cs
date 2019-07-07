using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuchhaltungRazor.Models;

namespace BuchhaltungRazor.Pages.Ladens
{
    public class CreateModel : PageModel
    {
        private readonly BuchhaltungRazor.Models.BuchhaltungRazorContext _context;

        public CreateModel(BuchhaltungRazor.Models.BuchhaltungRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Laden Laden { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ladens.Add(Laden);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}