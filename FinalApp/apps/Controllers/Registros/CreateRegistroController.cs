using FinalApp.apps.Templates.Registros;
using FinalApp.src.Registros.Application.Create;
using FinalApp.src.Registros.Infrastructure.Persistance;
using FinalApp.src.Telefonos.Application.Create;
using FinalApp.src.Telefonos.Infrastructure.Persistance;
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
