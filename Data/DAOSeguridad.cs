using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Utilitarios;

/// <summary>
/// Descripción breve de DAOSeguridad
/// </summary>
/// 
namespace Data
{

    public class DAOSeguridad
    {
        public void insertarToken(UToken token)
        {
            using (var db = new Mapeo())
            {
                db.token.Add(token);
                db.SaveChanges();
            }
        }

        public void insertarAcceso(UMac acceso)
        {
            using (var db = new Mapeo())
            {
                db.acceso.Add(acceso);
                db.SaveChanges();
            }
        }

        public void cerrarAcceso(int userId)
        {
            using (var db = new Mapeo())
            {
                UMac acceso = db.acceso.Where(x => x.User_id == userId && x.Fecha_fin == null).FirstOrDefault();
                acceso.Fecha_fin = DateTime.Now;
            
                db.acceso.Attach(acceso);

                var entry = db.Entry(acceso);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public UToken getTokenByUser(int userId)
        {
            return new Mapeo().token.Where(x => x.User_id == userId && x.Vigencia > DateTime.Now).FirstOrDefault();
        }

        public UToken getTokenByToken(string token)
        {
            return new Mapeo().token.Where(x => x.Tokeng == token).FirstOrDefault();
        }

        public void updateClave(UUsuario usuario)
        {
            using (var db = new Mapeo())
            {
                UUsuario usuarioAnterior = db.usuari.Where(x => x.Id == usuario.Id).First();
                usuarioAnterior.Contrasenia = usuario.Contrasenia;

                db.usuari.Attach(usuarioAnterior);

                var entry = db.Entry(usuarioAnterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
    }