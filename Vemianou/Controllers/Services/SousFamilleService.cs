using Vemianou.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


    public class SousFamilleService
    {
         ModelCristal db = new ModelCristal();

        public List<SOUSFAMILL> listeCategorie(string famille)
        {
            string ms="";
            List<SOUSFAMILL> listCategorie = new List<SOUSFAMILL>();
            
            try
            {
                if(famille != null){
                    listCategorie = db.SOUSFAMILL.Where(s => s.FAMILL.GROUPFAMILL.libgroup == famille).ToList();
                    ms = listCategorie.Count.ToString();
                }
                else{
                    listCategorie = db.SOUSFAMILL.ToList();
                    ms = listCategorie.Count.ToString();
                }
                
            }
            catch (Exception )
            {
                ms = listCategorie.Count.ToString();
            }
           
            return listCategorie;
        }
        public List<SOUSFAMILL> listeCategorie2()
        {
            List<SOUSFAMILL> listCategorie = new List<SOUSFAMILL>();
            List<int>  iditems = db.ITEM.Select(i => i.category).ToList();
            listCategorie = db.SOUSFAMILL.Where(sf => iditems.Contains(sf.idsousfamill)).Take(6).ToList();
            return listCategorie;
        }
        
        //delete categorie
        public int deleteCategorie(int id)
        {
            int r= 0 ;
            List<ITEM> listItems = db.ITEM.Where(i => i.category==id).ToList();
            SOUSFAMILL sf = db.SOUSFAMILL.Find(id);
            try{
                db.ITEM.RemoveRange(listItems);
                db.SOUSFAMILL.Remove(sf);
                r = db.SaveChanges();
            }catch(Exception e){
                r = 0;
            }
            
            return r;

        }

        //add categorie
        public int addCategorie(SOUSFAMILL sf)
        {
            int r = 0;
            
            try
            {
                db.SOUSFAMILL.Add(sf);
                r=db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return r;

        }

        //add categorie

    
        public int updateCategorie(SOUSFAMILL sf)
        {
            int r = 0;
            try
            {
                SOUSFAMILL sfm = db.SOUSFAMILL.Find(sf.idsousfamill);
                sfm.libsousfamill = sf.libsousfamill;
                sfm.typsousfamill = sf.typsousfamill;
                db.Entry(sfm).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return r;

        }
        public SOUSFAMILL getSousFamill(long id)
        {
            SOUSFAMILL sf = db.SOUSFAMILL.Find(id);
            return sf;
        }
        public string updateImage(int id, string imagePath)
        {
            string r = "";
            try
            {
                SOUSFAMILL sf = db.SOUSFAMILL.Find(id);
                sf.imgsousfamill1 = imagePath;
                db.Entry(sf).State = EntityState.Modified;
                r = db.SaveChanges().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                r = ex.ToString();
            }
            return r;
        }

    }
    
