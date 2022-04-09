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
using Stripe;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;


namespace WolfCoin.MVVVM.View
{
    /// <summary>
    /// Interaction logic for BuyView.xaml
    /// </summary>
    public partial class BuyView : UserControl
    {

        private int finalCharge;
        private string connString;
        MySqlConnection conn;
        private string username;



        public BuyView()
        {
            InitializeComponent();
            connString = Convert.ToString(Properties.Settings.Default.Properties["ConnectionString"].DefaultValue);
        }

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

        private void BtnBuySend_Click(object sender, RoutedEventArgs e)
        {

            getUsername();

            finalCharge = Convert.ToInt32(SendPopUpInput.Text) * Convert.ToInt32(SendPopUpInputAmount.Text);

            try
            {
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


                int finalSenderBalance = Convert.ToInt32(senderBalance) + Convert.ToInt32(SendPopUpInput.Text);

                conn.Open();
                query = "SELECT COUNT(*) FROM forSale WHERE price = @price";
                cmd = new MySqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@price", SendPopUpInputAmount.Text);
                db = cmd.ExecuteReader();
                db.Read();

                if (Convert.ToInt32(db.GetValue(0)) >= Convert.ToInt32(SendPopUpInput.Text))
                {
                    conn.Close();




                    try
                    {
                        StripeConfiguration.ApiKey = "sk_test_51KchCkKjiNRBYwECUiAg5c5E1Asn7hvOBAzmdEJTzqceNll2dbevhx7pC82Y8VVTEO6141z3Rw7jtuVDcfskRlJK00QDMtCLh7";

                        var opttoken = new TokenCreateOptions
                        {
                            Card = new TokenCardOptions
                            {
                                Number = CardNumberValue.Text,
                                ExpMonth = Convert.ToInt32(ExpirationValueMonth.Text),
                                ExpYear = Convert.ToInt32(ExpirationValueYear.Text),
                                Cvc = CVCValue.Text

                            }
                        };

                        var tokenservice = new TokenService();
                        Token stripetoken = tokenservice.Create(opttoken);

                        var options = new ChargeCreateOptions
                        {
                            Amount = finalCharge,
                            Currency = "usd",
                            Description = "Test Transaction",
                            Source = stripetoken.Id


                        };

                        var service = new ChargeService();
                        Charge charge = service.Create(options);



                        //charge.invoice for database


                        if (charge.Paid)
                        {

                            SendLabel.Content = "Bought " + SendPopUpInput.Text + " Wolfcoins for $" + SendPopUpInputAmount.Text;
                            //charge.Invoice.ToJson();

                            List<string> Owners = new List<string>();

                            List<Tuple<string, string>> blockchains = new List<Tuple<string, string>>();

                            conn.Open();
                            query = "SELECT * FROM forSale WHERE price = @price ORDER BY timeEnteredMarket ASC";
                            cmd = new MySqlCommand(query, conn);
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Parameters.AddWithValue("@price", SendPopUpInputAmount.Text);
                            db = cmd.ExecuteReader();


                            for (int i = 0; i < Convert.ToInt32(SendPopUpInput.Text); i++)
                            {

                                db.Read();

                                Owners.Add(Convert.ToString(db.GetValue(0)));
                                blockchains.Add(new Tuple<string, string>(Convert.ToString(db.GetValue(1)), Convert.ToString(db.GetValue(2))));

                            }


                            /*
                             * Add payouts to OWNER LIST
                             * 
                             * 
                             * */


                            for (int i = 0; i < blockchains.Count; i++)
                            {
                                conn.Close();
                                conn.Open();
                                query = "DELETE FROM forSale WHERE nonce = @nonce AND previoushash = @previoushash";
                                cmd = new MySqlCommand(query, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Parameters.AddWithValue("@nonce", blockchains[i].Item1);
                                cmd.Parameters.AddWithValue("@previoushash", blockchains[i].Item2);

                                cmd.ExecuteNonQuery();

                            }



                            for (int i = 0; i < blockchains.Count; i++)
                            {
                                conn.Close();
                                conn.Open();
                                query = "UPDATE blockchain SET owner = @username WHERE nonce = @nonce AND previoushash = @previoushash";
                                cmd = new MySqlCommand(query, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Parameters.AddWithValue("@username", username);
                                cmd.Parameters.AddWithValue("@nonce", blockchains[i].Item1);
                                cmd.Parameters.AddWithValue("@previoushash", blockchains[i].Item2);
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

                        }
                        else
                        {

                            SendLabel.Content = "Failed";
                            //charge.Invoice.ToJson();
                        }





                    }
                    catch (StripeException ex)
                    {
                        SendLabel.Content = ex.Message;
                    }

                    
                }
                else
                {
                    SendLabel.Content = "Not Enough WolfCoins at that Price";
                    conn.Close();
                }
            }
            catch (MySqlException en)
            {
                SendLabel.Content = en.Message;
            }

        }
    }
}
