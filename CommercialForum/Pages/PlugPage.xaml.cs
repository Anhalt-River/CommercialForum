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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommercialForum.Pages
{
    /// <summary>
    /// Логика взаимодействия для PlugPage.xaml
    /// </summary>
    public partial class PlugPage : Page
    {
        public PlugPage()
        {
            InitializeComponent();
        }

        private void ToPlatformBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainPageFrame.Navigate(new TradingPlatformPage());
        }
    }
}
