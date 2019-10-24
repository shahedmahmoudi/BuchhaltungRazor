using Bewerbungsdaten.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bewerbungsdaten.ModelView
{
    public class BewerbungDetail
    {
        public int Id { get; set; }
        public string NameDerFirma { get; set; }
        public string Berufsbezeichnung { get; set; }
        public int? StandortId { get; set; }
        public string Adresse { get; set; }
        public string Telefon { get; set; }
        public DateTime? Anforderungsdatum { get; set; }
        public DateTime? Wiederholungsdatum { get; set; }
        public string Ergebnis { get; set; }
        public string Webseite { get; set; }
        public string Art { get; set; }
        public bool? Status { get; set; }

        public int ZustandID { get; set; }
        public string ZustandTitel { get; set; }
        public IEnumerable<SelectListItem> Zustands { get; set; }

        public int StadtID { get; set; }
        public string StadtTitel { get; set; }
        public IEnumerable<SelectListItem> Stadts { get; set; }

        public virtual Standort Standort { get; set; }
    }
}
