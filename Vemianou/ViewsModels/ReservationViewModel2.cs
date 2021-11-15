using Vemianou.Models;
using System;

namespace Cristal.ViewsModels
{
    public class ReservationViewModel2
    {
        public string noms { get; set; }
        public string email { get; set; }
        public string contact {get;set;}
        public string adresse { get; set; }
        public DateTime datedebut {get;set;}
        public string datereservation { get; set; }
        public int njour { get; set; }
        public int nper { get; set; }
        public DateTime datefin { get; set; }
        public ITEM item { get; set; }
        public string codereservation { get; set; }
        public string demandespeciale { get; set; }
        public int etatreser { get; set; }
    }
}