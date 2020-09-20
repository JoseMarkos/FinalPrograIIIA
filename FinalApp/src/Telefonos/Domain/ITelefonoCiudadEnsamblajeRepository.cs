using FinalApp.src.Data.Telefonos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.src.Telefonos.Domain
{
    public interface ITelefonoCiudadEnsamblajeRepository
    {
#nullable enable
        TelefonoCiudadEnsanblaje? Search(string name);
        ICollection<TelefonoCiudadEnsanblaje>? SearchAll();
#nullable disable
    }
}
