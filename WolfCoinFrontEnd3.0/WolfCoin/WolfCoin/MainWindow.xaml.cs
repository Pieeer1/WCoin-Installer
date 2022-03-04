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

namespace WolfCoin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string username;
        private string connString = "SERVER= 68.178.247.52;PORT= 3306;DATABASE=wolfcoinlogin_db;USERNAME = Pieeer1;PASSWORD = 456456";
        MySqlConnection conn;

        public MainWindow(string uid)
        {
            username = uid;
            InitializeComponent();
            this.Title = username;
            SendPopUp.IsOpen = false;
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



        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            SendPopUp.IsOpen = true;
        }



        //Sending Coins
        private void BtnSubmitSend_Click_1(object sender, RoutedEventArgs e)
        {
            string recieverUID = SendPopUpInput.Text;
            int recieverAmount = Convert.ToInt32(SendPopUpInputAmount.Text);
            string recieverBalance = "";
            List<string> nonces = new List<string>();

            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();


            for (int i = 0; i < recieverAmount; i++)
            {

                string query = "SELECT nonce FROM blockchain WHERE Owner = @username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@username", username);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                nonces.Add(dr.GetString(0));
                MessageBox.Show("nonce " + Convert.ToString(nonces[i]));
            }

            conn.Close();
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                string query = "SELECT Count(*) FROM wallet WHERE uid = @recieverUID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@recieverUID", recieverUID);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.GetInt32(0) > 0)
                {
                    conn.Close();
                    conn.Open();

                    query = "SELECT balance FROM wallet WHERE uid = @recieverUID";
                    cmd = new MySqlCommand(query, conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@recieverUID", recieverUID);
                    MySqlDataReader da = cmd.ExecuteReader();
                    da.Read();
                    recieverBalance = da.GetString(0);
                    conn.Close();
                    conn.Open();
                    query = "SELECT balance FROM wallet WHERE uid = @senderUID";
                    cmd = new MySqlCommand(query, conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@senderUID", username);
                    MySqlDataReader db = cmd.ExecuteReader();
                    db.Read();

                    string senderBalance = db.GetString(0);


                    if (Convert.ToInt32(senderBalance) < recieverAmount)
                    {
                        MessageBox.Show("Insufficient Balance");
                        return;
                    }
                    else
                    {
                        conn.Close();
                        conn.Open();
                        int FinalRecieverBalance = Convert.ToInt32(recieverBalance) + Convert.ToInt32(recieverAmount);
                        MessageBox.Show(Convert.ToString(FinalRecieverBalance));
                        MessageBox.Show(recieverUID);
                        int FinalSenderBalance = Convert.ToInt32(senderBalance) - Convert.ToInt32(recieverAmount);
                        try
                        {
                            query = "UPDATE wallet SET balance = @FinalRecieverBalance WHERE uid = @recieverUID";
                            cmd = new MySqlCommand(query, conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Parameters.AddWithValue("@recieverUID", recieverUID);
                            cmd.Parameters.AddWithValue("@FinalRecieverBalance", Convert.ToString(FinalRecieverBalance));
                            cmd.BeginExecuteNonQuery();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                        Task.Delay(10000).ContinueWith(_ =>
                        {
                            conn.Close();
                            conn.Open();
                            try
                            {
                                query = "UPDATE wallet SET balance = @FinalSenderBalance WHERE uid = @senderUID";
                                cmd = new MySqlCommand(query, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Parameters.AddWithValue("@senderUID", username);
                                cmd.Parameters.AddWithValue("@FinalSenderBalance", Convert.ToString(FinalSenderBalance));
                                cmd.BeginExecuteNonQuery();
                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        );
                        Task.Delay(15000).ContinueWith(_ =>
                        {
                        }
                        );
                        for (int i = 0; i < nonces.Count; i++)
                        {
                            conn.Close();
                            conn.Open();

                            try
                            {
                                query = "UPDATE blockchain SET Owner = @recieverUID WHERE Owner = @senderUID AND nonce = @nonces";
                                cmd = new MySqlCommand(query, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Parameters.AddWithValue("@recieverUID", recieverUID);
                                cmd.Parameters.AddWithValue("@senderUID", username);
                                cmd.Parameters.AddWithValue("@nonces", nonces[i]);
                                cmd.BeginExecuteNonQuery();
                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }


                    }



                }
                else
                {
                    MessageBox.Show("Invalid UID");
                    conn.Close();
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error Connecting to Server");

            }



            SendPopUp.IsOpen = false;
        }
    }
    
}
