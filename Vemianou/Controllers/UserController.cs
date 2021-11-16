using Vemianou.Models;
using Cristal.ViewsModels;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Vemianou.ViewsModels;

public class UserController : Controller
    {
        UserService userService = new UserService();
        ModelVemianou db = new ModelVemianou();    
        NumberFormatInfo numf = new CultureInfo("fr-FR", false).NumberFormat;
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View("~/Views/Home/Login.cshtml");
        }

    [HttpPost()]
    public ActionResult Login(USER us)
    {
        USER user;
        user = userService.getUser(us.loginuser, us.passeuser);
        if (user == null)
        {
            ViewData["errins"] = "Compte non trouvé!";
            return View("~/Views/Home/Login.cshtml");
        }
        else
        {
            FormsAuthentication.SetAuthCookie(us.iduser.ToString(), false);
            Session["user"] = user;
            return RedirectToAction("ListeEvenements", "Admin");
        }
      
    }


        public ActionResult NouveauCompte()
        {
            return View("inscription");
        }

        [HttpPost()]
        public ActionResult EnregistrerCompte(USER us)
        {
            if(us.iduser == 0)
            {
                
                USER u=userService.addUser(us);
                if (u == null)
                {
                    TempData["errins"] = "Cet email existe déja !";
                    return View("Inscription",us);
                }
                else {
                    FormsAuthentication.SetAuthCookie(us.iduser.ToString(), false);
                    Session["user"] = u;
                    if (Session["cmde"] != null){
                        return RedirectToAction("Commander", "Menu");
                    }
                    if(Session["reserv"] != null){
                        int reserid = (int)Session["idreser"];
                        return RedirectToAction("InfoReservation", "Reservation", new { iditem = reserid });
                    }
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return RedirectToAction("Login");
        }
        public ActionResult Logout(){
            
            Session["user"] = null;
            Session["panier"] = null;
            Session["total"] = null;
            Session["cmde"] = null;
            Session["reserv"] = null;

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult updateUser(USER us){
            int r=userService.updateUser(us);
            if (r != 0)
            {
                TempData["success"] = "Modification effectuée avec succès !";
            }
            else
            {
                TempData["error"] = "Modification non effectuée!";
            }
            return RedirectToAction("infocompte","Admin",new { iduser = r});
        }

       public ActionResult MesCommandes()
        {
            USER us = Session["user"] as USER;
            List<CommandeViewModel> commandes = new List<CommandeViewModel>();
            List<VENTE> ventes = new List<VENTE>();
            ventes = db.VENTE.Where(v => v.iduser == us.iduser).ToList();
            foreach(VENTE vt in ventes)
            {
              
                CommandeViewModel cmv = new CommandeViewModel();
                List<ItemViewModel> items = new List<ItemViewModel>();
                cmv.date = vt.datvente.ToString("dd/MM/yyy");
                cmv.montant = vt.totalvente.ToString("N0", numf);
                cmv.numeroCommande = vt.codevente;
                //items

                foreach(DETVENTE det in vt.DETVENTE)
                {
                    ItemViewModel itvm = new ItemViewModel();
                    itvm.designation = det.ITEM.designation ;
                    itvm.prix2 = det.prixunit.ToString("N0",numf);
                    itvm.quantite = (int)det.qteachat ;
                    itvm.soustotal = det.soustot.ToString("N0",numf);
                    items.Add(itvm);
                }
                
                cmv.items.AddRange(items);
                commandes.Add(cmv);
            }
            return View("commandes",commandes);
        }
    }
