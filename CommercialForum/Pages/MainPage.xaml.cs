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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommercialForum.Models;
using CommercialForum.Windows;

namespace CommercialForum.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            BasicComponentsController();
            BasicRoleController();
        }

        //Загрузка основных положений страницы
        private void BasicComponentsController()
        {
            /*NavigationManager.MainPageFrame = MainPage_localFrame;*/
            MainPage_localFrame.Content = new PlugPage();

            BalanceFrame.Content = new BalancePages.BalanceStatusPage();
        }

        private bool isMenuToggle;
        private void menuBut_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubAnime = new DoubleAnimation();
            if (!isMenuToggle)
            {
                doubAnime.From = 0;
                doubAnime.To = 500;
                doubAnime.Duration = TimeSpan.FromSeconds(1);
                MenuBoard.BeginAnimation(WidthProperty, doubAnime);
                isMenuToggle = true;
            }
            else
            {
                doubAnime.From = 500;
                doubAnime.To = 0;
                doubAnime.Duration = TimeSpan.FromSeconds(1);
                MenuBoard.BeginAnimation(WidthProperty, doubAnime);
                isMenuToggle = false;
            }
        }

        //Проверка на роли и сокрытие запретных кнопок
        private void BasicRoleController()
        {
            switch (App.RoleId)
            {
                case 1:       //Клиент
                    TraderListBut.Visibility = Visibility.Collapsed;
                    UserListBut.Visibility = Visibility.Collapsed;
                    break;
                case 2:       //Торговец                    
                    UserListBut.Visibility = Visibility.Collapsed;
                    break;
                case 3:       //Сотрудник       
                    TraderListBut.Visibility = Visibility.Collapsed;
                    break;
                case 4:       //Администратор
                    break;
            }
        }

        private void MyProfileBut_Click(object sender, RoutedEventArgs e)
        {
            MainPage_localFrame.Content = new MyProfilePage();
        }

        private void BasketBut_Click(object sender, RoutedEventArgs e)
        {
            if (!App.isBasketOpened)
            {
                BasketWindow basketWindow = new BasketWindow();
                basketWindow.Owner = App.Current.MainWindow;
                basketWindow.Show();
            }
        }

        private void PurchaseHistoryBut_Click(object sender, RoutedEventArgs e)
        {
            MainPage_localFrame.Content = new PurchaseHistoryPage();
        }

        private void TraderListBut_Click(object sender, RoutedEventArgs e)
        {
            MainPage_localFrame.Content = new ProductPages.ProductListPage();
        }

        private void BalanceBut_Click(object sender, RoutedEventArgs e)
        {
            MainPage_localFrame.Content = new BalancePages.BalancePage();
        }

        private void LeaveBut_Click(object sender, RoutedEventArgs e)
        {
            App.AuthId = 0;
            App.RoleId = 0;
            NavigationService.Navigate(new AuthPage());
        }

        private void TradingPlatformBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainPageFrame.Content = new TradingPlatformPage();
        }

        private void UserListBut_Click(object sender, RoutedEventArgs e)
        {
            MainPage_localFrame.Content = new StaffPages.MainStaffPage();
        }
    }
}
