using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RSS_Activity_Tests
{
    [TestClass]
    public class DictionaryTests
    {
        [TestMethod]
        public void TestDictionaryCreation()
        {
            //Expected Result
            Dictionary<String,String[]> Expected = new Dictionary<string, string[]>();
            Expected.Add("BBC", new string[] { "http://feeds.bbci.co.uk/news/rss.xml" });

            //Create and attempt to read dictionary
            var dictionary = new RSS_Activity_Project.RSSDictionary(@"..\..\..\..\\RSS Activity Project\RSS_Dictionary1.txt");
            var fileString = dictionary.RetrieveDictionary();
            dictionary.setDictionary(fileString);
            var result = dictionary.dictionary;

            //Assert statement
            Assert.AreEqual(Expected.Count, result.Count);

        }
    }
}
