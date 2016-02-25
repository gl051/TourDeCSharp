using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gl051.Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            ISample s = GetSample();
            Console.WriteLine(s.Descripton);
            s.Run();
            Console.Out.WriteLine("Sample ended, press enter for finish.");
            Console.WriteLine("Press a key to close ...");
            Console.ReadKey();
        }

        static ISample GetSample() {
            return new Samples.EncodingConvertDemo();
        }
    }
}
