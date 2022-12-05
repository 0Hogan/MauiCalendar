using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mauiCalendar.Data
{
    public class CalendarEvent
    {
        int id = 0;                 // The unique id of the event.
        string name = "Untitled";   // The name of the event.
        DateTime startTime;         // The start time/day of the event.
        DateTime endTime;           // The end time/day of the event.
        string location = "";       // The location associated with the event.
        string notes = "";          // Any notes associated with the event.
        int categoryId = 0;         // The id of the group with which the event is associated (e.x. family, work, school, etc.)


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public int CategoryId { get; set; }


        // C-tor.
        public CalendarEvent()
        {
            Name = "Untitled"; // Untitled by default.
            StartTime = DateTime.Now; // The one required field.
            EndTime = StartTime + new TimeSpan(hours: 1, minutes: 0, seconds: 0); // By default, initialize the end time to one hour after the start time.
            Location = "";
            Notes = "";
        }

        // Publish the event to the database and the calendar.
        public void Publish()
        {
            //CalendarDatabase.Add(this);
        }

        /* Don't think we need these... We can initialize using an empty CalendarEvent, and then update each field.
        CalendarEvent(DateTime startTime)
        {
            Name = "Untitled"; // Untitled by default.
            StartTime = startTime; // The one required field.
            EndTime = startTime + new TimeSpan(hours: 1, minutes: 0, seconds: 0); // By default, initialize the end time to one hour after the start time.
            Location = "";
            Notes = "";
        }


        CalendarEvent(string name, DateTime startTime, DateTime endTime, string location, string notes)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Location = location;
            Notes = notes;
        }
        */

    }
}
