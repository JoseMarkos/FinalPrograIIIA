using DAL.Registros.Domain;
using DAL.Shared.Infrastructure.Persistance;
using Modelos.Registros;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Registros.Infrastructure.Persistance
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
