using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;

namespace marcatel_api.Models
{
    public class CapturaModel
    {
        public int IdRenglon { get; set; }
        public float Cantidad { get; set; }
        public int IdUsuario { get; set; }
        public string Codigo { get; set; }
        public string Fecha {get; set;}
    }

    public class GuardarMapeoRequest
    {
        public int Id {get; set;}
        public int IdUsuario {get; set;}
    }

    public class GetCantidadesCapturadas
    {
        public int IdSucursal {get;set;}
        public string Fecha {get; set;}
        public string FechaFinal {get; set;}
        public string FEchaCaptura {get; set;}
        public int IdDepartamento {get; set;}    
        public int IncluyeCeros {get; set;}
        public int pageSize {get; set;}
        public string search {get;set;}
        public int skip {get; set;}
    }

    public class CantidadesCapturadasModel
    {
        public string Codigo {get; set;}
        public string Descripcion {get; set;}
        public decimal Cantidad {get; set;} 
        public int IdDetalleMapeo {get; set;}
    }

    public class GetDiferenciasInventarios
    {
        public string Codigo {get; set;}
        public string Descripcion {get; set;}
        public decimal Costo {get; set;}
        public decimal PrecioPublico {get; set;}
        public decimal SalidaVenta {get; set;}
        public decimal SalidaPConsumo {get;set ;}
        public decimal SalidaConversion {get; set;}
        public decimal SalidaPmerma {get; set;}
        public decimal SalidaTransferencia {get; set;}
        public decimal AjusteNegativo {get; set;}
        public decimal SalidaEspecial {get;set;}
        public decimal SalidaDevolucion {get; set;}
        public decimal EntradaPTraspaso {get; set;}
        public decimal EntradaPConversion {get; set;}
        public decimal EntradaSOrden {get; set;}
        public decimal EntradaDevolucion {get; set;}
        public decimal AjustePositivo {get; set;}
        public decimal EntradaEspecial {get; set;}
        public decimal Teorico {get; set;}
        public decimal Capturado {get; set;}
        public decimal Congelado {get;set;}
        public decimal Diferencia {get; set;}
        public decimal TotalRegistros {get; set;}
        
    }

    public class ReporteValorInventario
    {
        public string Familia {get; set;}
        public string Departamento {get; set;}
        public decimal SalidaVenta {get; set;}
        public decimal SalidaPConsumo {get;set ;}
        public decimal SalidaConversion {get; set;}
        public decimal SalidaPmerma {get; set;}
        public decimal SalidaTransferencia {get; set;}
        public decimal AjusteNegativo {get; set;}
        public decimal EntradaPTraspaso {get; set;}
        public decimal EntradaPConversion {get; set;}
        public decimal EntradaSOrden {get; set;}
        public decimal EntradaDevolucion {get; set;}
        public decimal AjustePositivo {get; set;}
        public decimal EntradaEspecial {get; set;}
        public decimal SalidaEspecial {get; set;}
        public decimal Teorico {get; set;}
        public decimal Valor {get; set;}
    }

    public class GuardarCodigosCantidadesAjusteInv
    {
        public int IdDepartamento {get;set ;}
        public int IdUsuario {get; set;}
        public int IdSucursal {get; set;}
        public string Fecha {get; set;}
        public List<AjusteCodigos> Codigos {get; set;}
        
    }

    public class AjusteCodigos
    {
        public string Codigo {get; set;}
        public decimal Cantidad {get;set;}
        public decimal Teorico {get; set;}
    }

    public class GuardarTeoricoFecha
    {
        public string FechaInicial {get; set;}
        public string FechaFinal {get; set;}
        public string FechaExistencia {get; set;}
        public int IdSucursal {get; set;}
        public int IdDepartamento {get; set;}
    }

    public class CapturaDirectaModel
    {
        public string Codigo {get; set;}
        public int IdMapeo {get; set;}
        public decimal Cantidad {get;set;}
        public int Usuario {get;set;}
    }
}
