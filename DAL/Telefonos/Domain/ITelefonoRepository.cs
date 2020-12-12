using Modelos.Telefonos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Telefonos.Domain
{
    public interface ITelefonoRepository
    {
        void Save(Telefono telefono);
#nullable enable
        ICollection<Telefono>? SearchAll();
#nullable disable
    }
}
