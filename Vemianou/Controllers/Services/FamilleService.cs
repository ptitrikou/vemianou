
using Vemianou.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

    public class FamilleService
    {
        ModelCristal db = new ModelCristal();

        public List<FAMILL> listeFamille()
        {
            String ms = "";
            List<FAMILL> listCategorie = new List<FAMILL>();

            try
            {
                listCategorie = db.FAMILL.ToList();
                ms = listCategorie.Count.ToString();
            }
            catch (Exception )
            {
                ms = listCategorie.Count.ToString();
            }

            return listCategorie;
        }
        
        //delete categorie
        public int deleteFamill(int id)
        {
            int r=0;
            List<SOUSFAMILL> listSousFamill = db.SOUSFAMILL.Where(sfm => sfm.idfamill == id).ToList();
            try{
                foreach(SOUSFAMILL s in listSousFamill)
                {
                    List<ITEM> listItems = db.ITEM.Where(i => i.category == s.idsousfamill).ToList();
                    db.ITEM.RemoveRange(listItems);
                    db.SOUSFAMILL.Remove(s);
                }
                //db.SaveChanges();
                FAMILL f = db.FAMILL.Find(id);
                db.FAMILL.Remove(f);
                r = db.SaveChanges();
            }catch(Exception e)
            {
               r = 0;
            }
            return r;
        }

        //add categorie
        public int addFamill(FAMILL f)
        {
            int r = 0;

            try
            {
                db.FAMILL.Add(f);
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return r;

        }

        //add categorie


        public int updateFamill(FAMILL f)
        {
            int r = 0;
            try
            {
                FAMILL fm = db.FAMILL.Find(f.idfamill);
                fm.libfamill = f.libfamill;
                fm.idgroupfamill = f.idgroupfamill;
                db.Entry(fm).State = EntityState.Modified;
                r = db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return r;

        }
        public FAMILL getFamill(long id)
        {
            FAMILL fm = db.FAMILL.Find(id);
            return fm;
        }

        public string updateImage(int id, string imagePath)
        {
            string r = "";
            try
            {
                FAMILL sf = db.FAMILL.Find(id);
                sf.imgfamill1 = imagePath;
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

