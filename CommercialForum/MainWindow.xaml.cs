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
using CommercialForum.Models;
using CommercialForum.Pages;

namespace CommercialForum
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BasicFrameConnect();
        }

        private void BasicFrameConnect()
        {
            NavigationManager.MainPageFrame = MainWindowFrame;
            if (App.AuthId == 0)
            {
                MainWindowFrame.Content = new AuthPage();
            }
            else
            {
                MainWindowFrame.Content = new MainPage();
            }
        }
    }
}
