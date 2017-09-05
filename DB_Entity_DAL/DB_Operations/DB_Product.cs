using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Entity_DAL.MedelsDataBase;

namespace DB_Entity_DAL.DB_Operations
{
   public class DB_Product
    {
        public string InsertProduct(Product product)
        {

            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                db.Products.Add(product);
                db.SaveChanges();
                return product.name + "was succefully inserted";
            }
            catch (Exception e)
            {

                return "Error:" + e.Message;
            }
        }


        public string UpdateProduct(int id, Product product)
        {
            try
            {

                Sell_BuyEntities db = new Sell_BuyEntities();
                Product p = db.Products.Find(id);
                p.name = product.name;
                p.delivery_date = product.delivery_date;
                p.price = product.price;
                p.quantity = product.quantity;
                p.id_brand = product.id_brand;
                p.currency = product.currency;
                p.C_description = product.C_description;
                p.producer = product.producer;

                p.C_image = product.C_image;
                p.rating = product.rating;
                p.id_magazine = product.id_magazine;
                p.C_status = product.C_status;


                db.SaveChanges();
                return p.name + "was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }
        public string DeleteProduct(int id)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                Product product = db.Products.Find(id);

                db.Products.Attach(product);
                db.Products.Remove(product);
                db.SaveChanges();

                return product.name + "was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public Product GetProduct(int id)
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    Product product = db.Products.Find(id);
                    return product;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Product> GetallProducts()
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    List<Product> products = (from x in db.Products
                                              select x).ToList();
                    return products;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
