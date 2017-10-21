using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digital_X_Ray.Models;
using System.Globalization;
using System.Security.Claims;

namespace Digital_X_Ray.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        DXREntities _databaseManager = new DXREntities();

        public ActionResult Index()
        {
            return this.View();
        }

        public JsonResult getDates(string fechaElegida, string diaElegido)
        {
            try
            {
                var identity = (ClaimsIdentity)User.Identity;

                var cod = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                       .Select(c => c.Value).SingleOrDefault();
                var nuevaFecha = DateTime.ParseExact(fechaElegida,"yyyy-MM-dd", CultureInfo.InvariantCulture);
                string fechaInicio = null;
                string fechaFin = null;
                string formatoFecha = "yyyy-MM-dd";

                if (diaElegido.Equals("0"))
                {
                    fechaInicio = nuevaFecha.ToString(formatoFecha);
                    fechaFin = nuevaFecha.AddDays(5.0).ToString(formatoFecha);
                } else if (diaElegido.Equals("1"))
                {
                    fechaInicio = nuevaFecha.AddDays(-1.0).ToString(formatoFecha);
                    fechaFin = nuevaFecha.AddDays(4.0).ToString(formatoFecha);
                }
                else if (diaElegido.Equals("2"))
                {
                    fechaInicio = nuevaFecha.AddDays(-2.0).ToString(formatoFecha);
                    fechaFin = nuevaFecha.AddDays(3.0).ToString(formatoFecha);
                }
                else if (diaElegido.Equals("3"))
                {
                    fechaInicio = nuevaFecha.AddDays(-3.0).ToString(formatoFecha);
                    fechaFin = nuevaFecha.AddDays(2.0).ToString(formatoFecha);
                }
                else if (diaElegido.Equals("4"))
                {
                    fechaInicio = nuevaFecha.AddDays(-4.0).ToString(formatoFecha);
                    fechaFin = nuevaFecha.AddDays(1.0).ToString(formatoFecha);
                }
                else if (diaElegido.Equals("5"))
                {
                    fechaInicio = nuevaFecha.AddDays(-5.0).ToString(formatoFecha);
                    fechaFin = nuevaFecha.ToString(formatoFecha);
                }

                List<sp_cargarCasos_Result> listaBase = new List<sp_cargarCasos_Result>();
                listaBase = this._databaseManager.sp_cargarCasos(cod, fechaInicio, fechaFin).ToList();
                var lst = (from n in listaBase
                           select new { n.chrNroCaso, dtmfecProg = ((DateTime)n.dtmfecProg).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),n.chrCliAdic,
                               n.bytHoraIni, n.chrEstCaso, n.chrDesEsp, n.difrInicio, n.difrFin});
                return Json(lst,JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
                throw;
            }
        }

    }
}