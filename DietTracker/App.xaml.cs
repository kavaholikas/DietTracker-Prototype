using CommunityToolkit.Mvvm.Messaging;
using DietTracker.Messages;

namespace DietTracker;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override void OnResume()
    {
        base.OnResume();
		//MessagingCenter.Send<App>(this, "Hello");
		WeakReferenceMessenger.Default.Send(new OnResumeMessage(this));
    }
}
