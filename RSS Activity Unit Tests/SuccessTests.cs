using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace RSS_Activity_Tests
{
    [TestClass]
    public class SuccessTests
    {
        [TestMethod]
        public void SuccessTest()
        {
            //
            //ONLY WORKS WITH EXPECTED RESULT UNTIL FEEDS ARE UPDATED. NEED TO MANUALLY UPDATED EXPECTED
            //
            //Expected Result
            const string Expected = "The following companies have not posted in the past 1 days: \nBill Maher, NBC";

            //Create new Program Instance
            var RSSfeed = new RSS_Activity_Project.RSSGetter();
            //Initialize Variable
            string filePath = @"..\..\..\\RSS Activity Project\RSS_Dictionary2.txt";
            int daysAgo = 1;

            //run program
            string result = RSSfeed.Get_RSS(filePath, daysAgo);

            //Assert statement
            Assert.AreEqual(Expected, result);

        }
    }
}
