using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vemianou.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Causes()
        {
            return View();
        }
        public ActionResult Dons()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Blogs()
        {
            return View();
        }
        public ActionResult DetailsBlog(int num)
        {
            if (num == 1)
            {
                return View("journee_arbre");
            }else if(num== 2)
            {
                return View("table_banc");
            }else if (num == 3)
            {
                return View("remise_moto");
            }
            else if (num == 4)
            {
                return View("kit_scolaire");
            }
            else
            {
                return View("DetailsBlog");
            }
            
        }
        public ActionResult Event()
        {
            return View();
        }
        public ActionResult Galleries()
        {
            return View();
        }
        
        public ActionResult saveContact()
        {
            //return Redirect(Request.UrlReferrer.ToString());
            TempData["success"] = "Contact envoyé avec succès !";
            return RedirectToAction("Index");
        }
    }
}