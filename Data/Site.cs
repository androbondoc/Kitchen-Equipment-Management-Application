using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEMA.Data
{
    public class Site
    {
        [Key]
        public int site_id { get; set; }
        public int user_id { get; set; }
        public string? description { get; set; }
        public bool active { get; set; }
    }
}
