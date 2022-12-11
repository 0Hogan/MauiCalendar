using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mauiCalendar.Models
{
    public class CalendarEvent
    {
        int id = 0;
        string name = "Untitled";
        DateTime startTime;
        DateTime endTime;
        string location = "";
        string notes = "";
        int categoryId = 0;        


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } // The unique id of the event.
        public string Name { get; set; } // The name of the event.
        public DateTime StartTime { get; set; } // The start time/day of the event.
        public DateTime EndTime { get; set; } // The end time/day of the event.
        public string Location { get; set; } // The location associated with the event.
        public string Notes { get; set; } // Any notes associated with the event.
        public int CategoryId { get; set; } // The id of the group with which the event is associated (e.x. family, work, school, etc.)


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
