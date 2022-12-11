using mauiCalendar.ViewModel;

namespace mauiCalendar;

public partial class CalendarListViewPage : ContentPage
{
	public CalendarListViewPage(CalendarViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}