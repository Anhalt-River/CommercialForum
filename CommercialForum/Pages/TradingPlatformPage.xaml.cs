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
using static System.Net.Mime.MediaTypeNames;

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

        List<Product> all_productsList;
        private void ProductListLoader()
        {
            all_productsList = new List<Product>();
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

        private void AvailableBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AvailabilitySort();
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

        private bool CostValidationController(string text)
        {
            foreach (char symbol in text)
            {
                if (!Char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }

        private void MinPriceBox_LostFocus(object sender, RoutedEventArgs e)
        {
            /*if (MinPriceBox.Text.Length == 0)
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productsList.ItemsSource);
                view.Filter = i => ((Product)i).Cost != 0;
                view.Refresh();
                return;
            }*/

            if (CostValidationController(MinPriceBox.Text))
            {
                UnitePricesController();
            }
            else
            {
                MessageBox.Show("Вы указали не целочисленное значение в поле минимальной цены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MaxPriceBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CostValidationController(MaxPriceBox.Text))
            {
                UnitePricesController();
            }
            else
            {
                MessageBox.Show("Вы указали не целочисленное значение в поле максимальной цены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UnitePricesController()
        {
            if (MinPriceBox.Text.Length != 0 && MaxPriceBox.Text.Length != 0)
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productsList.ItemsSource);
                view.Filter = i => ((Product)i).Cost >= Convert.ToDouble(MinPriceBox.Text) 
                                        && ((Product)i).Cost <= Convert.ToDouble(MaxPriceBox.Text);
                view.Refresh();
            }
            else
            {
                if (MinPriceBox.Text.Length != 0)
                {
                    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productsList.ItemsSource);
                    view.Filter = i => ((Product)i).Cost >= Convert.ToDouble(MinPriceBox.Text);
                    view.Refresh();
                }
                else if (MaxPriceBox.Text.Length != 0)
                {
                    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productsList.ItemsSource);
                    view.Filter = i => ((Product)i).Cost <= Convert.ToDouble(MaxPriceBox.Text);
                    view.Refresh();
                }
            }
        }

        private bool little_plug = true;
        private void AvailableCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (little_plug)
            {
                little_plug = false;
                return;
            }

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productsList.ItemsSource);
            view.Filter = i => ((Product)i).IsAvailable == "Yes";
            view.Refresh();
        }

        private void AvailableCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productsList.ItemsSource);
            view.Filter = i => ((Product)i).IsAvailable == "No";
            view.Refresh();
        }

        private void AvailableCheckBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productsList.ItemsSource);
            view.Filter = i => ((Product)i).IsAvailable == "Yes" || ((Product)i).IsAvailable == "No";
            view.Refresh();
        }

        private void CategorySearchBut_Click(object sender, RoutedEventArgs e)
        {
            ProductListLoader();
            List<Product> new_productList = new List<Product>();
            foreach (var product in all_productsList)
            {
                var all_relations = App.Connection.Category_Relationship.Where(u=> u.Id_Product == product.IdProduct).ToList();

                bool Satisfy = true;
                foreach (var relation in App.CategoryTransit)
                {
                    var find_relation = all_relations.Where(u=> u.Id_Category == relation.IdCategory).FirstOrDefault();
                    if (find_relation == null)
                    {
                        Satisfy = false;
                        break;
                    }
                }

                if (Satisfy)
                {
                    new_productList.Add(product);
                }
            }

            productsList.ItemsSource = null;
            productsList.ItemsSource = new_productList;
        }

        private void SearchByName()
        {
            /*List<Product> searchList = new List<Product>();
            foreach (var view_product in productsList.ItemsSource)
            {
                Product product = view_product as Product;
                if (product.Name.Contains(SearchBox.Text))
                {
                    searchList.Add((Product)view_product);
                }
            }
            productsList.ItemsSource = searchList;*/

            List<Product> searchList = new List<Product>();
            foreach (var product in all_productsList)
            {
                if (product.Name.Contains(SearchBox.Text))
                {
                    searchList.Add(product);
                }
            }
            productsList.ItemsSource = searchList;
        }

        private void SearchBut_Click(object sender, RoutedEventArgs e)
        {
            SearchByName();
        }
    }
}
