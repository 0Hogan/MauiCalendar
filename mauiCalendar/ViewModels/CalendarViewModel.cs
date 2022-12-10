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
        CalendarDatabase CalDatabase = new();


        // List of events with which to track the previously calculated expressions.
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
            //       PreviousCalculations = new();
            CalendarEvent testing = new CalendarEvent();
            testing.Name = "hello world";
            calEvents.Add(testing);
            int i = 0;
            CalendarDays CalDay = new CalendarDays();

            CalendarEvent[] calendarEvents = new[] { testing, testing,testing };

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


            // Load any calculation history from previous sessions.
            LoadHistoryAsync();

            //    lastCalculation = "0";
            //       lastResult = "0";
        }

        // Adds the last expression and its answer to previousCalculations.
        [RelayCommand]
        async void Add()
        {

            CalendarEvent input = new();


            await CalDatabase.SaveItemAsync(input);

            //        LastCalculation = output;

        }

        async void LoadHistoryAsync()
        {
            //        var previousCalculationsList = await previousCalculationsDatabase.GetItemsAsync();

            //        foreach (var calculation in previousCalculationsList)
            {
                //           previousCalculations.Add(calculation.Calculation);
            }
            //        dbHistoryIsLoaded = true;
        }



        [RelayCommand]
        async void ClearCompleteCalendarAsync()
        {
            //        dbHistoryIsLoaded = false;
            await CalDatabase.DeleteHistoryAsync();
            //       PreviousCalculations?.Clear();
            //        dbHistoryIsLoaded = true;
        }

    }
    public class CalendarDays
    {

        public int DayNumber { get; set; }
        public int MonthNumber { get; set; }
        public CalendarEvent[] Events { get; set; }
    }

}