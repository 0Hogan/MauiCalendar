using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using mauiCalendar.Data;
//using mauiCalendar.Models;
//using Android.Test;
using mauiCalendar.Models;

namespace mauiCalendar.ViewModel
{
    public partial class CalendarViewModel : ObservableObject
    {
        CalendarDatabase calendarDatabase = new();

        // List of events with which to track the all the events currently scheduled.
        [ObservableProperty]
        ObservableCollection<CalendarEvent> calEvents = new();

        [ObservableProperty]
        ObservableCollection<CalendarDays> calDays = new();

        // The last expression.
        //    [ObservableProperty]
        //    string lastCalculation;

        // The last result (well, ideally, but it doesn't update quickly enough, so it's actually a variant of the last expression)
        //    [ObservableProperty]
        //    string lastResult;



        public CalendarViewModel()
        {
            CalendarEvent testing = new();
            testing.Name = "hello world";
            calEvents.Add(testing);
            int i = 0;
            CalendarDays CalDay = new CalendarDays();

            CalendarEvent[] calendarEvents = new[] { testing, testing, testing };

            //need to create the current month of days? then add into the days the event objects? 
            for (i = 0; i < 32; i++) {
                testing = new();
                testing.Name = "looping " + i.ToString();
                CalDay = new CalendarDays();

                CalDay.DayNumber = i;
                CalDay.MonthNumber = 12;

                calendarEvents[0] = testing;


                CalDay.Events = calendarEvents;


                CalDays.Add(CalDay);
            }

            // Load all previously scheduled events.
            LoadHistoryAsync();
        }

        // Adds the last expression and its answer to previousCalculations.
        [RelayCommand]
        async void Add()
        {

            CalendarEvent input = new();


            await calendarDatabase.SaveItemAsync(input);

            //        LastCalculation = output;

        }

        async void LoadHistoryAsync()
        {
            var calendarEvents = await calendarDatabase.GetItemsAsync();

            foreach (var calendarEvent in calendarEvents)
            {
                // Add the events in chronological order.
            }
            
        }


        [RelayCommand]
        async void ClearCompleteCalendarAsync()
        {
            await calendarDatabase.DeleteHistoryAsync();
        }

    }
    public class CalendarDays
    {

        public int DayNumber { get; set; }
        public int MonthNumber { get; set; }
        public CalendarEvent[] Events { get; set; }
    }

}