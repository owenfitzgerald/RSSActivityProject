using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS_Activity_Project
{
    public class RSSGetter
    {
        public string Get_RSS(string filePath, int daysAgo)
        {
            //Initialize Variables
            List<string> outputList = new List<string>();
            DateTime now = DateTime.Now;
            //declare Dictionary with input filepath
            RSSDictionary dictionary = new RSSDictionary(filePath);

            //read in file
            String fileString = dictionary.RetrieveDictionary();

            //parse dictionary
            dictionary.setDictionary(fileString);

            //get feeds from dictionary
            dictionary.getFeeds();

            //get postBy date
            DateTime postBy = now.AddDays(-daysAgo);
            //add feeds without posts to output
            foreach (var company in dictionary.postDict)
            {
                if (company.Value < postBy) outputList.Add(company.Key);
            }

            var result = $"The following companies have not posted in the past {daysAgo} days: \n" + String.Join(", ", outputList.ToArray());
            return result;
        }
    }
}
