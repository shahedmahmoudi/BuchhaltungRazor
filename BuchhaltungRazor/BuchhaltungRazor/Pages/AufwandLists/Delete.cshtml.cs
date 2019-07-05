using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuchhaltungRazor.Models;

namespace BuchhaltungRazor.Pages.AufwandLists
{
    public class DeleteModel : PageModel
    {
        private readonly BuchhaltungRazor.Models.BuchhaltungRazorContext _context;

        public DeleteModel(BuchhaltungRazor.Models.BuchhaltungRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AufwandList AufwandList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AufwandList = await _context.AufwandList.FirstOrDefaultAsync(m => m.ID == id);

            if (AufwandList == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AufwandList = await _context.AufwandList.FindAsync(id);

            if (AufwandList != null)
            {
                _context.AufwandList.Remove(AufwandList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id = AufwandList.AufwandID });
        }
    }
}
