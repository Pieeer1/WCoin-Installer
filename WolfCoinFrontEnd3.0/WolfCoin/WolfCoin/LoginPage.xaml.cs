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
using Emailer;
using System.Text.RegularExpressions;

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
        int factorVerify;
        int factorSend; 

        public LoginPage()
        {
            InitializeComponent();
            connString = Convert.ToString(Properties.Settings.Default.Properties["ConnectionString"].DefaultValue);
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





                if (username.Length > 1 && password.Length > 1)
                {
                    try
                    {
                        conn = new MySqlConnection();
                        conn.ConnectionString = connString;
                        conn.Open();

                        string query = "SELECT usersUid, usersPwd FROM users WHERE usersUid= @username";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", passResult);
                        MySqlDataReader dr = cmd.ExecuteReader();
                        dr.Read();

                        if (dr.GetString(0) == username && passResult.ToLower() == dr.GetString(1))
                        {
                            conn.Close();

                            btnCreateAccount.Visibility = Visibility.Hidden;
                            btnCreateAccount.IsEnabled = false;
                            btnSubmit.Visibility = Visibility.Hidden;
                            btnSubmit.IsEnabled = false;
                            

                            try
                            {
                                conn.Open();
                                query = "SELECT usersEmail FROM users WHERE usersUid = @username";
                                cmd = new MySqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@username", username);
                                dr = cmd.ExecuteReader();
                                dr.Read();
                                FactorStack.Visibility = Visibility.Visible;
                                FactorStack.IsEnabled = true;
                                int factorCode = GenerateRandomNo();
                                factorSend = factorCode;
                                string[] toList = { Convert.ToString(dr.GetValue(0)) };


                                conn.Close();

                                string bodyString = @"<body><h3>Your Two Factor Authorization Code is: </h3><h1>" +  Convert.ToString(factorCode) + @"</h1><p>Do not Share This Code With Anyone</p></body>" ;


                                Emailer.Emailer.SendEmail("Two Factor Login Code", bodyString, toList);

                                ErrorLabel.Content = "Check Email: " + toList[0] + ", enter 4 Digits ";

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            btnVerify.Visibility = Visibility.Visible;
                            btnVerify.IsEnabled = true;

                    }
                        else
                        {
                            ErrorLabel.Content = "Incorrect Login Credentials";
                        }

                    }
                    catch (MySqlException ex)
                    {
                        ErrorLabel.Content= "Username Not Found";

                    }
                }
                else
                {
                    ErrorLabel.Content = "Please Fill Out All Values";

                }
            }

        public int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }



        private void SubmitEnter(object sender, ExecutedRoutedEventArgs e)
        {
            BtnSubmit_Click(sender, e);
        }


        private void TypeNumericValidation(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]{1}").IsMatch(e.Text);
        }
        private void PasteNumericValidation(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String input = (String)e.DataObject.GetData(typeof(String));
                if (new Regex("[^0-9]{1}").IsMatch(input))
                {
                    e.CancelCommand();
                }
            }
            else e.CancelCommand();
        }

        private void BtnVerify_Click(object sender, RoutedEventArgs e)
        {
            factorVerify = (Convert.ToInt32(factor0.Text) * 1000) + (Convert.ToInt32(factor1.Text) * 100) + (Convert.ToInt32(factor2.Text) * 10) + (Convert.ToInt32(factor3.Text));

            if (factorVerify == factorSend)
            {
                MainWindow dashboard = new MainWindow(username);
                dashboard.Show();
                this.Close();
            }
            else
            {
                ErrorLabel.Content = "Incorrect 4 Digit Code";
            }

        }
    }
}
