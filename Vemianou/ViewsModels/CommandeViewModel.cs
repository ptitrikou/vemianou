using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vemianou.ViewsModels
{
    public class CommandeViewModel
    {
        public CommandeViewModel()
        {
            items = new List<ItemViewModel>();
        }
        public string numeroCommande { get; set; }
        public string montant { get; set; }
        public List<ItemViewModel> items { get; set; }
        public string date { get; set; }
    }
}