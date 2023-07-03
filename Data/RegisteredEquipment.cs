using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEMA.Data
{
    public class RegisteredEquipment
    {
        [Key]
        public int id { get; set; }
        public int equipment_id { get; set; }
        public int site_id { get; set; }
    }
}
