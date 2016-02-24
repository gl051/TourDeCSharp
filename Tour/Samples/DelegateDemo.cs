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
    

    // A delegate is a type that represents reference to methods with a specific signature and return type
    // Let's define a StringDoSomething type:
    public delegate void StringManipulatorDelegate(String strInput); // you have  define the type 

    
    public class DelegateDemo : ISample
    {
        
        #region ISample Members

        public string Descripton
        {
            get { return "Delegate demos."; }
        }

        public void Run()
        {
            BroadcastingExample();
            
        }

        #endregion

     
        static void Example1()
        {
            /*
            string[] names = { "Gianluca", "Lisa", "Sofia", "Antonio" };

            // Instanciate and calling a delegate 
            Magician.MagicNumberDelegate myDelFunction = Util.MyMagicNumberFormula;
            myDelFunction("dummy call");

            

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
            
             */ 
            
        }
        
        static void Example2()
        {
            /*
            // A delegate can refer to more functions and all of them will be executed when called (multicasting)
            Broadcaster.broadcastDelegate mydel = Util.MyHello1;
            mydel += Util.MyHello2;
            mydel += Util.MyHello3;
            Broadcaster.RunMultiCast(mydel);

            // Unregister a function
            Console.WriteLine("Unregister a function");
            mydel -= Util.MyHello1;
            Broadcaster.RunMultiCast(mydel);
             */
        }

        private void BroadcastingExample() {
            String cityName = "San Francisco";
            Console.WriteLine("Using delegates to broadcast a string manipulation: {0}", cityName);
            
            // A delegate instance is a referece (similar to a pointer) to one or more methods
            StringManipulatorDelegate del = null;
            
            // First method to be delegated to executem, it's a reference and not call to the method.
            del += ReverseMyString;
            // Another one added (order of execution is the same as the addition)
            del += UpperMyString;
            // One more method to add
            del += RemoveVowelsMyString;
            
            // Calling the delegate, broadast the call to all delegated functions
            del(cityName);

            // Remove a delegate method
            del -= RemoveVowelsMyString;

            del(cityName);
        }

        private void PluginMethodExample() { 
            string name = "New York City";

            // You can use delegate to plug-in method at runtime
            DelegateDemo.Tranform(name, UpperMyString); 
            // 
            DelegateDemo.Tranform(name, UpperMyString);
            DelegateDemo.Tranform(name, UpperMyString);
            
        }

        public static void Tranform(String name, StringManipulatorDelegate del) {
            del(name);
        }

        # region Private Methods
        private void ReverseMyString(String strInput)
        {
            Console.WriteLine(strInput.Reverse().ToArray());
        }

        private void UpperMyString(String strInput)
        {
            Console.WriteLine(strInput.ToUpper());
        }

        private void RemoveVowelsMyString(String strInput)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            foreach (char c in strInput)
            {
                if (vowels.Contains(c) == false)
                    Console.Write(c);
            }

            Console.WriteLine();
        }
        #endregion

    }

   

   

   

}
