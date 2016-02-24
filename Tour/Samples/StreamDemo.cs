using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gl051.Tour.Samples
{
    public class StreamDemo : ISample
    {

        #region ISample Members

        public string Descripton
        {
            get { return "Stream in C#"; }
        }

        public void Run()
        {
            using (FileStream fs = new FileStream("stream1.out", FileMode.Create))
            {
                Console.WriteLine("Can read: {0}", fs.CanRead);
                Console.WriteLine("Can read: {0}", fs.CanWrite);
                Console.WriteLine(fs.Position);

                // Write bytes
                fs.WriteByte(byte.Parse("45"));
                fs.WriteByte(byte.Parse("12"));
                Console.WriteLine(fs.Position);

                // Read bytes
                fs.Seek(0, SeekOrigin.Begin);
                Console.WriteLine(fs.Position);
                // Read one byte
                int val = fs.ReadByte();
                Console.WriteLine(val.ToString());
                // Read array of bytes
                fs.Seek(0, SeekOrigin.Begin);
                byte[] barray = new byte[10];
                var c = fs.Read(barray, 0, barray.Length);
                BitConverter.ToInt16(barray, 0);
            }

            using (FileStream fs = File.OpenWrite("stream2.out"))
            {
                string msg = "Hello World, from San Francisco";
                byte[] barray = Encoding.UTF8.GetBytes(msg);
                fs.Write(barray, 0, barray.Length);
            }

            using (FileStream fs = File.OpenRead("stream2.out"))
            {
                byte[] barray = new byte[1000];
                int chunk = fs.Read(barray, 0, barray.Length);
                Array.Resize<byte>(ref barray, chunk);
                string msg = Encoding.UTF8.GetString(barray);
            }

        }

        #endregion


    }
}
