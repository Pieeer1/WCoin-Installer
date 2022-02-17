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
using IronPython.Hosting;
using System.Diagnostics;
using System.IO;

namespace WolfCoin.MVVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void ViewWalletButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");

            Option2_IronPython();


        }
        static void Option2_IronPython()
        {
            var engine = Python.CreateEngine();

            var script = "..\\..\\Python\\Main.py";
            var source = engine.CreateScriptSourceFromFile(script);

            var argv = new List<string>();
            argv.Add("");

            engine.GetSysModule().SetVariable("argv", argv);


            var eIO = engine.Runtime.IO;

            var errors = new MemoryStream();
            eIO.SetErrorOutput(errors, Encoding.Default);

            var results = new MemoryStream();
            eIO.SetOutput(results, Encoding.Default);


            var scope = engine.CreateScope();

            source.Execute(scope);


            string str(byte[] x) => Encoding.Default.GetString(x);

            Console.WriteLine("Errors: ");
            Console.WriteLine(str(errors.ToArray()));
            Console.WriteLine();
            Console.WriteLine("Results: ");
            Console.WriteLine(str(results.ToArray()));


        }


    }
}
