using Modelos.Registros;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Registros.Domain
{
    public interface IRegistroRepository
    {
        void Save(Registro registro);
#nullable enable
        ICollection<Registro>? SearchAll();
#nullable disable
    }
}
