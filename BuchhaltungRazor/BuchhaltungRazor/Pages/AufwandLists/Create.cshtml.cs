using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BuchhaltungRazor.Models;

namespace BuchhaltungRazor.Pages.AufwandLists
{
    public class CreateModel : PageModel
    {
        private readonly BuchhaltungRazor.Models.BuchhaltungRazorContext _context;
        public int? IDAufwand;
        public CreateModel(BuchhaltungRazor.Models.BuchhaltungRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
            IDAufwand = id;
            return Page();
        }

        [BindProperty]
        public AufwandList AufwandList { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //AufwandList.AufwandID = html
            _context.AufwandList.Add(AufwandList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = AufwandList.AufwandID });
        }
    }
}