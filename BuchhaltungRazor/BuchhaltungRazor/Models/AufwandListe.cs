using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuchhaltungRazor.Models
{
    public class AufwandList
    {
        [Required, ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Titel { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Betrag { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PreisEinheit { get; set; }
        public int AufwandID { get; set; }
    }
}
