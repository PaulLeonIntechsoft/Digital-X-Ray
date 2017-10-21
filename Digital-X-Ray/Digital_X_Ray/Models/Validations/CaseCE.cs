
using Digital_X_Ray.Models;
using System.Collections.Generic;

namespace Digital_X_Ray.Models.Validations
{
    public class CaseCE
    {

        public sp_cargarCaso_Result detallesCaso { get; set; }
        public List<sp_cargarImagenesDeCaso_Result> imagenesCaso { get; set; }

    }
}