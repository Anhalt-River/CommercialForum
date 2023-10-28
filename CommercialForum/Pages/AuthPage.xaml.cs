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

namespace CommercialForum.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void AuthBut_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorisationProcess())
            {
                NavigationService.Navigate(new MainPage());
            }
        }

        private bool AuthorisationProcess()
        {
            var search_user = App.Connection.Users.Where(x => x.Email == EmailBox.Text).FirstOrDefault();
            if (search_user == null)
            {
                MessageBox.Show("Пользователя с указанным почтовым адресом не найдено", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            if (search_user.Password != PasswordBox.Password)
            {
                MessageBox.Show("Указан неверный пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }


            MessageBox.Show("Авторизация успешно пройдена", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            App.AuthId = search_user.Id_User;
            App.RoleId = Convert.ToInt32(search_user.Id_Role);

            return true;
        }

        private void RegistrateBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
