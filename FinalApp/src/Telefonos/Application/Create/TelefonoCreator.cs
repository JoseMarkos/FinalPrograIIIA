using FinalApp.src.Data.Telefonos;
using FinalApp.src.Telefonos.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.src.Telefonos.Application.Create
{
    public class TelefonoCreator
    {
        private readonly ITelefonoRepository Repository;

        public TelefonoCreator(ITelefonoRepository repository)
        {
            Repository = repository;
        }

        public void Create(TelefonoCiudadEnsamblajeValueObject telefonoCiudadEnsanblaje
            , TelefonoGamaValueObject telefonoGamaId
            , TelefonoColorValueObject telefonoColorId
            , decimal productionPrice)
        {
            var telefono = new Telefono()
            {
                TelefonoCiudadEnsanblajeId = telefonoCiudadEnsanblaje.GetValue(),
                TelefonoGamaId = telefonoGamaId.GetValue(),
                TelefonoColorId = telefonoColorId.GetValue(),
                ProductionPrice = productionPrice
            };

            Repository.Save(telefono);
        }
    }
}
