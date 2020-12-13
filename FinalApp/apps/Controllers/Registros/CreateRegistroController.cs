using DAL.Registros.Application.Create;
using DAL.Registros.Infrastructure.Persistance;
using DAL.Telefonos.Application.Create;
using DAL.Telefonos.Infrastructure;
using FinalApp.apps.Templates.Registros;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinalApp.apps.Controllers.Registros
{
    public class CreateRegistroController : IController
    {
        public Form GetForm()
        {
            var registroRepository = new SQLServerRegistroRepository();
            var registerCreator = new RegisterCreator(registroRepository);
            var registerCreatorHandler = new CrearRegistroCommandHandler(registerCreator);

            var telefonoRepository = new SQLServerTelefonoRepository();
            var telefonoCreator = new TelefonoCreator(telefonoRepository);
            var telefonoCreatorHandler = new TelefonoCreateCommandHandler(telefonoCreator);


            var data = new Dictionary<string, object>
            {
                { "telefonoCreatorHandler", telefonoCreatorHandler },
                { "registerCreatorHandler", registerCreatorHandler },
            };

            var form = new CreateRegistro(data);
            return form;
        }
    }
}
