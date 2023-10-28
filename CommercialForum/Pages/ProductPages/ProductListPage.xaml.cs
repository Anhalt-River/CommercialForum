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
using CommercialForum.Models;
using CommercialForum.Windows;

namespace CommercialForum.Pages.ProductPages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
            BasicListController();
        }

        private void BasicListController()
        {
            var all_rowList = App.Connection.Products.Where(u => u.Id_Trader == App.AuthId).ToList();
            List<Product> products = new List<Product>();
            foreach (var product in all_rowList)
            {
                Product new_element = new Product()
                {
                    IdProduct = product.Id_Product,
                    Name = product.Name,
                    Cost = Convert.ToDouble(product.Cost),
                    IsAvailable = product.IsAvailable,
                    DidPut = product.DidPut,
                    IdTrader = Convert.ToInt32(product.Id_Trader)
                };

                if (product.Image != null)
                {
                    MemoryStream memoryStream = new MemoryStream(product.Image);
                    BitmapImage new_Bitmap = new BitmapImage();
                    new_Bitmap.BeginInit();
                    new_Bitmap.StreamSource = memoryStream;
                    new_Bitmap.EndInit();
                    new_element.Image = new_Bitmap;
                }
                else
                {
                    new_element.Image = new BitmapImage(new Uri("pack://application:,,,/Materials/Images/image_fail.png"));
                }

                products.Add(new_element);
            }

            productsList.ItemsSource = products;
        }

        private void OrderBut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LearnMoreBut_Click(object sender, RoutedEventArgs e)
        {
            if (productsList.SelectedItem != null)
            {
                if (!App.isProductsOpened)
                {
                    var product = productsList.SelectedItem as Product;

                    ProductWindow productWindow = new ProductWindow(product.IdProduct);
                    productWindow.Owner = App.Current.MainWindow;
                    productWindow.Show();
                }
            }
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            if (!App.isProductsOpened)
            {
                ProductWindow productWindow = new ProductWindow();
                productWindow.Owner = App.Current.MainWindow;
                productWindow.Show();
            }
        }
    }
}
