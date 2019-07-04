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
    public class IndexModel : PageModel
    {
        private readonly BuchhaltungRazor.Models.BuchhaltungRazorContext _context;

        public IndexModel(BuchhaltungRazor.Models.BuchhaltungRazorContext context)
        {
            _context = context;
        }

        public IList<AufwandList> AufwandList { get;set; }

        public async Task OnGetAsync(int? id)
        {

            var AW = from m in _context.AufwandList where m.AufwandID == id select m; 
            AufwandList = await AW.ToListAsync();
        }
    }
}
