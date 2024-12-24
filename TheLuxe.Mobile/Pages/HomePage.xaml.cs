using System.Collections.ObjectModel;
using TheLuxe.Mobile.Models;
using TheLuxe.Mobile.Services;

namespace TheLuxe.Mobile.Pages;

public partial class HomePage : ContentPage
{
    public ObservableCollection<PopularProduct> ProductsCollection;
    public ObservableCollection<Category> CategoriesCollection;

    public HomePage()
	{
		InitializeComponent();

        ProductsCollection = new ObservableCollection<PopularProduct>();
        CategoriesCollection = new ObservableCollection<Category>();
        GetPopularProducts();
        GetCategories();
        LblUserName.Text = Preferences.Get("userName", string.Empty);
    }

    private async void GetCategories()
    {
        var categories = await ApiService.GetCategories();

        foreach (var item in categories)
        {
            CategoriesCollection.Add(item);
        }

        CvCategories.ItemsSource = CategoriesCollection;
    }

    private async void GetPopularProducts()
    {
        var products = await ApiService.GetPopularProducts();

        foreach (var item in products)
        {
            ProductsCollection.Add(item);
        }

        CvProducts.ItemsSource = ProductsCollection;
    }

    private async void ImgMenu_Tapped(object sender, EventArgs e)
    {
        GridOverlay.IsVisible = true;
        await SlMenu.TranslateTo(0, 0, 400, Easing.Linear);
    }

    private async void TapCloseMenu_Tapped(object sender, EventArgs e)
    {
        await SlMenu.TranslateTo(-250, 0, 400, Easing.Linear);
        GridOverlay.IsVisible = false;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var response = await ApiService.GetTotalCartItems(Preferences.Get("userId", 0));
        LblTotalItems.Text = response.totalItems.ToString();
    }

    private void CvCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as Category;
        if (currentSelection == null) return;
        Navigation.PushModalAsync(new ProductListPage(currentSelection.id, currentSelection.name));
        ((CollectionView)sender).SelectedItem = null;
    }

    private void CvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as PopularProduct;
        if (currentSelection == null) return;
        Navigation.PushModalAsync(new ProductDetailPage(currentSelection.id));
        ((CollectionView)sender).SelectedItem = null;
    }

    private void TapCartIcon_Tapped(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new CartPage());
    }
}