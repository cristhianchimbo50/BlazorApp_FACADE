namespace BlazorApp_FACADE.Models
{
    public class DetallePago
    {
        public int Id { get; set; }
        public int PagoId { get; set; }
        public string Concepto { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }

        public int Cantidad { get; set; }
        public string NombreServicio { get; set; } = string.Empty;
    }

}
