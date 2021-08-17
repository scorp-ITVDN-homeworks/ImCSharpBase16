using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public class DateOperations
    {
        DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public DateOperations(DateTime date)
        {
            Date = date;
        }

        public static int operator - (DateOperations date1, DateOperations date2)
        {
            TimeSpan span = date1.date.Subtract(date2.date);
            
            return (int)span.TotalDays;
        }

        public static DateOperations operator + (DateOperations date1, int days)
        {
            TimeSpan span = new TimeSpan(days, 0, 0, 0);            
            date1.date = date1.date.Add(span);
            return date1;
        }
    }
}
