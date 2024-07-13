namespace marcatel_api.Models
{
    public class ClienteModel
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public decimal Deuda {get; set;}
        public string Rfc {get; set;}
        public string CondicionPago {get; set;}
        public decimal LimiteCredito {get; set;}
        public string Correo {get; set;}
        public string DireccionFiscal {get; set;}
        public string Telefono {get; set;}
        public string CodPostal {get; set;}
        public string Ciudad {get; set;}
        public string Colonia {get; set;}
        public string Contacto {get; set;}
        public string Representante {get; set;}
        public int ListaPrecios {get; set;}
        public string Cfdi {get; set;}
        public string Banco {get; set;}
        public string Cuenta {get; set;}
        public string Comentarios {get; set;}
        public string Regimen {get; set;}
        public int idSucursal {get; set;}
        public int IdCliente {get; set;}
        public byte[] Huella { get; set; }
        public int Historico {get; set;}
        
    }

    public class ClienteCreditoModel: ClienteModel
    {
        public int Tickets { get; set; }
        public float Monto { get; set; }
    }

    public class ClienteIdModel
    {
        public int Id {get; set;}
        public string NombreCliente {get; set;}
    }

    public class CLmodel
    {
        public int id {get; set;}
        public string nombre {get; set;}
        public string rfc {get; set;}
        public string condicionPago {get; set;}
        public string limiteCredito {get; set;}
        public string correo {get; set;}
        public string direccion {get; set;}
        public string telefono {get; set;}
        public string codPostal {get; set;}
        public string ciudad {get; set;}
        public string colonia {get; set;}
        public string representante {get; set;}
        public string banco {get; set;}
        public string cuenta {get; set;}
        public string comentarios {get; set;}
        public int usuario {get; set;}
        public string contacto {get; set;}
        
    }
}