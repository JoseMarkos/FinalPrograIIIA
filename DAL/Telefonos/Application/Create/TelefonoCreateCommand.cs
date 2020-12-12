using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Telefonos.Application.Create
{
    public class TelefonoCreateCommand
    {
        private readonly int TelefonoCiudadEnsanblajeId;
        private readonly int TelefonoGamaId;
        private readonly int TelefonoColorId;
        private readonly decimal ProductionPrice;

        public TelefonoCreateCommand(int telefonoCiudadEnsanblajeId, int telefonoGamaId, int telefonoColorId, decimal productionPrice)
        {
            TelefonoCiudadEnsanblajeId = telefonoCiudadEnsanblajeId;
            TelefonoGamaId = telefonoGamaId;
            TelefonoColorId = telefonoColorId;
            ProductionPrice = productionPrice;
        }

        public int TelefonoCiudadEnsanblajeId1 => TelefonoCiudadEnsanblajeId;

        public int TelefonoGamaId1 => TelefonoGamaId;

        public int TelefonoColorId1 => TelefonoColorId;

        public decimal ProductionPrice1 => ProductionPrice;
    }
}
