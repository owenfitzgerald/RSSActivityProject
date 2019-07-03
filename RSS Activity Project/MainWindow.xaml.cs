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
            String filePath = URLBox.Text;
            RSSGetter getter = new RSSGetter();

            //ensure valid days input
            bool isNumeric = int.TryParse(daysBox.Text, out int daysAgo);
            if (!isNumeric) return;

            //temporarily set text
            outputBox.Text = "Fetching...";

            //Get info from classes
            string result = getter.Get_RSS(filePath, daysAgo);
            outputBox.Text = result;
        }

        
    }

}
