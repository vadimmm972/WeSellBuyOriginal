using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Entity_DAL.MedelsDataBase;

namespace DB_Entity_DAL.DB_Operations
{
    public class DB_Brand
    {
        public string InsertBrand(Brand brand)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                db.Brands.Add(brand);
                db.SaveChanges();
                return brand.name_brand + "was succefully inserted";
            }
            catch (Exception e)
            {

                return "Error:" + e.Message;
            }
        }
        public string UpdateBasket(int id, Brand brand)
        {
            try
            {

                Sell_BuyEntities db = new Sell_BuyEntities();
                Brand b = db.Brands.Find(id);
                b.name_brand = brand.name_brand;
                db.SaveChanges();
                return b.name_brand + "was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }
    }
}
