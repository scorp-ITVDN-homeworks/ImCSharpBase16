using System;
using System.Collections.Generic;
using System.Text;

namespace InputTools
{
    public static partial class ArrayTools
    {
        /* вывести массив
         */
        public static void ViewArray(int[] itemsArray)
        {
            for (int i = 0; i < itemsArray.Length; i++)
            {
                Console.WriteLine(itemsArray[i]);
            }
        }

        /* минимальное значение из массива
         */
        public static T ArrayMinValue<T>(T[] numbersArray)
        {
            T[] tempArray = numbersArray;
            Array.Sort(tempArray);
            return tempArray[0];
        }

        /* максимальное значение из массива
         */
        public static T ArrayMaxValue<T>(T[] numbersArray)
        {
            T[] tempArray = numbersArray;
            Array.Sort(tempArray);
            Array.Reverse(tempArray);
            return tempArray[0];
        }

        /* среднее арифметическое чисел с плавающей точкой из массива
         */
        public static double Average(double[] numbersArray)
        {
            double sum = GetArrayNumbersSum(numbersArray);
            return sum / numbersArray.Length;
        }

        /* среднее арифметическое целых чисел из массива
         */
        public static int Average(int[] numbersArray)
        {
            int sum = GetArrayNumbersSum(numbersArray);
            return sum / numbersArray.Length;
        }

        /* сумма значений типа double из массива
         */
        public static int GetArrayNumbersSum(int[] numbersArray)
        {
            int sum = 0;
            int len = numbersArray.Length;
            for (int i = 0; i < len; i++)
            {
                sum += numbersArray[i];
            }
            return sum;
        }

        /* сумма значений типа integer из массива
         */
        public static double GetArrayNumbersSum(double[] numbersArray)
        {
            double sum = 0;
            int len = numbersArray.Length;
            for (int i = 0; i < len; i++)
            {
                sum += numbersArray[i];
            }
            return sum;
        }

        /* список всех нечётных значений из integer-массива
         */
        public static int[] GetOddArrayItems(int[] numbersArray)
        {
            int len = numbersArray.Length;
            int[] oddNumbers = new int[] { };
            for (int i = 0; i < len; i++)
            {
                if ((numbersArray[i] & 1) == 1)
                {
                    Array.Resize(ref oddNumbers, oddNumbers.Length + 1);
                    oddNumbers[oddNumbers.Length - 1] = numbersArray[i];
                }
            }
            return oddNumbers;
        } 
    }    
}

