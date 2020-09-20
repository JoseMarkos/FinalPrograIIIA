using FinalApp.src.Data.Registros;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.src.Registros.Domain
{
    public interface IRegistroRepository
    {
        void Save(Registro registro);
#nullable enable
        ICollection<Registro>? SearchAll();
#nullable disable
    }
}
