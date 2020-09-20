using FinalApp.apps.Templates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinalApp.apps.Controllers.Dashboards
{
    public class DashboardController : IController
    {
        public Form GetForm()
        {
            var routes = Routes.GetRoutes();

            var registroMenuItems = new Dictionary<string, IController>
            {
                { "Add a register", (IController)routes["CreateRegistro"] },
            };

            var reporteMenuItems = new Dictionary<string, IController>
            {
                { "Report by Gama", (IController)routes["ReporteGama"] },
                { "Report multiparametros", (IController)routes["ReporteMultiparametro"] }
            };

            var data = new Dictionary<string, object>
            {
                { "registroMenuItems", registroMenuItems },
                { "reporteMenuItems", reporteMenuItems },
            };

            var form = new Dashboard(data);
            return form;
        }
    }
}
