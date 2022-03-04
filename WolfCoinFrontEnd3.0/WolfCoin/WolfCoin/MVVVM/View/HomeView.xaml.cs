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
namespace WolfCoin.MVVVM.View
{

/// <summary>
/// Interaction logic for HomeView.xaml
/// </summary>
    public partial class HomeView : UserControl
    {
        private string uid;
        private string connString = "SERVER= 68.178.247.52;PORT= 3306;DATABASE=wolfcoinlogin_db;USERNAME = Pieeer1;PASSWORD = 456456";
        MySqlConnection conn;
        
        public HomeView()
        {
            InitializeComponent();

        }

        private void ViewWalletButton_Click(object sender, RoutedEventArgs e)
        {
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
                MessageBox.Show(Convert.ToString(dr.GetInt32(0)));
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error With Connection");

            }

        }

        private void MineButton_Click(object sender, RoutedEventArgs e)
        {

            getUsername();
            string result;

            Console.WriteLine("Making API Call...");
            MessageBox.Show("Mining.....");
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
                try
                {
                    conn = new MySqlConnection();
                    conn.ConnectionString = connString;
                    conn.Open();

                    string query = "INSERT INTO blockchain(blockIndex, blockTimeStamp, nonce, previoushash, Owner) VALUES(@index, @timestamp, @nonce, @previoushash, @Owner)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Owner", uid);
                    cmd.Parameters.AddWithValue("@index", index);
                    cmd.Parameters.AddWithValue("@timestamp", timestamp);
                    cmd.Parameters.AddWithValue("@nonce", nonce);
                    cmd.Parameters.AddWithValue("@previoushash", previoushash);
                    cmd.BeginExecuteNonQuery();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error, Could not Connect");

                }
                updateWallet();
            }
        }

        public void getUsername()
        {
            foreach (Window item in Application.Current.Windows)
            {
                if (item.Title != null && item.Title.Length >= 5)
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
                MessageBox.Show("Error With Connection");
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
                MessageBox.Show("Error, Could not Connect");

            }


        }


    }

}
