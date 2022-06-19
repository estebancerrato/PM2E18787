using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM2Examen.Models;
using System.Threading.Tasks;

namespace PM2Examen.Controllers
{
    public class dbsitios
    {
        readonly SQLiteAsyncConnection dbbase;

        //Constructor de la clase  

        public dbsitios(string dbpath)
        {
            //condision a la base de datos 
            dbbase = new SQLiteAsyncConnection(dbpath);


            //crearemos las tablas en la base de datos 
            dbbase.CreateTableAsync<sitios>();
        }
        //hacemos la creacion del crud


        public Task<int> sitioSave(sitios direcc)
        {
            if (direcc.id != 0)
            {
                return dbbase.UpdateAsync(direcc);//actualizamos
            }
            else
            {
                return dbbase.InsertAsync(direcc);//i si no esta lo inserta
            }
        }

        //con read podemos leer informacion de la tabla 
        //read
        public Task<List<sitios>> ObtenerlistadoSitio()

        {
            return dbbase.Table<sitios>().ToListAsync();
        }

        //eliminar
        public Task<int> eliminarsitio(sitios direcc)
        {
            return dbbase.DeleteAsync(direcc);

        }
        // Obtener Latitud de UbicacionesDB
        public Task<sitios> ObtenerLongitud(float uLongitud)
        {
            return dbbase.Table<sitios>().Where(i => i.longitud == uLongitud).FirstOrDefaultAsync();
        }

        // Obtener Latitud de UbicacionesDB
        public Task<sitios> ObtenerLatitud(float uLatitud)
        {
            return dbbase.Table<sitios>().Where(i => i.latitud == uLatitud).FirstOrDefaultAsync();
        }

        // Obtener Descripcion de UbicacionesDB
        public Task<sitios> ObtenerDescripcion(String uDescripcion)
        {
            return dbbase.Table<sitios>().Where(i => i.descripcion == uDescripcion).FirstOrDefaultAsync();
        }


    }
}
