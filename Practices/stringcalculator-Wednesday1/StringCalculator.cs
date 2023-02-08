
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        string[] numbersArray = numbers.Split(',');
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
