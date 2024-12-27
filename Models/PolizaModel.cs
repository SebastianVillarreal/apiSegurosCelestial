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
        public string Fecha {get; set;}
        public string FechaVencimiento {get;set;}
        public int PorVencer {get; set;}
    }

    public class ConsecutivoPoliza
    {
        public int Consecutivo {get; set;}
    }

    public class InsertBeneficiarioModel
    {
        public int ConsecutivoPoliza {get; set;}
        public string Nombre {get; set;}
        public int Edad {get; set;}
        public string Parantesco {get; set;}
        public int usuario {get; set;}  
    }
    public class BeneficiarioModel : InsertBeneficiarioModel
    {
        public int Id {get; set;}
    }
}

