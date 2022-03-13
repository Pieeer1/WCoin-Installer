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

namespace WolfCoin.MVVVM.View
{
    /// <summary>
    /// Interaction logic for SendView.xaml
    /// </summary>
    public partial class SendView : UserControl
    {

        private string connString;
        MySqlConnection conn;
        private string username;

        public SendView()
        {
            InitializeComponent();
            connString = Convert.ToString(Properties.Settings.Default.Properties["ConnectionString"].DefaultValue);
        }
        public void getUsername()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.Title != null && item.Title.Length > 5)
                {
                    username = item.Title;
                    break;

                }
            }
        }
        private void BtnSubmitSendClick(object sender, RoutedEventArgs e)
        {
            getUsername();
            string recieverUID = SendPopUpInput.Text;
            int recieverAmount = Convert.ToInt32(SendPopUpInputAmount.Text);
            string recieverBalance = "";
            List<string> nonces = new List<string>();

            conn = new MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string query1 = "SELECT nonce FROM blockchain WHERE Owner = @username";
            MySqlCommand cmd1 = new MySqlCommand(query1, conn);
            cmd1.CommandType = System.Data.CommandType.Text;
            cmd1.Parameters.AddWithValue("@username", username);
            MySqlDataReader dr1 = cmd1.ExecuteReader();

            for (int i = 0; i < recieverAmount; i++)
            {


                dr1.Read();

                nonces.Add(dr1.GetString(0));
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
                        SendLabel.Content = "Insufficient Balance";
                        return;
                    }
                    else
                    {
                        conn.Close();
                        conn.Open();
                        int FinalRecieverBalance = Convert.ToInt32(recieverBalance) + Convert.ToInt32(recieverAmount);
                        int FinalSenderBalance = Convert.ToInt32(senderBalance) - Convert.ToInt32(recieverAmount);
                        try
                        {
                            query = "UPDATE wallet SET balance = @FinalRecieverBalance WHERE uid = @recieverUID";
                            cmd = new MySqlCommand(query, conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Parameters.AddWithValue("@recieverUID", recieverUID);
                            cmd.Parameters.AddWithValue("@FinalRecieverBalance", Convert.ToString(FinalRecieverBalance));
                            cmd.ExecuteNonQuery();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }



                        conn.Close();
                        conn.Open();
                        try
                        {
                            query = "UPDATE wallet SET balance = @FinalSenderBalance WHERE uid = @senderUID";
                            cmd = new MySqlCommand(query, conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Parameters.AddWithValue("@senderUID", username);
                            cmd.Parameters.AddWithValue("@FinalSenderBalance", Convert.ToString(FinalSenderBalance));
                            cmd.ExecuteNonQuery();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

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
                                cmd.ExecuteNonQuery();
                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        SendLabel.Content = "Sent " + recieverAmount + " Wolfcoins to " + recieverUID ;


                    }



                }
                else
                {
                    SendLabel.Content = "Invalid User";
                    conn.Close();
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }



        }
    }


}
