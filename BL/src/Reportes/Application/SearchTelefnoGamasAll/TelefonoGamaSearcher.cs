using DAL.Shared.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.src.Reportes.Application.SearchTelefnoGamasAll
{
    public class TelefonoGamaSearcher
    {
        public static IEnumerable<string> Trigger()
        {
            using var context = new IPearContext();

            var list = context.TelefonoGamas.ToList();

            var listNames = from x in list
                            select x.Name;

            return listNames;
        }
    }
}
