using System;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Services;
using marcatel_api.Utilities;
using Microsoft.AspNetCore.Authorization;
using marcatel_api.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using marcatel_api.Helpers;

namespace marcatel_api.Controllers
{
   
    [Route("api/[controller]")]
    public class MapeosController: ControllerBase
    {
        private readonly MapeosService _mapeoService;
        private readonly ILogger<MapeosController> _logger;
        private readonly IJwtAuthenticationService _authService;
        Encrypt enc = new Encrypt();

        public MapeosController(MapeosService mapeoservice, ILogger<MapeosController> logger, IJwtAuthenticationService authService) {
            _mapeoService = mapeoservice;
            _logger = logger;
       
            _authService = authService;
        }

        [HttpPost("CongelarInventario")]
        public JsonResult CongelarInventario([FromBody] CongelarInventarioModel mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.CongelarInventario(mapeo.IdSucursal, mapeo.Fecha, mapeo.FechaInicial, mapeo.FechaFinal);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Proceso completado con éxito";

                objectResponse.response = new
                {
                    data = CatClienteResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        [HttpPost("GetAreasInventario")]
        public JsonResult InsertModulo()
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.GetAreasInv();
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro insertado con exito";

                objectResponse.response = new
                {
                    data = CatClienteResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        [HttpPost("Insert")]
        public JsonResult InsertMapeo([FromBody] InsertMapeo mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.InsertMapeo(mapeo);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro insertado con exito";

                objectResponse.response = new
                {
                    data = CatClienteResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        [HttpPost("Eliminar")]
        public JsonResult DeleteMapeo([FromBody] DeleteMapeo mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.EliminarMapeo(mapeo.IdMapeo);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro eliminado con exito";

                objectResponse.response = new
                {
                    data = CatClienteResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        [HttpPost("Ajustar")]
        public JsonResult Ajustar([FromBody] AjustarDiferencias mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 _mapeoService.AjustarDiferencias(mapeo.IdSucursal, mapeo.Usuario, mapeo.IdDepartamento, mapeo.fecha_captura);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro insertado con exito";

                objectResponse.response = new
                {
                    data = true
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        [HttpPost("Actualizar")]
        public JsonResult Actualizar([FromBody] MapeoModel mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 _mapeoService.ActualizarDatosMapeo(mapeo);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro actualizado con exito";

                objectResponse.response = new
                {
                    data = true
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

                //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("InsertarCodigosDiferencias")]
        public JsonResult InsertarCodigosDiferencias([FromBody] GuardarCodigosCantidadesAjusteInv lista)
        {
            ListToDataTable ltod = new ListToDataTable();
            var dt  = ltod.ToDataTable(lista.Codigos);
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var articulo = _mapeoService.InsertarCodigosDiferencias(dt, lista.IdDepartamento, lista.IdUsuario, lista.IdSucursal, lista.Fecha);
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.message = "Informacion Guardada";
                objectResponse.success = true;
                objectResponse.response = new
                {
                    data = articulo
                };
                
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
            return new JsonResult(objectResponse);

        }

        [HttpPost("GetImpresion")]
        public JsonResult GetImpresion([FromBody] GetMapeosImpresionReq mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.GetMapeosImpresion(mapeo.IdSucursal, 0, mapeo.IdUsuario);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro insertado con exito";

                objectResponse.response = new
                {
                    data = CatClienteResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        [HttpGet("GetMapeosFechas")]
        public JsonResult GetMapeosFechas([FromQuery] string fecha_inicial, string fecha_final, int sucursal)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.GetMapeosFechas(sucursal, fecha_inicial, fecha_final);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro insertado con exito";

                objectResponse.response = new
                {
                    data = CatClienteResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        [HttpPost("Finalizar")]
        public JsonResult FinalizarMapeo([FromBody] RenglonMapeoModel mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 _mapeoService.FinalizarMapeo(mapeo.Id);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Registro insertado con exito";

                objectResponse.response = new
                {
                    data = true
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }


        [HttpPost("GetById")]
        public JsonResult GetById([FromQuery] int Id)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.GetDatosMapeo(Id);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información recuperada cop éxito";

                objectResponse.response = new
                {
                    data = respuesta
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("GetKardexArticulos")]
        
        public JsonResult GetKardexArticulos([FromBody] GetKardexCodigoReq mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.GetKardexArticulos(mapeo.FechaInicial, mapeo.FechaFinal, mapeo.Sucursal, mapeo.IdDepartamento);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información recuperada con éxito";

                objectResponse.response = new
                {
                    data = respuesta
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        [HttpPost("Get")]
        public JsonResult GetMapeos([FromQuery] int id_sucursal)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.GetMapeos(id_sucursal);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información recuperada cop éxito";

                objectResponse.response = new
                {
                    data = respuesta
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("GetKardexDepartamento")]
        
        public JsonResult GetKardexDepartamento([FromBody] GetKardexCodigoReq mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.GetKardexDepartamento(mapeo.FechaInicial, mapeo.FechaFinal, mapeo.Sucursal, mapeo.IdDepartamento);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información recuperada con éxito";

                objectResponse.response = new
                {
                    data = respuesta
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetKardexFamilia")]
        
        public JsonResult GetKardexFamilia([FromQuery] int sucursal, int familia, string fecha_inicial, string fecha_final)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.GetKardexFamilia(fecha_inicial, fecha_final, sucursal, familia);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información recuperada con éxito";

                objectResponse.response = new
                {
                    data = respuesta
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }


            return new JsonResult(objectResponse);

        }

        
    }
}