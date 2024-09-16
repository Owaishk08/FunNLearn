namespace FunNLearn.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    private async void startlesson_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LessonPage());
    }

    private async void viewprofile_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage());
    }

    private void achievements_Clicked(object sender, EventArgs e)
    {

    }

    private void setting_Clicked(object sender, EventArgs e)
    {

    }
}