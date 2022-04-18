using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class UserChoice
    {
        public static string StringRequest(string requested)
        {
            Console.Write("Enter " + requested + ": ");
            string input = Console.ReadLine();
            return input;
        }
        public static int NumberRequested(string requested)
        {
            while(true)
            {
                string input = StringRequest(requested);
                int result;
                if(!int.TryParse(input, out result))
                {
                    Console.WriteLine("Please use valid input");
                    continue;
                }

                return result;
            }    
        }
    }
}
