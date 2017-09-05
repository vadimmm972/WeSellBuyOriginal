using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Entity_DAL.MedelsDataBase;

namespace DB_Entity_DAL.DB_Operations
{
   public class DB_City
    {
        public string InsertRegion(City sity)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                db.Cities.Add(sity);
                db.SaveChanges();
                return sity.name_sity + " was succefully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public string UpdateRegion(int id, City sity)
        {
            try
            {

                Sell_BuyEntities db = new Sell_BuyEntities();
                City s = db.Cities.Find(id);
                s.id_region = sity.id_region;
                s.id_country = sity.id_country;
                s.name_sity = sity.name_sity;

                db.SaveChanges();
                return s.name_sity + " was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }

        public List<City> GetCityByIdRegion(int id)
        {
            Sell_BuyEntities db = new Sell_BuyEntities();
            var regionToCountry = (from r in db.Cities
                                   where r.id_region == id
                                   select r).ToList();

            return regionToCountry;
        }

        public string DeleteRegion(int id)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                City sity = db.Cities.Find(id);

                db.Cities.Attach(sity);
                db.Cities.Remove(sity);
                db.SaveChanges();

                return sity.name_sity + " was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public List<City> GetallCity()
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    List<City> sity = (from x in db.Cities
                                       select x).ToList();
                    return sity;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
