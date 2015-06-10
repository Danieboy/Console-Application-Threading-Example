using System;
using System.Threading;

namespace ConsoleApplicationThreadidngExample
{
    class ThreadCreationProgram
    {
        public static void CallToChildThread()
        {
            try
            {
                Console.WriteLine("Thread starts");

                //Counting to 10
                for (int counter = 0; counter <= 10; counter++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(counter);
                }

                Console.WriteLine("Thread Completed");
            }

            catch (ThreadAbortException e)
            {
                Console.WriteLine("Thread Abort Exception");
            }
            finally
            {
                Console.WriteLine("Couldn't catch the Thread Exception");
            }
        }

        static void Main(string[] args)
        {
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("In Main: Creating the thread");
            Thread childThread = new Thread(childref);
            childThread.Start();

            //Stop the main thread for some time
            Thread.Sleep(3500);

            //Now abort the child
            Console.WriteLine("In Main: Aborting the thread");

            childThread.Abort();
            Console.ReadKey();
        }
    }
}