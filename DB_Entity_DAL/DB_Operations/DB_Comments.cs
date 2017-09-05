using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Entity_DAL.MedelsDataBase;


namespace DB_Entity_DAL.DB_Operations
{
    public class DB_Comments
    {
        public string InsertComments(Comment comment)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                db.Comments.Add(comment);
                db.SaveChanges();
                return comment.comment1 + "was succefully inserted";
            }
            catch (Exception e)
            {

                return "Error:" + e.Message;
            }
        }

        public string UpdateComments(int id, Comment comment)
        {
            try
            {

                Sell_BuyEntities db = new Sell_BuyEntities();
                Comment c = db.Comments.Find(id);
                c.id_user = comment.id_user;
                c.id_product = comment.id_product;
                c.comment1 = comment.comment1;

                db.SaveChanges();
                return c.comment1 + "was succefully updated";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }

        }
        public string DeleteComments(int id)
        {
            try
            {
                Sell_BuyEntities db = new Sell_BuyEntities();
                Comment comment = db.Comments.Find(id);

                db.Comments.Attach(comment);
                db.Comments.Remove(comment);
                db.SaveChanges();

                return comment.comment1 + "was succefully delited";
            }
            catch (Exception e)
            {
                return "Error:" + e.Message;
            }
        }
        public List<Comment> GetallComments()
        {
            try
            {
                using (Sell_BuyEntities db = new Sell_BuyEntities())
                {
                    List<Comment> comment = (from x in db.Comments
                                             select x).ToList();
                    return comment;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
