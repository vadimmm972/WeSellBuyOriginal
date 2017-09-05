using OperationTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSellBuy.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        public ActionResult Index()
        {
            return View();
        }
        private AuthenticationTools userTools = new AuthenticationTools();
        //
     
        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult Authorization()
        {

            return View();
        }

        [HttpPost]
        public string AuthorizationUser(string _surname, string _name, string _lastname
            , string _phone, string _email, string _login
            , string _password, int _idcountry, int _idRegion
            , int _idCity, string _photo)
        {
            string resAddUser = userTools.RegisterUser(_surname, _name, _lastname, _phone, _email, _login, _password, _idcountry, _idRegion, _idCity, _photo);
            return resAddUser;
        }

        [HttpPost]
        public string SignInUser(string _login, string _password)
        {
            string resultSignIn = userTools.SignInUserTools(_login, _password);
            string resParse = ParseSignInResult(resultSignIn);
            return resParse;
        }

        public void SignOut()
        {
            HttpCookie myCookie = new HttpCookie("AuthenticationSellBuy");
            // lblLogin.Text = "Cookie = " + myCookie.Value;
            myCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(myCookie);
        }

        public string ParseSignInResult(string strParse)
        {
            string resSTR = "";
            if (strParse.IndexOf("success") != -1)
            {
                string[] split = strParse.Split('/');
                split[0].Replace("id=", " ");
                string id = split[0].Replace("id=", " ").Trim();

                HttpCookie aCookie = new HttpCookie("AuthenticationSellBuy");
                aCookie.Value = id;
                aCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(aCookie);

                //      resSTR = strParse = split[1].Replace("success", " ");
                resSTR = "success";

            }
            else
            {
                resSTR = strParse;
            }
            return resSTR.Trim();
        }


        [HttpPost]
        public JsonResult LoadUserInfo()
        {
            if (Request.Cookies["AuthenticationSellBuy"] != null)
            {
                var value = Request.Cookies["AuthenticationSellBuy"].Value;
                return Json(userTools.GetInfoUser(Convert.ToInt16(value)));
            }

            return Json(null);
        }
	}
}