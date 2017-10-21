using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digital_X_Ray.Models;
using Digital_X_Ray.Models.Validations;

namespace Digital_X_Ray.Controllers
{
    [Authorize]
    public class CaseController : Controller
    {

        DXREntities _databaseManager = new DXREntities();

        public ActionResult Detail(string id)
        {

            CaseCE model = new CaseCE();

            var codigoPag = this.RouteData.Values["id"];

            List<sp_cargarCaso_Result> listaBase = new List<sp_cargarCaso_Result>();
            listaBase = this._databaseManager.sp_cargarCaso(id).ToList();
            sp_cargarCaso_Result casoSeleccionado = new sp_cargarCaso_Result();
            casoSeleccionado = listaBase.First();
            int idCaso = 0;
            idCaso = casoSeleccionado.intIDCaso;

            List<sp_cargarImagenesDeCaso_Result> listaBaseImagenes = new List<sp_cargarImagenesDeCaso_Result>();
            listaBaseImagenes = this._databaseManager.sp_cargarImagenesDeCaso(idCaso).ToList();

            model.detallesCaso = casoSeleccionado;
            model.imagenesCaso = listaBaseImagenes;

            return View(model);
        }

        [HttpPost]
        public JsonResult setData(string codigoCaso, string problema, string trabajo, string observaciones, string codigoEstado, string imagenes)
        {
            try
            {
                int rows1 = 0;
                int rows2 = 0;

                if (!imagenes.Trim().Equals("") && imagenes != null)
                {
                    string[] imageInd = imagenes.Split(new[] { "||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||" }, StringSplitOptions.None);

                    foreach (var item in imageInd)
                    {
                        if (item != null && !item.Trim().Equals(""))
                        {
                            rows2 += this._databaseManager.sp_subirImagenes(Convert.ToInt32(codigoCaso), item);
                        }
                    }
                }


                rows1 = this._databaseManager.sp_editarCaso(Convert.ToInt32(codigoCaso), problema, trabajo, observaciones, codigoEstado);

                if (rows1 > 0)
                {
                    return Json(new { success = true, message = "Cambios guardados correctamente."}, JsonRequestBehavior.AllowGet);
                }else
                {
                    return Json(new { success = false, message = "Error en el proceso." }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error en el proceso." }, JsonRequestBehavior.AllowGet);
                throw ex;
            }
        }

    }
}