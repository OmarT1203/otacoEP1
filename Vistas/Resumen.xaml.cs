namespace otacoEP1.Vistas;

public partial class Resumen : ContentPage
{
    public Resumen(string usuario, string nombre, string apellido, string edad, DateTime fecha,
                   string ciudad, string pais, double montoInicial, double pagoMensual)
    {
        InitializeComponent();

        lblUsuarioConectado.Text = $"Usuario Conectado: {usuario}";
        lblNombre.Text = nombre;
        lblApellido.Text = apellido;
        lblEdad.Text = edad;
        lblFecha.Text = fecha.ToShortDateString();
        lblCiudad.Text = ciudad;
        lblPais.Text = pais;
        lblMontoInicial.Text = $"${montoInicial:F2}";
        lblPagoMensual.Text = $"${pagoMensual:F2}";
        lblPagoTotal.Text = $"${(montoInicial + (pagoMensual * 4)):F2}";
    }
}
