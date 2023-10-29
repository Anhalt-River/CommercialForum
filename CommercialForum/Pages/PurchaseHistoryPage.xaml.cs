using CommercialForum.Models;
using CommercialForum.Windows;
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
    /// Логика взаимодействия для PurchaseHistoryPage.xaml
    /// </summary>
    public partial class PurchaseHistoryPage : Page
    {
        public PurchaseHistoryPage()
        {
            InitializeComponent();
            BasicComponentController();
        }

        private List<Order> all_ordersList;
        private void BasicComponentController()
        {
            all_ordersList = new List<Order>();
            var all_baskets = App.Connection.Basket.Where(u=> u.Id_Client == App.AuthId).ToList();
            foreach (var basket in all_baskets)
            {
                var search_order = App.Connection.Orders.Where(u=> u.Id_Basket == basket.Id_Basket).FirstOrDefault();
                Order order = new Order()
                {
                    IdOrder = search_order.Id_Order,
                    TotalCost = (float)search_order.TotalAmount,
                    IsConcluded = search_order.IsConcluded,
                    IdBasket = (int)search_order.Id_Basket
                };

                if (search_order.Date == null)
                {
                    order.Date = "Не оплачен";
                }
                else
                {
                    order.Date = search_order.Date.ToString();
                }

                all_ordersList.Add(order);
            }

            ordersList.ItemsSource = all_ordersList;
        }

        private void BreakOrderBut_Click(object sender, RoutedEventArgs e)
        {
            if (ordersList.SelectedItem != null)
            {
                var selected_order = ordersList.SelectedItem as Order;
                if (selected_order.IsConcluded == "No") 
                {
                    var search_order = App.Connection.Orders.Where(u=> u.Id_Order == selected_order.IdOrder).FirstOrDefault();
                    var search_basket = App.Connection.Basket.Where(u => u.Id_Basket == search_order.Id_Basket).FirstOrDefault();

                    App.Connection.Orders.Remove(search_order);
                    App.Connection.Basket.Remove(search_basket);

                    App.Connection.SaveChanges();

                    NavigationService.Refresh();
                }
                else
                {
                    MessageBox.Show("Вы не можете отменить заказ, который уже был оплачен", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void HistoryBut_Click(object sender, RoutedEventArgs e)
        {
            if (ordersList.SelectedItem != null)
            {
                var selected_order = ordersList.SelectedItem as Order;
                if (!App.isProductsOpened)
                {
                    BasketWindow basketWindow = new BasketWindow(selected_order.IdBasket);
                    basketWindow.Owner = App.Current.MainWindow;
                    basketWindow.Show();
                }
            }
        }

        private void PaymentBut_Click(object sender, RoutedEventArgs e)
        {
            if (ordersList.SelectedItem != null)
            {
                var selected_order = ordersList.SelectedItem as Order;

                var search_user = App.Connection.Users.Where(u=> u.Id_User == App.AuthId).FirstOrDefault();
                if (search_user.Balance < selected_order.TotalCost)
                {
                    MessageBox.Show("На вашем балансе недостаточно средств для оплаты!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (selected_order.IsConcluded == "No")
                {
                    var search_order = App.Connection.Orders.Where(u => u.Id_Order == selected_order.IdOrder).FirstOrDefault();
                    var search_basket = App.Connection.Basket.Where(u => u.Id_Basket == search_order.Id_Basket).FirstOrDefault();

                    search_user.Balance -= selected_order.TotalCost;
                    search_order.Date = DateTime.Now;
                    search_order.IsConcluded = "Yes";
                    search_basket.Status = "Paid";

                    App.Connection.SaveChanges();

                    NavigationService.Refresh();
                }
                else
                {
                    MessageBox.Show("Вы не можете оплатить заказ, который уже был оплачен...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
