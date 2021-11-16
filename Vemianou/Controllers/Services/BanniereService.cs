using Vemianou.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

    public class BanniereService
    {
        ModelVemianou db = new ModelVemianou();
        public List<ITEM> listeBanniere()
        {
            List<ITEM> listItem = new List<ITEM>();
            listItem = db.ITEM.Where(i => i.typeitem == -1).ToList();
            
            return listItem;
        }
        public string addBanniere(int id)
        {
            string r = "";
            try
            {
                ITEM it = db.ITEM.Find(id);
                it.typeitem = -1;
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
        public string deleteBanniere(int id)
        {

            string r = "";
            try
            {
                ITEM it = db.ITEM.Find(id);
                it.typeitem = 1;
                db.Entry(it).State = EntityState.Modified;
                r =db.SaveChanges().ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                r = ex.ToString();
            }

            return r;
        }
    }
