using FinalApp.src.Data.Telefonos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.src.Telefonos.Domain
{
    public interface ITelefonoRepository
    {
        void Save(Telefono telefono);
#nullable enable
        ICollection<Telefono>? SearchAll();
#nullable disable
    }
}
