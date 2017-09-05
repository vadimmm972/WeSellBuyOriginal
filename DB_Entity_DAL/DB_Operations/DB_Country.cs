using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Entity_DAL.MedelsDataBase;

namespace DB_Entity_DAL.DB_Operations
{
    public class DB_Country
    {
        private OperationslogError nLog = new OperationslogError();
        public string InsertCountry(Country country)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                db.Countries.Add(country);
                db.SaveChanges();
                return country.name_country + "was succefully inserted";
            }
            catch (Exception e)
            {

                return "Error:" + e.Message;
            }
        }

        public string UpdateCountry(int id, Country country)
        {
            try
            {

                Sell_BuyEntities db = new Sell_BuyEntities();
                Country c = db.Countries.Find(id);
                c.name_country = country.name_country;
                db.SaveChanges();
                return c.name_country + "was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }

        public string DeleteCountry(int id)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                Country country = db.Countries.Find(id);

                db.Countries.Attach(country);
                db.Countries.Remove(country);
                db.SaveChanges();

                return country.name_country + "was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public Country GetCountry(int id)
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    Country country = db.Countries.Find(id);
                    return country;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Country> GetallCountries()
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    List<Country> country = (from x in db.Countries
                                             select x).ToList();
                    return country;
                }
            }
            catch (Exception e)
            {
                nLog.WriteLog("DB_Entity_DAL -> DB_Operation -> DB_Country -> GetallCountries :\r\n Message: " + e.Message + "\r\n " + e.StackTrace , 0);
                return null;
            }
        }

        public List<string> GetCountiesName()
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    List<string> country = db.Countries.Select(d => d.name_country).ToList();
                    return country;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetIdCountry(string nameCountry)
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {

                    int id = 0;
                    var idCounrty = (from u in db.Countries
                                     where u.name_country == nameCountry
                                     select u.id).ToList();

                    id = Convert.ToInt32(idCounrty[0]);
                    return id;
                }
            }
            catch (Exception)
            {
                return 0;
            }


        }
    }
}
