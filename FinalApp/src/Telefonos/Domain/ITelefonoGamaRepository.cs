using FinalApp.src.Data.Telefonos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.src.Telefonos.Domain
{
    public interface ITelefonoGamaRepository
    {
#nullable enable
        ICollection<TelefonoGama>? SearchAll();
#nullable disable
    }
}
