namespace marcatel_api.Models
{
    public class OrdenCompraModel
    {
        public int Id { get; set; }
        public int Orden { get; set; }
        public string ClaveProveedor { get; set; }
        public int Comprador { get; set; }
        public string FechaEstimadaEntrega { get; set; }
        public int CondicionPago { get; set; }
        public int LabcLab { get; set; }
        public string Referencia { get; set; }
        public float Importe { get; set; }
        public float IvaOrden { get; set; }
        public float Total { get; set; }
        public float Ieps { get; set; }
        public int OrdnOrden { get; set; }
        public string Fecha { get; set; }
        public int IdSucursal { get; set; }
        public string Sucursal { get; set; }
        public string NombreProveedor { get; set; }
        public string Retraso { get; set; }
        public string Factura { get; set; }
        public string Mensaje { get; set; }
        public int IdProveedor { get; set; }
        public string fecha_ini {   get; set;}
        public string fecha_fin {get; set;}
    }
}