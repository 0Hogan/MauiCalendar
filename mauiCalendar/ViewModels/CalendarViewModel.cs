using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLite;
using System.Collections.ObjectModel;
using mauiCalendar.Data;
using mauiCalendar.Models;

namespace mauiCalendar.ViewModel
{
    public partial class CalendarViewModel : ObservableObject
    {
        CalendarDatabase calendarDatabase = new();

        // List of events with which to track the all the events currently scheduled.
        [ObservableProperty]
        ObservableCollection<CalendarEvent> calendarEvents = new();

        // A list of years of events.
        [ObservableProperty]
        ObservableCollection<CalendarYear> calendarYears = new();

        public CalendarViewModel()
        {
            // Load all previously scheduled events.
            LoadHistoryAsync();

            /********** Testing Data **********/
            CalendarEvent test1 = new()
            {
                Name = "Event 1",
                StartTime = new DateTime(2022, 12, 11, 14, 0, 0),
                EndTime = new DateTime(2022, 12, 11, 15, 0, 0)
            };

            CalendarEvent test2 = new()
            {
                Name = "Event 2",
                StartTime = new DateTime(2022, 12, 13, 14, 30, 0),
                EndTime = new DateTime(2022, 12, 13, 16, 0, 0)
            };

            CalendarEvent test3 = new()
            {
                Name = "Event 3",
                StartTime = new DateTime(2022, 12, 19, 19, 0, 0),
                EndTime = new DateTime(2022, 12, 19, 19, 0, 0)
            };

            calendarEvents.Add(test1);
            calendarEvents.Add(test2);
            calendarEvents.Add(test3);


            CalendarYear tester = new(2022);
            calendarYears.Add(tester);
            calendarYears[0].AddEvent(test1);
            calendarYears[0].AddEvent(test2);
            calendarYears[0].AddEvent(test3);


            /******** End Testing Data ********/

        }

        // Add an event.
        [RelayCommand]
        async void AddEvent(CalendarEvent calendarEvent)
        {
            await calendarDatabase.SaveItemAsync(calendarEvent);
            calendarEvents.Add(calendarEvent);
            
            int indexForInsertion = calendarEvents.Count;
            // Add the event to the calendarEvents collection in chronological order.
            for (int i = 0; i < calendarEvents.Count; i++)
            {
                if (calendarEvents[i].StartTime <= calendarEvent.StartTime)
                {
                    
                    break;
                }
            }
            // If the index for insertion is greater than the current number of events, add the new event at the back of the list.
            if (indexForInsertion >= calendarEvents.Count)
                calendarEvents.Add(calendarEvent);
            // Otherwise, insert it into the proper position within the list.
            else
                calendarEvents.Insert(indexForInsertion, calendarEvent);

            // Add the event to the calendarYears collection in chronological order.
            indexForInsertion = calendarYears.Count;
            for (int i = 0; i < calendarYears.Count; i++)
            {
                if (calendarYears[i].Year == calendarEvent.StartTime.Year)
                {
                    indexForInsertion = i;
                    break;
                }
            }

            if (indexForInsertion >= calendarYears.Count)
            {
                indexForInsertion = calendarYears.Count;
                calendarYears.Add(new CalendarYear(calendarEvent.StartTime.Year));
            }

            calendarYears[indexForInsertion].AddEvent(calendarEvent);
        }

        async void RemoveEvent(CalendarEvent calendarEvent)
        {
            await calendarDatabase.DeleteEventAsync(calendarEvent);
            calendarEvents.Remove(calendarEvent);
            for (int i = 0; i < calendarYears.Count; i++)
            {
                if (calendarYears[i].Year == calendarEvent.StartTime.Year)
                    calendarYears[i].RemoveEvent(calendarEvent);
            }
        }

        // Load all events from the database.
        // This might get a bit scary for large numbers of events over the years... But that's out of the scope of this project.
        async void LoadHistoryAsync()
        {
            var calendarEvents = await calendarDatabase.GetItemsAsync(); // @TODO: Make sure these are in order...
            
            foreach (var calendarEvent in calendarEvents)
            {
                // Add the events in chronological order.
                this.calendarEvents.Add(calendarEvent);

                int indexForInsertion = calendarYears.Count;
                for (int i = 0; i < calendarYears.Count; i++)
                {
                    if (calendarYears[i].Year == calendarEvent.StartTime.Year)
                    {
                        indexForInsertion = i;
                        break;
                    }
                }

                if (indexForInsertion >= calendarYears.Count)
                {
                    indexForInsertion = calendarYears.Count;
                    calendarYears.Add(new CalendarYear(calendarEvent.StartTime.Year));
                }

                calendarYears[indexForInsertion].AddEvent(calendarEvent);
            }
        }


        [RelayCommand]
        async void ClearCompleteCalendarAsync()
        {
            await calendarDatabase.DeleteHistoryAsync();
            calendarYears.Clear();
            calendarEvents.Clear();
        }

    }
}