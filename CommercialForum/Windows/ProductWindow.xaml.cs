using System.Linq;
using System.Windows;
using CommercialForum.Pages;
using CommercialForum.Pages.ProductPages;

namespace CommercialForum.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            InitializeComponent();
            BasicComponentsController();

            ProductFrame.Content = new ProductEntryPage();
        }

        public ProductWindow(int productId)
        {
            InitializeComponent();
            BasicComponentsController();

            switch (App.RoleId)
            {
                case 1:
                    ProductFrame.Content = new ProductPage(productId);
                    break;
                case 2:
                    var search_product = App.Connection.Products.Where(u=> u.Id_Product == productId).FirstOrDefault();
                    if (search_product.Id_Trader == App.AuthId)
                    {
                        ProductFrame.Content = new ProductEditPage(productId);
                    }
                    else
                    {
                        ProductFrame.Content = new ProductPage(productId);
                    }
                    break;
                case 3:
                    ProductFrame.Content = new ProductEditPage(productId);
                    break;
                case 4:
                    ProductFrame.Content = new ProductEditPage(productId);
                    break;
            }
        }

        private void BasicComponentsController()
        {
            App.isProductsOpened = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.MainWindow.Activate();
            App.isProductsOpened = false;
        }
    }
}
