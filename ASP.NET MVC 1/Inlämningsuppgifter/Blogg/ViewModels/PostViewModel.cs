using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogg.Models;

namespace Blogg.ViewModels
{

    public class PostViewModel
    {
        public List<BlogPosts> BlogPosts { get; set; }
        public List<Categories> Categories { get; set; }
        public List<BlogPosts> SelectedPost { get; set; }

        public PostViewModel()
        {
            BlogPosts = new List<BlogPosts>();
            Categories = new List<Categories>();
            SelectedPost = new List<BlogPosts>();
        }
    }
}
