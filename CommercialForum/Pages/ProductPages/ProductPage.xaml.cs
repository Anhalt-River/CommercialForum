using CommercialForum.AppData;
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

namespace CommercialForum.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private int taked_productId = -1;
        public ProductPage(int productId)
        {
            InitializeComponent();
            BasicComponentController(productId);
        }

        private void BasicComponentController(int productId)
        {
            taked_productId = productId;
            var search_product = App.Connection.Products.Where(u => u.Id_Product == taked_productId).FirstOrDefault();
            if (search_product != null)
            {
                Product_NameBlock.Text = search_product.Name;
                Product_CostBlock.Text = search_product.Cost.ToString();
                Product_DescBox.Text = search_product.Description;

                if (search_product.Image != null)
                {
                    MemoryStream memoryStream = new MemoryStream(search_product.Image);
                    BitmapImage new_Bitmap = new BitmapImage();
                    new_Bitmap.BeginInit();
                    new_Bitmap.StreamSource = memoryStream;
                    new_Bitmap.EndInit();
                    Product_Image.Source = new_Bitmap;
                }
                else
                {
                    Product_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Materials/Images/image_fail.png"));
                }

                if (search_product.IsAvailable == "No")
                {
                    AvailableCheckBox.IsChecked = !AvailableCheckBox.IsChecked;
                }
            }
        }

        private void OrderBut_Click(object sender, RoutedEventArgs e)
        {
            var search_basket = App.Connection.Basket.Where(u => u.Id_Client == App.AuthId && u.Status == "Processing").FirstOrDefault();
            if (search_basket == null)
            {
                Basket new_basket = new Basket()
                {
                    Id_Client = App.AuthId,
                    Status = "Processing"
                };
                App.Connection.Basket.Add(new_basket);
                App.Connection.SaveChanges();

                BasketList basketList = new BasketList()
                {
                    Id_Basket = new_basket.Id_Basket,
                    Id_Product = taked_productId,
                };
                App.Connection.BasketList.Add(basketList);
                App.Connection.SaveChanges();
            }
            else
            {
                var search_productInside = App.Connection.BasketList.Where(u => u.Id_Product == taked_productId && u.Id_Basket == search_basket.Id_Basket).FirstOrDefault();
                if (search_productInside == null)
                {
                    BasketList basketList = new BasketList()
                    {
                        Id_Basket = search_basket.Id_Basket,
                        Id_Product = taked_productId,
                        Count = 1
                    };
                    App.Connection.BasketList.Add(basketList);
                }
                else
                {
                    search_productInside.Count++;
                }
                App.Connection.SaveChanges();
            }
        }

        private void DeOrderBut_Click(object sender, RoutedEventArgs e)
        {
            var search_basket = App.Connection.Basket.Where(u => u.Id_Client == App.AuthId && u.Status == "Processing").FirstOrDefault();
            if (search_basket == null)
            {
                MessageBox.Show("У вас нет даже корзины, какой товар?", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var search_productInside = App.Connection.BasketList.Where(u=> u.Id_Product == taked_productId && u.Id_Basket == search_basket.Id_Basket).FirstOrDefault();
                if (search_productInside == null)
                {
                    MessageBox.Show("Данного товара нет в вашей корзине", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    App.Connection.BasketList.Remove(search_productInside);
                    App.Connection.SaveChanges();
                }
            }
        }
    }
}
