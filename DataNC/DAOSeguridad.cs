using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilitarios;

/// <summary>
/// Descripción breve de DAOSeguridad
/// </summary>
/// 
namespace DataNC
{

    public class DAOSeguridad
    {
        private readonly Mapeo _context;

        public DAOSeguridad(Mapeo context)
        {
            _context = context;
        }

        public void insertarToken(UToken token)
        {
            using (var db = _context)
            {
                db.token.Add(token);
                db.SaveChanges();
            }
        }
        public void insertarToken_Seguridad(UToken_Seguridad tokenseguridad)
        {
            using (var db = _context)
            {
                db.token_seguridad.Add(tokenseguridad);
                db.SaveChanges();
            }
        }
        public void insertarAcceso(UAcceso acceso)
        {
            using (var db = _context)
            {
                db.acceso.Add(acceso);
                db.SaveChanges();
            }
        }

        public void cerrarAcceso(int userId)
        {
            using (var db = _context)
            {
                UAcceso acceso = db.acceso.Where(x => x.UserId == userId && x.FechaFin == null).FirstOrDefault();
                acceso.FechaFin = DateTime.Now;
            
                db.acceso.Attach(acceso);

                var entry = db.Entry(acceso);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
       
        }
        public void destruirToken(int userId)
        {
            using (var db = _context)
            {
                UToken_Seguridad tokenAcceso= db.token_seguridad.Where(X => X.UserId ==userId).First();
                db.token_seguridad.Remove(tokenAcceso);
                db.SaveChanges();

            }
        }
        public List<UToken_Seguridad> recorrerTokenSeguridad()
        {
            using (var db = _context)
            {

                return _context.token_seguridad.OrderBy(X =>X.Id).ToList<UToken_Seguridad>();
            }

            
        }
        public UToken getTokenByUser(int userId)
        {
            return _context.token.Where(x => x.User_id == userId && x.Vigencia > DateTime.Now).FirstOrDefault();
        }

        public UToken getTokenByToken(string token)
        {
            return _context.token.Where(x => x.Tokeng == token).FirstOrDefault();
        }

        public void updateClave(UUsuario usuario)
        {
            using (var db = _context)
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
            using (var db =_context)
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