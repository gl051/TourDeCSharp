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
            ISample s = new Samples.TokenParser();
            Console.WriteLine(s.Descripton);
            s.Run();
            Console.Out.WriteLine("Sample ended, press enter for finish.");
            Console.ReadLine();
        } 
    }
}
