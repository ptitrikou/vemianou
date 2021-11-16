using Vemianou.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


    public class UserService
    {
        ModelVemianou db = new ModelVemianou();
        public USER addUser(USER us)
        {
            USER u=null;            
            try
            {
                string email = db.USER.Where(ur => ur.email == us.email).Select(ur => ur.email).ToList().FirstOrDefault();
                if (email != null)
                {
                    u=null;
                }
                else
                {
                    USER usr = new USER();
                    usr.nomuser = us.nomuser;
                    usr.prenomsuser = us.prenomsuser;
                    usr.nomprenomsuser = us.nomuser + " " + us.prenomsuser;
                    usr.email = us.email;
                    usr.teluser = us.teluser;
                    usr.sexeuser=us.sexeuser;
                    usr.statut=true;
                    usr.statut2=0;
                    usr.statut3=0;
                    usr.passeuser = us.passeuser;
                    usr.adressuser=us.adressuser;
                    usr.coduser="aucun";
                    usr.datecreat=DateTime.Now;
                    usr.details1 = "aucun";
                    usr.details2 = "aucun";
                    usr.details3 = "aucun";
                    usr.idville = 0;
                    usr.idpays = 0;
                    usr.typuser = 0;
                    usr.typuser2 = 0;
                    usr.indicatifuser = "+228";
                    usr.loginuser = us.loginuser;

                    db.USER.Add(usr);
                    db.SaveChanges();
                    u = usr;
                }
                                
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex.ToString());
                
            }

            return u;
        }

        public USER addUser2(string nom,string adresse,string telephone)
        {
            USER usr = new USER();
            usr.nomuser = nom;
            usr.prenomsuser = "";
            usr.nomprenomsuser = "";
            usr.email = "";
            usr.teluser = telephone;
            usr.sexeuser = 0;
            usr.statut = true;
            usr.statut2 = 0;
            usr.statut3 = 0;
            usr.passeuser = "";
            usr.adressuser = adresse;
            usr.coduser = "aucun";
            usr.datecreat = DateTime.Now;
            usr.details1 = "aucun";
            usr.details2 = "aucun";
            usr.details3 = "aucun";
            usr.idville = 0;
            usr.idpays = 0;
            usr.typuser = 0;
            usr.typuser2 = 0;
            usr.indicatifuser = "+228";
            usr.loginuser ="";

            db.USER.Add(usr);
            db.SaveChanges();
            return usr;
        }
        public USER getUser(string username, string password)
        {
            USER us=null;
            //us = db.users.FirstOrDefault(u => u.mailUser == username || u.loginUser == username && u.passUser == password);
            try
            {
                List<USER> listUsers = db.USER.Where(u => u.email == username || u.loginuser == username).ToList();
                us = listUsers.Where(u => u.passeuser == password).FirstOrDefault();
            }
            catch
            {
                us = null;
            }
            
            return us;
        }
        public USER getUser2(string email, string phone)
        {
            USER us = null;
           
            us = db.USER.Where(u => u.email == email && u.teluser ==phone).FirstOrDefault();
           
            return us;
        }
         
       public int deleteAdmin(int idadmin)
        {
            USER us = db.USER.Find(idadmin);
            db.USER.Remove(us);
            db.SaveChanges();
            return 1;
        }
        public USER getUserAdmin()
        {
            USER us = new USER();
            try
            {
                us=db.USER.FirstOrDefault(u => u.typuser == 1);
            }
            catch (Exception)
            {

            }
            return us;
        }
        public int updateUser(USER user)
        {
            int r = 0;
            USER us = db.USER.Find(user.iduser);
            us.nomuser = user.nomuser;
            us.prenomsuser = user.prenomsuser;
            us.nomprenomsuser = user.nomuser + user.prenomsuser ;
            us.email = user.email;
            us.adressuser = user.adressuser;
            us.teluser = user.teluser;
            us.details1 = user.details1;
            us.passeuser = user.passeuser;
            db.Entry(us).State = EntityState.Modified;
            db.SaveChanges();
            r = user.iduser;
            return r;
        }
        public int updateUser2(long userId,string password)
        {
            int r = 0;
            USER us = db.USER.Find(userId);           
            us.passeuser =password;
            db.Entry(us).State = EntityState.Modified;
            r = db.SaveChanges();
            return r;
        }
        public List<USER> listUsers()
        {
            List<USER> listUsers = db.USER.Where(u => u.typuser == 0).ToList();
            return listUsers;
        }
        public USER getUserById(long userId)
        {
            USER us = db.USER.Find(userId);
            return us;
        }
        
    }
