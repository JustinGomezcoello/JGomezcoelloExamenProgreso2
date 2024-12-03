
using System.IO;
using JGomezcoelloExamenProgreso2.Models; 
namespace JGomezcoelloExamenProgreso2;

public partial class JGomezcoelloRecarga : ContentPage
{
    public Recarga Recargas { get; set; }

    private const string FileName = "JustinGomezcoello.txt";

    public JGomezcoelloRecarga()
    {
        InitializeComponent();
        Recargas = new Recarga();
        BindingContext = Recargas;
        CargarUltimaRecarga();
    }

    private void Recargar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(jgomezcoello_entryTelefono.Text) ||
            string.IsNullOrWhiteSpace(jgomezcoello_entryNombre.Text))
        {
            DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
            return;
        }

        string nuevaRecarga = $"Nombre: {jgomezcoello_entryNombre.Text}, Número: {jgomezcoello_entryTelefono.Text}\n";
        string filePath = Path.Combine(FileSystem.AppDataDirectory, FileName);

        // Agregar la nueva recarga al archivo
        File.AppendAllText(filePath, nuevaRecarga);

        // Imprimir la ruta en la terminal para saber en donde se guarda
        System.Diagnostics.Debug.WriteLine($"Archivo guardado en: {filePath}");

        // confirmación
        DisplayAlert("Éxito", "Recarga realizada con éxito.", "OK");

        // Actualizar manualmente el Label de última recarga
        jgomezcoello_labelUltimaRecarga.Text = nuevaRecarga;

        // Limpiar los campos de entrada para volver a ingresar un nuevo dato
        jgomezcoello_entryTelefono.Text = string.Empty;
        jgomezcoello_entryNombre.Text = string.Empty;
    }

    private void CargarUltimaRecarga()
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, FileName);
        if (File.Exists(filePath))
        {
            Recargas.UltimaRecarga = File.ReadAllText(filePath);
        }
        else
        {
            Recargas.UltimaRecarga = "No hay recargas previas.";
        }
    }
}
