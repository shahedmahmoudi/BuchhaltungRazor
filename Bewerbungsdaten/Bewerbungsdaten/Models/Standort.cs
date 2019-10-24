using System;
using System.Collections.Generic;

namespace Bewerbungsdaten.Models
{
    public partial class Standort
    {
        public Standort()
        {
            Bewerbung = new HashSet<Bewerbung>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Art { get; set; }
        public int? ElternId { get; set; }

        public virtual ICollection<Bewerbung> Bewerbung { get; set; }
    }
}
