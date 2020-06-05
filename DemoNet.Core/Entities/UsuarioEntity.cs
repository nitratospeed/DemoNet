using System;
using System.Collections.Generic;
using System.Text;

namespace DemoNet.Core.Entities
{
    public class UsuarioEntity
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Ocupacion { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
