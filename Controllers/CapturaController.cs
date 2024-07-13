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
    public class CapturaController: ControllerBase
    {
        private readonly MapeosService _mapeoService;
        private readonly ILogger<MapeosController> _logger;
        private readonly IJwtAuthenticationService _authService;
        Encrypt enc = new Encrypt();

        public CapturaController(MapeosService mapeoservice, ILogger<MapeosController> logger, IJwtAuthenticationService authService) {
            _mapeoService = mapeoservice;
            _logger = logger;
       
            _authService = authService;
        }

        [HttpPost("GetMapeosCapturar")]
        public JsonResult GetMapeosCapturar([FromBody] MapeoModel mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.GetMapeosCapturar(mapeo.IdSucursal, 1);
                
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

        [HttpPost("GetMapeosCapturados")]
        public JsonResult GetMapeosCapturados([FromBody] MapeoModel mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.GetMapeosCapturados(mapeo.IdSucursal, 1);
                
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

        [HttpPost("GetCantidadesCapturadas")]
        public JsonResult GetCantidadesCapturadas([FromBody] GetCantidadesCapturadas req)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.GetCantidadesCapturadas(req.IdSucursal, req.Fecha);
                
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

        [HttpPost("GetMapeosCodigo")]
        public JsonResult GetMapeosCodigo([FromBody] GetMapeosCodigoReq request)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.GetMapeosCodigo(request.Codigo, request.Fecha, request.IdSucursal);
                
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

        [HttpPost("GetDiferenciasInventarios")]
        public JsonResult GetDiferenciasInventarios([FromBody] GetCantidadesCapturadas req)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.GetDiferenciasInventarios(req.IdSucursal, req.Fecha, req.IdDepartamento, req.FEchaCaptura, req.FechaFinal, req.IncluyeCeros, req.pageSize, req.skip);
                
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

        [HttpPost("GetDiferenciasInventariosExport")]
        public JsonResult GetDiferenciasInventariosExport([FromBody] GetCantidadesCapturadas req)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.GetDiferenciasInventariosExport(req.IdSucursal, req.Fecha, req.IdDepartamento, req.FEchaCaptura, req.FechaFinal, req.IncluyeCeros);
                
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

        [HttpGet("GetReporteValorInventario")]
        public JsonResult GetReporteValorInventario([FromQuery] int sucursal, string fecha_inicial, string fecha_final)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.ReporteValorInventario(sucursal,fecha_inicial, fecha_final );
                
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

        [HttpPost("Insert")]
        public JsonResult InsertCaptura([FromBody] CapturaModel captura)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.InsertCaptura(captura);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información registrada con éxito";

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

        [HttpPost("Finalizar")]
        public JsonResult FinalizarCaptura([FromBody] GuardarMapeoRequest captura)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.FinalizarCaptura(captura.Id, captura.IdUsuario);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información registrada con éxito";

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

        [HttpPost("GuardarTeoricoFecha")]
        public JsonResult InsertCaptura([FromBody] GuardarTeoricoFecha captura)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.GuardarTeoricoFecha(captura.FechaInicial, captura.FechaFinal, captura.FechaExistencia, captura.IdSucursal, captura.IdDepartamento);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información registrada con éxito";

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

        [HttpPost("InsertarConteoDirecto")]
        public JsonResult InsertarConteoDirecto([FromBody] CapturaDirectaModel captura)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.InsertarConteoDirecto(captura.Usuario, captura.Cantidad, captura.Codigo, captura.IdMapeo);
                
                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Información registrada con éxito";

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

        [HttpGet("GetCantidadesCapturadasMapeo")]
        public JsonResult GetCantidadesCapturadasMapeo([FromQuery] int id_mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                 var respuesta = _mapeoService.GetCantidadesCapturadasMapeo(id_mapeo);
                
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