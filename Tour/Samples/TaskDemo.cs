using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gl051.Tour.Samples
{
    class TaskDemo : ISample
    {
        const int NUM_MESSAGES = 10;
        
        #region ISample Members

        public string Descripton
        {
            get { return "Task Demo"; }
        }

        public void Run()
        {
            // When you create a task object you provide the code to be run by the task when it runs.
            // This can be provided as anonymous funtion (thourgh a lambda expression), or you can use
            // a method already available and provide the delegate via the Action constructor;
            // 1. Anymous function
            Task task1 = new Task(() =>
            {
                for (int i = 0; i < NUM_MESSAGES; i++)
                {
                    Console.WriteLine("This is task number 1");
                    System.Threading.Thread.Sleep(1200);
                }

                Console.Out.WriteLine("Task 1 ended");
                
            });

            Task task2 = new Task(new Action(MyTaskFunction));

            task1.Start();
            task2.Start(); 
        }

        #endregion

        private void MyTaskFunction()
        {
            for (int i = 0; i <= NUM_MESSAGES; i++)
            {
                Console.WriteLine("This is task number 2;");
                System.Threading.Thread.Sleep(1350);
            }

            Console.Out.WriteLine("Task 2 ended");
        }
    }
}
