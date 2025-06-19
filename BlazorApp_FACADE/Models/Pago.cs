namespace BlazorApp_FACADE.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public int CitaId { get; set; }
        public string Metodo { get; set; } = "Efectivo";
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.Now;
        public string NumeroComprobante { get; set; } = string.Empty;
        public string TipoComprobante { get; set; } = "Factura";
        public List<DetallePago>? Detalles { get; set; }
    }
}
