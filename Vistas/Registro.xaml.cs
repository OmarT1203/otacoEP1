namespace otacoEP1.Vistas;

public partial class Registro : ContentPage
{
    string usuarioConectado;
    const double COSTO_CURSO = 1500;

    public Registro(string usuario)
    {
        InitializeComponent();
        usuarioConectado = usuario;
        lblUsuarioConectado.Text = $"Usuario Conectado: {usuarioConectado}";
    }

    private void CalcularPago_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtMontoInicial.Text))
        {
            DisplayAlert("Error", "Ingrese el monto inicial del estudiante.", "OK");
            return;
        }

        if (!double.TryParse(txtMontoInicial.Text, out double montoInicial))
        {
            DisplayAlert("Error", "Ingrese un valor numérico válido.", "OK");
            return;
        }

        if (montoInicial <= 0 || montoInicial >= COSTO_CURSO)
        {
            DisplayAlert("Error", "El monto inicial debe ser mayor que 0 y menor que 1500.", "OK");
            return;
        }

        // Cálculo: (1500 - x) / 4 + 4% del costo total
        double restante = COSTO_CURSO - montoInicial;
        double cuotaBase = restante / 4;
        double interesPorCuota = COSTO_CURSO * 0.04;
        double cuotaConInteres = cuotaBase + interesPorCuota;

        txtPagoMensual.Text = cuotaConInteres.ToString("F2");
    }

    private async void VerResumen_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtApellido.Text) ||
            string.IsNullOrWhiteSpace(txtEdad.Text) ||
            string.IsNullOrWhiteSpace(txtMontoInicial.Text) ||
            string.IsNullOrWhiteSpace(txtPagoMensual.Text))
        {
            await DisplayAlert("Error", "Complete todos los campos y calcule el pago mensual.", "OK");
            return;
        }

        double montoInicial = double.Parse(txtMontoInicial.Text);
        double pagoMensual = double.Parse(txtPagoMensual.Text);

        await Navigation.PushAsync(new Resumen(usuarioConectado,
            txtNombre.Text, txtApellido.Text, txtEdad.Text, dpFecha.Date,
            pkCiudad.SelectedItem?.ToString() ?? "",
            pkPais.SelectedItem?.ToString() ?? "",
            montoInicial, pagoMensual));
    }
}



