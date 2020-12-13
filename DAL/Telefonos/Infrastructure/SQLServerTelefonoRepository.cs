using DAL.Shared.Infrastructure.Persistance;
using DAL.Telefonos.Domain;
using Modelos.Telefonos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Telefonos.Infrastructure
{
    public class SQLServerTelefonoRepository : ITelefonoRepository
    {
        public void Save(Telefono telefono)
        {
            using var context = new IPearContext();

            context.Telefonos.Add(telefono);
            context.SaveChanges();
        }

        public ICollection<Telefono> SearchAll()
        {
            using var context = new IPearContext();

            return context.Telefonos.ToList();
        }
    }
}
