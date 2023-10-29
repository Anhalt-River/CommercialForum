using CommercialForum.AppData;
using CommercialForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CommercialForum.Windows
{
    /// <summary>
    /// Логика взаимодействия для CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        public CategoryWindow(int productId)
        {
            InitializeComponent();
            BasicComponentsController();
            ProductController(productId);
        }

        public CategoryWindow()
        {
            InitializeComponent();
            BasicComponentsController();
            TranzitController();
        }

        private void ProductController(int productId)
        {
            CategoryFrame.Content = new Pages.CategoryPage(productId);
            App.isCategoriesTransit = false;
        }

        private void TranzitController()
        {
            CategoryFrame.Content = new Pages.CategoryPage();
            App.isCategoriesTransit = true;
        }

        private void BasicComponentsController()
        {
            App.isCategoriesOpened = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.MainWindow.Activate();
            App.isCategoriesOpened = false;
        }
    }
}
