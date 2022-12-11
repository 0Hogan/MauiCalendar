using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mauiCalendar.Models
{
    public class CalendarMonth
    {
        public string Name { get; set; }
        public int Month { get; set; }
        public List<CalendarDay> CalendarDays { get; set; }

        public CalendarMonth(int month, int numDays)
        {
            if (month < 1 || month > 12)
                throw new Exception("Invalid month! There are no months numbered less than 1 or greater than 12!");
            Month = month;
            CalendarDays = new();
            for (int i = 1; i <= numDays; i++)
            {
                CalendarDays.Add(new CalendarDay(i));
            }

            switch(month)
            {
                case 1:
                    Name = "January";
                    break;
                case 2:
                    Name = "February";
                    break;
                case 3:
                    Name = "March";
                    break;
                case 4:
                    Name = "April";
                    break;
                case 5:
                    Name = "May";
                    break;
                case 6:
                    Name = "June";
                    break;
                case 7:
                    Name = "July";
                    break;
                case 8:
                    Name = "August";
                    break;
                case 9:
                    Name = "September";
                    break;
                case 10:
                    Name = "October";
                    break;
                case 11:
                    Name = "November";
                    break;
                case 12:
                    Name = "December";
                    break;
            }
        }

        // Add an event to the month.
        public void AddEvent(CalendarEvent calendarEvent)
        {
            // Find the day to which the event should be added:
            int day = calendarEvent.StartTime.Day;

            // Add the event the selected day (`day - 1` because it the list starts at 0 while days in a month start at 1)
            CalendarDays[day - 1].AddEvent(calendarEvent);
        }

        // Remove an event from the month.
        public void RemoveEvent(CalendarEvent calendarEvent)
        {
            // Find the day in which the calendarEvent starts.
            int day = calendarEvent.StartTime.Day;

            // Remove the event from the day.
            CalendarDays[day - 1].RemoveEvent(calendarEvent);
        }

        // Clear all events from the month.
        public void ClearMonth()
        {
            CalendarDays.Clear();
        }
    }
}
