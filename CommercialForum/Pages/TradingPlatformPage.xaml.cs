using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using CommercialForum.AppData;
using CommercialForum.Models;
using CommercialForum.Windows;

namespace CommercialForum.Pages
{
    /// <summary>
    /// Логика взаимодействия для TradingPlatformPage.xaml
    /// </summary>
    public partial class TradingPlatformPage : Page
    {
        private List<int> taked_categories = new List<int>();
        
        public TradingPlatformPage()
        {
            InitializeComponent();
            ProductListLoader();
            BasicComponentsController();
        }
        
        private void BasicComponentsController()
        {
        }

        List<Product> all_productsList = new List<Product>();
        private void ProductListLoader()
        {
            var all_rowProducts = App.Connection.Products.Where(u=> u.DidPut == "Yes").ToList();
            foreach (var rowProduct in all_rowProducts)
            {
                Product take_product = new Product()
                {
                    IdProduct = rowProduct.Id_Product,
                    Name = rowProduct.Name,
                    Cost = Convert.ToDouble(rowProduct.Cost),
                    IsAvailable = rowProduct.IsAvailable,

                };

                if (rowProduct.Image != null)
                {
                    MemoryStream memoryStream = new MemoryStream(rowProduct.Image);
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

        private void MainPageBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainPageFrame.Navigate(new MainPage());
        }

        private void CategoryChooseBut_Click(object sender, RoutedEventArgs e)
        {
            if (!App.isCategoriesOpened)
            {
                CategoryWindow categoryWindow = new CategoryWindow();
                categoryWindow.Owner = App.Current.MainWindow;
                categoryWindow.Show();
            }
        }

        private void MoreInfoBut_Click(object sender, RoutedEventArgs e)
        {
            if (!App.isProductsOpened)
            {
                var item = (sender as Button).DataContext as Product;
                ProductWindow productWindow = new ProductWindow(item.IdProduct);
                productWindow.Owner = App.Current.MainWindow;
                productWindow.Show();
            }
        }

        /*private MouseButtonEventArgs test;*/

        private bool isAvailable = true;
        private void AvailableBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AvailabilitySort();
        }

        private void AvailableCheckBox_Click(object sender, RoutedEventArgs e)
        {
            AvailableFilter();
        }

        private int AvailableFilterRegime = 0;
        private void AvailableFilter()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productsList.ItemsSource);

            if (AvailableFilterRegime == 0)
            {
                AvailableFilterRegime += 1;
                view.Filter = i => ((Product)i).IsAvailable == "No";
            }
            else if (AvailableFilterRegime == 1)
            {
                AvailableFilterRegime += 1;
                view.Filter = i => ((Product)i).IsAvailable == "Yes";
            }
            else
            {
                AvailableFilterRegime = 0;
                view.Filter = i => ((Product)i).IsAvailable == "Yes" || ((Product)i).IsAvailable == "No";
            }
            view.Refresh();
        }

        private bool isAvailableSortRegime;
        private void AvailabilitySort()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productsList.ItemsSource);

            view.SortDescriptions.Clear();

            if (isAvailableSortRegime)
            {
                isAvailableSortRegime = false;
                view.SortDescriptions.Add(new SortDescription("IsAvailable", ListSortDirection.Ascending));
            }
            else
            {
                isAvailableSortRegime = true;
                view.SortDescriptions.Add(new SortDescription("IsAvailable", ListSortDirection.Descending));
            }

            view.Refresh();
        }


        private void CostBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CostSort();
        }

        private int isCostRegime;
        private bool isCostSortRegime;
        private void CostSort()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productsList.ItemsSource);

            /*if (isCostRegime == 0)
            {
                isCostRegime += 1;
                view.SortDescriptions.Add(new SortDescription("Cost", ListSortDirection.Ascending));
            }
            else if (isCostRegime == 1)
            {
                isCostRegime += 1;
                view.SortDescriptions.Add(new SortDescription("Cost", ListSortDirection.Descending));
            }
            else if (isCostRegime == 2)
            {
                isCostRegime = 0;
                view.SortDescriptions.Clear();
            }*/

            view.SortDescriptions.Clear();

            if (isCostSortRegime)
            {
                isCostSortRegime = false;
                view.SortDescriptions.Add(new SortDescription("Cost", ListSortDirection.Ascending));
            }
            else
            {
                isCostSortRegime = true;
                view.SortDescriptions.Add(new SortDescription("Cost", ListSortDirection.Descending));
            }
            view.Refresh();
        }

        private void NameBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
