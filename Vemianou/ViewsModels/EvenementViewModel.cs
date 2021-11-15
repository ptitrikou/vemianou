using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vemianou.ViewsModels
{
    public class EvenementViewModel
    {
        public int iditem { get; set; }
        public string designation { get; set; }
        public string description { get; set; }
        public string details { get; set; }
        public string dateevent { get; set; }
        public string datepublish { get; set; }
        public string etat { get; set; }
        public string imagepath { get; set; }
        public List<String> images { get; set; }
    }
}