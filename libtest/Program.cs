using System;

namespace libtest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if(args.Length<1)
                {
                    Usage();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: {0}",ex.GetType().FullName);
                Console.WriteLine("Message: {0}",ex.Message);
                Console.WriteLine("Stack: {0}",ex.StackTrace);
            }
        }

        private static void Usage()
        {
            Console.WriteLine("usage: libtest <arg list>");
        }
    }
}
