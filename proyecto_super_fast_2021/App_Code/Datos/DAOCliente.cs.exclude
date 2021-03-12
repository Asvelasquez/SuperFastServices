using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOCliente
/// </summary>
[Serializable]
[Table("cliente", Schema = "informacion")]

public class DAOCliente
{
    public Cliente login(Cliente cliente)
    {
        return new Mapeo().client.Where(x => x.Correo.ToUpper().Equals(cliente.Correo.ToUpper()) && x.Contrasenia.Equals(cliente.Contrasenia)).FirstOrDefault();
    }
    //metodo insertar cliente
    public void insertCliente(Cliente cliente){
        using (var db = new Mapeo())
        {
            db.client.Add(cliente);
            db.SaveChanges();

        }
    }

    public List<Cliente> obtenerCliente()
    {
        using (var db = new Mapeo())
        {
            return (from u in db.client
                    join r in db.rol on u.Rol_id equals r.Id
                    join u2 in db.client on u.Rol_id equals u2.Rol_id
                    select new
                    {
                        u,
                        r.Nombre
                    }).ToList().Select(m => new Cliente
                    {
                        Apellido = m.u.Apellido,
                        Contrasenia = m.u.Contrasenia,
                        Correo = m.u.Correo,
                        Id_cliente = m.u.Id_cliente,
                        Nombre = m.u.Nombre,
                        Nombre_rol = m.Nombre,
                        Direccion = m.u.Direccion,
                        Rol_id = m.u.Rol_id,
                        Telefono = m.u.Telefono
                    }).ToList();
        }
    }
}