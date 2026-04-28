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
    public class ReportesController: ControllerBase
    {
        private readonly ReportesService _reportesService;
        private readonly ILogger<ReportesController> _logger;
        Encrypt enc = new Encrypt();

        public ReportesController(ReportesService reportesservice, ILogger<ReportesController> logger) {
            _reportesService = reportesservice;
            _logger = logger;
        }

        [HttpPost("GetReporteAbonos")]
        public JsonResult GetReporteAbonos([FromBody] ReporteAbonosRequest request)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _reportesService.GetReporteAbonos(request);
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = (CatClienteResponse.Count > 0) ? "Información obtenida correctamente" : "No se encontraron resultados";

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