
using System;
using System.Text;

namespace AkvelonFizzBuzz
{
    public class Program
    {
        static void Main(string[] args)
        {
            FizzBuzzDetector detector = new FizzBuzzDetector();

            string input = "Mary had a little lamb";

            FizzBuzzResult result = detector.getOverlappings(input);

            Console.WriteLine("Output:");
            Console.WriteLine(result.Output);

            Console.WriteLine($"Count: {result.Count}");
        }
    }

    public class FizzBuzzResult
    {
        public string Output { get; set; }
        public int Count { get; set; }

        public FizzBuzzResult(string output, int count)
        {
            Output = output;
            Count = count;
        }
    }

    public class FizzBuzzDetector
    {
        public FizzBuzzResult getOverlappings(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            StringBuilder output = new StringBuilder();

            int wordCount = 0;
            int matchCount = 0;
            int i = 0;

            while (i < input.Length)
            {
                if (char.IsLetterOrDigit(input[i]))
                {
                    int start = i;

                    while (i < input.Length &&
                           char.IsLetterOrDigit(input[i]))
                    {
                        i++;
                    }

                    wordCount++;

                    if (wordCount % 15 == 0)
                    {
                        output.Append("FizzBuzz");
                        matchCount++;
                    }
                    else if (wordCount % 3 == 0)
                    {
                        output.Append("Fizz");
                        matchCount++;
                    }
                    else if (wordCount % 5 == 0)
                    {
                        output.Append("Buzz");
                        matchCount++;
                    }
                    else
                    {
                        output.Append(input, start, i - start);
                    }
                }
                else
                {
                    output.Append(input[i]);
                    i++;
                }
            }

            return new FizzBuzzResult(output.ToString(), matchCount);
        }
    }
}
