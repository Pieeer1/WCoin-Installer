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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using CryptSharp;
using System.Security.Cryptography;

namespace WolfCoin
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {

        public static readonly RoutedUICommand Login = new RoutedUICommand("Login", "Login", typeof(LoginPage));

        MySqlConnection conn;
        string connString;
        string username;
        string password;

        public LoginPage()
        {
            InitializeComponent();
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

        public static string PHPMd5Hash(string pass)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] input = Encoding.UTF8.GetBytes(pass);
                byte[] hash = md5.ComputeHash(input);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            loadMain();
        }

        private void BtnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.wolf-coin.us/signup.php");
        }

        private void loadMain()
        {

                username = txtUsername.Text;
                password = txtPassword.Password;

                string passResult = PHPMd5Hash(password);

                connString = "SERVER= 68.178.247.52;PORT= 3306;DATABASE=wolfcoinlogin_db;USERNAME = Pieeer1;PASSWORD = 456456";



                if (username.Length > 1 && password.Length > 1)
                {
                    try
                    {
                        conn = new MySqlConnection();
                        conn.ConnectionString = connString;
                        conn.Open();

                        string query = "SELECT usersUid, usersPwd FROM users WHERE usersUid=@username";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", passResult);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.GetString(0) == username && passResult.ToLower() == dr.GetString(1))
                        {
                            MainWindow dashboard = new MainWindow(username);
                            dashboard.Show();
                            this.Close();
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Login Credentials");

                        }

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error Connecting to Server");

                    }
                }
                else
                {
                    MessageBox.Show("Please Fill Out All Values");

                }
            }





        private void SubmitEnter(object sender, ExecutedRoutedEventArgs e)
        {
            BtnSubmit_Click(sender, e);
        }
    }
}
