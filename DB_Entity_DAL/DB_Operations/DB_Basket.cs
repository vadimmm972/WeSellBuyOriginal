using DB_Entity_DAL.MedelsDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Entity_DAL.DB_Operations
{
  
    public class DB_Basket
    {
        public string InsertBasket(Basket basket)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                db.Baskets.Add(basket);
                db.SaveChanges();
                return basket.Product.name + "was succefully inserted";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }
        public string UpdateBasket(int id, Basket basket)
        {
            try
            {

                Sell_BuyEntities db = new Sell_BuyEntities();
                Basket b = db.Baskets.Find(id);
                b.id_user = basket.id_user;
                b.id_product = basket.id_product;
                db.SaveChanges();
                return b.id_product.Value + "was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }

        public string DeleteBasket(int id)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                Basket basket = db.Baskets.Find(id);

                db.Baskets.Attach(basket);
                db.Baskets.Remove(basket);
                db.SaveChanges();

                return basket.Product.name + "was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }
        public Basket GetBasket(int id)
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    Basket basket = db.Baskets.Find(id);
                    return basket;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
       
    }
}
