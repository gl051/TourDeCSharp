using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gl051.Tour.Samples
{
    class TokenParser : ISample
    {
        #region ISample Members

        public string Descripton
        {
            get { return "Parse a string to extract configuration data based on tokens";  }
        }

        public void Run()
        {
            const char CHAR_SEPARATOR = ';';
            const string TOKEN = "GroupId";
            String inputString = "DataSource=ABC.XYZ.123;Credentials=QSRC001;GroupId=134506;";

            // Cleaning the string
            inputString = inputString.Trim();
            inputString = inputString.TrimEnd(CHAR_SEPARATOR);

            // Build a dictionary mapping all values provided in the strings
            String[] elements = inputString.Split(CHAR_SEPARATOR);
            Dictionary<String, String> dict = elements.ToDictionary(e => e.Split('=')[0], e => e.Split('=')[1]);

            // When you have the dictionary you can look for a specific token, be sure to check token is a key
            String value;
            // --- check 1
            if (dict.Keys.Contains(TOKEN))
                value = dict[TOKEN];
            // --- check 2          
            dict.TryGetValue(TOKEN, out value);

            // Or you can go through the dictionary items to get them all
            foreach(var k in dict){
                Console.WriteLine("{0} = {1}", k.Key, k.Value);
            }
         
        }

        #endregion
    }

}
