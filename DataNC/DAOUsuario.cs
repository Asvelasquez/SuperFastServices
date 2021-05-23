using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilitarios;


/// <summary>
/// Descripción breve de DAOUsuario
/// </summary>
/// 

namespace DataNC
{
    //[Serializable]
    //[Table("usuario", Schema = "informacion")]
    public class DAOUsuario
    {
        private readonly Mapeo _context;

        public DAOUsuario(Mapeo context)
        {
            _context = context;
        }


        public void insertUsuario(UUsuario usuario2)
        {
            using (var db = _context)
            {
                db.usuari.Add(usuario2);
                db.SaveChanges();
            }
        }

        //validar correo registrarse 
        public UUsuario getCorreoByregistrarse(string correo)
        {

            return _context.usuari.Where(x => (x.Correo.Equals(correo))).FirstOrDefault();
        }
        //envio dinamico clase generarToken dinamico correo
        public UUsuario getCorreoByCorreos(string correo)
        {
            return _context.usuari.Where(x => (x.Correo.Contains(correo))).FirstOrDefault();
        }

        //public Usuario getcerrarsession(string cerrar)
        //{

        //    return ();
        //}
        // public ();
        //login
        public async Task<UUsuario> loginusuario(UUsuario usuario)
        {
            return await _context.usuari.Where(x => x.Correo.ToUpper().Equals(usuario.Correo.ToUpper()) && x.Contrasenia.Equals(usuario.Contrasenia)).FirstOrDefaultAsync();
        }

        //login request
        public async Task<UUsuario> loginusuario1(LoginRequest user)
        {
           
            using (var db = _context)
            {
             UUsuario usuario = await  db.usuari.Where(x => x.Correo.ToUpper().Equals(user.Correo.ToUpper()) && x.Contrasenia.Equals(user.Contrasenia)).FirstOrDefaultAsync();
                if (usuario != null)
                {
                    //var propiedades = db.aplicacion.Where(x => x.Id == user.AplicacionID).FirstOrDefault();
                    //usuario.Expiracion = propiedades.Expiracion;
                    //usuario.Key = propiedades.Key;
                    //usuario.AplicacionId = user.AplicacionID;
                    
                    var propiedades = db.aplicacion.Where(x => x.Id == user.AplicacionID).FirstOrDefault();
                    usuario.Expiracion = propiedades.Expiracion;
                    usuario.Key = propiedades.Key;
                    usuario.AplicacionId = user.AplicacionID;
                }
                return usuario;
            }
        }
        //metodo asincrono ejemplo obtener usuarios
        public  List<UUsuario> ObtenerUsuarios()
        {
            using (var db =  _context)
            {
                return  db.usuari.ToList();
            }
        }

        public UUsuario nuevacontrasenia(UUsuario usuario)
        {
            return _context.usuari.Where(x => x.Contrasenia.Equals(usuario.Contrasenia)).FirstOrDefault();
        }

        public UUsuario getUserByUserName(string correo)
        {
            return _context.usuari.Where(x => x.Correo.ToUpper().Equals(correo.ToUpper())).FirstOrDefault();
        }

        public List<UUsuario> mostrarsolicitudaliado()
        {
            return _context.usuari.Where(x => x.Id_rol == 2 && x.Aprobacion == 0).ToList<UUsuario>();
        }

        public List<UUsuario> mostrarsolicitudaliadorechazado()
        {
            return _context.usuari.Where(x => x.Id_rol == 2 && x.Aprobacion == 2).ToList<UUsuario>();
        }
        public List<UUsuario> mostrarsolicitudaliadoaceptado()
        {
            return _context.usuari.Where(x => x.Id_rol == 2 && x.Aprobacion == 1).ToList<UUsuario>();
        }

        public List<UUsuario> mostrarsolicituddomiciliario()
        {
            return _context.usuari.Where(x => x.Id_rol == 3 && x.Aprobacion == 0).ToList<UUsuario>();
        }

        public List<UUsuario> mostrarsolicituddomiciliariorechazado()
        {
            return _context.usuari.Where(x => x.Id_rol == 3 && x.Aprobacion == 2).ToList<UUsuario>();
        }
        public List<UUsuario> mostrarsolicituddomiciliarioaceptado()
        {
            return _context.usuari.Where(x => x.Id_rol == 3 && x.Aprobacion == 1).ToList<UUsuario>();
        }

        public void aceptarusuario(UUsuario usuario, String auditoria)
        {
            using (var db = _context)
            {
                UUsuario aprobacionanterior = db.usuari.Where(x => x.Id == usuario.Id).First();
                aprobacionanterior.Auditoria = auditoria;
                aprobacionanterior.Aprobacion = 1;

                db.usuari.Attach(aprobacionanterior);
                var entry = db.Entry(aprobacionanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();
                Correo email = new Correo();
                String emailmensaje;
                if (aprobacionanterior.Id_rol == 2)
                {
                    emailmensaje = "Su solicitud de aprobacion de Aliado a sido ACEPTADA, Ahora puedes iniciar sesion con el correo y la contraseña que ingreso al registrarse" + ", El correo es: " + aprobacionanterior.Correo + "Y la contraseña es: " + aprobacionanterior.Contrasenia;
                    email.correoaprobacion(aprobacionanterior.Correo, emailmensaje);
                }
                else if (aprobacionanterior.Id_rol == 3)
                {
                    emailmensaje = "Su solicitud de aprobacion de Domiciliario a sido ACEPTADA, Ahora puedes iniciar sesion con el correo y la contraseña que ingreso al registrarse" + ", El correo es: " + aprobacionanterior.Correo + "Y la contraseña es: " + aprobacionanterior.Contrasenia;
                    email.correoaprobacion(aprobacionanterior.Correo, emailmensaje);
                }

            }
        }
        public void rechazarusuario(UUsuario usuario, String auditoria)
        {
            using (var db = _context)
            {
                UUsuario aprobacionanterior = db.usuari.Where(x => x.Id == usuario.Id).First();
                aprobacionanterior.Auditoria = auditoria;
                aprobacionanterior.Aprobacion = 2;
                db.usuari.Attach(aprobacionanterior);
                var entry = db.Entry(aprobacionanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();
                Correo email = new Correo();
                String emailmensaje;
                if (aprobacionanterior.Id_rol == 2)
                {
                    emailmensaje = "Su solicitud de aprobacion de Aliado a sido RECHAZADA, Consideramos que no cumple los requisitos para ser Aliado de SuperFast";
                    email.correoaprobacion(aprobacionanterior.Correo, emailmensaje);
                }
                else if (aprobacionanterior.Id_rol == 3)
                {
                    emailmensaje = "Su solicitud de aprobacion de Domiciliario a sido RECHAZADA, Consideramos que no cumple los requisitos para ser domiciliario de SuperFast";
                    email.correoaprobacion(aprobacionanterior.Correo, emailmensaje);
                }
            }


        }//
        public void revisionusuario(UUsuario usuario, String auditoria)
        {
            using (var db = _context)
            {
                UUsuario aprobacionanterior = db.usuari.Where(x => x.Id == usuario.Id).First();
                aprobacionanterior.Auditoria = auditoria;
                aprobacionanterior.Aprobacion = 0;

                db.usuari.Attach(aprobacionanterior);
                var entry = db.Entry(aprobacionanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();
                Correo email = new Correo();
                String emailmensaje;
                if (aprobacionanterior.Id_rol == 2)
                {
                    emailmensaje = "Su solicitud de aprobacion de Aliado esta en revision, si es acapetada o no se le notificara de nuevo";
                    email.correoaprobacion(aprobacionanterior.Correo, emailmensaje);
                }
                else if (aprobacionanterior.Id_rol == 3)
                {
                    emailmensaje = "Su solicitud de aprobacion de Domiciliario esta en revision, si es acapetada o no se le notificara de nuevo";
                    email.correoaprobacion(aprobacionanterior.Correo, emailmensaje);
                }
            }
        }//

        public void actualizarperfil(UUsuario usuario)
        {
            using (var db = _context)
            {
                UUsuario usuarioanterior = db.usuari.Where(x => x.Id == usuario.Id).First();
                usuarioanterior.Nombre = usuario.Nombre;
                usuarioanterior.Apellido = usuario.Apellido;
                usuarioanterior.Correo = usuario.Correo;
                usuarioanterior.Contrasenia = usuario.Contrasenia;
                usuarioanterior.Direccion = usuario.Direccion;
                usuarioanterior.Telefono = usuario.Telefono;
                usuarioanterior.Documento = usuario.Documento;
                usuarioanterior.Tipovehiculo = usuario.Tipovehiculo;
                usuarioanterior.Imagenperfil = usuario.Imagenperfil;
                db.usuari.Attach(usuarioanterior);
                var entry = db.Entry(usuarioanterior);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }//
        public UUsuario mostrar(int userId)
        {
            return _context.usuari.Where(x => x.Id == userId).First();
        }


    }
}
