using CherryPicker.NET.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.Validator;

public class UserInputValidator
{
    public enum Answer { Yes, No };

    public static bool YesAndNoQuestion(string text)
    {
        char[] validAnswers = { 'y', 'Y', 'n', 'N' };
        Console.Write(text + " y/n ?: ");
        char answer = ' ';
        int index = 0;
        while (true)
        {
            answer = Console.ReadKey().KeyChar;
            index = Array.IndexOf(validAnswers, answer);
            if (-1 == index)
            {
                Console.WriteLine();
                Console.Write(UserMessages.EnterYesNoCharacters);
                continue;
            }
            Console.WriteLine();
            break;
        }
        return (validAnswers[index] == 'y' || validAnswers[index] == 'Y');
    }
}
