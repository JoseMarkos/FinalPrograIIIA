using DAL.Telefonos.Domain;
using Modelos.Telefonos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Telefonos.Application.Create
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
