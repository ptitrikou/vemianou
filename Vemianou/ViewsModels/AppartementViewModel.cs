using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vemianou.ViewsModels
{
    public class AppartementViewModel
    {
        public AppartementViewModel()
        {
            images = new List<String>();
        }
        public int iditem { get; set; }
        public string designation { get; set; }
        public string description { get; set; }
        public List<string> details { get; set; }
        public string prix { get; set; }
        public string prix2 { get; set; }
        public string impath { get; set; }
        public string impath2 { get; set; }
        public string impath3 { get; set; }
        public string datpublish { get; set; }
        public string categorie { get; set; }
        public string devise { get; set; }
        public int nbpersonne { get; set; }
        public List<string> images { get; set; }
    }
}