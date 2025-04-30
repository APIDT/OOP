using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace LibraryManagement
{
    public class Department
    {
        public string Name { get; set; }

        private List<LibraryItem> Items { get; } = new List<LibraryItem>();

        public Department(string name)
        {
            Name = name;
        }

        public void AddItem(LibraryItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(LibraryItem item)
        {
            Items.Remove(item);
        }

        public IEnumerable<LibraryItem> GetItems()
        {
            return Items;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}