namespace MauiAppHotel.Views;

public partial class TabelaPrecos : ContentPage
{
    public TabelaPrecos()
    {
        InitializeComponent();
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}