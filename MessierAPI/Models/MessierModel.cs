namespace MessierAPI.Models
{
    public class MessierModel
    {
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Constelación { get; set; } = string.Empty;
        public string Distancia { get; set; } = string.Empty;
        public string FechaDescubrimiento { get; set; } = string.Empty;
        public string Magnitud { get; set; } = string.Empty; // Brillo del objeto
        public string AscensionRecta { get; set; } = string.Empty;
        public string TamañoAparente { get; set; } = string.Empty; // Tamaño en el cielo en minutos de arco
        public string Descubridor { get; set; } = string.Empty; // Nombre de la persona que lo descubrió
        public string Descripcion { get; set; } = string.Empty; // Descripción breve del objeto
        public string ImagenURL { get; set; } = string.Empty; // URL a una imagen del objeto

    }


}