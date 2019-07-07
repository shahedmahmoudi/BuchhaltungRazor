using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BuchhaltungRazor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BuchhaltungRazor.Pages.Ladens
{
    public class IndexModel : PageModel
    {
        private readonly BuchhaltungRazor.Models.BuchhaltungRazorContext _context;

        public IndexModel(BuchhaltungRazor.Models.BuchhaltungRazorContext context)
        {
            _context = context;
        }

        public IList<Laden> Laden { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            var Lad = from m in _context.Ladens select m;

            if(!string.IsNullOrEmpty(SearchString))
            {
                Lad = Lad.Where(x => x.Titel.Contains( SearchString));
            }
            Laden = await Lad.ToListAsync();
        }
    }
}
