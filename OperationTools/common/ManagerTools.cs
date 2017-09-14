using DB_Entity_DAL.DB_Operations;
using DB_Entity_DAL.MedelsDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationTools.common
{
    public class InfoShop
    {
        public int IdShop { get; set; }
        public string NameShop { get; set; }
        public string PhotoShop { get; set; }
    }
    public class CategoryTools
    {
       public int id { get; set; }
       public string name { get; set; }
    }
    public class ManagerTools
    {
        DB_User dbUser = new DB_User();
        DB_Magazine dbMag = new DB_Magazine();
        DB_Shop dbShop = new DB_Shop();
        private AllUrlPuth url = new AllUrlPuth();
        public string CheckPassTools(int _id, string _pass)
        {
            string result = dbUser.CheckPassProfile(_id, _pass);
            return result;
        }

        public List<CategoryTools> GetAllCategories()
        {
            DB_Category dbCateory = new DB_Category();
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

        public string CreateNewShopTools(string _name , string _pass , int _category , string _photo , int _iduser)
        {
            bool checkMagazine = dbMag.CheckMagazine(_name);
            if(checkMagazine)
            {
                Magazine magZ = new Magazine
                {
                    name_magazine = _name,
                    C_password = _pass,
                    id_category = _category,
                    C_image = _photo,
                    dateCreate = DateTime.Now
                };
                int idMagazine = dbMag.InsertMagazine(magZ);
                if (idMagazine != 0)
                {
                  
                    Shop newShop = new Shop
                    {
                        id_user = _iduser,
                        id_magazine = idMagazine
                    };

                    bool resAddednewShop = dbShop.InsertUserShop(newShop);
                    if(resAddednewShop)
                    {
                        return "Магазин ("+_name+") успешно создан";
                    }
                    else
                    {
                        return "Ошибка , обратитесь к разработчику сайта";
                    }
                }

                return "Ошибка при создание магазина";
            }
            else
            {
                return "Магазин с таким название уже существует";
            }
        }

        public List<InfoShop> GetListMyShops(int _id)
        {
            List<InfoShop> lstShops = null;

            var allShop = dbShop.GeAllShopsByUserId(_id);
            if (allShop != null)
            {
                lstShops = new List<InfoShop>();
                foreach(Shop s in allShop)
                {
                    lstShops.Add(new InfoShop { IdShop = s.id, NameShop = s.Magazine.name_magazine, PhotoShop = url.photoShop+s.Magazine.C_image });
                }
            }
            return lstShops;
        }
        
    }
}
