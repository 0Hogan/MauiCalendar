using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mauiCalendar.Models
{
    public class CalendarYear
    {
        public int Year { get; set; }
        public List<CalendarMonth> CalendarMonths { get; set; }

        public CalendarYear(int year, int numDays)
        {
            Year = year;
            CalendarMonths = new();
            for (int i = 1; i <= 12; i++)
            {
                int numOfDays;
                switch (i)
                {
                    // The months with 31 days:
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        numOfDays = 31;
                        break;

                    // The months with 30 days:
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        numOfDays = 30;
                        break;

                    // February:
                    case 2:
                        if (year % 4 == 0) // This is not quite correct, but will capture most cases.
                            numOfDays = 29;
                        else
                            numOfDays = 28;
                        break;
                    default:
                        throw new Exception("Invalid month! Somehow, you managed to screw up an auto-generated number, Michael (Hogan, not Hamlin). Nice work, ya eedjit.");
                }
                
                CalendarMonths.Add(new CalendarMonth(i, numOfDays));
            }
        }

        // Add an event to the year.
        public void AddEvent(CalendarEvent calendarEvent)
        {
            // Sort the event into the right month:
            int month = calendarEvent.StartTime.Month;

            // Then add it to the month (`month - 1` because it the list starts at 0 while months in a year start at 1):
            CalendarMonths[month - 1].AddEvent(calendarEvent);
        }

        // Remove an event from the year.
        public void RemoveEvent(CalendarEvent calendarEvent)
        {
            // Find the month in which the calendarEvent starts.
            int month = calendarEvent.StartTime.Month;

            // Remove the event from the month.
            CalendarMonths[month - 1].RemoveEvent(calendarEvent);
        }

        // Clear all events from the year.
        public void ClearYear()
        {
            CalendarMonths.Clear();
        }
    }
}
