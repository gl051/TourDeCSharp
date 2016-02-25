using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gl051.Tour.Samples
{
    class EncodingConvertDemo : ISample
    {

        #region ISample Members

        public string Descripton
        {
            get { return "Enconding and byte conversion"; }
        }

        public void Run()
        {
            StringToHex();
        }

        #endregion

        private void StringToHex() {
            Console.Out.WriteLine("Find the HEX respresentation of a string");
            string str = "San Francisco";
            byte[] ba = Encoding.Default.GetBytes(str);
            string hexstr = BitConverter.ToString(ba);
            Console.WriteLine("String: {0}", str);
            Console.WriteLine("HEX value: {0}", hexstr);
        }
    }
}
