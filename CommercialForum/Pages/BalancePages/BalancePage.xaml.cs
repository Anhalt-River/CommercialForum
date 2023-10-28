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

namespace CommercialForum.Pages.BalancePages
{
    /// <summary>
    /// Логика взаимодействия для BalancePage.xaml
    /// </summary>
    public partial class BalancePage : Page
    {
        public BalancePage()
        {
            InitializeComponent();

        }

        private void BalancePage_Click(object sender, RoutedEventArgs e)
        {
            var search_user = App.Connection.Users.Where(u=> u.Id_User == App.AuthId).FirstOrDefault();
            search_user.Balance += 1000;
            MessageBox.Show("Баланс пополнен!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            App.Connection.SaveChanges();
        }
    }
}
