//using AndroidX.Lifecycle;
//using Java.Util.Functions;
using mauiCalendar.Models;
using mauiCalendar.ViewModel;
using System.ComponentModel;

namespace mauiCalendar;

public partial class CreateNewEventPage : ContentPage
{
	public CreateNewEventPage(CalendarViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

	}

	private void Button_Clicked(object sender, EventArgs e)
	{

		CalendarViewModel vm = (CalendarViewModel)BindingContext;

		CalendarEvent calendarEvent = new();

		calendarEvent.Name = this.Name.Text ;
		calendarEvent.StartTime = this.SsTime.Date; //new DateTime(2022, 12, 13, 14, 30, 0);                        //SsTime.; //DateTime.Parse(SsTime.ToString());    // DateTime.Parse(STime.ToString());

		calendarEvent.EndTime = this.EeTime.Date;					//new DateTime(2022, 12, 13, 14, 30, 0);			//EeTime;// DateTime.Parse(EeTime.ToString());	//DateTime.Parse(ETime.ToString());

        calendarEvent.Location = this.Location.Text;
		calendarEvent.Notes = this.Notes.Text;
		
		calendarEvent.CategoryId = Convert.ToInt32( this.CatID.Text);


		vm.AddEvent(calendarEvent);


      

    }
}