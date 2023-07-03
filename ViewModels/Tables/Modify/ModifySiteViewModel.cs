using KEMA.Data;
using KEMA.Models.Entity;
using KEMA.Models;
using KEMA.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KEMA.Models.ModelBase;

namespace KEMA.ViewModels
{
    class ModifySiteViewModel : UpdateItemModel<SiteEntity>
    {
        public ModifySiteViewModel(SiteEntity item, bool newRecord, string itemName) : base(item, newRecord, itemName) { }

        public List<EquipmentEntity> Items
        {
            get
            {
                var _categoryList = EquipmentManager.GetUnassignedList(UserManager._LoggedUser.user_id, Item.site_id).ToList();
                if (Item.RegisteredEquipments.Count > 0)
                {
                    foreach (var c in _categoryList)
                    {
                        var check = Item.RegisteredEquipments.FirstOrDefault(f => f.equipment_id == c.equipment_id);
                        if (check != null)
                        {
                            c.IsSelected = true;
                        }
                    }
                }
                return _categoryList;
            }
        }

        protected override bool Save(object parameter)
        {
            bool result = false;
            if (string.IsNullOrEmpty(Item.description))
            {
                PopupProvider.Error("Site save", "Description is required.");
                return result;
            }

            var selected = SiteManager._selected.Distinct().ToList();
            foreach (var s in selected)
            {
                if (s.IsSelected)
                {
                    Item.SelectedRegisteredEquipments.Add(new RegisteredEquipment()
                    {
                        equipment_id = s.equipment_id,
                        site_id = Item.site_id,
                    });
                }
            }
            Item.user_id = UserManager._LoggedUser.user_id;
            if (NewRecord)
            {
                result = SiteManager.NewSite(Item);
            }
            else
            {
                result = SiteManager.ModifySite(Item);
            }
            return result;
        }
    }
}
