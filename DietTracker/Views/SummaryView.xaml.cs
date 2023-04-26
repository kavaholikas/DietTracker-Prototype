using DietTracker.ViewModels;

namespace DietTracker.Views;

public partial class SummaryView : ContentPage
{
	public SummaryView(SummaryViewModel viewModel)
	{
		BindingContext = viewModel; 
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		(BindingContext as SummaryViewModel).OnAppearing();
    }

}