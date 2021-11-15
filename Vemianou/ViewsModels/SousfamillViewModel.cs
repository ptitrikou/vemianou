using Vemianou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vemianou.ViewsModels
{
    public class SousfamillViewModel
    {
        public SousfamillViewModel()
        {

        }
        public SousfamillViewModel(int idsousfamill,string libsousfamill,int typsousfamill,List<ItemViewModel>items)
        {
            this.items = new List<ItemViewModel>();
            this.items = items;
            this.idsousfamill = idsousfamill;
            this.libsousfamill = libsousfamill;
            this.typsousfamill = typsousfamill;

        }
        public int idsousfamill { get; set; }

        public string libsousfamill { get; set; }

        public int typsousfamill { get; set; }
        public int nitems { get; set; }
        public List<ItemViewModel>items { get; set; }
    }
}