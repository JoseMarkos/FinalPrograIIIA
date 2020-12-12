using Modelos.Telefonos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Telefonos.Domain
{
    public interface ITelefonoCiudadEnsamblajeRepository
    {
#nullable enable
        TelefonoCiudadEnsanblaje? Search(string name);
        ICollection<TelefonoCiudadEnsanblaje>? SearchAll();
#nullable disable
    }
}
