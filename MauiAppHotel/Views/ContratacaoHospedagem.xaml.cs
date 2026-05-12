namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    public ContratacaoHospedagem()
    {
        InitializeComponent();
    }

    private void OnCalcularReserva(object sender, EventArgs e)
    {
        // Validar suite
        if (pck_quarto.SelectedIndex == -1)
        {
            DisplayAlert("Atencao", "Selecione uma suite", "OK");
            return;
        }

        // Validar datas
        if (dtpck_checkout.Date <= dtpck_checkin.Date)
        {
            DisplayAlert("Erro", "O check-out deve ser pelo menos 1 dia após o check-in!", "OK");
            return;
        }

        // Obter valores
        double[] valores = { 150, 200, 300, 450 };
        double valorDiaria = valores[pck_quarto.SelectedIndex];

        int adultos = (int)stp_adultos.Value;
        int criancas = (int)stp_criancas.Value;
        int dias = (dtpck_checkout.Date - dtpck_checkin.Date).Days;

        // Calcular itens da fatura
        double diarias = valorDiaria * dias;
        double taxaServico = diarias * 0.10;
        double taxaHospedes = (adultos + criancas) * 15;
        double taxaLimpeza = 50;
        double taxaCriancasExtra = criancas * 10;

        double total = diarias + taxaServico + taxaHospedes + taxaLimpeza + taxaCriancasExtra;

        // Exibir fatura completa
        lblResumoQuarto.Text = pck_quarto.Items[pck_quarto.SelectedIndex];
        lblResumoHospedes.Text = $"{adultos} adultos, {criancas} criancas";
        lblResumoDias.Text = $"{dias} dias";
        lblResumoDiarias.Text = $"Diarias: R$ {diarias:F2}";
        lblResumoTaxa.Text = $"Servico: R$ {taxaServico:F2} | Hospedes: R$ {taxaHospedes:F2} | Limpeza: R$ {taxaLimpeza:F2} | Criancas: R$ {taxaCriancasExtra:F2}";
        lblResumoTotal.Text = $"R$ {total:F2}";

        frameResultado.IsVisible = true;
    }

    private void OnLimpar(object sender, EventArgs e)
    {
        pck_quarto.SelectedIndex = -1;
        stp_adultos.Value = 0;
        stp_criancas.Value = 0;
        dtpck_checkin.Date = DateTime.Now;
        dtpck_checkout.Date = DateTime.Now.AddDays(1);
        frameResultado.IsVisible = false;
    }

    private async void OnAbrirSobre(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}