using CommercialForum.Models;
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

namespace CommercialForum.Pages.StaffPages
{
    /// <summary>
    /// Логика взаимодействия для ClientListPage.xaml
    /// </summary>
    public partial class ClientListPage : Page
    {
        public ClientListPage()
        {
            InitializeComponent();
            BasicComponentController();
        }

        private List<User> all_clientsList;
        private void BasicComponentController()
        {
            all_clientsList = new List<User>();
            var all_clients = App.Connection.Users.Where(u=> u.Id_Role == 1 || u.Id_Role == 2).ToList();
            foreach (var client in all_clients)
            {
                User user = new User()
                {
                    Iduser = client.Id_User,
                    FName = client.FName,
                    LName = client.FName,
                    Patronymic = client.FName,
                    Email = client.Email
                };

                var search_role = App.Connection.Roles.Where(u=> u.Id_Role == client.Id_Role).FirstOrDefault();
                user.Role = search_role.Name;
                all_clientsList.Add(user);
            }

            clientsList.ItemsSource = all_clientsList;

            if (App.RoleId != 4)
            {
                UserDataBut.Visibility = Visibility.Collapsed;
            }
        }

        private void BackBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TraderProductsBut_Click(object sender, RoutedEventArgs e)
        {
            if (clientsList.SelectedItem != null)
            {
                var selected_user = clientsList.SelectedItem as User;
                if (selected_user.Role != "Trader")
                {
                    MessageBox.Show($"Вы выбрали продавца {selected_user.Iduser}", "Success");
                }
                else
                {
                    MessageBox.Show($"Выбранный вами пользователь не является продавцом", "Erorr");
                }
            }
        }

        private void HistoryBut_Click(object sender, RoutedEventArgs e)
        {
            if (clientsList.SelectedItem != null)
            {
                var selected_user = clientsList.SelectedItem as User;
                MessageBox.Show($"Вы просмотрели историю пользователя {selected_user.Iduser}", "Success");
            }
        }

        private void UserDataBut_Click(object sender, RoutedEventArgs e)
        {
            if (clientsList.SelectedItem != null)
            {
                var selected_user = clientsList.SelectedItem as User;
                MessageBox.Show($"Вы просмотрели/изменили данные пользователя {selected_user.Iduser}", "Success");
            }
        }
    }
}
