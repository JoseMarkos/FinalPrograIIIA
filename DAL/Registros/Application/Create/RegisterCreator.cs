using DAL.Registros.Domain;
using Modelos.Registros;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Registros.Application.Create
{
    public class RegisterCreator
    {
        private readonly IRegistroRepository repository;

        public RegisterCreator(IRegistroRepository repository)
        {
            this.repository = repository;
        }

        public void Create(DateTime dateAdded, int telefonoId)
        {
            var registro = new Registro()
            {
                DateAdded = dateAdded,
                TelefonoId = telefonoId
            };

            repository.Save(registro);
        }
    }
}
