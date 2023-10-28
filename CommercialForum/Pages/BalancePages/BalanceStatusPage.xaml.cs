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
using CommercialForum.AppData;

namespace CommercialForum.Pages.BalancePages
{
    /// <summary>
    /// Логика взаимодействия для BalanceStatusPage.xaml
    /// </summary>
    public partial class BalanceStatusPage : Page
    {
        public BalanceStatusPage()
        {
            InitializeComponent();

            BasicUpdateComponent();
        }


        private async void BasicUpdateComponent()
        {
            var row_material = App.Connection.Users.Where(u => u.Id_User == App.AuthId).FirstOrDefault().Balance;
            double balance = Convert.ToDouble(row_material);
            MoneyBlock.Text = balance.ToString();

            while (App.AuthId != 0)
            {
                await updateAsync();
            }
        }

        private async Task updateAsync()
        {
            await Task.Delay(10000);
            if (App.AuthId != 0)
            {
                var row_material = App.Connection.Users.Where(u => u.Id_User == App.AuthId).FirstOrDefault().Balance;
                double balance = Convert.ToDouble(row_material);
                MoneyBlock.Text = balance.ToString();
            }
        }
    }
}
