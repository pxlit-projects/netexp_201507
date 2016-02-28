using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_objects
{
    public class Verkeersbord
    {
        [Key]
        public int      id { get; set; }
        public int      objectid { get; set; }
        public string   point_lat { get; set; }
        public string   point_lng { get; set; }
        public int      xkey { get; set; }
        public string   vrije_hoogte { get; set; }
        public string   ophanging { get; set; }
        public string   type { get; set; }
        public string   vorm { get; set; }
        public string   afmeting1 { get; set; }
        public string   afmeting2 { get; set; }
        public string   opschrift { get; set; }
        public string   fabtype { get; set; }
        public string   beeldvlak { get; set; }
        public string   fabdatum { get; set; }
        public string   subkey { get; set; }
        public string   x { get; set; }
        public string   y { get; set; }
        public object   shape { get; set; }
    }
}
