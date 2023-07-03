using KEMA.Data;
using KEMA.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEMA.Models
{
    public class EquipmentManager
    {
        public static List<EquipmentEntity> GetList(int userId)
        {
            if (userId == 0)
                return new List<EquipmentEntity>();
            else
            {
                var eqList = new List<EquipmentEntity>();
                using (var context = new KEMADbContext())
                {
                    var rs = context.Equipments.Where(w => w.user_id == userId).ToList();
                    foreach (var equipment in rs)
                    {

                        eqList.Add(new EquipmentEntity()
                        {
                            equipment_id = equipment.equipment_id,
                            user_id = equipment.user_id,
                            condition = equipment.condition,
                            description = equipment.description,
                            serial_number = equipment.serial_number
                        });
                    }

                }

                return eqList;
            }

        }

        public static List<EquipmentEntity> GetUnassignedList(int userId, int siteId = 0)
        {
            if (userId == 0)
                return new List<EquipmentEntity>();
            else
            {
                var eqlist = new List<EquipmentEntity>();
                using (var context = new KEMADbContext())
                {

                    var rs = context.Equipments.Where(w => w.user_id == userId).ToList();
                    foreach (var item in rs)
                    {
                        var checkIfAssigned = context.RegisteredEquipments.Where(w => w.equipment_id == item.equipment_id).ToList();
                        if (checkIfAssigned.Count == 0)
                        {
                            eqlist.Add(new EquipmentEntity()
                            {
                                equipment_id = item.equipment_id,
                                user_id = item.user_id,
                                condition = item.condition,
                                description = item.description,
                                serial_number = item.serial_number
                            });
                        }

                        var checkIfAssignedtoSite = context.RegisteredEquipments.Where(w => w.equipment_id == item.equipment_id && w.site_id == siteId).ToList();
                        if (checkIfAssignedtoSite.Count > 0)
                        {
                            eqlist.Add(new EquipmentEntity()
                            {
                                equipment_id = item.equipment_id,
                                user_id = item.user_id,
                                condition = item.condition,
                                description = item.description,
                                serial_number = item.serial_number
                            });
                        }
                    }

                }

                return eqlist;
            }

        }

        public static EquipmentEntity GetEquipmentByID(int ID)
        {
            if (ID == 0)
                return new EquipmentEntity();
            else
            {
                var equipmentEntity = new EquipmentEntity();
                using (var context = new KEMADbContext())
                {
                    var rs = context.Equipments.FirstOrDefault(w => w.equipment_id == ID);
                    equipmentEntity = new EquipmentEntity()
                    {
                        equipment_id = rs.equipment_id,
                        user_id = rs.user_id,
                        condition = rs.condition,
                        description = rs.description,
                        serial_number = rs.serial_number
                    };
                }
                return equipmentEntity;
            }
        }

        public static bool NewEquipment(EquipmentEntity item)
        {
            try
            {
                using (var context = new KEMADbContext())
                {
                    var equipment = new Equipment();
                    equipment.equipment_id = item.equipment_id;
                    equipment.user_id = item.user_id;
                    equipment.condition = item.condition;
                    equipment.description = item.description;
                    equipment.serial_number = item.serial_number;
                    context.Equipments.Add(equipment);
                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {

                return false;
            }
            return true;
        }

        public static bool ModifyEquipment(EquipmentEntity item)
        {
            try
            {
                using (var context = new KEMADbContext())
                {
                    var equipment = context.Equipments.FirstOrDefault(f => f.equipment_id == item.equipment_id);
                    if (equipment != null)
                    {
                        equipment.user_id = item.user_id;
                        equipment.condition = item.condition;
                        equipment.description = item.description;
                        equipment.serial_number = item.serial_number;
                        context.Equipments.Update(equipment);
                        context.SaveChanges();
                    }

                }
            }
            catch (System.Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool DeleteEquipment(EquipmentEntity item)
        {
            try
            {
                using (var context = new KEMADbContext())
                {
                    var equipment = context.Equipments.FirstOrDefault(f => f.equipment_id == item.equipment_id);
                    if (equipment != null)
                    {
                        RemoveRegisteredEquipments(equipment);
                        context.Equipments.Remove(equipment);
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

        private static void RemoveRegisteredEquipments(Equipment item)
        {
            using (var context = new KEMADbContext())
            {
                var regEquipment = context.RegisteredEquipments.Where(f => f.equipment_id == item.equipment_id);
                if (regEquipment != null)
                {
                    context.RegisteredEquipments.RemoveRange(regEquipment);
                    context.SaveChanges();
                }
            }
        }
    }
}
