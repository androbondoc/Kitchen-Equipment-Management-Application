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
    class ModifyEquipmentViewModel : UpdateItemModel<EquipmentEntity>
    {
        public ModifyEquipmentViewModel(EquipmentEntity item, bool newRecord, string itemName) : base(item, newRecord, itemName) { }

        private List<string> _categoryList;
        public List<string> CategoryList
        {
            get
            {
                if (_categoryList == null)
                {
                    _categoryList = new List<string>();
                    _categoryList.Add("Working");
                    _categoryList.Add("Not Working");
                }
                return _categoryList;
            }
            set { SetProperty(ref _categoryList, value); }
        }

        protected override bool Save(object parameter)
        {
            bool result = false;

            if (string.IsNullOrEmpty(Item.serial_number))
            {
                PopupProvider.Error("Equipment save", "Serial number is required.");
                return result;
            }

            if (string.IsNullOrEmpty(Item.description))
            {
                PopupProvider.Error("Equipment save", "Description is required.");
                return result;
            }

            Item.user_id = UserManager._LoggedUser.user_id;
            if (NewRecord)
            {
                result = EquipmentManager.NewEquipment(Item);
            }
            else
            {
                result = EquipmentManager.ModifyEquipment(Item);
            }
            return result;
        }
    }
}
