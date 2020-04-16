using StringsAndLanguagesApp.ClosureKleen;
using System;
using System.Collections.Generic;

namespace StringsAndLanguagesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string isSetOrTuple = Kleen.ChooseSetOrTuple();
            int size = Kleen.ReadSize();
            char[] elements = StringsCore.String.DefineCharSequence(size);
            List<string> kleenResult = Kleen.BuildClosureKleen(isSetOrTuple, elements);

            Show(kleenResult);
            Console.ReadKey();
        }

        public static void Show(List<string> itemsToShow)
        {
            foreach (var item in itemsToShow)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}