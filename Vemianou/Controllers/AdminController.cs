using Vemianou.Models;
using Vemianou.ViewsModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


public class AdminController : Controller
    {
        SousFamilleService categorieService = new SousFamilleService();
        ItemService itemService = new ItemService();
        NouveauteService nouveauteService = new NouveauteService();
        BanniereService banniereService = new BanniereService();
        UserService userService = new UserService();
        SousFamilleService sousFamilleService = new SousFamilleService();
        FamilleService familleService = new FamilleService();
        GroupfamillService groupfamilleService = new GroupfamillService();
        CommandeService commandeService = new CommandeService();
        ModelVemianou db = new ModelVemianou();
        // GET: Admin
        public ActionResult Index()
        {

              return RedirectToAction("ListeEvenements");
        }
        public ActionResult ListeAdministrateurs()
        {
            List<USER> users = db.USER.Where(u => u.typuser == 1).ToList();
            USER us = Session["user"] as USER;
            ViewBag.typeuser = us.typuser;
            return View("Administrateurs",users);
        }
        public ActionResult DeleteAdmin(int idadmin)
        {
            USER us = Session["user"] as USER;
            if(us.iduser == idadmin)
            {
                TempData["error"] = "Utilisateur en cours !";
            }
            else
            {
                int n = userService.deleteAdmin(idadmin);
                if (n == 1)
                {
                    TempData["success"] = "Utilisateur supprimé avec succès !";
                }
                else
                {
                    TempData["error"] = "Utilisateur non supprimé !";
                }

           
            }
            return RedirectToAction("ListeAdministrateurs");
        }
      
        public ActionResult NouvellesCommandes()
        {
           
                List<VENTE> listeCommande = commandeService.nouvellesCommande();
                ViewBag.cmdencours = commandeService.nbreCommandEncours();
                ViewBag.cmdlivre = commandeService.nbreCommandLivre();
                ViewBag.cmdeffectue = commandeService.listeCommande().Count;
                ViewBag.nclients = userService.listUsers().Count;
                return View(listeCommande);
          

        }

        //article
        public ActionResult Categories()
        {
           
                List<SOUSFAMILL> listeCategorie = sousFamilleService.listeCategorie(null);
                ViewBag.categories = listeCategorie;
                ViewBag.familles = familleService.listeFamille();
                return View();
          

        }
        public ActionResult Familles()
        {
            
                List<FAMILL> listeFamille = familleService.listeFamille();
                ViewBag.familles = listeFamille;
                ViewBag.groupfamilles = groupfamilleService.listeGroupFamill();
                return View();
           

        }
        public ActionResult GroupeFamilles()
        {
            
                List<GROUPFAMILL> listeGroupeFamille = groupfamilleService.listeGroupFamill();
                ViewBag.groupfamilles = listeGroupeFamille;
                return View();
          

        }
        //delete categorie
        public ActionResult deleteCategorie(int id)
        {
           
                int r = sousFamilleService.deleteCategorie(id);
                if (r != 0)
                {
                    TempData["deletecatsuc"] = "Catégorie supprimée avec succès !";
                }
                else
                {
                    TempData["deletecater"] = "Catégorie non supprimée!";
                }
                return RedirectToAction("Categories");
          

        }
        public ActionResult deleteFamill(int id)
        {
           
                int r = familleService.deleteFamill(id);
                if (r != 0)
                {
                    TempData["deletecatsuc"] = "Catégorie supprimée avec succès !";
                }
                else
                {
                    TempData["deletecater"] = "Catégorie non supprimée!";
                }
                return RedirectToAction("Familles");
           
        }
        public ActionResult deleteGroupFamill(int id)
        {
            
                int r = groupfamilleService.deleteGroupFamill(id);
                if (r != 0)
                {
                    TempData["deletecatsuc"] = "Catégorie supprimée avec succès !";
                }
                else
                {
                    TempData["deletecater"] = "Catégorie non supprimée!";
                }
                return RedirectToAction("GroupeFamilles");
           
        }
        //add categorie
        [HttpPost]
        public ActionResult addCategorie(SOUSFAMILL sf)
        {
           
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                fileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName;
                Request.Files[0].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName)));
                sf.imgsousfamill1 = fileName;
                int r = sousFamilleService.addCategorie(sf);
                if (r != 0)
                {
                    TempData["addcatsuc"] = "Catégorie ajoutée avec succès !";
                }
                else
                {
                    TempData["addcater"] = "Catégorie non ajoutée!";
                }
                return RedirectToAction("Categories");
           
        }
        //add categorie
        [HttpPost]
        public ActionResult addFamill(FAMILL fm)
        {           
            string fileName = Path.GetFileName(Request.Files[0].FileName);
            fileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName;
            Request.Files[0].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName)));
            fm.imgfamill1 = fileName;
            fm.typfamill=0;
            fm.ordrefamill=0;
            fm.param1=0;
            fm.param2=0;
            fm.param3="";
            fm.etatfamill=0;
            int r =familleService.addFamill(fm);
            if (r != 0)
            {
                TempData["addcatsuc"] = "Catégorie ajoutée avec succès !";
            }
            else
            {
                TempData["addcater"] = "Catégorie non ajoutée!";
            }
            return RedirectToAction("Familles");          
        }
        [HttpPost]
        public ActionResult addGroupFamill(GROUPFAMILL gf)
        {
            
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                fileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName;
                Request.Files[0].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName)));
                gf.imaggroup = fileName;
                int r = groupfamilleService.addGroupFamill(gf);
                if (r != 0)
                {
                    TempData["addcatsuc"] = "Catégorie ajoutée avec succès !";
                }
                else
                {
                    TempData["addcater"] = "Catégorie non ajoutée!";
                }
                return RedirectToAction("GroupeFamilles");
          
        }
        //add categorie
        [HttpPost]
        public ActionResult updateCategorie(SOUSFAMILL sf)
        {
           
                int r = sousFamilleService.updateCategorie(sf);
                if (r != 0)
                {
                    TempData["updatecatsuc"] = "Catégorie modifiée avec succès !";
                }
                else
                {
                    TempData["updatecater"] = "Catégorie non modifiée!";
                }
                return RedirectToAction("Categories");
          
        }
        //add categorie
        [HttpPost]
        public ActionResult updateGroupFamill(GROUPFAMILL gf)
        {
            

                int r = groupfamilleService.updateGroupFamill(gf);
                if (r != 0)
                {
                    TempData["updatecatsuc"] = "Catégorie modifiée avec succès !";
                }
                else
                {
                    TempData["updatecater"] = "Catégorie non modifiée!";
                }
                return RedirectToAction("GroupeFamilles");
            
        }
        [HttpPost]
        public ActionResult updateFamill(FAMILL fm)
        {
           
                int r = familleService.updateFamill(fm);
                if (r != 0)
                {
                    TempData["updatecatsuc"] = "Catégorie modifiée avec succès !";
                }
                else
                {
                    TempData["updatecater"] = "Catégorie non modifiée!";
                }
                return RedirectToAction("Familles");

        }
        public ActionResult AjouterMenu()
        {              
               List<SOUSFAMILL> listeCategorie = sousFamilleService.listeCategorie("restauration");
                ViewBag.categories = listeCategorie;
                return View("NouveauArticle");
    
        }
        public ActionResult AjouterAppartement()
        {
              
                List<SOUSFAMILL> listeCategorie = sousFamilleService.listeCategorie("reservation");
                ViewBag.categories = listeCategorie;
                return View("NouveauAppartement");

          
        }
        [HttpPost]
        public ActionResult AjouterMenu(ITEM it)
        {
            
                if ((it.tauxremiz > 0 && it.prix2 == 0) || (it.prix2 > it.prixitem))
                {
                    TempData["error"] = "Les informations entrés sont invalide !Veuillez reprendre";
                    return View(it);
                }
                else
                {

                    string fileName = "";
                    string fileName2 = "";
                    string fileName3 = "";
                    string fileName4="";
                    string fileName5 = "";
                    string fileName6 = "";
                    string fileName7 = "";
                    string fileName8 = "";
                     if (!string.IsNullOrEmpty(Request.Files[0].FileName))
                    {
          
                        fileName = Path.GetFileName(Request.Files[0].FileName);
                        fileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName;

                        Request.Files[0].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName)));
                        it.imagpath1 = fileName;
                    }

                    if (!string.IsNullOrEmpty(Request.Files[1].FileName))
                    {
                        //
                        fileName2 = Path.GetFileName(Request.Files[1].FileName);
                        fileName2 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName2;
                        Request.Files[1].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName2)));
                        it.imagpath2 = fileName2;
                    }

                    if (!string.IsNullOrEmpty(Request.Files[2].FileName))
                    {
                        fileName3 = Path.GetFileName(Request.Files[2].FileName);
                        fileName3 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName3;
                        Request.Files[2].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName3)));
                        it.imagpath3 = fileName3;
                    }
                    if (!string.IsNullOrEmpty(Request.Files[3].FileName))
                    {
                        fileName4 = Path.GetFileName(Request.Files[3].FileName);
                        fileName4 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName4;

                        Request.Files[3].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName4)));
                        it.imagpath4 = fileName4;
                    }
                    if (!string.IsNullOrEmpty(Request.Files[4].FileName))
                    {
                        fileName5 = Path.GetFileName(Request.Files[4].FileName);
                        fileName5 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName5;

                        Request.Files[4].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName5)));
                        it.imagpath5 = fileName5;
                    }
                    if (!string.IsNullOrEmpty(Request.Files[5].FileName))
                    {
                        fileName6 = Path.GetFileName(Request.Files[5].FileName);
                        fileName6 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName6;

                        Request.Files[5].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName6)));
                        it.imagpath6 = fileName6;
                    }
                    if (!string.IsNullOrEmpty(Request.Files[6].FileName))
                    {
                        fileName7 = Path.GetFileName(Request.Files[6].FileName);
                        fileName7 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName7;

                        Request.Files[6].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName7)));
                        it.imagpath7 = fileName7;
                    }
                    if (!string.IsNullOrEmpty(Request.Files[7].FileName))
                    {
                        fileName8 = Path.GetFileName(Request.Files[7].FileName);
                        fileName8 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName8;

                        Request.Files[7].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName8)));
                        it.imagpath8 = fileName8;
                    }
                    string r = itemService.addItem(it);
                    if (r == "1")
                    {
                        TempData["success"] = "Menu enregistré avec succès !";
                    }
                     else if( r == "2")
                    {
                        TempData["error"] = "Menu non enregistré .Veuillez changer la designation !";
                    }
                    else
                    {
                        TempData["error"] = "Menu non enregistré .Veuillez reessayer !";
                    }

                }

                return Redirect("ListeMenus");
           
        }
        [HttpPost]
        public ActionResult AjouterAppartement(ITEM it)
        {
                string fileName, fileName2, fileName3, fileName4,fileName5,fileName6,fileName7,fileName8 ;

                if (!string.IsNullOrEmpty(Request.Files[0].FileName))
                {
          
                    fileName = Path.GetFileName(Request.Files[0].FileName);
                    fileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName;

                    Request.Files[0].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName)));
                    it.imagpath1 = fileName;
                }

                if (!string.IsNullOrEmpty(Request.Files[1].FileName))
                {
                    //
                    fileName2 = Path.GetFileName(Request.Files[1].FileName);
                    fileName2 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName2;
                    Request.Files[1].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName2)));
                    it.imagpath2 = fileName2;
                }

                if (!string.IsNullOrEmpty(Request.Files[2].FileName))
                {
                    fileName3 = Path.GetFileName(Request.Files[2].FileName);
                    fileName3 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName3;
                    Request.Files[2].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName3)));
                    it.imagpath3 = fileName3;
                }
                if (!string.IsNullOrEmpty(Request.Files[3].FileName))
                {
                    fileName4 = Path.GetFileName(Request.Files[3].FileName);
                    fileName4 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName4;

                    Request.Files[3].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName4)));
                    it.imagpath4 = fileName4;
                }
                if (!string.IsNullOrEmpty(Request.Files[4].FileName))
                {
                    fileName5 = Path.GetFileName(Request.Files[4].FileName);
                    fileName5 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName5;

                    Request.Files[4].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName5)));
                    it.imagpath5 = fileName5;
                }
                if (!string.IsNullOrEmpty(Request.Files[5].FileName))
                {
                    fileName6 = Path.GetFileName(Request.Files[5].FileName);
                    fileName6 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName6;

                    Request.Files[5].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName6)));
                    it.imagpath6 = fileName6;
                }
                if (!string.IsNullOrEmpty(Request.Files[6].FileName))
                {
                    fileName7 = Path.GetFileName(Request.Files[6].FileName);
                    fileName7 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName7;

                    Request.Files[6].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName7)));
                    it.imagpath7 = fileName7;
                }
                if (!string.IsNullOrEmpty(Request.Files[7].FileName))
                {
                    fileName8 = Path.GetFileName(Request.Files[7].FileName);
                    fileName8 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName8;

                    Request.Files[7].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName8)));
                    it.imagpath8 = fileName8;
                }


                string r = itemService.addItem(it);
                if (r == "1")
                {
                    TempData["success"] = "Appartement enregistré avec succès !";
                }
                else if( r == "2")
                {
                    TempData["error"] = "Appartement non enregistré .Veuillez changer la designation !";
                }
                else
                {
                    TempData["error"] = "Appartement non enregistré .Veuillez reessayer !";
                }

               
                return Redirect("ListeAppartements");
           
        }
        //liste des articles
        public ActionResult NouveauCompte(string nomuser,string prenomuser,string loginuser,string passuser)
        {
            USER us = new USER();
            us.nomuser = nomuser;
            us.prenomsuser = prenomuser;
            us.nomprenomsuser = nomuser + prenomuser;
            us.loginuser = loginuser;
            us.passeuser = passuser;
            us.email="Aucun";
            us.teluser = "Aucun";
            us.adressuser = "Aucun";
            us.sexeuser = 0;
            userService.addUser(us);
            
            TempData["success"] = "Compte enregistré avec succès !";
            return RedirectToAction("ListeAdministrateurs");
        }
        public ActionResult listeMenus()
        {
           
                List<ITEM> listArticle = itemService.listeArticle("restauration");
                ViewBag.articles = listArticle;
                return View("listeArticle");
            
        }
        public ActionResult listeAppartements()
        {
            List<AppartementViewModel> appartements = new List<AppartementViewModel>();
            
            List<ITEM> listArticle = itemService.listeArticle("reservation");
            foreach (ITEM it in listArticle){
                AppartementViewModel apt = new AppartementViewModel();
                apt.iditem = it.iditem;
                apt.designation = it.designation;
                apt.description = it.designdetails;
                apt.prix = it.prixitem.ToString() ;
                apt.prix2 = it.prix2.ToString();
                apt.details = it.designdetails2.Split('-').ToList();
                if(apt.details.ElementAt(0) == "")
                   apt.details.RemoveAt(0);
                apt.devise = it.devise;
                apt.nbpersonne = (int)it.tauxremiz;
                apt.impath = it.imagpath1;
                apt.datpublish = it.datpublish.ToString();
                apt.categorie = sousFamilleService.getSousFamill(it.category).libsousfamill;
                appartements.Add(apt);
            }
            return View("listeAppartement",appartements);

        }
        public ActionResult showItem(int id,int type)
        {
           
            ITEM it = itemService.detailsArticle(id);
            List<string> listeImage = new List<string>();
                if(it.imagpath1 != null)
            {
                listeImage.Add(it.imagpath1);
            }
            if (it.imagpath2 != null)
            {
                listeImage.Add(it.imagpath2);
            }
            if (it.imagpath3 != null)
            {
                listeImage.Add(it.imagpath3);
            }
            if (it.imagpath4 != null)
            {
                listeImage.Add(it.imagpath4);
            }
            if (it.imagpath5 != null)
            {
                listeImage.Add(it.imagpath5);
            }
            if (it.imagpath6 != null)
            {
                listeImage.Add(it.imagpath6);
            }
            if (it.imagpath7 != null)
            {
                listeImage.Add(it.imagpath7);
            }
            if (it.imagpath8 != null)
            {
                listeImage.Add(it.imagpath8);
            }
            ViewBag.article = it;
            ViewBag.images = listeImage;
            if(type ==0)
                return View("showArticle");
            else if(type == 2)
               return View("showEvenement");
            else
                return View("showAppartement");
            
        }
        
        public ActionResult updateItem(int id,int type)
        {
           
               
                ITEM it = itemService.detailsArticle(id);

                if (type == 0){
                    List<SOUSFAMILL> listeCategorie = sousFamilleService.listeCategorie("restauration");
                    ViewBag.categories = listeCategorie;
                    return View("updateArticle", it);
                }
                else if(type == 2){
                    List<SOUSFAMILL> listeCategorie = sousFamilleService.listeCategorie("publication");
                    ViewBag.categories = listeCategorie;
                    return View("updateEvenement", it);
                }
                else{
                    List<SOUSFAMILL> listeCategorie = sousFamilleService.listeCategorie("reservation");
                    ViewBag.categories = listeCategorie;
                    return View("updateAppartement", it);
                }                              
        }

        [HttpPost]
        [ValidateInput(false)]   
        public ActionResult updateItem(ITEM it)
        {
                ITEM itm =db.ITEM.Find(it.iditem);
               
                string r = itemService.updateArticle(it);
                if (r == "1")
                {
                    TempData["success"] = "Modification éffectueé avec succès !";
                }
                 else if( r == "2")
                {
                    TempData["error"] = "Veuillez changer la designation !";
                }
                else
                {
                    TempData["error"] = "Modification non éffectueé !";
                }

                if(itm.SOUSFAMILL.FAMILL.GROUPFAMILL.libgroup =="restauration")
                     return RedirectToAction("ListeMenus");
                else if(itm.SOUSFAMILL.FAMILL.GROUPFAMILL.libgroup == "evenementiel")
                     return RedirectToAction("ListeEvenements");
                else
                     return RedirectToAction("ListeEvenements");

        }
        public ActionResult deleteItem(int id,int type)
        {           
                string r = itemService.deleteArticle(id);
                if (r == "1")
                {
                    TempData["success"] = "Supression éffectuée avec succès !";
                    /*System.IO.File.Delete(Server.MapPath(Path.Combine("~/Content/images/", imagepath1)));
                    System.IO.File.Delete(Server.MapPath(Path.Combine("~/Content/images/", imagepath2)));
                    System.IO.File.Delete(Server.MapPath(Path.Combine("~/Content/images/", imagepath3)));*/
                }
                else
                {
                    TempData["error"] = "Supression non éffectuée!";
                }
                /*if(type == 0)                   
                    return RedirectToAction("ListeMenus");
                else
                   return RedirectToAction("ListeAppartements");*/
                return Redirect(Request.UrlReferrer.ToString());
            
        }
        public ActionResult updateImage(int id,string type)
        {
                ITEM it = db.ITEM.Find(id);
                ViewBag.type=type;
                return View(it);
          
        }
        [HttpPost]
        public ActionResult updateImage(int id, int nim, string oldimage, string type, HttpPostedFileBase file1)
        {
            
            string r;
            System.IO.File.Delete(Server.MapPath(Path.Combine("~/Content/images/", oldimage)));
            string fileName = Path.GetFileName(file1.FileName);
            fileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName;
            file1.SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName)));
            r = itemService.updateImage(id, nim, fileName);
            if (r == "1")
            {
                TempData["success"] = "Image modifié avec succès !";
            }
            else
            {
                TempData["error"] = "Image non modifié!";
            }
            ViewBag.type = type;
            return RedirectToAction("showItem",new {id=id,type=type });

        }
        [HttpPost]
        public ActionResult updateImageCategorie(int id, string oldimage, HttpPostedFileBase file1)
        {
            
                string r = "";
                System.IO.File.Delete(Server.MapPath(Path.Combine("~/Content/images/", oldimage)));
                string fileName = Path.GetFileName(file1.FileName);
                fileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName;
                file1.SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName)));
                sousFamilleService.updateImage(id, fileName);
                if (r == "1")
                {
                    TempData["success"] = "Image modifié avec succès !";
                }
                else
                {
                    TempData["error"] = "Image non modifié!";
                }
                return RedirectToAction("Categories");
           
        }
        [HttpPost]
        public ActionResult updateImageFamill(int id, string oldimage, HttpPostedFileBase file1)
        {
            
                string r = "";
                // System.IO.File.Delete(Server.MapPath(Path.Combine("~/Content/images/", oldimage)));
                string fileName = Path.GetFileName(file1.FileName);
                fileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName;
                file1.SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName)));
                familleService.updateImage(id, fileName);
                if (r == "1")
                {
                    TempData["success"] = "Image modifié avec succès !";
                }
                else
                {
                    TempData["error"] = "Image non modifié!";
                }
                return RedirectToAction("Familles");
           
        }
        [HttpPost]
        public ActionResult updateImageGroupFamill(int id, string oldimage, HttpPostedFileBase file1)
        {
            USER user = Session["user"] as USER;
            
                string r = "";
                // System.IO.File.Delete(Server.MapPath(Path.Combine("~/Content/images/", oldimage)));
                string fileName = Path.GetFileName(file1.FileName);
                fileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName;
                file1.SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName)));
                groupfamilleService.updateImage(id, fileName);
                if (r == "1")
                {
                    TempData["success"] = "Image modifié avec succès !";
                }
                else
                {
                    TempData["error"] = "Image non modifié!";
                }
                return RedirectToAction("GroupeFamilles");
            
        }

        //liste nouveautes
        public ActionResult Nouveautes()
        {
           
                List<ITEM> listeNouveautes = nouveauteService.listeNouveaute();
                ViewBag.nouveautes = listeNouveautes;
                List<ITEM> listeArticles = itemService.listeArticle2();
                ViewBag.articles = listeArticles;

                return View();
           
        }
        [HttpPost]
        public ActionResult addNouveaute(int id)
        {
           
                string r = nouveauteService.addNouveaute(id);

                if (r == "1")
                {
                    TempData["success"] = "Article ajouté avec succès !";
                }
                else
                {
                    TempData["error"] = "Article non ajouté !";
                }
                return RedirectToAction("Nouveautes");
          
        }

        public ActionResult deleteNouveaute(int id)
        {
           
                string r = nouveauteService.deleteNouveaute(id);
                if (r == "1")
                {
                    TempData["success"] = "Article supprimé avec succès !";
                }
                else
                {
                    TempData["error"] = "Article non supprimé !";
                }
                return RedirectToAction("Nouveautes");
            
        }

        //liste banniers
        public ActionResult Bannieres()
        {
            
                List<ITEM> listeBannieres = banniereService.listeBanniere();
                ViewBag.bannieres = listeBannieres;
                List<ITEM> listeArticles = itemService.listeArticle3();
                ViewBag.articles = listeArticles;

                return View();
          
        }

        //delete banniere
        public ActionResult deleteBanniere(int id)
        {
            
                string r = banniereService.deleteBanniere(id);
                if (r == "1")
                {
                    TempData["success"] = "Article supprimé avec succès !";
                }
                else
                {
                    TempData["error"] = "Article non supprimé !";
                }
                return RedirectToAction("Bannieres");
          
        }
        [HttpPost]
        public ActionResult addBanniere(int id)
        {
           
                string r = banniereService.addBanniere(id);

                if (r == "1")
                {
                    TempData["success"] = "Article ajouté avec succès !";
                }
                else
                {
                    TempData["error"] = "Article non ajouté !";
                }
                return RedirectToAction("Bannieres");
           
        }

        public ActionResult newsletters()
        {

            return View();
        }
        public ActionResult infocompte(int iduser)
        {
           
                USER us = userService.getUserById(iduser);
                return View(us);
            
        }
        public ActionResult listeUsers()
        {
           
                List<USER> listUsers = userService.listUsers();
                ViewBag.cmdencours = commandeService.nbreCommandEncours();
                ViewBag.cmdlivre = commandeService.nbreCommandLivre();
                ViewBag.cmdeffectue = commandeService.listeCommande().Count;
                ViewBag.nclients = userService.listUsers().Count;
                return View(listUsers);
           
        }
        public ActionResult detailsCommande(int idcommande)
        {
            
            VENTE vente = commandeService.detailsCommande(idcommande);
            ViewBag.user = userService.getUserById(vente.iduser);
            List<DETVENTE> detailsventes = db.DETVENTE.Where(d => d.idvente == vente.idvente).ToList();
            ViewBag.detailsventes = detailsventes;
            return View(vente);
           
        }

        public ActionResult Publicite()
        {

            ViewBag.par = db.PARAMS.FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult updatePub(PARAMS parm)
        {
           
                PARAMS par = db.PARAMS.Find(parm.IDparam);
                par.p21 = parm.p21;
                par.p22 = parm.p22;
                par.p23 = parm.p23;
                db.Entry(par).State = EntityState.Modified;
                int r = db.SaveChanges();
                return RedirectToAction("Publicite");
           

        }
        [HttpPost]
        public ActionResult updatePubImage(int id, string oldimage, HttpPostedFileBase file1)
        {
                    
                int r = 0;

                string fileName = Path.GetFileName(file1.FileName);
                file1.SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName)));
                PARAMS par = db.PARAMS.Find(id);
                par.p24 = fileName;
                db.Entry(par).State = EntityState.Modified;
                r = db.SaveChanges();
                if (r == 1)
                {
                    TempData["success"] = "Image modifié avec succès !";
                }
                else
                {
                    TempData["error"] = "Image non modifié!";
                }
                return RedirectToAction("Publicite");
            
        }

        public ActionResult promotions()
        {
            List<ITEM> listeArticles = db.ITEM.Where(it => it.tauxremiz != 0).ToList();
            ViewBag.prom = listeArticles;
            return View();
        }

        public ActionResult updateCommande(long idcommande)
        {
            commandeService.updateCommande(idcommande);
            return RedirectToAction("Index", "Admin");
        }
         
        //public ActionResult MenuDuJour()
        //{
        //    List<MenuDuJourViewModel> menus = new List<MenuDuJourViewModel>();
        //    List<ITEM>items = new List<ITEM>();
        //    foreach(PARAMS pr in db.PARAMS.Where(p => p.libp.Equals("menu")).ToList())
        //    {
        //        MenuDuJourViewModel menudujour = new MenuDuJourViewModel();
        //        ITEM it = itemService.getItem((int)pr.p1);
        //        menudujour.iditem = it.iditem;
        //        menudujour.designation = it.designation;
        //        menudujour.description = it.designdetails;
        //        if (it.tauxremiz != 0)
        //        {
        //            menudujour.prix = it.prix2.ToString();
        //        }
        //        else
        //        {
        //            menudujour.prix = it.prixitem.ToString();
        //        }
        //        menudujour.dateenr = ((DateTime)(pr.p40)).ToString("dd-MM-yyyy");

        //        if(((DateTime)pr.p40 - DateTime.Now).TotalDays == 0) { 
        //           menudujour.date="Aujourd'hui";
        //           menudujour.stat = 1;
        //        }else if(((DateTime)pr.p40 - DateTime.Now).TotalDays > 0){
        //           menudujour.date = ((DateTime)(pr.p41)).ToString("dd-MM-yyyy");
        //           menudujour.stat = 2;
        //        }
        //        else {
        //           menudujour.date = ((DateTime)(pr.p41)).ToString("dd-MM-yyyy");
        //           menudujour.stat = 0;
        //        }
               
        //        menudujour.lienimage = it.imagpath1;
        //        menus.Add(menudujour);
        //    }
           
        //    foreach (SOUSFAMILL sfm in sousFamilleService.listeCategorie("restauration"))
        //    {
        //        items.AddRange(sfm.ITEM);
        //    }

        //    ViewBag.listemenu = new SelectList(items, "iditem", "designation");
        //    ViewBag.dateactu = DateTime.Now.ToString("yyyy-MM-dd");
        //    return View(menus);
        //}
        
        [HttpPost]
        public ActionResult MenuDuJour(DateTime date,int iditem)
        {
            PARAMS pr = new PARAMS();
            DateTime datemenu = new DateTime(date.Year,date.Month,date.Day);
            pr.p1 = iditem;
            pr.libp = "menu";
            pr.p41 = datemenu;
            pr.p40 = DateTime.Now;
            db.PARAMS.Add(pr);
            db.SaveChanges();
            return RedirectToAction("MenuDuJour");
        }
        [HttpPost]
        public ActionResult DeleteMenuDuJour(int iditem)
        {
            PARAMS pr = db.PARAMS.Where(p => p.p1 == iditem).ToList().FirstOrDefault();
            db.PARAMS.Remove(pr);
            db.SaveChanges();
            TempData["success"] = "Menu supprimé avec succès !";
            return RedirectToAction("MenuDuJour");
        }

        public ActionResult ListeEvenements()
        {
            List<EvenementViewModel> evenements = new List<EvenementViewModel>();

            List<ITEM> listArticle = itemService.listeArticle("publication");
            foreach (ITEM it in listArticle)
            {
                EvenementViewModel vent = new EvenementViewModel();
                vent.iditem = it.iditem;
                vent.designation = it.designation;
                vent.description = it.designdetails;
                vent.dateevent = it.datpromo1.ToString("dd-MM-yyyy");
                vent.datepublish = it.datpublish.ToString("dd-MM-yyyy");
                vent.imagepath = it.imagpath1;
                evenements.Add(vent);
            }
            return View("Evenements",evenements);
        }

        public ActionResult NouveauEvenement()
        {
            List<SOUSFAMILL> listeCategorie = sousFamilleService.listeCategorie("publication");
            ViewBag.categories = listeCategorie;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]   
        public ActionResult NouveauEvenement(ITEM it)
        {
            string fileName, fileName2, fileName3, fileName4,fileName5,fileName6,fileName7,fileName8 ;
           
            if (!string.IsNullOrEmpty(Request.Files[0].FileName))
            {

                fileName = Path.GetFileName(Request.Files[0].FileName);
                fileName = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName;

                Request.Files[0].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName)));
                it.imagpath1 = fileName;
            }

            if (!string.IsNullOrEmpty(Request.Files[1].FileName))
            {
                //
                fileName2 = Path.GetFileName(Request.Files[1].FileName);
                fileName2 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName2;
                Request.Files[1].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName2)));
                it.imagpath2 = fileName2;
            }

            if (!string.IsNullOrEmpty(Request.Files[2].FileName))
            {
                fileName3 = Path.GetFileName(Request.Files[2].FileName);
                fileName3 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName3;
                Request.Files[2].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName3)));
                it.imagpath3 = fileName3;
            }
            if (!string.IsNullOrEmpty(Request.Files[3].FileName))
            {
                fileName4 = Path.GetFileName(Request.Files[3].FileName);
                fileName4 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName4;

                Request.Files[3].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName4)));
                it.imagpath4 = fileName4;
            }
            if (!string.IsNullOrEmpty(Request.Files[4].FileName))
            {
                fileName5 = Path.GetFileName(Request.Files[4].FileName);
                fileName5 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName5;

                Request.Files[4].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName5)));
                it.imagpath5 = fileName5;
            }
            if (!string.IsNullOrEmpty(Request.Files[5].FileName))
            {
                fileName6 = Path.GetFileName(Request.Files[5].FileName);
                fileName6 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName6;

                Request.Files[5].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName6)));
                it.imagpath6 = fileName6;
            }
            if (!string.IsNullOrEmpty(Request.Files[6].FileName))
            {
                fileName7 = Path.GetFileName(Request.Files[6].FileName);
                fileName7 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName7;

                Request.Files[6].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName7)));
                it.imagpath7 = fileName7;
            }
            if (!string.IsNullOrEmpty(Request.Files[7].FileName))
            {
                fileName8 = Path.GetFileName(Request.Files[7].FileName);
                fileName8 = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileName8;

                Request.Files[7].SaveAs(Server.MapPath(Path.Combine("~/Content/images/", fileName8)));
                it.imagpath8 = fileName8;
            }


            string r = itemService.addItem(it);
            if (r == "1")
            {
                TempData["success"] = "Evenement enregistré avec succès !";
            }
            else if (r == "2")
            {
                TempData["error"] = "Evenement non enregistré .Veuillez changer le titre !";
            }
            else
            {
                TempData["error"] = "Evenement non enregistré .Veuillez réessayer !";
            }

            return RedirectToAction("ListeEvenements");
        }
}

