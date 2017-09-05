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
                Magazine m = db.Magazines.Find(id);

                m.name_magazine = magazine.name_magazine;
                m.C_image = magazine.C_image;
                m.C_status = magazine.C_status;
                db.SaveChanges();
                return m.name_magazine + " was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }

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
