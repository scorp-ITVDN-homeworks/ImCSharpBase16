using System;
using System.Threading;

using static InputTools.UIFeatures;


namespace InputTools
{
    public static class UIFeatures
    {
        public static void DrawSymbolLine(int time, int number, char symbol, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            for (int i = 0; i < number; i++)
            {
                Console.Write(symbol);
                Thread.Sleep(time);
            }

            Console.ResetColor();
            Console.WriteLine();

        }

        public static void DrawSymbolLine(int time, int number, char symbol)
        {
            for (int i = 0; i < number; i++)
            {
                Console.Write(symbol);
                Thread.Sleep(time);
            }
            Console.WriteLine();
        }

        public static void DrawSymbolLine(int number, char symbol)
        {
            Console.WriteLine(new string(symbol, number));

        }

        public static void DrawSymbolLine(int number, char symbol, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(new string(symbol, number));
            Console.ResetColor();

        }
    }

    public static class ProgramElementEdit
    {
        

        /* Метод для сопоставления заданной строки и элементов перечисления
         * Если есть элемент с именем, совпадающим со строкой - возврат true
         * 
         * цель его только в том, что он немного сокращает запись
         * позволяет переписывать или не переписывать уже существующий
         * экземпляр перечисления в зависимости от ввода строки
         */
        public static bool SearchInEnum<E>(ref E enumItem, string input) where E : Enum
        {
            bool isCorrectCommand = false;
            isCorrectCommand = Enum.IsDefined(typeof(E), input);
            if (isCorrectCommand)
            {
                enumItem = (E)Enum.Parse(typeof(E), input);
            }
            return isCorrectCommand;
        }

        /*Метод для возврата списка имён из перечисления
         * Не понимаю, зачем я его сделал, ведь это лишь обёртка
         * над точно таким же статическим методом из класса Enum
         */
        public static string[] NamesInEnum<E>() where E : Enum
        {
            string[] names = Enum.GetNames(typeof(E));
            return names;
        }
    }
}
