using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuchhaltungRazor.Models
{
    public class Laden
    {
        [Required,ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Titel { get; set; }
        public ICollection<Aufwand> aufwands { get; set; }
    }
}
