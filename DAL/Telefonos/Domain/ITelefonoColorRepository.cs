using Modelos.Telefonos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Telefonos.Domain
{
    public interface ITelefonoColorRepository
    {
#nullable enable
        ICollection<TelefonoColor>? SearchAll();
#nullable disable
    }
}
