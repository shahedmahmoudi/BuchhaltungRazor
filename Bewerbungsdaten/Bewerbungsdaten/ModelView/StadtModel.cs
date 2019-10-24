using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bewerbungsdaten.ModelView
{
    public class StadtModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Art { get; set; }
        public int? ElternId { get; set; }
    }
}
