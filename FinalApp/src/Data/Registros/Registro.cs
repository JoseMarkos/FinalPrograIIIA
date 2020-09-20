using FinalApp.src.Data.Telefonos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalApp.src.Data.Registros
{
    public class Registro
    {
        public int Id { get; set; }
        public DateTime? DateAdded { get; set; }
        public int? TelefonoId { get; set; }
        public Telefono Telefono { get; set; }
    }
}
