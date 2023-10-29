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
    /// Логика взаимодействия для MyProfilePage.xaml
    /// </summary>
    public partial class MyProfilePage : Page
    {
        public MyProfilePage()
        {
            InitializeComponent();
            BasicComponentsController();
        }

        private void BasicComponentsController()
        {
            var search_user = App.Connection.Users.Where(u=> u.Id_User == App.AuthId).FirstOrDefault();
            if (search_user != null)
            {
                EmailBlock.Text = search_user.Email;
                OldFNameBlock.Text = search_user.FName;
                NewFNameBox.Text = search_user.FName;

                OldLNameBlock.Text = search_user.LName;
                NewLNameBox.Text = search_user.LName;

                OldPatronymicBlock.Text = search_user.Patronymic;
                NewPatronymicBox.Text = search_user.Patronymic;
            }


        }

        private void editBut_Click(object sender, RoutedEventArgs e)
        {
            if (AdditionalBoxController())
            {
                var search_user = App.Connection.Users.Where(u => u.Id_User == App.AuthId).FirstOrDefault();
                if (!_isAdditionalEmpty)
                {
                    search_user.FName = NewFNameBox.Text;
                    search_user.LName = NewLNameBox.Text;
                    search_user.Patronymic = NewPatronymicBox.Text;
                }
                else
                {
                    search_user.FName = "Unknown_FName";
                    search_user.LName = "Unknown_LName";
                    search_user.Patronymic = "Unknown_Patronymic";
                }

                App.Connection.SaveChanges();
                MessageBox.Show("Новые ФИО успешно загружены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                BasicComponentsController();
            }
        }



        private string _additionBoxes_errorMessage;
        private bool _isAdditionalEmpty = false;
        private bool AdditionalBoxController()
        {
            if (NewFNameBox.Text.Length != 0 || NewLNameBox.Text.Length != 0 || NewPatronymicBox.Text.Length != 0)
            {
                if (!NameBox_formatControl(NewFNameBox) || !NameBox_formatControl(NewLNameBox) || !NameBox_formatControl(NewPatronymicBox))
                {
                    MessageBox.Show("Заданные дополнительные поля имени не форматированы. " + _additionBoxes_errorMessage, "Ошибка форматирования", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return false;
                }

                return true;

            }
            else
            {
                _isAdditionalEmpty = true;
                return true;
            }
        }

        private bool NameBox_formatControl(TextBox taked_button)
        {
            string taked_text = taked_button.Text.ToString();

            if (taked_text.Length > 50)
            {
                _additionBoxes_errorMessage = "Ни одно из полей ФИО не должно быть больше 50-и символов!";
                return false;
            }

            foreach (char symbol in taked_text)
            {
                if (!Char.IsLetter(symbol))
                {
                    _additionBoxes_errorMessage = "В полях имени должны быть только буквы!";
                    return false;
                }
            }

            if (taked_text == "Unknown Name")
            {
                _additionBoxes_errorMessage = "Если задаете ФИО, то не пропускайте ни одного поля. Unknown Name быть не должно!";
                return false;
            }

            return true;
        }

        private void EditCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            OldFieldsPanel.Visibility = Visibility.Collapsed;
            NewFieldsPanel.Visibility = Visibility.Visible;
            editBut.Visibility = Visibility.Visible;
        }

        private void EditCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            OldFieldsPanel.Visibility = Visibility.Visible;
            NewFieldsPanel.Visibility = Visibility.Collapsed;
            editBut.Visibility = Visibility.Collapsed;
        }
    }
}
