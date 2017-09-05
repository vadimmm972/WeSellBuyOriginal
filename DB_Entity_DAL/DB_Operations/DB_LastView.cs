using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Entity_DAL.MedelsDataBase;

namespace DB_Entity_DAL.DB_Operations
{
   public class DB_LastView
    {
        public string InsertLastView(LastView lastview)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                db.LastViews.Add(lastview);
                db.SaveChanges();
                return "was succefully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public List<LastView> GetallCountries()
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    //List<LastView> country = (from x in db.LastViews
                    //                         select x.Product).ToList();
                    //return country;
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
