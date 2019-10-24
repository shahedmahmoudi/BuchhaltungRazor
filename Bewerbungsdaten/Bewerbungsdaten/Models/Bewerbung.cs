using System;
using System.Collections.Generic;

namespace Bewerbungsdaten.Models
{
    public partial class Bewerbung
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

        public virtual Standort Standort { get; set; }
    }
}
