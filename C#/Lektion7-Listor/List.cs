using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lektion7_Listor
{

    class ListItem
    {
        public object data;
        public ListItem next;
    }
    class List
    {
        private ListItem first = null;

        public void Add(object item)
        {
            ListItem listItem = new ListItem();
            listItem.data = item;
            listItem.next = first;

            this.first = listItem;
        }
    }
}
