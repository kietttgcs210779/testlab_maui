namespace TestLab;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private async void SendMessage_Clicked(System.Object sender, System.EventArgs e)
    {
		await DisplayAlert("Alert message test?", "This is try message.", "ok");
    }

    private async void TakeNotePage_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PushAsync(new TakeNotePage());
    }
}


