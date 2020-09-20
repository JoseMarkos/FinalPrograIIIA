using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.src.Registros.Application.Create
{
    public class CrearRegistroCommand
    {
        private readonly DateTime dateAdded;
        private readonly int telefonoId;

        public CrearRegistroCommand(DateTime dateAdded, int telefonoId)
        {
            this.dateAdded = dateAdded;
            this.telefonoId = telefonoId;
        }

        public DateTime DateAdded => dateAdded;

        public int TelefonoId => telefonoId;
    }
}
