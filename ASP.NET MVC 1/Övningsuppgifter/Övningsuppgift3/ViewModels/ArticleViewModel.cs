using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Övningsuppgift3.Models;

namespace Övningsuppgift3.ViewModels
{
    public class ArticleViewModel
    {
        public List<Categories> Categories { get; set; }
        public List<Articles> SelectedArticles { get; set; }

        public ArticleViewModel()
        {
            this.SelectedArticles = new List<Articles>();
            this.Categories = new List<Categories>();
        }
    }
}
