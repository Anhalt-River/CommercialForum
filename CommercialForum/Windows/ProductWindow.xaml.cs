using System.Windows;
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

            ProductFrame.Content = new ProductEditPage(productId);
        }

        private void BasicComponentsController()
        {
            App.isProductsOpened = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.isProductsOpened = false;
        }
    }
}
