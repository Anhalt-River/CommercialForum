using Microsoft.Win32;
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
using System.IO;
using CommercialForum.AppData;
using CommercialForum.Windows;

namespace CommercialForum.Pages.ProductPages
{
    /// <summary>
    /// Логика взаимодействия для ProductEntryPage.xaml
    /// </summary>
    public partial class ProductEntryPage : Page
    {
        private List<int> categories = new List<int>();  //Нужно ли оставлять эти категории?
        public ProductEntryPage()
        {
            InitializeComponent();
        }

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

            CostFieldError();
            return isError;
        }

        private bool isError = false;
        private void CostFieldError()
        {
            if (isCostError)
            {
                Product_CostBox.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Product_CostBox.BorderBrush = new SolidColorBrush(Colors.Navy);
            }
        }

        private byte[] image_data = null;
        private void EntryBut_Click(object sender, RoutedEventArgs e)
        {
            if (!FieldsController())
            {
                Products new_product = new Products()
                {
                    Name = Product_NameBox.Text,
                    Cost = Convert.ToDouble(Product_CostBox.Text),
                    Id_Trader = App.AuthId,
                    DidPut = "Yes",
                };

                if (image_data != null)
                {
                    new_product.Image = image_data;
                }

                if ((bool)AvailableCheckBox.IsChecked)
                {
                    new_product.IsAvailable = "Yes";
                }
                else
                {
                    new_product.IsAvailable = "No";
                }

                if (Product_DescBox.Text.Length > 0)
                {
                    new_product.Description = Product_DescBox.Text;
                }


                App.Connection.Products.Add(new_product);
                App.Connection.SaveChanges();
                MessageBox.Show("Товар успешно добавлен!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);

                RelocateToEditPage(new_product.Id_Product);
            }
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

        private void RelocateToEditPage(int productId)
        {
            NavigationService.Navigate(new ProductEditPage(productId));
        }

        /*private void CategoryChooseBut_Click(object sender, RoutedEventArgs e)
        {
            if (!App.isCategoriesOpened)
            {
                CategoryWindow categoryWindow = new CategoryWindow();
                categoryWindow.Owner = App.Current.MainWindow;
                categoryWindow.Show();
                App.isCategoriesOpened = true;
            }
        }*/
    }
}
