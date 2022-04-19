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
using System.Diagnostics;
using System.IO;
using Microsoft.Scripting.Hosting;
using System.Net.Http;
using System.Net;
using MySql.Data.MySqlClient;
using WolfCoin;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Threading;

namespace WolfCoin.MVVVM.View
{

/// <summary>
/// Interaction logic for HomeView.xaml
/// </summary>
    public partial class HomeView : UserControl
    {
        private string uid;
        string connString;
        MySqlConnection conn;
        
        public HomeView()
        {
            InitializeComponent();
            connString = Convert.ToString(Properties.Settings.Default.Properties["ConnectionString"].DefaultValue);
        }

        private void ViewWalletButton_Click(object sender, RoutedEventArgs e)
        {
            LoadingSymbol.IsLoading = true;
            getUsername();
            updateWallet();
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                string query = "SELECT COUNT(*) FROM blockchain WHERE Owner=@username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@username", uid);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            LoadingSymbol.IsLoading = false;
        }

        private void MineButton_Click(object sender, RoutedEventArgs e)
        {

            if (AmountToMineTextBox.Text != null)
            {
                for(int i=0;i< Convert.ToInt32(AmountToMineTextBox.Text);i++)
                {
                    ViewMiningLabel.Content = "";
                    LoadingSymbol.IsLoading = true;
                    connString = Convert.ToString(Properties.Settings.Default.Properties["ConnectionString"].DefaultValue);
                    getUsername();
                    string result;



                    Console.WriteLine("Making API Call...");
                    using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
                    {
                        client.BaseAddress = new Uri("http://wolf-coin.us/test/");
                        HttpResponseMessage response = client.GetAsync("mine").Result;
                        response.EnsureSuccessStatusCode();
                        result = response.Content.ReadAsStringAsync().Result;
                    }

                    if (result != "{\"message}\": \"Block did not mine.\"}")
                    {


                        var getResult = JObject.Parse(result);
                        string index = getResult.Value<string>("index");
                        string timestamp = getResult.Value<string>("timestamp");
                        string nonce = getResult.Value<string>("nonce");
                        string previoushash = getResult.Value<string>("previous_hash");
                        ViewMiningLabel.Content = "Last Block Mined: " + "\nTimestamp: " + timestamp + "\nNonce: " + nonce + "\nPrevious Hash: " + previoushash;
                        try
                        {
                            conn = new MySqlConnection();
                            conn.ConnectionString = connString;

                            using (conn)
                            {
                                conn.Open();

                                string query = "INSERT INTO blockchain(blockIndex, blockTimeStamp, nonce, previoushash, Owner) VALUES(@index, @timestamp, @nonce, @previoushash, @Owner)";
                                MySqlCommand cmd = new MySqlCommand(query, conn);
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Parameters.AddWithValue("@Owner", uid);
                                cmd.Parameters.AddWithValue("@index", index);
                                cmd.Parameters.AddWithValue("@timestamp", timestamp);
                                cmd.Parameters.AddWithValue("@nonce", nonce);
                                cmd.Parameters.AddWithValue("@previoushash", previoushash);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                        conn.Close();
                        updateWallet();
                    }
                    LoadingSymbol.IsLoading = false;
                    //Thread.Sleep(5000);
                }
            }
        }

        public void getUsername()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.Title != null && item.Title.Length > 5)
                {
                    uid = item.Title;
                    break;

                }
            }
        }


        public void updateWallet()
        {
            string updateString;

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                string query = "SELECT COUNT(*) FROM blockchain WHERE Owner=@username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@username", uid);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                updateString = Convert.ToString(dr.GetInt32(0));

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                string query = "UPDATE wallet SET balance = @updateString WHERE uid = @uid";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@updateString", updateString);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.BeginExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            ViewWalletLabel.Content = "Wallet Balance: " + updateString;

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




    }

}
