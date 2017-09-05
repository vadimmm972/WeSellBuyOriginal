using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Entity_DAL.MedelsDataBase;

namespace DB_Entity_DAL.DB_Operations
{
    public class DB_UsersMagazine
    {
        public bool InsertUserMagazine(UserMagazine us_m)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                db.UserMagazines.Add(us_m);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
