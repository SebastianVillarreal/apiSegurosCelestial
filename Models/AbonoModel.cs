using System.Collections.Generic;

namespace marcatel_api.Models
{
    public class AbonoModel 
    {
        public int Id { get; set; }
        public string nombreCliente { get; set; }
        public int IdCliente {get; set;}
        public decimal total {get; set;}
        public float Monto { get; set; }
        public int Usuario { get; set; }
        public int IdTicket { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string FolioInterno {get; set;}
        public int IdFolio {get; set;}
        
        

    }


    public class DetalleAbonoModel
    {
        public int Id {get; set;}
        public int idTicket {get; set;}
        public decimal monto {get; set;}
        public string formaPago {get; set;}
        public string referencia {get; set;}
        public string fecha {get; set; }
    }

    public class ResponseAbonos
    {
        public string nombreCliente {get; set;}
        public decimal total {get; set;}
        public List<DetalleAbonoModel> pagos {get; set;}

    }

    public class ResponseEntradasProveedor
    {
        public string nombreProveedor {get; set;}
        public string direccion {get; set;}
        public List<LibroDiarioModel> entradas {get; set;}

    }
}