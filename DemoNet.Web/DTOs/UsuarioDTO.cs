using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoNet.Web.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Ocupacion { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    }
}
