using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CommercialForum.Models;
using CommercialForum.Pages.ProductPages;
using Microsoft.Win32;
using CommercialForum.Windows;

namespace CommercialForum.Pages.ProductPages
{
    /// <summary>
    /// Логика взаимодействия для ProductEditPage.xaml
    /// </summary>
    public partial class ProductEditPage : Page
    {
        private int taked_productId;
        public ProductEditPage(int productId)
        {
            InitializeComponent();
            BasicComponentController(productId);
        }

        private byte[] image_data = null;
        private bool didPut = false;
        private void BasicComponentController(int productId)
        {
            taked_productId = productId;
            var search_product = App.Connection.Products.Where(u=> u.Id_Product == taked_productId).FirstOrDefault();
            if (search_product != null)
            {
                Product_NameBox.Text = search_product.Name;
                Product_CostBox.Text = search_product.Cost.ToString();
                Product_DescBox.Text = search_product.Description;

                if (search_product.Image != null)
                {
                    MemoryStream memoryStream = new MemoryStream(search_product.Image);
                    BitmapImage new_Bitmap = new BitmapImage();
                    new_Bitmap.BeginInit();
                    new_Bitmap.StreamSource = memoryStream;
                    new_Bitmap.EndInit();
                    Product_Image.Source = new_Bitmap;
                    image_data = search_product.Image;
                }
                else
                {
                    Product_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Materials/Images/image_fail.png"));
                }

                if (search_product.IsAvailable == "No")
                {
                    AvailableCheckBox.IsChecked = !AvailableCheckBox.IsChecked;
                }

                if (search_product.DidPut == "No")
                {
                    didPut = false;
                    DiscontinieBut.Content = "Выставить на продажу";
                }
                else
                {
                    didPut = true;
                    DiscontinieBut.Content = "Снять с продажи";
                }
            }
        }

        private bool isError = false;
        private bool isCostError;
        private bool isCostEmptyError;
        private bool isNameEmptyError;
        private bool isNameError;
        private bool FieldsController()
        {

            isCostError = false;
            isCostEmptyError = false;
            isNameEmptyError = false;
            isNameError = false;

            foreach (char symbol in Product_CostBox.Text)
            {
                if (!Char.IsDigit(symbol))
                {
                    isCostError = true;
                    MessageBox.Show("Цена не может представляться чем-то помимо цифр",
                        "Ошибка ценообразования", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
            }

            if (Product_CostBox.Text.Length == 0)
            {
                isCostEmptyError = true;
                MessageBox.Show("Цена товара не может оставаться пустой!",
                    "Ошибка имяобразования", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (Product_NameBox.Text.Length == 0)
            {
                isNameEmptyError = true;
                MessageBox.Show("Имя для товара не может оставаться пустым!",
                    "Ошибка имяобразования", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (Product_NameBox.Text.Length >= 100)
            {
                isNameEmptyError = true;
                MessageBox.Show("Имя товара не может превышать 99 символов!",
                    "Ошибка имяобразования", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            if (isCostError || isNameEmptyError || isNameError || isCostEmptyError)
            {
                isError = true;
            }
            else
            {
                isError = false;
            }

            return isError;
        }

        private void EditBut_Click(object sender, RoutedEventArgs e)
        {
            if (!FieldsController())
            {
                var search_product = App.Connection.Products.Where(u=> u.Id_Product == taked_productId).FirstOrDefault();
                search_product.Name = Product_NameBox.Text;
                search_product.Cost = Convert.ToDouble(Product_CostBox.Text);

                if ((bool)AvailableCheckBox.IsChecked)
                {
                    search_product.IsAvailable = "Yes";
                }
                else
                {
                    search_product.IsAvailable = "No";
                }

                if (didPut)
                {
                    search_product.DidPut = "Yes";
                }
                else
                {
                    search_product.DidPut = "No";
                }

                if (Product_DescBox.Text.Length > 0)
                {
                    search_product.Description = Product_DescBox.Text;
                }
                else
                {
                    search_product.Description = null;
                }

                App.Connection.SaveChanges();
                MessageBox.Show("Товар успешно отредактирован!", "Успех!");
            }
        }

        private void DeleteBut_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалить товар?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var search_product = App.Connection.Products.Where(u=> u.Id_Product == taked_productId).FirstOrDefault();
                App.Connection.Products.Remove(search_product);
                App.Connection.SaveChanges();
                var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

                App.Current.MainWindow.Activate();
                NavigationManager.MainPageFrame.Refresh();

                MessageBox.Show("Товар успешно удален с продаж!", "Успех!");
                window.Close();
            }
        }

        private void DiscontinieBut_Click(object sender, RoutedEventArgs e)
        {
            var search_product = App.Connection.Products.Where(u => u.Id_Product == taked_productId).FirstOrDefault();

            if (didPut)
            {
                search_product.DidPut = "No";
                DiscontinieBut.Content = "Выставить на продажу";
                MessageBox.Show("Товар успешно снят с продажи!", "Успех!");
            }
            else
            {
                search_product.DidPut = "Yes";
                DiscontinieBut.Content = "Снять с продажи";
                MessageBox.Show("Товар успешно добавлен на площадку!", "Успех!");
            }

            didPut = !didPut;
            App.Connection.SaveChanges();
        }

        private void ProductImageBut_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (openFileDialog.ShowDialog() == true)
            {
                var taked_filename = openFileDialog.FileName;
                image_data = File.ReadAllBytes(taked_filename);
                Product_Image.Source = new BitmapImage(new Uri(taked_filename));
            }
        }

        private void CategoryChooseBut_Click(object sender, RoutedEventArgs e)
        {
            if (!App.isCategoriesOpened)
            {
                CategoryWindow categoryWindow = new CategoryWindow(taked_productId);
                categoryWindow.Owner = App.Current.MainWindow;
                categoryWindow.Show();
            }
        }
    }
}
