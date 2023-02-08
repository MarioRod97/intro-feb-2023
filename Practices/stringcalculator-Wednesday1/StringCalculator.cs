
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace StringCalculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        //var delimiters = new List<char> { ',', '\n', ';' };
        char[] delimeters = { ',', ';', '\n', '/', '*'};

        string[] numbersArray = numbers.Split(delimeters, StringSplitOptions.None);
        
        int numbersSum = 0;

        if (String.IsNullOrEmpty(numbers)) return 0;
        else {
            foreach (string number in numbersArray)
            {
                numbersSum += int.Parse(number);
            }
            return numbersSum;
        };
    }
}
