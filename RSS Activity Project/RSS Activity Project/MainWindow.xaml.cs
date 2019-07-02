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

namespace RSS_Activity_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonPress(object sender, RoutedEventArgs e)
        {
            //Initialize Variables
            outputBox.Text = "";
            var outputList = new List<string>();
            var filePath = URLBox.Text;
            var dictionary = new RSSDictionary(filePath);

            var fileString = dictionary.RetrieveDictionary();
            
            outputBox.Text += "Reading File...\n";
            outputBox.Text += fileString;

            var result = String.Join(",", outputList.ToArray());
            outputBox.Text += result;
        }

    }
}
