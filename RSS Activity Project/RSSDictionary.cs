using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Text;
using System.Threading.Tasks;

namespace RSS_Activity_Project
{
    public class RSSDictionary
    {
        public string filePath { get; set; }
        public Dictionary<String,String[]> dictionary { get; set; }
        public Dictionary<String,DateTime> postDict { get; set; }
        public RSSDictionary(String filepath)
        {
            filePath = filepath;
        }


        //Method to retrieve dictionary from file
        public String RetrieveDictionary()
        {
            //check input
            if (System.IO.File.Exists(filePath) == false)
            {
                //return DNE error
                return "File does not exist";
            }

            //read file
            string text = System.IO.File.ReadAllText(filePath);
            //check for empty
            if (text == "")
            {
                //return empty error
                return "Empty file";
            }

            //return success
            return text;
        }

        public void setDictionary(string inputString)
        {
            //initialize new dictionary
            dictionary = new Dictionary<string, string[]>();

            //parse file into list
            List<string> valueList = inputString.Split('\n').ToList();
            //for each item in list split into Company, URL and add to Dict
            foreach (var feed in valueList)
            {
                //if company already has a feed, add feed
                string[] values = feed.Split(',');
                if (dictionary.ContainsKey(values[0]))
                    dictionary[values[0]].Append(values[1]);
                else //else create key for company and add feed
                    dictionary.Add(values[0], new string[] { values[1]});
            }
        }

        public void getFeeds()
        {
            //Initialize postDict
            postDict = new Dictionary<string, DateTime>();
            //for each item in dictionary
            foreach (var company in dictionary)
            {
                //initialize variable for timestamp
                DateTime latestPost = new DateTime();
                //for each feed by company
                foreach (var feed in company.Value)
                {
                    //set reader settings
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.DtdProcessing = DtdProcessing.Parse;
                    settings.MaxCharactersFromEntities = 1024;
                    //initialize reader
                    using (var reader = XmlReader.Create(feed,settings))
                    {
                        //initialize feed using reader 
                        SyndicationFeed syndicationFeed = SyndicationFeed.Load(reader);
                        //store items array
                        var syndicationItems = syndicationFeed.Items.ToArray();
                        //get latest post date if it is sooner than the previous feed's latest post
                        if (latestPost < syndicationItems[0].PublishDate.Date)
                        {
                            latestPost = syndicationItems[0].PublishDate.Date;
                        }
                    }

                }

                //add feeds to dictionary
                postDict.Add(company.Key, latestPost);
            }
        }

    }
}
