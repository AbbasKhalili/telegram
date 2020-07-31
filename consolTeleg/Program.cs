using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consolTeleg
{
    class Program
    {
        static void Main(string[] args)
        {

            var t = new Telegcs();
            t.Connect();
            Console.WriteLine("Conected OK!");
            //t.Authentication();
            Console.WriteLine("Authentication OK!");
            Console.WriteLine("Enter Text to send : ");
            var msg1 = Console.ReadLine();
            while (msg1 != "x")
            {
                var msg = Console.ReadLine();
                t.SendMessage(msg);
                Console.WriteLine("Message has been sent.");
                msg1 = msg;
            }
            Console.ReadLine();
        }
    }
}
