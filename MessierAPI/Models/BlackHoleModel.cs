
namespace MessierAPI.Models;

   public class BlackHoleModel
{
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Distancia { get; set; } = string.Empty;
    public string MasasSolares { get; set; } = string.Empty; // Masa del agujero negro en masas solares
    public string Descripcion { get; set; } = string.Empty; // Descripción breve del objeto
    public string ImagenURL { get; set; } = string.Empty; // URL a una imagen del objeto
    public string RadioSchwarzschild { get; set; } = string.Empty; // Radio de Schwarzschild del agujero negro
    public string FechaDescubrimiento { get; set; } = string.Empty; // Fecha de descubrimiento
    public string Descubridor { get; set; } = string.Empty; // Nombre de la persona que lo descubrió
    
}

