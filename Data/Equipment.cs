using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEMA.Data
{
    public class Equipment
    {
        [Key]
        public int equipment_id { get; set; }
        public string? serial_number { get; set; }
        public string? description { get; set; }
        public string? condition { get; set; }
        public int user_id { get; set; }
    }
}
