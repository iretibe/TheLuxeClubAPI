using TheLuxe.Mobile.Services;

namespace TheLuxe.Mobile.Pages;

public partial class SignupPage : ContentPage
{
	public SignupPage()
	{
		InitializeComponent();
	}

    private async void BtnSignUp_Clicked(object sender, EventArgs e)
    {
        if (!EntPassword.Text.Equals(EntConfirmPassword.Text))
        {
            await DisplayAlert("Password mismatch", "Wrong password confirmation", "Cancel");
        }
        else
        {
            var response = await ApiService.RegisterUser(EntName.Text, EntEmail.Text, EntPassword.Text);

            if (response)
            {
                await DisplayAlert("Hi", "Your account has been created", "Okay");
            }
            else
            {
                await DisplayAlert("Ooops", "There is an arror", "Cancel");
            }
        }
    }

    private async void BtnLogin_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new LoginPage());
    }
}