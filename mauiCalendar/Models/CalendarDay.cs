using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mauiCalendar.Models
{
    public class CalendarDay
    {
        public int Day { get; set; }
        public List<CalendarEvent> CalendarEvents { get; set; }

        public CalendarDay(int day)
        {
            if (day < 1 || day > 31)
                throw new Exception("This day isn't valid. There are no months with greater than 31 days and you can't have a day numbered less than 1!");
            Day = day;
            CalendarEvents = new();
        }

        // Add an event to the day.
        public void AddEvent(CalendarEvent calendarEvent)
        {
            int indexForInsert = CalendarEvents.Count;
            for (int i = 0; i < CalendarEvents.Count; i++)
            {
                // If the event to be added has a start time before the event in CalendarEvents we're currently looking at, note the current index and break.
                if (i == 0 && calendarEvent.StartTime.Hour < CalendarEvents[i].StartTime.Hour || (calendarEvent.StartTime.Hour == CalendarEvents[i].StartTime.Hour && calendarEvent.StartTime.Minute <= CalendarEvents[i].StartTime.Minute))
                {
                    indexForInsert = i;
                    break;
                }
            }

            // If it comes after all other events for the day (or there are no other events for the day), add it to the end of CalendarEvents.
            if (indexForInsert >= CalendarEvents.Count)
                CalendarEvents.Add(calendarEvent);

            // Otherwise, insert it into the proper place within the list of Calendar Events.
            else
                CalendarEvents.Insert(indexForInsert, calendarEvent);

            // Make sure to add the event in the right order.
            CalendarEvents.Add(calendarEvent);
        }

        // Remove an event from the day.
        public void RemoveEvent(CalendarEvent calendarEvent)
        {
            // Find the calendarEvent and remove it from the day.
            for (int i = 0; i < CalendarEvents.Count; i++)
            {
                if (calendarEvent.Id == CalendarEvents[i].Id)
                {
                    CalendarEvents.RemoveAt(i);
                    break;
                }
            }
        }

        // Clear all events from the day.
        public void ClearDay()
        {
            CalendarEvents.Clear();
        }
    }
}
