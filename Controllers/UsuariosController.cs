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
    public class UsuariosController: ControllerBase
    {
        private readonly UsuariosService _usuarioService;
        private readonly ILogger<UsuariosController> _logger;
        Encrypt enc = new Encrypt();

        public UsuariosController(UsuariosService usuarioservice, ILogger<UsuariosController> logger) {
            _usuarioService = usuarioservice;
            _logger = logger;
        }

        [HttpPost("InsertUsuario")]
        public JsonResult InsertUsuario([FromBody] UsuarioRequest request)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _usuarioService.InsertUsuario(request);
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "Usuario creado con éxito";

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

        [HttpGet("GetUsuarios")]
        public JsonResult GetUsuarios()
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _usuarioService.GetUsuarios();
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

        [HttpGet("DeleteUsuario")]
        public JsonResult GetBeneficiarios([FromQuery] int usuarioId)
        {
            var objectResponse = Helper.GetStructResponse();
            try
            {
                var CatClienteResponse = _usuarioService.DeleteUsuario(usuarioId);
                objectResponse.StatusCode = (int)HttpStatusCode.Created;
                objectResponse.success = true;
                objectResponse.message = "Usuario actualizado con éxito";

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