using System;
using Vemianou.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


public class ItemService
    {
         ModelCristal db = new ModelCristal();    

        public string addItem(ITEM it)
        {
                string r = "";         
            
                List<string> listeArticle = db.ITEM.Where(i => i.designation == it.designation).Select(i => i.designation).ToList();
                if (!listeArticle.Any()) {
                    it.typeitem =0;                   
                    it.datpublish = DateTime.Now;
                    //it.datpromo1 = it.datpublish;
                    it.datpromo2 = it.datpromo1;
                    db.ITEM.Add(it);
                    db.SaveChanges();
                    r = "1";
                }
                else
                {
                   r = "2";
                }
         
            return r;
        }
        //liste des articles
        public List<ITEM> listeArticle(string famille,int n = 0,int iditem = 0)
        {
            List<ITEM>listitem = new List<ITEM>();
            if (n == 0)
            {
                listitem = db.ITEM.Where(i => i.SOUSFAMILL.FAMILL.GROUPFAMILL.libgroup == famille && i.datpromo1 < DateTime.Now).OrderByDescending(i => i.ordre1).ToList();

            }
            else
            {
                try{
                    listitem = db.ITEM.Where(i => i.SOUSFAMILL.FAMILL.GROUPFAMILL.libgroup == famille && i.iditem != iditem && i.datpromo1 < DateTime.Now).OrderByDescending(i => i.ordre1).ToList().GetRange(0, n);
                }
                catch (Exception){
                    listitem = db.ITEM.Where(i => i.SOUSFAMILL.FAMILL.GROUPFAMILL.libgroup == famille && i.iditem != iditem && i.datpromo1 < DateTime.Now).OrderByDescending(i => i.ordre1).ToList();
                }
            }

             return listitem;
        }

        public List<ITEM> EvenementsFuturs(string famille, int n = 0, int iditem = 0)
        {
            List<ITEM>listitem = new List<ITEM>();
            if (n == 0)
            {
                listitem = db.ITEM.Where(i => i.SOUSFAMILL.FAMILL.GROUPFAMILL.libgroup == famille && i.datpromo1 >= DateTime.Now).OrderByDescending(i => i.ordre1).ToList();

            }
            else
            {
                try{
                    listitem = db.ITEM.Where(i => i.SOUSFAMILL.FAMILL.GROUPFAMILL.libgroup == famille && i.iditem != iditem && i.datpromo1 >= DateTime.Now).OrderByDescending(i => i.ordre1).ToList().GetRange(0, n);
                }
                catch (Exception){
                    listitem = db.ITEM.Where(i => i.SOUSFAMILL.FAMILL.GROUPFAMILL.libgroup == famille && i.iditem != iditem && i.datpromo1 > DateTime.Now).OrderByDescending(i => i.ordre1).ToList();
                }
            }

            return listitem;
        }
       
        public List<ITEM> promotions()
        {
            List<ITEM> listItem = db.ITEM.Where(i => i.tauxremiz != 0).Take(3).OrderByDescending(i => i.iditem).ToList();
            if(listItem ==null)
               listItem=db.ITEM.Take(3).OrderByDescending(i => i.iditem).ToList();
            return listItem;
        }
        public ITEM getItem(int iditem)
        {
            ITEM it = db.ITEM.Find(iditem);
            return it;
        }
        public List<ITEM> listeArticle2()
        {
            List<ITEM> listItem = new List<ITEM>();
            listItem = db.ITEM.Where(i => i.category != 0).OrderByDescending(i => i.iditem).ToList();
            
            return listItem;
        }
        public List<ITEM> listeArticle3()
        {
            List<ITEM> listItem = new List<ITEM>();
            listItem = db.ITEM.Where(i => i.category != 0).ToList();

            return listItem;
        }
        public List<ITEM> listeArticle4(int category)
        {
            List<ITEM> listItem = db.ITEM.Where(i => i.category == category).ToList();
            return listItem;
        }
        public ITEM detailsArticle(int id)
        {
            ITEM it = db.ITEM.Where(i => i.iditem == id).FirstOrDefault();            
            return it;
        }
        public List<ITEM> autresArticle(int idarticle, long ? idcategorie,int nb)
        {
            List<ITEM> listItems = new List<ITEM>();
 
            try
            {
                listItems = db.ITEM.Where(i => i.category == idcategorie)
                                   .Where(i => i.iditem != idarticle)
                                   .Take(nb)
                                   .OrderByDescending(i => i.iditem)
                                   .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return listItems;
        }
        public string updateArticle(ITEM it)
        {
            string r;
            ITEM itm = db.ITEM.Find(it.iditem);
            itm.designation = it.designation;
            itm.designdetails = it.designdetails;
            itm.designdetails2 = it.designdetails2;
            itm.detailslivraison = it.detailslivraison;
            itm.category = it.category;
            itm.prixitem = it.prixitem;
            itm.ordre1 = it.ordre1;
            itm.prix2 = it.prix2;
            itm.tauxremiz = it.tauxremiz;
            itm.datpromo1 = it.datpromo1;
            if(itm.datpromo1 == null)
               itm.datpromo1 = DateTime.Now;

            try
            {
                db.Entry(itm).State = EntityState.Modified;
                r = db.SaveChanges().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                r = ex.ToString();
            }
            return r;
        }
        //delete article
        public string deleteArticle(int id)
        {
            string r;
            
            try
            {

                ITEM it = db.ITEM.Find(id);
                db.ITEM.Remove(it);
                db.SaveChanges();
                r = "1";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                r = ex.ToString();
            }
            return r;
        }
        //update image
        public string updateImage(int id, int nim, string imagePath)
        {
            string r;
            try
            {
                ITEM it = db.ITEM.Find(id);
                if (nim == 1)
                {
                    it.imagpath1 = imagePath;
                }
                else if (nim == 2)
                {
                    it.imagpath2 = imagePath;
                }
                else if(nim == 3)
                {
                    it.imagpath3 = imagePath;
                }
                else if(nim == 4)
                {
                    it.imagpath4 = imagePath;
                }
                else if (nim == 5)
                {
                    it.imagpath5 = imagePath;
                }
                else if(nim == 6)
                {
                    it.imagpath6 = imagePath;
                }
                else if(nim == 7)
                {
                    it.imagpath7 = imagePath;
                }
                else
                {
                    it.imagpath8 = imagePath;
                }

                db.Entry(it).State = EntityState.Modified;
                db.SaveChanges().ToString();
                r = "1";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                r = ex.ToString();
            }
            return r;
        }

        public List<string> listeImagesImtem(ITEM it)
        {
            List<string> listeImage = new List<string>();
            if (it.imagpath1 != null)
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
            return listeImage;
        }
        public List<ITEM> rechercheArticle(string texte)
        {
            List<ITEM> listItems = new List<ITEM>();
            listItems=db.ITEM.Where(i => i.designation.Contains(texte))
                             .OrderByDescending(i => i.iditem)
                             .ToList();
            return listItems;
        }

        public List<ITEM> rechercheArticlePrix(string prix1, string prix2)
        {

            List<ITEM> listItems = new List<ITEM>();
            float p1 = float.Parse(prix1);
            float p2 = float.Parse(prix2);
            try
            {
                listItems = db.ITEM.Where(i => i.prixitem >=p1 && i.prixitem <= p2)
                                  .OrderByDescending(i => i.iditem)
                                  .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return listItems;
        }

        public List<ITEM> rechercheCategorie(int idcategorie)
        {
            List<ITEM> listItem = db.ITEM.Where(i => i.category == idcategorie)
                                         .OrderByDescending(i => i.iditem)
                                         .ToList();
            return listItem;
        }

        public List<ITEM> rechercheFamille(int idfamille)
        {
            List<ITEM> listItem = new List<ITEM>();
            List<SOUSFAMILL> list = db.SOUSFAMILL.Where(sf => sf.typsousfamill == idfamille).ToList();
            foreach(SOUSFAMILL sf in list)
            {
                List<ITEM> listIt = db.ITEM.Where(i => i.category == sf.idsousfamill)
                                         .OrderByDescending(i => i.iditem)
                                         .ToList();
                if (listIt.Any())
                {
                    listItem.AddRange(listIt);
                }
            }
            
            return listItem;
        }

        public PARAMS GetMenuDuJour()
        {
            MenuDuJourViewModel menudujour = new MenuDuJourViewModel();
            DateTime dateactu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            PARAMS pr = db.PARAMS.Where(p => p.libp.Equals("menu") && p.p41 == dateactu ).ToList().LastOrDefault();
            if(pr == null){
                pr = db.PARAMS.Where(p => p.libp.Equals("menu")).ToList().LastOrDefault();
            }
            return pr;
        }
    }
