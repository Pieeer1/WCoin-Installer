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
using Stripe;
using System.Text.RegularExpressions;

namespace WolfCoin.MVVVM.View
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : UserControl
    {

        private string connString;
        MySqlConnection conn;
        private string username;

        public SellView()
        {
            InitializeComponent();
            connString = Convert.ToString(Properties.Settings.Default.Properties["ConnectionString"].DefaultValue);
        }



        private void TypeNumericValidation(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
        private void PasteNumericValidation(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String input = (String)e.DataObject.GetData(typeof(String));
                if (new Regex("[^0-9]+").IsMatch(input))
                {
                    e.CancelCommand();
                }
            }
            else e.CancelCommand();
        }


        //Use Stripe.payouts

        public void getUsername()
        {
            foreach (Window item in System.Windows.Application.Current.Windows)
            {
                if (item.Title != null && item.Title.Length > 5)
                {
                    username = item.Title;
                    break;

                }
            }
        }

        private void BtnSellSend_Click(object sender, RoutedEventArgs e)
        {
            getUsername();

            List<Tuple<string, string>> blockchains = new List<Tuple<string, string>>();

            conn = new MySqlConnection();
            conn.ConnectionString = connString;

            conn.Open();
            string query = "SELECT balance FROM wallet WHERE uid = @senderUID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@senderUID", username);
            MySqlDataReader db = cmd.ExecuteReader();
            db.Read();
            string senderBalance = db.GetString(0);
            conn.Close();

            int finalSenderBalance = Convert.ToInt32(senderBalance) - Convert.ToInt32(AmountToSell.Text);


            try
            {
                conn.Open();

                query = "SELECT balance FROM wallet WHERE uid = @senderUID";
                cmd = new MySqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@senderUID", username);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (Convert.ToInt32(dr.GetValue(0)) >= Convert.ToInt32(AmountToSell.Text))
                {
                    conn.Close();


                    conn.Open();


                    query = "SELECT nonce, previoushash FROM blockchain WHERE Owner = @username";
                    cmd = new MySqlCommand(query, conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@username", username);
                    dr = cmd.ExecuteReader();

                    for (int i=0;i<Convert.ToInt32(AmountToSell.Text);i++)
                    {

                        dr.Read();

                        blockchains.Add(new Tuple<string, string>(Convert.ToString(dr.GetValue(0)), Convert.ToString(dr.GetValue(1))));
                    }





                    for (int i = 0; i < blockchains.Count; i++)
                    {
                        conn.Close();
                        conn.Open();
                        query = "INSERT INTO forSale (seller, nonce, previoushash, price, timeEnteredMarket) VALUES(@username, @nonce, @previoushash, @price, UTC_TIMESTAMP)";
                        cmd = new MySqlCommand(query, conn);
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@price", PricePerCoin.Text);
                        cmd.Parameters.AddWithValue("@nonce", blockchains[i].Item1);
                        cmd.Parameters.AddWithValue("@previoushash", blockchains[i].Item2);

                        cmd.ExecuteNonQuery();

                    }



                    for (int i = 0; i < blockchains.Count; i++)
                    {
                        conn.Close();
                        conn.Open();
                        query = "UPDATE blockchain SET owner = NULL WHERE nonce = @nonce AND Owner = @username";
                        cmd = new MySqlCommand(query, conn);
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@nonce", blockchains[i].Item1);

                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                    conn.Open();
                    query = "UPDATE wallet SET balance = @FinalSenderBalance WHERE uid = @senderUID";
                    cmd = new MySqlCommand(query, conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@senderUID", username);
                    cmd.Parameters.AddWithValue("@FinalSenderBalance", Convert.ToString(finalSenderBalance));
                    cmd.ExecuteNonQuery();
                    conn.Close();




                    SendLabel.Content = "Selling " + AmountToSell.Text + " WolfCoins For $" + PricePerCoin.Text;
                }
                else
                {
                    SendLabel.Content = "Insufficient Balance";
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
