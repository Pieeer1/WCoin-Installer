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
using MySql.Data.MySqlClient;
using System.Threading;
using System.Configuration;

namespace WolfCoin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string username;
        private string connString;
        MySqlConnection conn;

        public MainWindow(string uid)
        {
            username = uid;
            InitializeComponent();
            this.Title = username;
            connString = Convert.ToString(Properties.Settings.Default.Properties["ConnectionString"].DefaultValue);
            WelcomeLabel.Content = "Welcome " + username;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            Environment.Exit(0);
        }

        public string getUsername()
        {
            return username;
        }


    }
}
