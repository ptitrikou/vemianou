using Vemianou.Models;
using Vemianou.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vemianou.Controllers
{
    public class HomeController : Controller
    {
        ItemService itemService = new ItemService();
        public ActionResult Index()
        {
            List<EvenementViewModel> eventsviewmodels = new List<EvenementViewModel>();
            List<EvenementViewModel> eventsviewmodels2 = new List<EvenementViewModel>();
            List<ITEM> evenements = itemService.listeArticle("publication",3).OrderByDescending(i => i.iditem).ToList();
            List<ITEM> evenementsfuturs = itemService.EvenementsFuturs("publication", 3).OrderByDescending(i => i.iditem).ToList();
            foreach (ITEM it in evenements)
            {
                EvenementViewModel vent = new EvenementViewModel();
                vent.iditem = it.iditem;
                vent.designation = it.designation;
                try{
                    vent.description = it.designdetails.Substring(0,100) + "...";
                }
                catch (ArgumentOutOfRangeException){
                    vent.description = it.designdetails ;
                }
                
                vent.dateevent = it.datpromo1.ToString("dd-MMMM-yyyy");
                vent.datepublish = it.datpublish.ToString("dd-MMMM-yyyy");
                vent.imagepath = it.imagpath1;
                eventsviewmodels.Add(vent);
            }
            foreach (ITEM it in evenementsfuturs)
            {
                EvenementViewModel vent = new EvenementViewModel();
                vent.iditem = it.iditem;
                vent.designation = it.designation;
                try
                {
                    vent.description = it.designdetails.Substring(0, 100) + "...";
                }
                catch (ArgumentOutOfRangeException)
                {
                    vent.description = it.designdetails;
                }

                vent.dateevent = it.datpromo1.ToString("dd-MMMM-yyyy");
                vent.datepublish = it.datpublish.ToString("dd-MMMM-yyyy");
                vent.imagepath = it.imagpath1;
                eventsviewmodels2.Add(vent);
            }
            ViewBag.evenements = eventsviewmodels;
            ViewBag.evenementsfutur = eventsviewmodels2;
            return View();
        }

        public ActionResult About()
        {
            List<EvenementViewModel> eventsviewmodels = new List<EvenementViewModel>();
            List<ITEM> evenements = itemService.listeArticle("publication", 2).OrderByDescending(i => i.iditem).ToList();

            foreach (ITEM it in evenements)
            {
                EvenementViewModel vent = new EvenementViewModel();
                vent.iditem = it.iditem;
                vent.designation = it.designation;
                try
                {
                    vent.description = it.designdetails.Substring(0, 100) + "...";
                }
                catch (ArgumentOutOfRangeException)
                {
                    vent.description = it.designdetails;
                }

                vent.dateevent = it.datpromo1.ToString("dd-MMMM-yyyy");
                vent.datepublish = it.datpublish.ToString("dd-MMMM-yyyy");
                vent.imagepath = it.imagpath1;
                eventsviewmodels.Add(vent);
            }
            ViewBag.evenements = eventsviewmodels;

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
            List<EvenementViewModel> eventsviewmodels = new List<EvenementViewModel>();
            List<ITEM> evenements = itemService.listeArticle("publication", 2).OrderByDescending(i => i.iditem).ToList();

            foreach (ITEM it in evenements)
            {
                EvenementViewModel vent = new EvenementViewModel();
                vent.iditem = it.iditem;
                vent.designation = it.designation;
                try
                {
                    vent.description = it.designdetails.Substring(0, 100) + "...";
                }
                catch (ArgumentOutOfRangeException)
                {
                    vent.description = it.designdetails;
                }

                vent.dateevent = it.datpromo1.ToString("dd-MMMM-yyyy");
                vent.datepublish = it.datpublish.ToString("dd-MMMM-yyyy");
                vent.imagepath = it.imagpath1;
                eventsviewmodels.Add(vent);
            }
            ViewBag.evenements = eventsviewmodels;

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
            else if (num ==5)
            {
                return View("latrine_publique_badu");
            }
            else
            {
                return View("DetailsBlog");
            }
            
        }
        public ActionResult DetailsEvenement(int iditem)
        {
            List<EvenementViewModel> eventsviewmodels = new List<EvenementViewModel>();
            List<SousfamillViewModel> sousfamillviewmodels = new List<SousfamillViewModel>();
            List<ITEM> listeevenements = itemService.listeArticle("publication", 3,iditem).OrderByDescending(i => i.iditem).ToList();
            EvenementViewModel eventviewmodel = new EvenementViewModel();
            ITEM itm = itemService.getItem(iditem);
            eventviewmodel.iditem = itm.iditem;
            eventviewmodel.designation = itm.designation;
            eventviewmodel.description = itm.designdetails;
            eventviewmodel.details = itm.designdetails2;
            eventviewmodel.dateevent = itm.datpromo1.ToString("dd-MMMM-yyyy");
            eventviewmodel.datepublish = itm.datpublish.ToString("dd-MMMM-yyyy");
            eventviewmodel.imagepath = itm.imagpath1;
            eventviewmodel.images = itemService.listeImagesImtem(itm);
         
            foreach (ITEM it in listeevenements)
            {
                EvenementViewModel vent = new EvenementViewModel();
                vent.iditem = it.iditem;
                vent.designation = it.designation;
                vent.description = it.designdetails;
                vent.dateevent = it.datpromo1.ToString("dd-MMMM-yyyy");
                vent.datepublish = it.datpublish.ToString("dd-MMMM-yyyy");
                vent.imagepath = it.imagpath1;
                eventsviewmodels.Add(vent);
            }

            ViewBag.autres = eventsviewmodels;
            try
            {
                ViewBag.evenements = eventsviewmodels.GetRange(0, 2);
            }
            catch (Exception)
            {
                ViewBag.evenements = eventsviewmodels;
            }
            return View(eventviewmodel);
        }
        public ActionResult Event(int? cat, int? nb)
        {
            List<EvenementViewModel> eventsviewmodels = new List<EvenementViewModel>();
            List<SousfamillViewModel> sousfamillviewmodels = new List<SousfamillViewModel>();
            List<ITEM> listeevenements = itemService.listeArticle("publication").OrderByDescending(i => i.iditem).ToList();
            List<ITEM> evenements = new List<ITEM>();
            int n, nombre, total;
            if (cat == null)
                evenements = listeevenements;
            else
            {
                evenements = itemService.listeArticle4((int)cat);
            }
            //paginate
            total = evenements.Count;
            double val = total / 5;
            if((val % 1) == 0){
                n = (int)val;
            }else{
                n = (int)Math.Ceiling(val) + 1;
            }           
            if (nb == null)
                nb = 1;
            nombre = (int)nb;
            if (nombre > n || nombre == 0)
            {
                nombre = 1;
            }
            else
            {
                try
                {
                    evenements = evenements.GetRange((nombre - 1) * 5, 5);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    evenements = evenements.GetRange((nombre - 1) * 5, (total - ((nombre - 1) * 5)));
                }
            }
            foreach (ITEM it in evenements)
            {
                EvenementViewModel vent = new EvenementViewModel();
                vent.iditem = it.iditem;
                vent.designation = it.designation;
                vent.description = it.designdetails;
                vent.dateevent = it.datpromo1.ToString("dd-MMMM-yyyy");
                vent.datepublish = it.datpublish.ToString("dd-MMMM-yyyy");
                vent.imagepath = it.imagpath1;
                eventsviewmodels.Add(vent);
            }
            try
            {
                ViewBag.recentposts = eventsviewmodels.GetRange(0, 3);
            }
            catch (Exception)
            {
                ViewBag.recentposts = eventsviewmodels;
            }

            ViewBag.nombre = nombre;
            ViewBag.total = total;
            ViewBag.n = n;
            try{
                ViewBag.evenements = eventsviewmodels.GetRange(0, 2);
            }
            catch (Exception){
                ViewBag.evenements = eventsviewmodels;
            }
            
            return View(eventsviewmodels);
        }
        public ActionResult Galleries()
        {
            List<EvenementViewModel> eventsviewmodels = new List<EvenementViewModel>();
            List<ITEM> evenements = itemService.listeArticle("publication", 2).OrderByDescending(i => i.iditem).ToList();

            foreach (ITEM it in evenements)
            {
                EvenementViewModel vent = new EvenementViewModel();
                vent.iditem = it.iditem;
                vent.designation = it.designation;
                try
                {
                    vent.description = it.designdetails.Substring(0, 100) + "...";
                }
                catch (ArgumentOutOfRangeException)
                {
                    vent.description = it.designdetails;
                }

                vent.dateevent = it.datpromo1.ToString("dd-MMMM-yyyy");
                vent.datepublish = it.datpublish.ToString("dd-MMMM-yyyy");
                vent.imagepath = it.imagpath1;
                eventsviewmodels.Add(vent);
            }
            ViewBag.evenements = eventsviewmodels;
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