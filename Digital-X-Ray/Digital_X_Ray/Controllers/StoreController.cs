using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digital_X_Ray.Models;

namespace Digital_X_Ray.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {

        DXREntities _databaseManager = new DXREntities();
        
        public ActionResult List()
        {
            List<sp_listarProductos_Result> listaBase = new List<sp_listarProductos_Result>();
            listaBase = _databaseManager.sp_listarProductos().ToList();
            return View(listaBase);
        }
    }
}