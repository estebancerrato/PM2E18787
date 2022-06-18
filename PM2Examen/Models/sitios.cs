using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2Examen.Models
{
    public class sitios
    {
        [PrimaryKey, AutoIncrement]
        public int  id { get; set; }    
        public float longitud { get; set; }  
        public float latitud { get; set; }
        public string descripcion { get; set; }
        public byte[] imagen { get; set; }    
    }
}
