using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringsAndLanguagesApp.ClosureKleen
{
    static class Kleen
    {        
        public const string CHOOSE_BASE_STRUCTURE_PATTERN = "^[TSst]$";
        public const string SIZE_STRUCTURE_PATTERN = "^[123]$";
        public const string EMPTY_ELEMENT = "∅";
        public const string EMPTY_STRING = "";
        public const int MAX_PERMUTATION = 10;

        public static string ChooseSetOrTuple()
        {
            string isSetOrTuple;


            while (true)
            {
                Console.WriteLine("Choose your base structure:\n[S] for Set\n[T] for Tuple");
                isSetOrTuple = Console.ReadLine();
                if (Regex.IsMatch(isSetOrTuple.ToString(), CHOOSE_BASE_STRUCTURE_PATTERN))
                {
                    break;
                }
            }

            return isSetOrTuple;
        }

        public static int ReadSize()
        {
            string size;

            while (true)
            {
                Console.WriteLine("Insert size (Min 1, Max 3): ");
                size = Console.ReadLine();
                if (Regex.IsMatch(size, SIZE_STRUCTURE_PATTERN))
                {
                    break;
                }
            }

            return Int32.Parse(size);
        }


        public static List<string> BuildClosureKleen(string choose, char[] elements)
        {
            string TUPLE_CHOOSE = "T";
            string SET_CHOOSE = "S";

            if (choose.ToUpper().Equals(SET_CHOOSE))
            {
                return AssembleKleenWithSet(elements);
            }
            else if (choose.ToUpper().Equals(TUPLE_CHOOSE))
            {
                return AssembleKleenWithTuple(elements);
            }
            else {
                return null;
            }
        }

        public static List<string> AssembleKleenWithSet(char[] charSequence)
        {
            char[] elementGenerated = new char[10];
            List<String> kleenResult = new List<string>();
            kleenResult.Add(EMPTY_ELEMENT);
            
            // Add to array result each element from charSequence
            foreach (char character in charSequence)
            {
                kleenResult.Add(character.ToString());
            }

            int setKleenSize = kleenResult.Count;
            var random = new Random();

            // Generate a permutation
            for (int i = 0; i < MAX_PERMUTATION; i++)
            {
                int nextRandom = random.Next(0, charSequence.Length);
                elementGenerated[i] = charSequence[nextRandom];               
                string permutation = StringsCore.String.Alpha(elementGenerated);
                if (kleenResult.Any(element => element == permutation))
                {
                    i--;
                }
                else
                {
                    kleenResult.Add(permutation);

                }
            }
            return kleenResult;
        }

        public static List<string> AssembleKleenWithTuple(char[] charSequence)
        {
            char[] elementGenerated = new char[charSequence.Count()];
            List<String> kleenResult = new List<string>();
            kleenResult.Add(EMPTY_ELEMENT);
            string basicElement = EMPTY_STRING;
            string permutation = EMPTY_STRING;

            // Add to array result each element from charSequence
            for (int i = 0; i < charSequence.Count(); i++)
            {
                elementGenerated[i] = charSequence[i];
            }
            basicElement = StringsCore.String.Alpha(elementGenerated);
            kleenResult.Add(basicElement);
            
            for (int i = 0; i < MAX_PERMUTATION; i++) {
                permutation = permutation + basicElement;
                kleenResult.Add(permutation);
            }

            return kleenResult;
        }
    }
}
