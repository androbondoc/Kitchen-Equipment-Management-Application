using KEMA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEMA.Models.Entity
{
    public class SiteEntity : Site
    {
        public SiteEntity()
        {
            this.RegisteredEquipments = new List<RegisteredEquipment>();
            this.SelectedRegisteredEquipments = new List<RegisteredEquipment>();
        }

        public string selectedRE { get; set; }
        public List<RegisteredEquipment> RegisteredEquipments { get; set; }
        public List<RegisteredEquipment> SelectedRegisteredEquipments { get; set; }
    }
}
