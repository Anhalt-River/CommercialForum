using CommercialForum.AppData;
using System.Collections.Generic;
using System.Windows;
using CommercialForum.Models;

namespace CommercialForum
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static ComForumEntities Connection = new ComForumEntities();
        public static int AuthId { get; set; } = 0;
        public static int RoleId { get; set; } = 0;
        public static bool isBasketOpened { get; set; } = false;
        public static bool isCategoriesOpened { get; set; } = false;
        public static bool isProductsOpened { get; set; } = false;

        public static List<Basic_Category> CategoryTransit { get; set; } = new List<Basic_Category>();
        public static bool isCategoriesTransit { get; set; } = false;
    }
}
