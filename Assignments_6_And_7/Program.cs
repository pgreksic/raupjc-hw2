using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_6_And_7
{
    class Program
    {
        private static async void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private static async Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuy();
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await IKnowWhoKnowsThis(10) + await IKnowWhoKnowsThis(30);
        }

        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return await FactorialDigitSum(n);
        }

        // Ignore this part .
        static void Main(string[] args)
        {
            // Main method is the only method that
            // can ’t be marked with async .
            // What we are doing here is just a way for us to simulate
            // async - friendly environment you usually have with
            // other . NET application types ( like web apps , win apps etc .)
            // Ignore main method , you can just focus on LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in the call hierarchy .
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        private static async Task<int> FactorialDigitSum(int number)
        {
            int factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            int sumOfDigits = 0;

            do
            {
                sumOfDigits += factorial % 10;
                factorial = factorial / 10;

            } while (factorial > 0);

            return sumOfDigits;
        }
    }
}
