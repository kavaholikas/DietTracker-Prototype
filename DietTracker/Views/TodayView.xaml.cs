using DietTracker.ViewModels;

namespace DietTracker.Views;

public partial class TodayView : ContentPage
{
	public TodayView(TodayViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}

	// Override this then you wanna run something on view switch
    protected override void OnAppearing()
    {
        base.OnAppearing();
		(BindingContext as TodayViewModel).OnAppearing();
    }
}