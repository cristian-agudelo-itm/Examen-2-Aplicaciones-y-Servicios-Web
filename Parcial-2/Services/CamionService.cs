using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antlr.Runtime.Misc;
using Microsoft.Ajax.Utilities;
using Parcial_2.Models;
namespace Parcial_2.Services
{
    public class CamionService
    {
        DBExamenEntities db = new DBExamenEntities();
        public CamionService() { }

        public Camion ConsultarCamion(string placa)
        {
            try
            {
                Camion camion = db.Camion.FirstOrDefault(c => c.Placa == placa);
                if (camion != null)
                {
                    return camion;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
            
        }

        public List<Camion> ConsultarCamiones()
        {
            try
            {
                return db.Camion.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
        }

        public Camion CrearCamion(Camion camion)
        {
            try
            {
                if (db.Camion.Where(c => c.Placa == camion.Placa).Any())
                {
                    throw new Exception("El camion ya existe");
                }

                db.Camion.Add(camion);
                db.SaveChanges();
                return camion;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
        }

        public string EliminarCamion(string placa)
        {
            try
            {
                Camion cm = db.Camion.FirstOrDefault(e => e.Placa == placa);
                if (cm == null)
                {
                    return "No existe el camion";
                }

                db.Camion.Remove(cm);
                db.SaveChanges();

                return "Eliminado correctamente";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return "Ocurrió un error al eliminar el camion";
        }


    }
}