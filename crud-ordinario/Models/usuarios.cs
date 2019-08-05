using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud_ordinario.Models
{
    public class usuarios
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string edociv { get; set; }
        public string hijos { get; set; }
        public string libros { get; set; }
        public string musica { get; set; }
        public string deportes { get; set; }
        public string otros { get; set; }
        public string intereses { get; set; }      

        
    }
}