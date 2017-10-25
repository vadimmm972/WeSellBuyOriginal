using OperationTools.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSellBuy.Helper;

namespace WebSellBuy.Controllers
{
    public class ManagerController : Controller
    {
        ManagerTools mgTools = new ManagerTools();
        StoreObjects strObj = new StoreObjects();
        StoreInfo storeinfo = null;
        //
        // GET: /Manager/
        public ActionResult Index()
        {
            return View("Manager");
        }
        
        public ActionResult CreateNewShop(string _name , string _image , string _password)
        {

            return null;
        }

        [HttpPost]
        public string CheckUserPassword(string _password , string _url)
        {
            if (Request.Cookies["AuthenticationSellBuy"] != null)
            {
                var value = Request.Cookies["AuthenticationSellBuy"].Value;
                string _result = mgTools.CheckPassTools(Convert.ToInt16(value), _password);
                if (_result == "success")
                {
                    if (_url == "UserProfile")
                    {
                        HttpCookie aCookie = new HttpCookie("UserProfileCoockie");
                        aCookie.Value = value.ToString();
                        aCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(aCookie);
                    }
                    else if (_url == "Manager")
                    {
                        HttpCookie aCookie = new HttpCookie("ManagerCoockie");
                        aCookie.Value = value.ToString();
                        aCookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(aCookie);
                    }
                }
                return _result;
            }
            return "Please sign in";
        }

        [HttpPost]
        public void SignOutUserManager()
        {
            HttpCookie myCookie = new HttpCookie("ManagerCoockie");
            // lblLogin.Text = "Cookie = " + myCookie.Value;
            myCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(myCookie);
        }
        [HttpPost]
        public void SignOutUserProfile()
        {
            HttpCookie myCookie = new HttpCookie("UserProfileCoockie");
            // lblLogin.Text = "Cookie = " + myCookie.Value;
            myCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(myCookie);
        }


        [HttpPost]
        public JsonResult GetAllCategory()
        {
            return Json(mgTools.GetAllCategories());
        }
        
        [HttpPost]
        public string CreateShop(string _nameShop, string _passShop, string _categoryShop, string _photoShop)
        {
            int IdCategory = Convert.ToInt32(_categoryShop);
            if (_nameShop == "" || _passShop == "" || IdCategory <= 0 || _photoShop == "")
            {
                return "Заполните все поля";
            }
            if (Request.Cookies["AuthenticationSellBuy"] != null)
            {
                var id = Request.Cookies["AuthenticationSellBuy"].Value;
                string reuslt = mgTools.CreateNewShopTools(_nameShop, _passShop, IdCategory, _photoShop, Convert.ToInt32(id));
                return reuslt;
            }
            else
            {
                return "Войдите в систему";
            }
        }
        
        [HttpPost]
        public JsonResult GetAllMyShops()
        {
            if (Request.Cookies["AuthenticationSellBuy"] != null)
            {
                var id = Request.Cookies["AuthenticationSellBuy"].Value;
           
              return Json(mgTools.GetListMyShops(Convert.ToInt32(id)));
            }
            else
            {
                return Json("Войдите в систему");
            }
        }

        [HttpPost]
        public string RemoveShop(int _idMagazine)
        {
            return mgTools.RemoveShopTools(_idMagazine);
        }

        [HttpPost]
        public JsonResult GetInfoByMagazine(int _id)
        {
            storeinfo = strObj.GetStoreinfo(this.storeinfo);
            if(storeinfo != null && storeinfo.CustomerID > 0)
            {
                return Json(mgTools.GetInfoMagazineById(_id));
            }
            else
            {
                return null;
            }
        }
	}
}