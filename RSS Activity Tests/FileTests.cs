using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RSS_Activity_Tests
{
    [TestClass]
    public class FileTests
    {
        
        [TestMethod]
        public void TestFileDNE()
        {
            //Expected Result
            const string Expected = "File does not exist";
            
            //Create and attempt to read dictionary
            var dictionary = new RSS_Activity_Project.RSSDictionary(@"");
            var result = dictionary.RetrieveDictionary();

            //Assert statement
            Assert.AreEqual(Expected, result);

        }

        [TestMethod]
        public void TestFileEmpty()
        {
            //Expected Result
            const string Expected = "Empty file";

            //Create and attempt to read dictionary
            var dictionary = new RSS_Activity_Project.RSSDictionary(@"..\..\..\..\\RSS Activity Project\RSS_Dictionary0.txt");

            var result = dictionary.RetrieveDictionary();

            //Assert statement
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void TestFileSuccess()
        {
            //Expected Result
            const string Expected = "BBC, http://feeds.bbci.co.uk/news/rss.xml";

            //Create and attempt to read dictionary
            var dictionary = new RSS_Activity_Project.RSSDictionary(@"..\..\..\..\\RSS Activity Project\RSS_Dictionary1.txt");

            var result = dictionary.RetrieveDictionary();

            //Assert statement
            Assert.AreEqual(Expected, result);
        }

    }
}

