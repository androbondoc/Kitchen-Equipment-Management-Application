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
    public class SitesViewModel : TableModel<SiteEntity>
    {
        public SitesViewModel()
        {
            ItemName = "Site";
            TableName = "Sites Management";
        }
        protected override void NewItem(object parameter)
        {
            SiteEntity Site = new SiteEntity();
            ModifySiteViewModel MSVM = new ModifySiteViewModel(Site, true, ItemName);
            ModifyItemWindow MIV = new ModifyItemWindow() { DataContext = MSVM };
            MIV.ShowDialog();

            if (MSVM.SaveEdit)
            {
                Site = MSVM.Item;
                PopupProvider.Info("Site has been added", string.Format("Site: {0}", Site.description));
                RefreshList(parameter);
                foreach (var p in List)
                    if (Site.site_id == p.site_id)
                        SelectedItem = p;
            }
        }

        protected override void EditItem(object parameter)
        {
            SiteEntity Site = new SiteEntity();
            Site = SelectedItem;
            ModifySiteViewModel MSVM = new ModifySiteViewModel(Site, false, ItemName);
            ModifyItemWindow MIV = new ModifyItemWindow() { DataContext = MSVM };
            MIV.ShowDialog();
            if (MSVM.SaveEdit)
            {
                Site = MSVM.Item;
                PopupProvider.Info("Site has been modified", string.Format("Site: {0}", Site.description));
                RefreshList(parameter);
                foreach (var p in List)
                    if (Site.site_id == p.site_id)
                        SelectedItem = p;
            }
        }

        
        protected override void DeleteItem(object parameter)
        {

            string name = SelectedItem.description;
            if (SiteManager.DeleteSite(SelectedItem))
            {
                RefreshList(parameter);
                PopupProvider.Info("Site deleted", string.Format("Site: {0}", name));
            }
            else
            {
                PopupProvider.Error("Error deleting selected site", "Selected site is set to one or more transactions.");
            }
        }

        protected override void RefreshList(object parameter)
        {
            SiteManager._selected = new List<EquipmentEntity>();
            List = SiteManager.GetList(UserManager._LoggedUser.user_id);
        }
    }
}
