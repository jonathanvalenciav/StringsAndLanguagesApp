using StringsAndLanguagesApp.Exceptions;
using System;

namespace StringsAndLanguagesApp.StringsCore
{
    static class String
    {
        public const string EMPTY_STRING = "";

        public static string AssembleString() {
            Console.WriteLine("Input your chars one by one to get an string.\nYou can to use alphabet or numbers that start at 0 to 9.\nTo close your input, please insert asterisk (*) and you can see your string.\n");
            //return Alpha(ReadInput());
            return "";
        }

        public static char[] DefineCharSequence(int numberOfElements) {
            char[] inputs = new char[numberOfElements];

            int charCounter = 0;
            while (true)
            {
                try
                {
                    Console.Write("[" + charCounter + "]: ");
                    char input = Convert.ToChar(Console.ReadLine());

                    if (StringUtils.isValid(input))
                    {
                        inputs[charCounter] = input;
                        charCounter++;
                    }
                    else
                    {
                        throw new InvalidInputException();
                    }

                    if (charCounter.Equals(numberOfElements))
                    {
                        return inputs;
                    }
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("Format used in your input is not valid. " + formatException.Message);
                }
                catch (InvalidInputException)
                {
                    Console.WriteLine("Format used in your input is not valid.");
                }                
            }
        }

        public static string Alpha(char[] chars)
        {
            string resultString = EMPTY_STRING;

            foreach (char aChar in chars)
            {
                resultString += aChar;
            }

            return resultString;
        }
    }
}
       
