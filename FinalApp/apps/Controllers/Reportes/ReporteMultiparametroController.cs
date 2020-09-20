using FinalApp.apps.Templates.Reportes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinalApp.apps.Controllers.Reportes
{
    public class ReporteMultiparametroController : IController
    {
        public Form GetForm()
        {
            var form = new ReporteMultiparametro();
            return form;
        }
    }
}
