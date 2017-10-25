using OperationTools.common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSellBuy.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        public ActionResult Index()
        {
            return View();
        }
        Location locationTools = new Location();


        public string UpdateImage()
        {
            try
            {
                var operation = System.Web.HttpContext.Current.Request.Form["changeUpdate"];
                var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                var fileName = System.Web.HttpContext.Current.Request.Form["NameImageUpdate"].ToString();
               
                if (operation == "1")
                {
                    var path = Path.Combine(Server.MapPath("~/Content/images/imagesPhotos"), fileName.Trim());
                    pic.SaveAs(path);
                }
                else if (operation == "2")
                {
                    var path = Path.Combine(Server.MapPath("~/Content/images/userPhotoForProfile"), fileName.Trim());
                    pic.SaveAs(path);
                    ViewBag.PhotoUser = fileName.Trim();
                }
                else if (operation == "3")
                {
                    var path = Path.Combine(Server.MapPath("~/Content/images/userPhotoForShops"), fileName.Trim());
                    pic.SaveAs(path);
                    ViewBag.PhotoUser = fileName.Trim();
                }
            }
            catch(Exception e)
            {
                return "";
            }
           
            return "success";
        }


        public JsonResult UploadImage()
        {
            Random rand = new Random();

            int temp;

            temp = rand.Next(1000000000);
            var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
            var id = System.Web.HttpContext.Current.Request.Form["id"];
            var operation = System.Web.HttpContext.Current.Request.Form["operation"];

            var fileName = "profile_";
            fileName += temp;
            fileName += "_";

            fileName += "us.jpg";

            if (operation == "1")
            {
                var path = Path.Combine(Server.MapPath("~/Content/images/imagesPhotos"), fileName.Trim());
                pic.SaveAs(path);
            }
            else if (operation == "2")
            {
                var path = Path.Combine(Server.MapPath("~/Content/images/userPhotoForProfile"), fileName.Trim());
                pic.SaveAs(path);
                ViewBag.PhotoUser = fileName.Trim();
            }
            else if (operation == "3")
            {
                var path = Path.Combine(Server.MapPath("~/Content/images/userPhotoForShops"), fileName.Trim());
                pic.SaveAs(path);
                ViewBag.PhotoUser = fileName.Trim();
            }

            var imgpath = "~/Content/images/userPhotoFor" + fileName.Trim();

            // var jsonResult = Json(imgpath, JsonRequestBehavior.AllowGet);
            return Json(fileName.Trim());

        }

        [HttpPost]
        public JsonResult GetCountries()
        {
            return Json(locationTools.GetAllCountries());
        }

        [HttpPost]
        public JsonResult GetRegions(int id)
        {
            return Json(locationTools.GetAllRegions(id));
        }

        [HttpPost]
        public JsonResult GetCity(int id)
        {
            return Json(locationTools.GetAllCity(id));
        }
	}
}