using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC01.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Clave { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", IdUsuario,Nombre,Correo,Telefono);
        }
    }
}
