using FinalApp.src.Data.Telefonos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.src.Telefonos.Domain
{
    public interface ITelefonoColorRepository
    {
#nullable enable
        ICollection<TelefonoColor>? SearchAll();
#nullable disable
    }
}
