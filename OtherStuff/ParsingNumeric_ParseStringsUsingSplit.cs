using System;
using System.Linq;

namespace HowToStrings
{
    public static class ParseStringsUsingSplit
    {
        Examples();
        public static void Examples()
        {
            Console.WriteLine("Example one");
            Console.WriteLine();
            ParseFormaProviders();

            Console.WriteLine("Example two");
            Console.WriteLine();
            ParseNumberstylesValues();

            Console.WriteLine("Example three");
            Console.WriteLine();
            UnicodeDigits();

            Console.WriteLine("Example four");
            Console.WriteLine();
            SplitWords();

            Console.WriteLine("Example five");
            Console.WriteLine();
            SplitWordsWithRepeatedSeparators();

            Console.WriteLine("Example six");
            Console.WriteLine();
            SplitOnMultipleChars();

            Console.WriteLine("Example seven");
            Console.WriteLine();
            SplitOnMultipleCharsWithGaps();

            Console.WriteLine("Example eight");
            Console.WriteLine();
            SplitUsingStrings();
        }

        private static void ParseFormaProviders()
        {
            
            string[] values = { "1,304.16", "$1,456.78", "1,094", "152",
                          "123,45 €", "1 304,16", "Ae9f" };
            double number;
            CultureInfo culture = null;

            foreach (string value in values)
            {
                //try to parse in the english US format
                try
                {
                    culture = CultureInfo.CreateSpecificCulture("en-US");
                    number = Double.Parse(value, culture);
                    Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number);
                }
                //if that fails announce it, then change the culture to france
                catch (FormatException)
                {
                    Console.WriteLine("{0}: Unable to parse '{1}'.",
                                      culture.Name, value);
                    culture = CultureInfo.CreateSpecificCulture("fr-FR");
                    // then try to parse the number into the French culture.
                    try
                    {
                        number = Double.Parse(value, culture);
                        Console.WriteLine("{0}: {1} --> {2}", culture.Name, value, number);
                    }
                    //if that fails announce that it failed
                    catch (FormatException)
                    {
                        Console.WriteLine("{0}: Unable to parse '{1}'.",
                                          culture.Name, value);
                    }
                }
                Console.WriteLine();
            }
            
        }

        private static void ParseNumberstylesValues()
        {
            
            string value = "1,304";
            int number;
            IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");
            //try to parse the value into an int32
            if (Int32.TryParse(value, out number))
                Console.WriteLine("{0} --> {1}", value, number);
            else
                Console.WriteLine("Unable to convert '{0}'", value);

            //it cannot be parsed because of the comma, so get around that by allowing thousands
            if (Int32.TryParse(value, NumberStyles.Integer | NumberStyles.AllowThousands,
                              provider, out number))
                Console.WriteLine("{0} --> {1}", value, number);
            else
                Console.WriteLine("Unable to convert '{0}'", value);
            
        }

        private static void UnicodeDigits()
        {
            // Define a string of Latin digits 0-9.
            //so we set the sting to unicode values 0-9
            value = "\u0030\u0031\u0032\u0033\u0034\u0035\u0036\u0037\u0038\u0039";
            ParseDigits(value);

            // Define a string of Fullwidth digits 0-9.
            value = "\uFF10\uFF11\uFF12\uFF13\uFF14\uFF15\uFF16\uFF17\uFF18\uFF19";
            ParseDigits(value);

            // Define a string of Arabic-Indic digits 0-9.
            value = "\u0660\u0661\u0662\u0663\u0664\u0665\u0666\u0667\u0668\u0669";
            ParseDigits(value);

            // Define a string of Bangla digits 0-9.
            value = "\u09e6\u09e7\u09e8\u09e9\u09ea\u09eb\u09ec\u09ed\u09ee\u09ef";
            ParseDigits(value);
        }

        static void ParseDigits(string value)
        {
            //then we try to parse the strings into int32
            try
            {
                int number = Int32.Parse(value);
                Console.WriteLine("'{0}' --> {1}", value, number);
            }
            //if it does not work because it is the wrong format we throw a massage
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse '{0}'.", value);
            }
        }

        private static void SplitWords()
        {
            
            string phrase = "The quick brown fox jumps over the lazy dog.";

            //split the string into an array via the spaces
            string[] words = phrase.Split(' ');

            //write each value in the array on a separate line
            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }
            
        }

        private static void SplitWordsWithRepeatedSeparators()
        {
            //same as  before but there are too many spaces, so there are too many lines
            string phrase = "The quick brown    fox     jumps over the lazy dog.";
            string[] words = phrase.Split(' ');

            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }
            
        }

        private static void SplitOnMultipleChars()
        {
            //assign an array of  delimiter characters
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            //write this string:
            string text = "one\ttwo three:four,five six seven";
            System.Console.WriteLine($"Original text: '{text}'");

            //then split that string with the array of delimiter characters into and array... 
            string[] words = text.Split(delimiterChars);
            System.Console.WriteLine($"{words.Length} words in text:");
            
            //...and print each value of the array into separate lines
            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }
            
        }
        
        private static void SplitOnMultipleCharsWithGaps()
        {
            // this just shows that consecutive splits will create blank values
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string text = "one\ttwo :,five six seven";
            System.Console.WriteLine($"Original text: '{text}'");

            string[] words = text.Split(delimiterChars);
            System.Console.WriteLine($"{words.Length} words in text:");

            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }
            
        }

        private static void SplitUsingStrings()
        {
            
            string[] separatingStrings = { "<<", "..." };

            string text = "one<<two......three<four";
            System.Console.WriteLine($"Original text: '{text}'");

            //by using System.StringSplitOptions.RemoveEmptyEntries you can remove  empty entries, so there are no blank lines
            string[] words = text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
            System.Console.WriteLine($"{words.Length} substrings in text:");

            foreach (var word in words)
            {
                System.Console.WriteLine(word);
            }
            
        }
    }
}
