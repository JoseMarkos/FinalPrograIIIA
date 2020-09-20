using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalApp.src.Data.Telefonos
{
    public class Telefono
    {
        public int Id { get; set; }
#nullable enable
        public int? TelefonoCiudadEnsanblajeId { get; set; }
        public TelefonoCiudadEnsanblaje? TelefonoCiudadEnsanblaje { get; set; }
        public int? TelefonoGamaId { get; set; }
        public TelefonoGama? TelefonoGama { get; set; }
        public int? TelefonoColorId { get; set; }
        public TelefonoColor? TelefonoColor { get; set; }
#nullable disable

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductionPrice { get; set; }
    }
}
