using System;
using Vemianou.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


    public class CommandeService
    {
        ModelVemianou db = new ModelVemianou();
        public List<VENTE> listeCommande()
        {
            List<VENTE> listeCommandes = db.VENTE.OrderByDescending(v => v.idvente).ToList();

            return listeCommandes;
        }
        public List<VENTE> nouvellesCommande()
        {
            List<VENTE> listeCommandes = db.VENTE.Where(vn => vn.idcommand == 0 && vn.etatvente == 0).OrderByDescending(vn => vn.idvente).ToList();

            return listeCommandes;
        }
        public int nbreCommandEncours()
        {
            int n = 0;
            n = db.VENTE.Where(vn => vn.idcommand == 0 && vn.etatvente == 0 ).ToList().Count();
            return n;
        }
        public int nbreCommandLivre()
        {
            int n = 0;
            n = db.VENTE.Where(vn => vn.idcommand == 0 && vn.etatvente == 1).ToList().Count();
            return n;
        }

        public VENTE detailsCommande(int idvente)
        {
            VENTE vente = db.VENTE.Find(idvente);
            return vente;
        }
        public List<VENTE> commandesClient(long userId)
        {
            List<VENTE> commandes = db.VENTE.Where(vn => vn.iduser == userId).OrderByDescending(vn => vn.idvente).ToList();
            return commandes;
        }
        public List<ITEM> topVentes(int n)
        {
            List<ITEM> topventes = new List<ITEM>();

            topventes = db.ITEM.OrderByDescending(i => i.ordre1).ToList();
            try
            {
                topventes = topventes.GetRange(0, n);
            }
            catch
            {

            }

            return topventes;
        }

        public void updateCommande(long idcommande)
        {
            VENTE vn = db.VENTE.Find(idcommande);
            vn.etatvente = 1;
            db.Entry(vn).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
