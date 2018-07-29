using System;
using System.Collections.Generic;
using Core.Models;

namespace Core.Helpers
{
    public class ItemHelper
    {
        private List<Item> _itens;

        private static ItemHelper _instance;
        public static ItemHelper Instance => _instance ?? (_instance = new ItemHelper());

        private ItemHelper()
        {
            _itens = new List<Item>
            {
                new Item() { Name = "Item 1", Image = "icon.png" },
                new Item() { Name = "Item 2", Image = "icon.png" },
                new Item() { Name = "Item 3", Image = "icon.png" },
                new Item() { Name = "Item 4", Image = "icon.png" },
                new Item() { Name = "Item 5", Image = "icon.png" }
            };
        }

        public List<Item> GetItems()
        {
            return _itens;
        }
    }
}
