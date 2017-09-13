using DB_Entity_DAL.DB_Operations;
using DB_Entity_DAL.MedelsDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationTools.common
{
    public class CategoryTools
    {
       public int id { get; set; }
       public string name { get; set; }
    }
    public class ManagerTools
    {
        DB_User dbUser = new DB_User();
        DB_Category dbCateory = new DB_Category();
        public string CheckPassTools(int _id, string _pass)
        {
            string result = dbUser.CheckPassProfile(_id, _pass);
            return result;
        }

        public List<CategoryTools> GetAllCategories()
        {
            List<CategoryTools> lstCat = null;
            var allcategories = dbCateory.GetallCategory();

            if(allcategories != null)
            {
                    lstCat = new List<CategoryTools>();
                foreach(var cat in allcategories)
                {
                    lstCat.Add(new CategoryTools { id = cat.id, name = cat.name_category });
                }
            }

            return lstCat;
        }

        public bool CreateNewShopTools(string _name , string _pass , int _category , string _photo , int _iduser)
        {
            Magazine magZ = new Magazine
            {
                name_magazine = _name,
                C_password = _pass,
                id_category = _category,
                C_image = _photo,
                dateCreate = DateTime.Now
            };
            return true;
        }
    }
}
