using FinalApp.apps.Controllers;
using FinalApp.apps.Controllers.Dashboards;
using FinalApp.apps.Controllers.Registros;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.apps
{
    public class Routes
    {
        public static Dictionary<string, IController> GetRoutes()
        {
            var dictionary = new Dictionary<string, IController>
            {
                { "Dashboard", new DashboardController() },
                { "CreateRegistro", new CreateRegistroController() },
            };

            return dictionary;
        }
    }
}
