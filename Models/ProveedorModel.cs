namespace marcatel_api.Models
{
    public class ProveedsorModel
    {
        public int Id { get; set; }
        public string ClaveProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public float Plazo { get; set; }
        public string Direccion { get; set; }
        public string RFC { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }

    public class ProveedorModel
    {
        public int Id {get; set;}
        public string clave {get; set;}
        public string nombre {get; set;}
        public string direccion {get;set;}
        public string ciudad {get;set;}
        public string telefono {get; set;}
        public string rfc {get; set;}
        public string email {get; set;}
        public string contacto {get; set;}
        public string estado {get; set;}
        public string pais {get; set;}
        public int codigoPostal {get; set;}
        public string giro {get; set;}
        public string condicion {get; set;}
        public int tipo {get; set;}
        public string representante {get; set;}
        public int cuentaContable {get; set;}
    }
}