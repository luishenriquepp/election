using System;
using System.Globalization;

namespace Election.BLL
{
    public class CreateElectionDateOfWeek
    {
        private DateTime Today { get; set; }

        public CreateElectionDateOfWeek(DateTime today)
        {
            Today = today;
        }

        public string Get()
        {
            return GetYear() + GetWeekOfYear();
        }

        private string GetYear()
        {
            return Today.Year.ToString();
        }

        private string GetWeekOfYear()
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(Today);
            if(day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                Today.AddDays(3);
            }
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();
        }
    }
}
