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
            var registroRepository = 2;

            var routes = Routes.GetRoutes();

            var menuItems = new Dictionary<string, IController>
            {
                { "Add a register", (IController)routes["CreateRegistro"] },
                //{ "Report by Gama", (IController)routes["ReporteGama"] },
               // { "Report multiparametros", (IController)routes["ReporteMultiparametros"] }
            };

            var data = new Dictionary<string, object>
            {
                { "menuItems", menuItems },
            };

            var form = new Dashboard(data);
            return form;
        }
    }
}
