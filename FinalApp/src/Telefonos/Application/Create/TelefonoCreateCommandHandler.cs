using FinalApp.src.Telefonos.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.src.Telefonos.Application.Create
{
    public class TelefonoCreateCommandHandler
    {
        private readonly TelefonoCreator Creator;

        public TelefonoCreateCommandHandler(TelefonoCreator creator)
        {
            Creator = creator;
        }

        public void Trigger(TelefonoCreateCommand command)
        {
            var telefonoCiudadEnsanblajeValueObject = new TelefonoCiudadEnsamblajeValueObject(command.TelefonoCiudadEnsanblajeId1);
            var telefonoGamaValueObject = new TelefonoGamaValueObject(command.TelefonoGamaId1);
            var telefonoColorValueObject = new TelefonoColorValueObject(command.TelefonoColorId1);

            Creator.Create(telefonoCiudadEnsanblajeValueObject, telefonoGamaValueObject, telefonoColorValueObject, command.ProductionPrice1);
        }
    }
}
