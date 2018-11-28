using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //value = 5, count = 0
        //value = 5, count = 1
        //return value = 6, count = 1
        //value = 6, count = 2
        //return value 7, count = 2
        //value = 7, count = 3
        //return value = 8, count = 3
        //value = 8, count = 4
        //return value = 9, count = 4
        //value = 9, count = 5
        //return value = 10, count = 6,
        //return value

        

        static int Recursive(int value, ref string word) {
            word += "C";
            if (value >= 5){
                word 
                return Recursive(value + 1, ref word);
            }
            if (value >= 10) {
                return value;
            }

            return 0;
            
        }

        static void Main(string[] args)
        {

            string word = "";
            int total = Recursive(5, ref word);

            Console.WriteLine(total);
            Console.WriteLine(word);
            Console.ReadKey();

          
        }
    }
}
