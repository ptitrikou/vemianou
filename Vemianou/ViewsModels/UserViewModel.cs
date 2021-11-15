using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vemianou.ViewsModels
{
    public class UserViewModel
    {
        public string nomprenoms { get; set; }
        public string email { get; set; }
        public string contact { get; set; }
        public string adresse { get; set; }
        public int iduser { get; set; }
    }
}