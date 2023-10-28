using CommercialForum.AppData;
using CommercialForum.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {

        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void backBut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void regBut_Click(object sender, RoutedEventArgs e)
        {
            bool isAdditionalOk = AdditionalBoxController();
            bool isMainOk = MainBoxController();
            if (isAdditionalOk && isMainOk)
            {
                RegistrationProcess();
            }

        }

        private void RegistrationProcess()
        {
            try
            {
                Users new_user = new Users()
                {
                    Email = EmailBox.Text,
                    Password = PasswordBox.Password,
                    Id_Role = 1,
                    Balance = 0
                };

                if (!_isAdditionalEmpty)
                {
                    new_user.FName = FNameBox.Text;
                    new_user.LName = LNameBox.Text;
                    new_user.Patronymic = PatronymicBox.Text;
                }
                App.Connection.Users.Add(new_user);
                App.Connection.SaveChanges();

                MessageBox.Show("Аккаунт успешно создан", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                Debug.Write($"{e}");
                MessageBox.Show("При создании аккаунта возникли независящие от вас ошибки. Обратитесь в службу поддержки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private bool MainBoxController()
        {
            var search_user = App.Connection.Users.Where(x => x.Email == EmailBox.Text).FirstOrDefault();
            if (search_user != null)
            {
                MessageBox.Show("Заданные главные поля имени не форматированы. Пользователь с заданной почтой уже существует", "Ошибка в поле почты", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            if (PasswordBox.Password.Length < 5)
            {
                MessageBox.Show("Заданные главные поля имени не форматированы. Пароль не может быть меньше 5-и символов!", "Ошибка в поле пароля", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            if (!EmailBox_formatControl())
            {
                MessageBox.Show("Заданные главные поля имени не форматированы. " + _mainBoxes_errorMessage, "Ошибка форматирования", MessageBoxButton.OK, MessageBoxImage.Stop);
                return false;
            }

            return true;
        }

        private string _mainBoxes_errorMessage;
        private bool EmailBox_formatControl()
        {
            if (!EmailBox.Text.Contains("@mail.ru"))
            {
                _mainBoxes_errorMessage = "Ваша почта должна содержать строку @mail.ru!";
                 return false;
            }


            if (EmailBox.Text.Length < 10)
            {
                _mainBoxes_errorMessage = "Ваша почта не может содержать одну лишь строку @mail.ru...";
                return false;
            }

            foreach (char symbol in EmailBox.Text)
            {
                if (!Char.IsLetterOrDigit(symbol) && symbol != '@' && symbol != '.')
                {
                    _mainBoxes_errorMessage = "В поле почты не должно быть пробелов и прочих ненужных символов";
                    return false;
                }
            }

            return true;
        }

        private string _additionBoxes_errorMessage;
        private bool _isAdditionalEmpty;
        private bool AdditionalBoxController()
        {
            if (FNameBox.Text != "Unknown Name" || LNameBox.Text != "Unknown Name" || PatronymicBox.Text != "Unknown Name")
            {
                _isAdditionalEmpty = false;

                if (!NameBox_formatControl(FNameBox) || !NameBox_formatControl(LNameBox) || !NameBox_formatControl(PatronymicBox))
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

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var taked_box = (TextBox)sender;
            if (taked_box.Text.Length == 0)
            {
                taked_box.Text = "Unknown Name";
            }
        }

        private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var taked_box = (TextBox)sender;
            if (taked_box.Text.Length == 0)
            {
                taked_box.Text = "Unknown address";
            }

            /*if (taked_box.IsKeyboardFocused)
            {
                taked_box.Text = "sssssssssssssssssssss";
            }
            else
            {
                taked_box.Text = "as";
            }*/
        }
    }
}
