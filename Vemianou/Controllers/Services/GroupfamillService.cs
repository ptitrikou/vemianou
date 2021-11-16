using Vemianou.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

    public class GroupfamillService
    {
        ModelVemianou db = new ModelVemianou();

        public List<GROUPFAMILL> listeGroupFamill()
        {
            List<GROUPFAMILL> listGroupfamill = new List<GROUPFAMILL>();

            try
            {
                listGroupfamill = db.GROUPFAMILL.ToList();
               
            }
            catch (Exception)
            {
               
            }

            return listGroupfamill;
        }

        //delete categorie
        public int deleteGroupFamill(int id)
        {
            int r = 0;
            List<FAMILL> listFamill = db.FAMILL.Where(fm => fm.typfamill == id).ToList();
            foreach(FAMILL f in listFamill)
            {
                List<SOUSFAMILL> listSousFamill = db.SOUSFAMILL.Where(sfm => sfm.typsousfamill ==f.idfamill).ToList();
                foreach (SOUSFAMILL s in listSousFamill)
                {
                    List<ITEM> listItems = db.ITEM.Where(i => i.category == s.idsousfamill).ToList();
                    db.ITEM.RemoveRange(listItems);
                    db.SOUSFAMILL.Remove(s);
                }
                db.FAMILL.Remove(f);
            }
            
            GROUPFAMILL gf = db.GROUPFAMILL.Find(id);
            db.GROUPFAMILL.Remove(gf);
            r = db.SaveChanges();
            return r;
        }

        //add categorie
        public int addGroupFamill(GROUPFAMILL f)
        {
            int r = 0;

            try
            {
                db.GROUPFAMILL.Add(f);
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return r;

        }

        //add categorie


        public int updateGroupFamill(GROUPFAMILL f)
        {
            int r = 0;
            try
            {
                GROUPFAMILL fm = db.GROUPFAMILL.Find(f.idgroupfamill);
                fm.libgroup = f.libgroup;
                db.Entry(fm).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return r;

        }
        public GROUPFAMILL getFamill(long id)
        {
            GROUPFAMILL fm = db.GROUPFAMILL.Find(id);
            return fm;
        }

        public string updateImage(int id, string imagePath)
        {
            string r = "";
            try
            {
                GROUPFAMILL gf = db.GROUPFAMILL.Find(id);
                gf.imaggroup = imagePath;
                db.Entry(gf).State = EntityState.Modified;
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
