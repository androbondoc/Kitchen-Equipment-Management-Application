using KEMA.Data;
using KEMA.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEMA.Models
{
    public class SiteManager
    {
        public static List<EquipmentEntity> _selected = new List<EquipmentEntity>();
        public static List<SiteEntity> GetList(int userId, int siteId = 0)
        {
            if (userId == 0)
                return new List<SiteEntity>();
            else
            {
                var siteList = new List<SiteEntity>();
                using (var context = new KEMADbContext())
                {
                    var rs = context.Sites.Where(w => w.user_id == userId).ToList();
                    if (siteId > 0)
                    {
                        rs = context.Sites.Where(w => w.user_id == userId && w.site_id == siteId).ToList();
                    }

                    foreach (var item in rs)
                    {
                        siteList.Add(new SiteEntity()
                        {
                            site_id = item.site_id,
                            user_id = item.user_id,
                            active = item.active,
                            description = item.description,
                            RegisteredEquipments = context.RegisteredEquipments.Where(w => w.site_id == item.site_id).ToList()

                        });
                    }
                    foreach (var ls in siteList)
                    {
                        ls.selectedRE = "";
                        foreach (var re in ls.RegisteredEquipments)
                        {
                            var ee = EquipmentManager.GetEquipmentByID(re.equipment_id);
                            ls.selectedRE += string.Format("[{0}] - {1} - {2}", ee.serial_number, ee.description, ee.condition) + Environment.NewLine;
                        }
                    }
                }
                return siteList;
            }
        }

        public static void SetSelected(List<EquipmentEntity> selection)
        {
            _selected = new List<EquipmentEntity>();
            foreach (var s in selection)
            {
                _selected.Add(s);
            }
        }

        public static bool NewSite(SiteEntity item)
        {
            try
            {
                using (var context = new KEMADbContext())
                {
                    var site = new Site();
                    site.site_id = item.site_id;
                    site.user_id = item.user_id;
                    site.description = item.description;
                    site.active = item.active;
                    context.Sites.Add(site);
                    context.SaveChanges();

                    foreach (var re in item.SelectedRegisteredEquipments)
                    {
                        var regEq = new RegisteredEquipment();
                        regEq.site_id = site.site_id;
                        regEq.equipment_id = re.equipment_id;
                        context.RegisteredEquipments.Add(regEq);
                        context.SaveChanges();
                    }
                }
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public static bool DeleteSite(SiteEntity item)
        {
            try
            {
                using (var context = new KEMADbContext())
                {
                    var site = context.Sites.FirstOrDefault(f => f.site_id == item.site_id);
                    if (site != null)
                    {
                        var regEq = context.RegisteredEquipments.Where(f => f.site_id == site.site_id);

                        context.RegisteredEquipments.RemoveRange(regEq);
                        context.SaveChanges();

                        context.Sites.Remove(site);
                        context.SaveChanges();
                    }
                }
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public static bool ModifySite(SiteEntity siteEntity)
        {
            try
            {
                using (var context = new KEMADbContext())
                {
                    var site = UpdateSite(siteEntity);

                    var regEqList = context.RegisteredEquipments.Where(f => f.site_id == siteEntity.site_id);

                    foreach (var regEq in regEqList)
                    {
                        RemoveRegisteredEquipment(regEq);
                    }

                    var reqs = siteEntity.SelectedRegisteredEquipments.Distinct().ToList();
                    foreach (var re in reqs)
                    {
                        var regEq = new RegisteredEquipment();
                        regEq.site_id = site.site_id;
                        regEq.equipment_id = re.equipment_id;
                        SaveRegisteredEquipment(regEq);
                    }
                }
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        private static Site UpdateSite(SiteEntity siteEntity)
        {
            var site = new Site();
            using (var context = new KEMADbContext())
            {
                site = context.Sites.FirstOrDefault(f => f.site_id == siteEntity.site_id);
                if (site != null)
                {
                    site.user_id = siteEntity.user_id;
                    site.description = siteEntity.description;
                    site.active = siteEntity.active;

                    context.Sites.Update(site);
                    context.SaveChanges();
                }
            }
            return site;
        }

        private static void RemoveRegisteredEquipment(RegisteredEquipment regEq)
        {
            using (var context = new KEMADbContext())
            {
                context.RegisteredEquipments.Remove(regEq);
                context.SaveChanges();
            }
        }

        private static void SaveRegisteredEquipment(RegisteredEquipment regEq)
        {
            using (var context = new KEMADbContext())
            {
                context.RegisteredEquipments.Add(regEq);
                context.SaveChanges();
            }
        }
    }
}
