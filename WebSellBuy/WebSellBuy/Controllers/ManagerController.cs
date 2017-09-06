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
        public string CheckUserPassword(string _password)
        {
            if (Request.Cookies["AuthenticationSellBuy"] != null)
            {
                var value = Request.Cookies["AuthenticationSellBuy"].Value;
                return mgTools.CheckPassTools(Convert.ToInt16(value),_password);
            }
            return "Please sign in";
        }
	}
}