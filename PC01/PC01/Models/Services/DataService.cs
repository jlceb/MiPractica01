using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PC01.Models.Services
{
    public class DataService : IDisposable
    {
        private string rutaDb;

        public DataService()
        {
            var directorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            rutaDb = System.IO.Path.Combine(directorio, "Usuarios.db");

            using (var _db = new SQLiteConnection(rutaDb))
            {
                _db.CreateTable<Usuario>();
            }
        }

        public void SaveUser(Usuario usuario)
        {
            using (var _db = new SQLiteConnection(rutaDb))
            {
                _db.Insert(usuario);
            }
        }

        public Usuario GetUser(string uMail)
        {
            using (var _db = new SQLiteConnection(rutaDb))
            {
                return _db.Table<Usuario>().FirstOrDefault(x => x.Correo == uMail);
            }
        }

        public List<Usuario> GetAllUser()
        {
            using (var _db = new SQLiteConnection(rutaDb))
            {
                return _db.Table<Usuario>().ToList();
            }
        }

        public void Dispose()
        {
            using (var _db = new SQLiteConnection(rutaDb))
            {
                _db.Dispose();
            }
        }
    }
}
