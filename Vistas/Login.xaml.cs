namespace otacoEP1.Vistas;

public partial class Login : ContentPage
{
    string[,] usuarios = new string[2, 2]
    {
        {"estudiante", "moviles"},
        {"uisrael", "2025"}
    };

    public Login()
    {
        InitializeComponent();
    }

    private async void IniciarSesion_Clicked(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text.Trim();
        string contrasena = txtContrasena.Text.Trim();

        bool acceso = false;

        for (int i = 0; i < 2; i++)
        {
            if (usuario == usuarios[i, 0] && contrasena == usuarios[i, 1])
            {
                acceso = true;
                break;
            }
        }

        if (acceso)
        {
            await Navigation.PushAsync(new Registro(usuario));
        }
        else
        {
            await DisplayAlert("Error", "Datos incorrectos", "OK");
        }
    }
}
