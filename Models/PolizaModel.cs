namespace apiSegurosCelestial.Models
{
    public class InsertPolizaModel
    {
        public string Nombre { get; set; }
        public string DireccionParticular { get; set; }
        public string Colonia  {get; set;}
        public string Telefono {get; set;}
        public string Poblacion {get; set;}
        public string DomicilioCobro { get; set; }
        public string Empresa { get; set; }
        public string TelEmpresa { get; set; }
        public string CalleEmpresa { get; set; }
        public string Beneficiario { get; set; }
        public string Edad { get; set; }
        public string Parentesco {get; set;}
        public string Vendedor {get; set;}
        public string Promotor {get; set;}

    }

    public class PolizaModel: InsertPolizaModel
    {
        public int Id { get; set; }
    }
}

