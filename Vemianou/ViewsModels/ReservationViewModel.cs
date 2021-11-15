using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vemianou.ViewsModels
{
    public class ReservationViewModel
    {
        public int idappart { get; set; }
        public string impath { get; set; }
        public string designation { get; set; }
        public  string prix { get; set; }
        public string description { get; set; }
        public string categorie { get; set; }
        public string date { get; set; }
        public string codereservation { get; set; }
    }
}