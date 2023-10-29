using CommercialForum.AppData;
using CommercialForum.Models;
using CommercialForum.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CommercialForum.Pages.BasketPages
{
    /// <summary>
    /// Логика взаимодействия для BasketListPage.xaml
    /// </summary>
    public partial class BasketListPage : Page
    {
        public BasketListPage()
        {
            InitializeComponent();
            BasicComponentController();
        }

        private int taked_BasketId;
        private void BasicComponentController()
        {
            var search_basket = App.Connection.Basket.Where(u => u.Id_Client == App.AuthId && u.Status == "Processing").FirstOrDefault();
            if (search_basket == null)
            {
                var result = MessageBox.Show("Желаете начать собирать корзину?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Basket new_basket = new Basket()
                    {
                        Id_Client = App.AuthId,
                        Status = "Processing"
                    };
                    App.Connection.Basket.Add(new_basket);
                    App.Connection.SaveChanges();

                    taked_BasketId = new_basket.Id_Basket;
                }
                else
                {
                    var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
                    App.Current.MainWindow.Activate();
                    window.Close();
                }
            }
            else
            {
                taked_BasketId = search_basket.Id_Basket;
                BasicProductsLoader();
            }
        }

        private List<Product> all_productsList;
        private void BasicProductsLoader()
        {
            all_productsList = new List<Product>();
            var all_rowProducts = App.Connection.BasketList.Where(u => u.Id_Basket == taked_BasketId).ToList();
            foreach (var rowProduct in all_rowProducts)
            {
                var product = App.Connection.Products.Where(u=> u.Id_Product == rowProduct.Id_Product).FirstOrDefault();
                Product take_product = new Product()
                {
                    IdProduct = product.Id_Product,
                    Name = product.Name,
                    Cost = Convert.ToDouble(product.Cost),
                    IsAvailable = product.IsAvailable,

                };

                if (product.Image != null)
                {
                    MemoryStream memoryStream = new MemoryStream(product.Image);
                    BitmapImage new_Bitmap = new BitmapImage();
                    new_Bitmap.BeginInit();
                    new_Bitmap.StreamSource = memoryStream;
                    new_Bitmap.EndInit();
                    take_product.Image = new_Bitmap;
                }
                else
                {
                    take_product.Image = new BitmapImage(new Uri("pack://application:,,,/Materials/Images/image_fail.png"));
                }

                all_productsList.Add(take_product);
            }

            productsList.ItemsSource = all_productsList;
        }

        private void ClearCartBut_Click(object sender, RoutedEventArgs e)
        {
            if (!isFreeToEdit)
            {
                MessageBox.Show("Оплачиваемую или оплаченную корзину нельзя отредактировать!", "Error", MessageBoxButton.OK, MessageBoxImage.Question);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите полностью очистить собранную корзину?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var all_basketProducts = App.Connection.BasketList.Where(u => u.Id_Basket == taked_BasketId).ToList();
                foreach (var basketProduct in all_basketProducts)
                {
                    App.Connection.BasketList.Remove(basketProduct);
                }
                App.Connection.SaveChanges();
            }
        }

        private void RemoveBut_Click(object sender, RoutedEventArgs e)
        {
            if (!isFreeToEdit)
            {
                MessageBox.Show("Оплачиваемую или оплаченную корзину нельзя отредактировать!", "Error", MessageBoxButton.OK, MessageBoxImage.Question);
                return;
            }

            if (productsList.SelectedItem != null)
            {
                var result = MessageBox.Show("Вы уверены, что хотите убрать этот товар из корзины?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var search_product = productsList.SelectedItem as Product;
                    var basketProduct = App.Connection.BasketList.Where(u => u.Id_Product == search_product.IdProduct).FirstOrDefault();
                    App.Connection.BasketList.Remove(basketProduct);
                    App.Connection.SaveChanges();
                }
            }
        }

        private void LearnMoreBut_Click(object sender, RoutedEventArgs e)
        {
            if (productsList.SelectedItem != null)
            {
                if (!App.isProductsOpened)
                {
                    var item = productsList.SelectedItem as Product;
                    ProductWindow productWindow = new ProductWindow(item.IdProduct);
                    productWindow.Owner = App.Current.MainWindow;
                    productWindow.Show();
                }
            }
        }

        private void PaymentBut_Click(object sender, RoutedEventArgs e)
        {
            if (all_productsList.Count == 0)
            {
                MessageBox.Show("В вашей корзине нет товаров, чтобы их приобретать!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var search_basket = App.Connection.Basket.Where(u => u.Id_Basket == taked_BasketId).FirstOrDefault();
                search_basket.Status = "Payment";
                search_basket.LastCollectDate = DateTime.Now;
                App.Connection.SaveChanges();

                var all_basketProducts = App.Connection.BasketList.Where(u => u.Id_Basket == taked_BasketId).ToList();
                float totalAmount = 0;
                foreach (var basketProduct in all_basketProducts)
                {
                    var product = App.Connection.Products.Where(u=> u.Id_Product == basketProduct.Id_Product).FirstOrDefault();
                    totalAmount += (float)product.Cost * (float)basketProduct.Count;
                }

                Orders new_order = new Orders()
                {
                    Id_Basket = taked_BasketId,
                    TotalAmount = totalAmount,
                    IsConcluded = "No"
                };
                App.Connection.Orders.Add(new_order);
                App.Connection.SaveChanges();
            }
        }

        public BasketListPage(int basketId)
        {
            InitializeComponent();
            BasicComponentController(basketId);
        }

        private bool isFreeToEdit = true;
        private void BasicComponentController(int basketId)
        {
            var search_basket = App.Connection.Basket.Where(u => u.Id_Basket == basketId).FirstOrDefault();
            if (search_basket != null)
            {
                isFreeToEdit = false;
                taked_BasketId = search_basket.Id_Basket;
                BasicProductsLoader();
            }
        }
    }
}
