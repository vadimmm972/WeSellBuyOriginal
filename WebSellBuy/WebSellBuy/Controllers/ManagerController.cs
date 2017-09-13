using OperationTools.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSellBuy.Controllers
{
    public class ManagerController : Controller
    {
        ManagerTools mgTools = new ManagerTools();
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
        public bool CreateNewShop(string _name , string _pass , int _category , string _photo)
        {

            if (_name == "" || _pass == "" || _category <= 0 || _photo == "")
            {
                return false;
            }
            if (Request.Cookies["AuthenticationSellBuy"] != null)
            {
                var id = Request.Cookies["AuthenticationSellBuy"].Value;
                bool reuslt = mgTools.CreateNewShopTools(_name, _pass, _category, _photo, Convert.ToInt32(id));
                return true;
            }
            else
            {
                return false;
            }
            
        }
	}
}