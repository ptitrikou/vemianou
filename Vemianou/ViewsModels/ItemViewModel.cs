using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vemianou.ViewsModels
{
    public class ItemViewModel
    {
        public int iditem{ get; set; }
        public string designation { get; set; }
        public string prix { get; set; }
        public string prix2 { get; set; }
        public string details { get; set; }
        public int category { get; set; }
        public int quantite { get; set; }
        public string soustotal { get; set; }
        public string imagepath { get; set; }
        public double tauxremiz { get; set; }
        public string devise { get; set; }
    }
}