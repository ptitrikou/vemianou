using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cristal.ViewsModels
{
    public class MenuDuJourViewModel
    {
        public int iditem { get; set; }
        public string designation { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public string prix { get; set; }
        public string dateenr { get; set; }
        public string lienimage { get; set; }
        public int stat { get; set; }
    }
}