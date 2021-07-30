using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSyscompsa.Models
{
    public class Webappusers
    {
        public int id         { get; set; }
        public int resp       { get; set; }
        public string usuario { get; set; }
        public string perfil  { get; set; }
    }

    public class Mensajeria
    {
        public string usuario        { get; set; }
        public string mensaje        { get; set; }
        public DateTime date_mensaje { get; set; }
        public int estado            { get; set; }
        public string token_canal    { get; set; }
    }
    
    public class Chanels
    {
        public string usuario           { get; set; }
        public string imgcanal          { get; set; }
        public string descripcion_canal { get; set; }
        public DateTime datetime        { get; set; }
        public int    estado            { get; set; }
        public string token_canal       { get; set; }
    }

}
