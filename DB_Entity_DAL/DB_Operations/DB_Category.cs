using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Entity_DAL.MedelsDataBase;

namespace DB_Entity_DAL.DB_Operations
{
   public class DB_Category
    {
        public string InsertCategory(Category category)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                db.Categories.Add(category);
                db.SaveChanges();
                return category.name_category + "was succefully inserted";
            }
            catch (Exception e)
            {

                return "Error:" + e.Message;
            }
        }

        public string UpdateCategory(int id, Category category)
        {
            try
            {

                Sell_BuyEntities db = new Sell_BuyEntities();
                Category c = db.Categories.Find(id);
                c.name_category = category.name_category;

                db.SaveChanges();
                return c.name_category + "was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }

        public string DeleteCategory(int id)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                Category category = db.Categories.Find(id);

                db.Categories.Attach(category);
                db.Categories.Remove(category);
                db.SaveChanges();

                return category.name_category + "was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }

        public List<Category> GetallCategory()
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    List<Category> category = (from x in db.Categories
                                               select x).ToList();
                    return category;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
