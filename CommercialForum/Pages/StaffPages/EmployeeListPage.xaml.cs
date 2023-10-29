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
    /// Логика взаимодействия для EmployeeListPage.xaml
    /// </summary>
    public partial class EmployeeListPage : Page
    {
        public EmployeeListPage()
        {
            InitializeComponent();
            BasicComponentController();
        }

        private List<User> all_employeesList;
        private void BasicComponentController()
        {
            all_employeesList = new List<User>();
            var all_clients = App.Connection.Users.Where(u=> u.Id_Role == 3 || u.Id_Role == 4).ToList();
            foreach (var client in all_clients)
            {
                User employee = new User()
                {
                    Iduser = client.Id_User,
                    FName = client.FName,
                    LName = client.FName,
                    Patronymic = client.FName,
                    Email = client.Email
                };

                var search_role = App.Connection.Roles.Where(u => u.Id_Role == client.Id_Role).FirstOrDefault();
                employee.Role = search_role.Name;
                all_employeesList.Add(employee);
            }

            employeesList.ItemsSource = all_employeesList;

            if (App.RoleId != 4)
            {
                UserDataBut.Visibility = Visibility.Collapsed;
            }
        }

        private void BackBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void UserDataBut_Click(object sender, RoutedEventArgs e)
        {
            if (employeesList.SelectedItem != null)
            {
                var selected_user = employeesList.SelectedItem as User;
                MessageBox.Show($"Вы просмотрели/изменили данные сотрудника {selected_user.Iduser}", "Success");
            }
        }
    }
}
