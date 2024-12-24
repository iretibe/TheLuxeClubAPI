using System.Collections.ObjectModel;
using TheLuxe.Mobile.Models;
using TheLuxe.Mobile.Services;

namespace TheLuxe.Mobile.Pages;

public partial class CartPage : ContentPage
{
    public ObservableCollection<ShoppingCartItem> ShoppingCartCollection;

    public CartPage()
	{
		InitializeComponent();

        ShoppingCartCollection = new ObservableCollection<ShoppingCartItem>();
        GetShoppingCartItems();
        GetTotalPrice();
    }

    private async void GetTotalPrice()
    {
        var totalPrice = await ApiService.GetCartSubTotal(Preferences.Get("userId", 0));
        LblTotalPrice.Text = totalPrice.subTotal.ToString();
    }

    private async void GetShoppingCartItems()
    {
        var shoppingCartItems = await ApiService.GetShoppingCartItems(Preferences.Get("userId", 0));

        foreach (var item in shoppingCartItems)
        {
            ShoppingCartCollection.Add(item);
        }

        LvShoppingCart.ItemsSource = ShoppingCartCollection;
    }

    private void TapBack_Tapped(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}