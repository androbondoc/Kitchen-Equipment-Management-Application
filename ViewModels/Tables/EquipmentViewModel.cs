using KEMA.Models.Entity;
using KEMA.Models.ModelBase;
using KEMA.Models;
using KEMA.Popup;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using KEMA.ViewModels;
using KEMA.Views;

namespace KEMA.ViewModels
{
    public class EquipmentsViewModel : TableModel<EquipmentEntity>
    {
        public EquipmentsViewModel()
        {
            ItemName = "Equipment";
            TableName = "Equipments Management";
        }

        protected override void NewItem(object parameter)
        {
            var Equipment = new EquipmentEntity();
            Equipment.condition = "Working"; //default value: Working
            var MEVM = new ModifyEquipmentViewModel(Equipment, true, ItemName);
            ModifyItemWindow MIV = new ModifyItemWindow() { DataContext = MEVM };
            MIV.ShowDialog();
            if (MEVM.SaveEdit)
            {
                Equipment = MEVM.Item;
                string equipmentName = Equipment.serial_number + " - " + Equipment.description;
                PopupProvider.Info("Equipment has been added", string.Format("Equipment name:{0}", equipmentName));
                RefreshList(parameter);
                foreach (var p in List)
                {
                    if (Equipment.equipment_id == p.equipment_id)
                    {
                        SelectedItem = p;
                    }
                }
            }
        }

        protected override void EditItem(object parameter)
        {
            var Equipment = new EquipmentEntity();
            Equipment = SelectedItem;
            var MEVM = new ModifyEquipmentViewModel(Equipment, false, ItemName);
            ModifyItemWindow MIV = new ModifyItemWindow() { DataContext = MEVM };
            MIV.ShowDialog();
            if (MEVM.SaveEdit)
            {
                Equipment = MEVM.Item;
                string equipmentName = Equipment.serial_number + " - " + Equipment.description;
                PopupProvider.Info("Equipment has been modified", string.Format("Equipment name:{0}", equipmentName));
                RefreshList(parameter);
                foreach (var p in List)
                    if (Equipment.equipment_id == p.equipment_id)
                        SelectedItem = p;
            }
        }

        protected override void DeleteItem(object parameter)
        {

            string name = SelectedItem.serial_number + " - " +SelectedItem.description;
            if (EquipmentManager.DeleteEquipment(SelectedItem))
            {
                RefreshList(parameter);
                PopupProvider.Info("Equipment has been deleted", string.Format("Equipment serial number:{0}", name));
            }
            else
            {
                PopupProvider.Error("Error deleting selected equipment", "Selected equipment is set to one or more transactions.");
            }
        }

        protected override void RefreshList(object parameter)
        {
            List = EquipmentManager.GetList(UserManager._LoggedUser.user_id);
        }
    }
}
