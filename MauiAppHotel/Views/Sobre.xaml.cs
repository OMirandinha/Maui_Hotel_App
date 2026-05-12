namespace MauiAppHotel.Views;

public partial class Sobre : ContentPage
{
    public Sobre()
    {
        InitializeComponent();
    }

    private async void OnVoltar(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}