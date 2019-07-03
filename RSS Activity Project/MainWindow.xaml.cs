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
            Get_RSS();
        }

        public void Get_RSS()
        {
            //Initialize Variables
            outputBox.Text = "";
            List<string> outputList = new List<string>();
            String filePath = URLBox.Text;
            DateTime now = DateTime.Now;
            //declare Dictionary with input filepath
            RSSDictionary dictionary = new RSSDictionary(filePath);

            //ensure valid days input
            bool isNumeric = int.TryParse(daysBox.Text, out int daysAgo);
            if (!isNumeric) return;

            //read in file
            String fileString = dictionary.RetrieveDictionary();
            //output info
            outputBox.Text += "Reading File...\n";
            outputBox.Text += fileString + "\n";

            //parse dictionary
            dictionary.setDictionary(fileString);
            //output info
            outputBox.Text += "Parsing Dictionary...\n";

            //get feeds from dictionary
            dictionary.getFeeds();
            outputBox.Text += "Getting Posts...\n";
            foreach (var item in dictionary.postDict)
            {
                outputBox.Text += item + "\n";
            }

            //get postBy date
            DateTime postBy = now.AddDays(-daysAgo);
            //add feeds without posts to output
            foreach (var company in dictionary.postDict)
            {
                if (company.Value < postBy) outputList.Add(company.Key);
            }

            var result = $"\nThe following companies have not posted in the past {daysAgo} days: \n" + String.Join(", ", outputList.ToArray());
            outputBox.Text += result;
        }

        
    }
}
