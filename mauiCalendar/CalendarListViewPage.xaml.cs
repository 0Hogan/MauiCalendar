using CommunityToolkit.Mvvm.Input;
using mauiCalendar.Models;
using mauiCalendar.ViewModel;
using System.Windows.Input;

namespace mauiCalendar;

public partial class CalendarListViewPage : ContentPage
{
	public CalendarListViewPage(CalendarViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	
}