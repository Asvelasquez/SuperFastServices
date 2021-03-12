using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOUsuario
/// </summary>
[Serializable]
[Table("usuario", Schema = "informacion")]
public class DAOUsuario
{
    public void insertUsuario(Usuario usuario2)
    {
        using (var db = new Mapeo())
        {
            db.usuari.Add(usuario2);
            db.SaveChanges();
        }
    }

    //validar correo registrarse 
    public Usuario getCorreoByregistrarse(string correo)
    {

        return new Mapeo().usuari.Where(x => (x.Correo.Equals(correo))).FirstOrDefault();
    }
    //envio dinamico clase generarToken dinamico correo
    public Usuario getCorreoByCorreos(string correo)
    {
        return new Mapeo().usuari.Where(x => (x.Correo.Contains(correo))).FirstOrDefault();
    }

    //public Usuario getcerrarsession(string cerrar)
    //{

    //    return ();
    //}
    // public ();
    public Usuario loginusuario(Usuario usuario)
    {
        return new Mapeo().usuari.Where(x => x.Correo.ToUpper().Equals(usuario.Correo.ToUpper()) && x.Contrasenia.Equals(usuario.Contrasenia)).FirstOrDefault();
    }
    public Usuario nuevacontrasenia(Usuario usuario)
    {
        return new Mapeo().usuari.Where(x =>  x.Contrasenia.Equals(usuario.Contrasenia)).FirstOrDefault();
    }

    public Usuario getUserByUserName(string correo)
    {
        return new Mapeo().usuari.Where(x => x.Correo.ToUpper().Equals(correo.ToUpper())).FirstOrDefault();
    }

    public List<Usuario> mostrarsolicitudaliado()
    {
        return new Mapeo().usuari.Where(x => x.Id_rol == 2 && x.Aprobacion == 0).ToList<Usuario>();
    }

    public List<Usuario> mostrarsolicitudaliadorechazado()
    {
        return new Mapeo().usuari.Where(x => x.Id_rol == 2 && x.Aprobacion == 2).ToList<Usuario>();
    }
    public List<Usuario> mostrarsolicitudaliadoaceptado()
    {
        return new Mapeo().usuari.Where(x => x.Id_rol == 2 && x.Aprobacion == 1).ToList<Usuario>();
    }

    public List<Usuario> mostrarsolicituddomiciliario()
    {
        return new Mapeo().usuari.Where(x => x.Id_rol == 3 && x.Aprobacion == 0).ToList<Usuario>();
    }

    public List<Usuario> mostrarsolicituddomiciliariorechazado()
    {
        return new Mapeo().usuari.Where(x => x.Id_rol == 3 && x.Aprobacion == 2).ToList<Usuario>();
    }
    public List<Usuario> mostrarsolicituddomiciliarioaceptado()
    {
        return new Mapeo().usuari.Where(x => x.Id_rol == 3 && x.Aprobacion == 1).ToList<Usuario>();
    }
    public void aceptarusuario(Usuario usuario, String auditoria){
        using (var db = new Mapeo()){
            Usuario aprobacionanterior = db.usuari.Where(x => x.Id == usuario.Id).First();
            aprobacionanterior.Auditoria = auditoria;
            aprobacionanterior.Aprobacion = 1;

            db.usuari.Attach(aprobacionanterior);
            var entry = db.Entry(aprobacionanterior);
            entry.State = EntityState.Modified;
            db.SaveChanges();
            Correo email = new Correo();
            String emailmensaje;
            if (aprobacionanterior.Id_rol == 2){
                emailmensaje = "Su solicitud de aprobacion de Aliado a sido ACEPTADA, Ahora puedes iniciar sesion con el correo y la contraseña que ingreso al registrarse" + ", El correo es: " + aprobacionanterior.Correo + "Y la contraseña es: " + aprobacionanterior.Contrasenia;
                email.correoaprobacion(aprobacionanterior.Correo, emailmensaje);
            }else if (aprobacionanterior.Id_rol == 3){
                emailmensaje = "Su solicitud de aprobacion de Domiciliario a sido ACEPTADA, Ahora puedes iniciar sesion con el correo y la contraseña que ingreso al registrarse" + ", El correo es: " + aprobacionanterior.Correo + "Y la contraseña es: " + aprobacionanterior.Contrasenia;
                email.correoaprobacion(aprobacionanterior.Correo, emailmensaje);
            }

        }
    }
    public void rechazarusuario(Usuario usuario, String auditoria)
    {
        using (var db = new Mapeo())
        {
            Usuario aprobacionanterior = db.usuari.Where(x => x.Id == usuario.Id).First();
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
    public void revisionusuario(Usuario usuario, String auditoria)
    {
        using (var db = new Mapeo())
        {
            Usuario aprobacionanterior = db.usuari.Where(x => x.Id == usuario.Id).First();
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

    public void actualizarperfil(Usuario usuario){
        using (var db = new Mapeo()){
            Usuario usuarioanterior = db.usuari.Where(x => x.Id == usuario.Id).First();
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
    public Usuario mostrar(int userId){
        return new Mapeo().usuari.Where(x => x.Id == userId ).First();
    }


}