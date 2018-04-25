using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Entity_DAL.MedelsDataBase;

namespace DB_Entity_DAL.DB_Operations
{
    public class DB_Magazine
    {
        OperationslogError nLog = new OperationslogError();
        public int InsertMagazine(Magazine magazine)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                db.Magazines.Add(magazine);
                db.SaveChanges();
                return magazine.id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }


        public string UpdateMagazine(int id, Magazine magazine)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var m = db.Magazines.FirstOrDefault(u => u.id == id);
                m.name_magazine = magazine.name_magazine;
                m.C_password = magazine.C_password;
                m.id_category = magazine.id_category;
                //m.C_status = magazine.C_status;
                db.SaveChanges();
                return m.name_magazine + " was succefully updated";
            }
            catch (Exception e)
            {
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_Country -> GetallCountries :\r\n Message: " + e.Message + "\r\n " + e.StackTrace, 0);
                return "Error";
            }
        }

        public bool CheckMagazine(string name)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var magazine = db.Magazines.FirstOrDefault(u => u.name_magazine == name);
                if (magazine == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_Magazine -> CheckMagazine :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);
                return false;
            }

        }
        //public void GetAllShopsById(int id)
        //{
        //      try
        //    {
        //        Sell_BuyEntities db = new Sell_BuyEntities();
        //        Magazine magazine = db.Magazines.Find(id);
        //          var roles = db.Shops.Where(x => x.id_user == id).Select(x => x);
        //        //db.Magazines.Attach(magazine);
        //        //db.Magazines.Remove(magazine);
        //        //db.SaveChanges();

        //     //   return magazine.name_magazine + " was succefully delited";
        //    }
        //    catch (Exception e)
        //    {
        //      //  return "Error:" + e.Message;
        //    }

        //}

        public string DeleteMagazine(int id)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                Magazine magazine = db.Magazines.Find(id);

                db.Magazines.Attach(magazine);
                db.Magazines.Remove(magazine);
                db.SaveChanges();

                return magazine.name_magazine + " was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }


        public List<Magazine> GetAllMagazineById(int id)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var magzAll = db.Magazines.Where(x => x.idUserCreator == id).Select(x => x).ToList();
                if (magzAll != null)
                {
                    return magzAll;
                }
                return null;
            }
            catch(Exception e)
            {
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_Magazine -> GetAllMagazineById :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);
                return null;
            }
        }

        public Magazine GetInfoByid(int id)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                var infoMagazine = db.Magazines.First(x => x.id == id);
                if (infoMagazine != null)
                {
                    return infoMagazine;
                }
                return null;
            }
            catch (Exception e)
            {
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_Magazine -> GetInfoByid :\r\n Message: " + e.Message + "\r\n " + e.StackTrace + "", 0);
                return null;
            }
        }




        public List<Magazine> GetallMagazine()
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    List<Magazine> magazine = (from x in db.Magazines
                                               select x).ToList();
                    return magazine;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
