using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Parcial_2.Models;
using Parcial_2.Services;

namespace Parcial_2.Controllers
{
    [RoutePrefix("api/Camiones")]
    public class CamionesController : ApiController
    {
        CamionService CamionSv = new CamionService();


        [HttpGet]
        [Route("{placa}")]
        public Camion ObtenerCamion(string placa)
        {
            return CamionSv.ConsultarCamion(placa);
        }

        [HttpGet]
        [Route("")]
        public List<Camion> ObtenerCamiones()
        {
            return CamionSv.ConsultarCamiones();
        }

        [HttpPost]
        [Route("Agregar")]
        public Camion AgregarCamion([FromBody] Camion camion)
        {
            return CamionSv.CrearCamion(camion);
        }

        [HttpDelete]
        [Route("{placa}")]
        public string EliminarCamion(string placa)
        {
            return CamionSv.EliminarCamion(placa);
        }
    }
}