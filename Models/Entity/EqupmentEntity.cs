using KEMA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEMA.Models.Entity
{
    public class EquipmentEntity : Equipment
    {
        public EquipmentEntity() { }

        public bool IsSelected { get; set; }

    }
}
