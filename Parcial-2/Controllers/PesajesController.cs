using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Parcial_2.Models;
using Parcial_2.Services;
using System.IO;
using System.Threading.Tasks;



namespace Parcial_2.Controllers
{
    [RoutePrefix("api/Pesajes")]
    public class PesajesController : ApiController
    {

        PesajeServices PeajeSv = new PesajeServices();

        [HttpPost]
        [Route("Agregar")]
        public async Task<HttpResponseMessage> SubirConDatos(HttpRequestMessage request)
        {
            return await PeajeSv.AgregarPesaje(request);
        }
    }
}