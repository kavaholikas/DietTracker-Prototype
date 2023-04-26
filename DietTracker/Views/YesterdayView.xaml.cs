using DietTracker.ViewModels;

namespace DietTracker.Views;

public partial class YesterdayView : ContentPage
{
	public YesterdayView(YesterdayViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		(BindingContext as YesterdayViewModel).OnAppearing();
    }
}