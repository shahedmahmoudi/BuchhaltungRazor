using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BuchhaltungRazor.Models
{
    public class Aufwand
    {
        [Required,ScaffoldColumn(false),DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Number { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        // [Required,DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Betrag { get; set; }
        public byte[] Quittung { get; set; }
        public ICollection< AufwandList> aufwandslist { get; set; }
    }
}
