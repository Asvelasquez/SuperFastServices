using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DAOAliado
/// </summary>
public class DAOAliado
{
    public void insertAliado(Aliado aliado){
        using (var db = new Mapeo()){
            db.aliad.Add(aliado);
            db.SaveChanges();
        }


    }
}