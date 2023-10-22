using CherryPicker.NET.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace CherryPicker.NET.Validator;

public class UserInputValidator
{
    public enum Answer { Continue, Abort, Exit };

    public static bool YesAndNoQuestion(string text)
    {
        char[] validAnswers = { 'y', 'n' };
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

    private static Answer GetAnswerByCommandChar(char commmand) => commmand switch
    {
        'c' => Answer.Continue,
        'a' => Answer.Abort,
        'e' => Answer.Exit,
        _ => throw new NotImplementedException()
    };

    public static Answer CherryPickCommandQuestion()
    {
        char[] validAnswers = { 'c', 'a', 'e' };
        Console.WriteLine(UserMessages.WhatCherryPickOperationPerform);
        Console.WriteLine(UserMessages.CommandCherryPickContinue);
        Console.WriteLine(UserMessages.CommandCherryPickAbort);
        Console.WriteLine(UserMessages.CommandCherryPickExit);
        char answer = ' ';
        int index = 0;
        Console.Write("Command: ");
        while (true)
        {
            answer = Console.ReadKey().KeyChar;
            index = Array.IndexOf(validAnswers, answer);
            if (-1 == index)
            {
                Console.WriteLine();
                Console.Write(UserMessages.EnterCherryPickCommandCharacters);
                continue;
            }
            Console.WriteLine();
            break;
        }
        return GetAnswerByCommandChar(answer);
    }
}
