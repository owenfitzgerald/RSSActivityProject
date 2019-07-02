using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSS_Activity_Project
{
    public class RSSDictionary
    {
        public string filePath { get; set; }
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
            Console.WriteLine(text);
            //check for empty
            if (text == "")
            {
                //return empty error
                return "Empty file";
            }

            //return success
            return text;
        }

    }
}
