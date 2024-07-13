namespace marcatel_api.Models
{
    public class LibroEntradaModel
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public string ClaveProveedor { get; set; }        
        public string Proveedor { get; set; }
        public string Factura { get; set; }
        public string NumeroNota { get; set; }        
        public float Total { get; set; }
        public string Observaciones { get; set; }
        public int Ordencompra { get; set; }
        public string ComentarioCancela { get; set; }
        public int Autorizado { get; set; }
        public float Suma { get; set; }
        public string Inicio { get; set; }
        public string Final { get; set; }
        public string TotalTime { get; set; }
        public int Tipo { get; set; }
        public int IdSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public string FechaRecibo { get; set; }
        public int Carta { get; set; }
        public string Recibe { get; set; }
        public byte[] Huella {get; set;}
        public int IdEntrada {get; set;}
    }

    public class InsertHuellaModel
    {
        public byte[] Huella {get; set;}
        public int IdCajero {get; set;}
    }
    
}