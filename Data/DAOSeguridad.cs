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
        public void insertarToken_Seguridad(UToken_Seguridad tokenseguridad)
        {
            using (var db = new Mapeo())
            {
                db.token_seguridad.Add(tokenseguridad);
                db.SaveChanges();
            }
        }
        public void insertarAcceso(UAcceso acceso)
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
                UAcceso acceso = db.acceso.Where(x => x.UserId == userId && x.FechaFin == null).FirstOrDefault();
                acceso.FechaFin = DateTime.Now;
            
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

        public UAplicacion getAplicaionesByToken(string token)
        {
            using (var db = new Mapeo())
            {
                return (from t in db.token_seguridad
                        join a in db.aplicacion on t.AplicacionId equals a.Id
                        where t.Token.Equals(token)
                        select new
                        {
                            a
                        }).ToList().Select(m => new UAplicacion
                        {
                            Id = m.a.Id,
                            Expiracion = m.a.Expiracion,
                            Key = m.a.Key,
                            Nombre = m.a.Nombre
                        }).FirstOrDefault();
            }
        }
    }
    }