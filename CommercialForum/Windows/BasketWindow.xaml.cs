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
using CommercialForum.Pages.BasketPages;

namespace CommercialForum.Windows
{
    /// <summary>
    /// Логика взаимодействия для BasketWindow.xaml
    /// </summary>
    public partial class BasketWindow : Window
    {
        public BasketWindow()
        {
            InitializeComponent();
            BasicComponentsController();

            BasketFrame.Content = new BasketListPage();
        }

        private void BasicComponentsController()
        {
            App.isBasketOpened = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.MainWindow.Activate();
            App.isBasketOpened = false;
        }

        public BasketWindow(int basketId)
        {
            InitializeComponent();
            BasicComponentsController();
            BasketFrame.Content = new BasketListPage(basketId);
        }
    }
}
