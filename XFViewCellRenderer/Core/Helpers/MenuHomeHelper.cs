using System;
using System.Collections.Generic;
using Core.Models;
using Core.Views;

namespace Core.Helpers
{
    public class MenuHomeHelper
    {
        private static List<MenuHome> _menus;

        private static MenuHomeHelper _instance;
        public static MenuHomeHelper Instance => _instance ?? (_instance = new MenuHomeHelper());

        private MenuHomeHelper()
        {
            _menus = new List<MenuHome>
            {
                new MenuHome() { Name = "TextCell", View = typeof(TextCellView) },
                new MenuHome() { Name = "ImageCell", View = typeof(ImageCellView) },
                new MenuHome() { Name = "ViewCell", View = typeof(ViewCellView) },
                new MenuHome() { Name = "Custom ViewCell - SeparatorInset", View = typeof(CustomViewCellView) }
            };
        }

        public List<MenuHome> GetMenus()
        {
            return _menus;
        }
    }
}
