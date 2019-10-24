using Bewerbungsdaten.Models;
using Bewerbungsdaten.ModelView;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bewerbungsdaten.Data
{
    public class BewerbungRepository
    {
        private readonly ArbeitssucheContext _context;
        public BewerbungRepository(ArbeitssucheContext context)
        {
            _context = context;
        }

      

        internal List<BewerbungDetail> GetBewerbungList()
        {
            List<Bewerbung> bewerbungs = new List<Bewerbung>();

            bewerbungs = _context.Bewerbung.Include(x=>x.Standort)
                .ToList();

            if (bewerbungs.Count > 0)
            {
                List<BewerbungDetail> bewerbungDetail = new List<BewerbungDetail>();
                foreach (var item in bewerbungs)
                {
                    var BDetail = new BewerbungDetail()
                    {
                        Id = item.Id,
                        Adresse = item.Adresse,
                        Anforderungsdatum = item.Anforderungsdatum,
                        Berufsbezeichnung = item.Berufsbezeichnung,
                        Ergebnis = item.Ergebnis,
                        StadtTitel = item.Standort.Name,
                        ZustandTitel= GetZustand(item.Standort.ElternId),
                        Telefon = item.Telefon,
                        Status = item.Status,
                        Webseite = item.Webseite,
                        Wiederholungsdatum = item.Wiederholungsdatum,
                        NameDerFirma=item.NameDerFirma,
                        Art=item.Art
                    };
                    bewerbungDetail.Add(BDetail);
                }
                return bewerbungDetail;
            }
           
            return null;
        }

        private string GetZustand(int? id)
        {
            return _context.Standort.Find(id).Name;
        }
    }
}
