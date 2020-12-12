using Modelos.Telefonos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Registros
{
    public class Registro
    {
        public int Id { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? TelefonoId { get; set; }
        public Telefono Telefono { get; set; }
    }
}
