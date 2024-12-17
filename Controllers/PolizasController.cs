using System;
using Microsoft.AspNetCore.Mvc;
using marcatel_api.Services;
using marcatel_api.Utilities;
using Microsoft.AspNetCore.Authorization;
using marcatel_api.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using marcatel_api.Helpers;
using apiSegurosCelestial.Services;
using apiSegurosCelestial.Models;

namespace marcatel_api.Controllers
{
   
    [Route("api/[controller]")]
    public class PolizasController: ControllerBase
    {
        private readonly PolizasService _mapeoService;
        private readonly ILogger<PolizasController> _logger;
        private readonly IJwtAuthenticationService _authService;
        Encrypt enc = new Encrypt();

        public PolizasController(PolizasService mapeoservice, ILogger<PolizasController> logger, IJwtAuthenticationService authService) {
            _mapeoService = mapeoservice;
            _logger = logger;
       
            _authService = authService;
        }

        [HttpPost("InsertPoliza")]
        public JsonResult InsertPoliza([FromBody] InsertPolizaModel mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.InsertPoliza(mapeo, 1);
                
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

        [HttpGet("GetPolizas")]
        public JsonResult GetPolizas()
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.GetPolizas();
                
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

        [HttpGet("Getconsecutivo")]
        public JsonResult Getconsecutivo()
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.Getconsecutivo();
                
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

        [HttpPost("InsertBeneficiario")]
        public JsonResult InsertBeneficiario([FromBody] InsertBeneficiarioModel mapeo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.InsertBeneficiario(mapeo, mapeo.usuario);
                
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

        [HttpGet("GetBeneficiarios")]
        public JsonResult GetBeneficiarios([FromQuery] int consecutivo)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.GetBeneficiarios(consecutivo);
                
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


        
    }
}