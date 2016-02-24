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
        /*
         * Stream Architecture:
         * ***********************************************************************************************
         * Stream Adapter:       StreamReader/SteamWriter, BinaryReader/BinaryWriter, XMLReader/XMLWriter
         *       _|_
         * Decorator Stream:     GZip Stream, Crypto Stream, Buffered Stream, Deflate Stream
         *       _|_
         * Backing Store Stream: FileStream, Memory Stream, Network Stream, IsolatedStorageStream
         * * ***********************************************************************************************
         * 
         * Stream is the abstract class that provides a generic view of sequence of files, i.e. FileStream
         * provides a stream for a file.
         * Decorator provides a binary transformation like encryption or compression.
         * Adapter wraps a stream in a class providing methods typed to a specific format (i.e. XML)
         */

        #region ISample Members

        public string Descripton
        {
            get { return "Stream in C#"; }
        }

        public void Run()
        {
            DemoBackingStoreStream();

        }

        #endregion

        private void DemoBackingStoreStream() {
            
            using (FileStream fs = new FileStream("stream1.out", FileMode.Create))
            {
                Console.WriteLine("Can read: {0}", fs.CanRead);
                Console.WriteLine("Can read: {0}", fs.CanWrite);
                Console.WriteLine("Current position of the stream {0}", fs.Position);

                // Write bytes
                Console.WriteLine("Write two bytes to the stream");
                fs.WriteByte(byte.Parse("45"));
                fs.WriteByte(byte.Parse("12"));
                Console.WriteLine("Current position of the stream {0}", fs.Position);

                // Read one byte
                fs.Seek(0, SeekOrigin.Begin);               
                int val = fs.ReadByte();
                Console.WriteLine("Read the first byte: {0}", val.ToString());
                // Read array of bytes
                fs.Seek(0, SeekOrigin.Begin);
                byte[] barray = new byte[10];
                int counted = fs.Read(barray, 0, barray.Length);
                Console.WriteLine("Read from the beginning of the stream {0} bytes", counted);
                for (int i = 0; i < counted; i++) {
                    Console.WriteLine("Byte[{0}] = {1}", i, barray[i]);
                }
                
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

    }
}
