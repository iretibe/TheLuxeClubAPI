using TheLuxe.Mobile.Services;

namespace TheLuxe.Mobile.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void TapBackArrow_Tapped(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        var response = await ApiService.Login(EntEmail.Text, EntPassword.Text);

        if (response)
        {
            Application.Current.MainPage = new NavigationPage(new HomePage());
        }
        else
        {
            await DisplayAlert("Ooops", "Something went wrong!", "Cancel");
        }
    }
}