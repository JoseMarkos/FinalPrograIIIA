using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.src.Registros.Application.Create
{
    public class CrearRegistroCommandHandler
    {
        private readonly RegisterCreator registerCreator;

        public CrearRegistroCommandHandler(RegisterCreator registerCreator)
        {
            this.registerCreator = registerCreator;
        }

        public void Trigger(CrearRegistroCommand command)
        {
            registerCreator.Create(command.DateAdded, command.TelefonoId);
        }
    }
}
