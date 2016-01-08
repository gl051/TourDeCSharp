using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gl051.Tour.Samples
{
    /* DELEGATES:
     * Any method that matches the delegate's signature, which consists of the return type and parameters, 
     * can be assigned to the delegate. This makes is possible to programmatically change method calls, 
     * and also plug new code into existing classes. As long as you know the delegate's signature, you can 
     * assign your own delegated method.
     * This ability to refer to a method as a parameter makes delegates ideal for defining (asynchronous) 
     * callback methods. 
     * 
     * For example, a sort algorithm could be passed a reference to the method that compares two objects. 
     * Separating the comparison code allows the algorithm to be written in a more general way.
    */
    

    public class DelegateDemo : ISample
    {
        
        #region ISample Members

        public string Descripton
        {
            get { return "Delegate demos."; }
        }

        public void Run()
        {
 	        throw new NotImplementedException();
        }

        #endregion

        static void Example1()
        {
            string[] names = { "Gianluca", "Lisa", "Sofia", "Antonio" };

            // Instanciate and calling a delegate 
            Magician.MagicNumberDelegate myDelFunction = Util.MyMagicNumberFormula;
            myDelFunction("dummy call");

            /**********************************/
            /* Delegate passed as parameter   */
            /**********************************/

            // 1) I can use a function 
            int[] mnA = Magician.GetMagicArray(names, Util.MyMagicNumberFormula);

            // 2) I can pass a delegate instance
            int[] mnZ = Magician.GetMagicArray(names, myDelFunction);

            // 3) I can use a lamba expression 
            int[] mnB = Magician.GetMagicArray(names, (str) => { return str.Length; });

            for (int k = 0; k < names.Length; k++)
            {
                Console.WriteLine("{0} magic number = {1}", names[k], mnA[k]);
                Console.WriteLine("{0} magic number = {1}", names[k], mnZ[k]);
                Console.WriteLine("{0} magic number = {1}", names[k], mnB[k]);
            }
        }

        static void Example2()
        {
            // A delegate can refer to more functions and all of them will be executed when called (multicasting)
            Broadcaster.broadcastDelegate mydel = Util.MyHello1;
            mydel += Util.MyHello2;
            mydel += Util.MyHello3;
            Broadcaster.RunMultiCast(mydel);

            // Unregister a function
            Console.WriteLine("Unregister a function");
            mydel -= Util.MyHello1;
            Broadcaster.RunMultiCast(mydel);
        }
    }

    static class Magician
    {
        public delegate int MagicNumberDelegate(string str);

        // We use a delegate to wire up dinamically a function to the execution of the method.
        // Calling this method will requires to provide the function to the fmagic delegate.
        // This class is so more generic and doesn't know how the MagicNumber is provided,
        // dinamically you have control on what will be executed by passing a different function 
        // (decoupling)

        public static int[] GetMagicArray(string[] names, MagicNumberDelegate fmagic)
        {
            int[] arrOutput = new int[names.Length];

            for (int i = 0; i < arrOutput.Length; i++)
            {
                arrOutput[i] = fmagic(names[i]);
            }

            return arrOutput;
        }

    }

    class Broadcaster
    {
        public delegate void broadcastDelegate();

        public static void RunMultiCast(broadcastDelegate del)
        {
            // Only need to call the delegate and the action will be broadcasted 
            // to all the functions registered at the delegate instance
            del();
        }
    }

    class Util
    {
        public static int MyMagicNumberFormula(string str)
        {
            return 5;
        }

        public static void MyHello1()
        {
            Console.WriteLine("Hello1 at " + System.DateTime.Now.ToString("hh:mm:ss:ff"));
            System.Threading.Thread.Sleep(500);
        }

        public static void MyHello2()
        {
            Console.WriteLine("Hello2 at " + System.DateTime.Now.ToString("hh:mm:ss:ff"));
        }

        public static void MyHello3()
        {
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Hello3 at " + System.DateTime.Now.ToString("hh:mm:ss:ff"));
        }
    }

}
