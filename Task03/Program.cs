using System;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            DateOperations testDate = new DateOperations(new DateTime(2000, 1, 1));
            DateOperations testDate2 = new DateOperations(DateTime.Now);

            TimeSpan span = testDate.Date.Subtract(testDate2.Date);
            Console.WriteLine((int)span.TotalDays);

            DateOperations testDate3 = testDate + (-(int)span.TotalDays);
            Console.WriteLine(testDate3.Date.ToString(@"dd.MM.yyyy"));

            // почему-то приходится переназначать, иначе 
            // некорректный результат
            testDate = new DateOperations(new DateTime(2000, 1, 1));
            testDate2 = new DateOperations(DateTime.Now);
            int newCenturyBegining = testDate2 - testDate;
            Console.WriteLine($"New century begining was {newCenturyBegining} days ago");

            Console.ReadKey();
        }
    }
}
