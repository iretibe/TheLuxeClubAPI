using System.Collections.ObjectModel;
using TheLuxe.Mobile.Models;
using TheLuxe.Mobile.Services;

namespace TheLuxe.Mobile.Pages;

public partial class ProductListPage : ContentPage
{
    public ObservableCollection<ProductByCategory> ProductByCategoryCollection;

    public ProductListPage(int categoryId, string categoryName)
	{
		InitializeComponent();

        LblCategoryName.Text = categoryName;
        ProductByCategoryCollection = new ObservableCollection<ProductByCategory>();
        GetProducts(categoryId);
    }

    private async void GetProducts(int id)
    {
        var products = await ApiService.GetProductByCategory(id);

        foreach (var item in products)
        {
            ProductByCategoryCollection.Add(item);
        }

        CvProducts.ItemsSource = ProductByCategoryCollection;
    }

    private void TapBack_Tapped(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void CvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentSelection = e.CurrentSelection.FirstOrDefault() as ProductByCategory;
        if (currentSelection == null) return;
        Navigation.PushModalAsync(new ProductDetailPage(currentSelection.id));
        ((CollectionView)sender).SelectedItem = null;
    }
}