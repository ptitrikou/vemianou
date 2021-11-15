using System;
using Vemianou.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

    public class NouveauteService
    {
        ModelCristal db = new ModelCristal();
        public List<ITEM> listeNouveaute()
        {
            List<ITEM> listItem = new List<ITEM>();
            listItem = db.ITEM.Where(i => i.typeitem == 0).ToList();
            
            return listItem;
        }
        public string addNouveaute(int id)
        {
            string r = "";
            try
            {
                ITEM it = db.ITEM.Find(id);
                it.typeitem = 0;
                db.Entry(it).State = EntityState.Modified;
                r = db.SaveChanges().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                r = ex.ToString();
            }

            return r;
        }

        //delete nouveaute
        public string deleteNouveaute(int id)
        {
            string r = "";
            try
            {
                ITEM it = db.ITEM.Find(id);
                it.typeitem=1;
                db.Entry(it).State = EntityState.Modified;
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
