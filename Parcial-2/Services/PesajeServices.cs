using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


using System.Net;
using System.Net.Http;
using System.IO;
using Parcial_2.Models;

namespace Parcial_2.Services
{

    public class Resultado
    {
        public string Ruta { get; set; }
        public string Error { get; set; }

        public Pesaje pesaje { get; set; }
        public Camion camion { get; set; }
    }


    public class PesajeServices
    {

        DBExamenEntities db = new DBExamenEntities();
        public async Task<HttpResponseMessage> AgregarPesaje(HttpRequestMessage request)
        {
            if (!request.Content.IsMimeMultipartContent())
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "No se recibió la imagen");

            Resultado resultado = await GuardarArchivo(request);

            if (!string.IsNullOrEmpty(resultado.Error))
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, resultado.Error);

            Camion d_camion = db.Camion.FirstOrDefault(e => e.Placa == resultado.pesaje.Camion.Placa);
            if (d_camion != null)
            {
                resultado.pesaje.Camion = d_camion;
            }
            else
            {
                db.Camion.Add(resultado.pesaje.Camion);
            }
            int nextId = db.Pesaje.OrderByDescending(p => p.id).Select(p => p.id).FirstOrDefault() + 1;

            resultado.pesaje.id = nextId;
            db.Pesaje.Add(resultado.pesaje);
            db.SaveChanges();


            return request.CreateResponse(HttpStatusCode.Created, "Pesaje registrado");
        }


        private async Task<Resultado> GuardarArchivo(HttpRequestMessage request)
        {


            string root = HttpContext.Current.Server.MapPath("~/media");
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);

            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                await request.Content.ReadAsMultipartAsync(provider);

                if (provider.FileData.Count == 0)
                    return new Resultado { Ruta = "", Error = "No se encontró la imagen" };

                var file = provider.FileData[0];
                var fileName = Path.GetFileName(file.Headers.ContentDisposition.FileName.Trim('"'));
                var extension = Path.GetExtension(fileName).ToLower();

                if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                {
                    File.Delete(file.LocalFileName);
                    return new Resultado { Ruta = "", Error = "Extension invalida" };
                }

                string n_name = Guid.NewGuid().ToString("N") + extension;


                var fullPath = Path.Combine(root, n_name);

                if (File.Exists(fullPath))
                    File.Delete(fullPath);


                string rutaRelativa = "/media/" + n_name;

                Pesaje pesaje = new Pesaje();
                pesaje.Camion = new Camion();
                pesaje.Camion.Placa = provider.FormData["Placa"];
                pesaje.Camion.Marca = provider.FormData["Marca"];
                pesaje.Camion.NumeroEjes = Convert.ToInt32(provider.FormData["Ejes"]);

                pesaje.FechaPesaje = DateTime.Now;
                pesaje.FotoPesaje = new List<FotoPesaje>();
                pesaje.FotoPesaje.Add(new FotoPesaje { ImagenVehiculo = rutaRelativa });

                pesaje.Peso = Convert.ToSingle(provider.FormData["Peso"]);
                pesaje.Estacion = provider.FormData["Estacion"];



                File.Move(file.LocalFileName, fullPath);
                return new Resultado { Ruta = rutaRelativa, Error = "", pesaje = pesaje };

            }
            catch (Exception e)
            {
                return new Resultado { Ruta = "", Error = "Error al procesar la imagen " + e.ToString() };
            }
        }
    }
}