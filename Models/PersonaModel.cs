using System.Collections.Generic;
namespace marcatel_api.Models
{
    public class PersonaModel
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre {get; set;}
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int Perfil { get; set; }
        public int IdSede { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreSede { get; set; }

    }

     public class MenuModel
    {
        
        public int Id { get; set; }
        
        public string Nombre { get; set; }
        
        public int Categoria { get; set; }

        
        public virtual List<ModuloModel> Modulos { get; set; }
        
        public virtual MenuModel Menu2 { get; set; }
    }
}