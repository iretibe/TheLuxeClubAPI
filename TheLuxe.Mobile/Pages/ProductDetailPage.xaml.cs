using TheLuxe.Mobile.Models;
using TheLuxe.Mobile.Services;

namespace TheLuxe.Mobile.Pages;

public partial class ProductDetailPage : ContentPage
{
    private int _productId;

    public ProductDetailPage(int productId)
	{
		InitializeComponent();

        GetProductDetails(productId);
        _productId = productId;
    }

    private async void GetProductDetails(int productId)
    {
        var product = await ApiService.GetProductById(productId);

        LblName.Text = product.name;
        LblDetail.Text = product.detail;
        ImgProduct.Source = product.FullImageUrl;
        LblPrice.Text = product.price.ToString();
        LblTotalPrice.Text = LblPrice.Text;
    }

    private void TapIncrement_Tapped(object sender, EventArgs e)
    {
        var i = Convert.ToInt16(LblQty.Text);
        i++;
        LblQty.Text = i.ToString();
        int j = Convert.ToInt16(LblQty.Text);
        decimal k = Convert.ToDecimal(LblPrice.Text);
        int l = Convert.ToInt16(k);
        int m = j * l;
        LblTotalPrice.Text = m.ToString();
    }

    private void TapDecrement_Tapped(object sender, EventArgs e)
    {
        var i = Convert.ToInt16(LblQty.Text);
        i--;
        if (i < 1)
        {
            return;
        }
        LblQty.Text = i.ToString();
        LblTotalPrice.Text = (Convert.ToInt16(LblQty.Text) * Convert.ToDecimal(LblPrice.Text)).ToString();
    }

    private void TapBack_Tapped(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private async void BtnAddToCart_Clicked(object sender, EventArgs e)
    {
        var addToCart = new AddToCart();
        addToCart.Qty = LblQty.Text;
        addToCart.Price = LblPrice.Text;
        addToCart.TotalAmount = LblTotalPrice.Text;
        addToCart.ProductId = _productId;
        addToCart.CustomerId = Preferences.Get("userId", 0);

        var response = await ApiService.AddItemsInCart(addToCart);

        if (response)
        {
            await DisplayAlert("", "Your item has been added to cart", "Okay");
        }
        else
        {
            await DisplayAlert("Ooops", "Something went wrong", "Cancel");
        }
    }
}