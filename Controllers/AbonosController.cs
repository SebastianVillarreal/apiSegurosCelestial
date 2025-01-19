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
    public class AbonosController: ControllerBase
    {
        private readonly PagosService _mapeoService;
        private readonly ILogger<AbonosController> _logger;
        private readonly IJwtAuthenticationService _authService;
        Encrypt enc = new Encrypt();

        public AbonosController(PagosService mapeoservice, ILogger<AbonosController> logger, IJwtAuthenticationService authService) {
            _mapeoService = mapeoservice;
            _logger = logger;
       
            _authService = authService;
        }
        [HttpPost("InsertAbonoPoliza")]
        public JsonResult InsertPoliza([FromBody] InsertPagoModel abono)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.InsertarAbonoPoliza(abono);
                
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

        [HttpGet("GetAbonosPolizas")]
        public JsonResult GetAbonosPolizas([FromQuery] int id_poliza)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _mapeoService.GetPolizas(id_poliza);
                
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
