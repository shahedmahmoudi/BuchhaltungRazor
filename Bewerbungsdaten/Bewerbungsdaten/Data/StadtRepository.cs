using Bewerbungsdaten.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bewerbungsdaten.Data
{
    public class StadtRepository
    {
        private readonly ArbeitssucheContext _context;
        public StadtRepository(ArbeitssucheContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetStandortZustandList()
        {

            List<SelectListItem> StandortZustand = _context.Standort.Where(x => x.Art == "Zustand")
                .OrderBy(n => n.Name)
                    .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();
            var newRow = new SelectListItem()
            {
                Value = null,
                Text = "Wählen Sie den Produktart"
            };
            StandortZustand.Insert(0, newRow);
            return new SelectList(StandortZustand, "Value", "Text");
        }

        public IEnumerable<SelectListItem> GetStadt()
        {
            List<SelectListItem> produkts = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
            };
            return produkts;
        }

        public IEnumerable<SelectListItem> GetStadt(int id)
        {
            IEnumerable<SelectListItem> Stadt = _context.Standort
                .OrderBy(n => n.Name)
                .Where(n => n.ElternId == id)
                .Select(n =>
                   new SelectListItem
                   {
                       Value = n.Id.ToString(),
                       Text = n.Name
                   }).ToList();
            return new SelectList(Stadt, "Value", "Text");
        }

    }
}
