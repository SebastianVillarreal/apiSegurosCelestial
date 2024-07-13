namespace marcatel_api.Models
{
    public class NotaEntradaModel
    {
        public int Id { get; set; }
        public int Orden { get; set; }
        public int Sucursal { get; set; }
        public string Fecha { get; set; }
        public string IdSucursal { get; set; }
        public string Factura { get; set; }
        public int IdProveedor {get; set;}
    }

    public class RenglonFichaEntrada
    {
        public string Codigo {get; set;}
        public string Descripcion {get; set;}
        public string UnidadMedida {get; set;}
        public string Descuentos {get; set;}
        public decimal Ieps {get; set;}
        public decimal IepsSeis {get; set;}
        public decimal Iva {get; set;}
        public decimal CostoUnitario {get; set;}
        public decimal CostoUnitarioImpuestos {get; set;}
        public decimal CostoxUnidad {get; set;}
        public decimal CostoPartida {get; set;}
        public decimal Cantidad {get; set;}
    }

    public class RPT_GetDetalleNotaEntradaDepto
    {
        public string Nombre {get; set;}
        public decimal CostuUnidad {get;set;}
        public decimal Cantidad {get; set;}
        public decimal Descuento {get; set;}
        public decimal Faltante {get; set;}
        public decimal Sobrante {get; set;}
        public decimal Ieps {get; set;}
        public decimal Iva {get; set;}
        public decimal IsrRet {get;set;}
        public decimal IvaRet {get; set;}
        public decimal Monto {get; set;}
        public decimal Total {get; set; }
    }
}