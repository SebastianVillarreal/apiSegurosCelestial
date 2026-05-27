using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using apiSegurosCelestial.Models;
using apiSegurosCelestial.Services;
using marcatel_api.Helpers;
using marcatel_api.Services;
using marcatel_api.Utilities;

namespace marcatel_api.Controllers
{
    [Route("api/[controller]")]
    public class CertificadosController : ControllerBase
    {
        private readonly CertificadosService _certificadosService;
        private readonly ILogger<CertificadosController> _logger;
        private readonly IJwtAuthenticationService _authService;
        Encrypt enc = new Encrypt();

        public CertificadosController(CertificadosService certificadosService, ILogger<CertificadosController> logger, IJwtAuthenticationService authService)
        {
            _certificadosService = certificadosService;
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("InsertCertificado")]
        public JsonResult InsertCertificado([FromBody] InsertCertificadoModel certificado)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var insertResponse = _certificadosService.InsertCertificado(certificado);

                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Proceso completado con éxito";

                objectResponse.response = new
                {
                    data = insertResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetAllCertificados")]
        public JsonResult GetAllCertificados()
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var certificadosResponse = _certificadosService.GetAllCertificados();

                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Proceso completado con éxito";

                objectResponse.response = new
                {
                    data = certificadosResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetCertificadoById")]
        public JsonResult GetCertificadoById([FromQuery] int pId)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var certificadoResponse = _certificadosService.GetCertificadoById(pId);

                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Proceso completado con éxito";

                objectResponse.response = new
                {
                    data = certificadoResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }

            return new JsonResult(objectResponse);
        }

        [HttpPost("InsertCertificadoAbono")]
        public JsonResult InsertCertificadoAbono([FromBody] InsertCertificadoAbonoModel abono)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var insertResponse = _certificadosService.InsertCertificadoAbono(abono);

                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Proceso completado con éxito";

                objectResponse.response = new
                {
                    data = insertResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetCertificadoAbonosByCertificado")]
        public JsonResult GetCertificadoAbonosByCertificado([FromQuery] int pIdCertificado)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var abonosResponse = _certificadosService.GetCertificadoAbonosByCertificado(pIdCertificado);

                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Proceso completado con éxito";

                objectResponse.response = new
                {
                    data = abonosResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetEstadoCuentaCertificado")]
        public JsonResult GetEstadoCuentaCertificado([FromQuery] int pIdCertificado)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var estadoCuentaResponse = _certificadosService.GetEstadoCuentaCertificado(pIdCertificado);

                objectResponse.StatusCode = (int)HttpStatusCode.OK;
                objectResponse.success = true;
                objectResponse.message = "Proceso completado con éxito";

                objectResponse.response = new
                {
                    data = estadoCuentaResponse
                };
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }

            return new JsonResult(objectResponse);
        }

        [HttpGet("GetCertificadoPdf")]
        public IActionResult GetCertificadoPdf([FromQuery] int pIdCertificado)
        {
            var pdfBytes = _certificadosService.GenerarCertificadoPdf(pIdCertificado);
            return File(pdfBytes, "application/pdf", "Certificado_" + pIdCertificado + ".pdf");
        }
    }
}
