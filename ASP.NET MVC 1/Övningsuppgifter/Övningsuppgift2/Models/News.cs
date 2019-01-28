using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Övningsuppgift2.Models
{
    public class News
    {
        public static int ID = 0;
        private int _id = 0;
        public string Headline { get; set; }
        public string NewsText { get; set; }

        public int Id
        {
            get { return _id; }
        }

        public News(string headline, string newstext)
        {
            ID++;
            this._id = ID;
            this.Headline = headline;
            this.NewsText = newstext;
        }
    }
}
