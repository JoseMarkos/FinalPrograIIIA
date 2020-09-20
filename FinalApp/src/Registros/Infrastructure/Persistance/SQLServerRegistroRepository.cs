using FinalApp.src.Data.Registros;
using FinalApp.src.Registros.Domain;
using FinalApp.src.Shared.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalApp.src.Registros.Infrastructure.Persistance
{
    public class SQLServerRegistroRepository : IRegistroRepository
    {
        public void Save(Registro registro)
        {
            using var context = new IPearContext();

            context.Registros.Add(registro);
            context.SaveChanges();
        }

        public ICollection<Registro> SearchAll()
        {
            using var context = new IPearContext();

            return context.Registros.ToList();
        }
    }
}
