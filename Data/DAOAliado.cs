using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilitarios;
/// <summary>
/// Descripción breve de DAOAliado
/// </summary>
/// 

namespace Data{
    class DAOAliado{
    public void insertAliado(UAliado aliado){
        using (var db = new Mapeo()){
            db.aliad.Add(aliado);
            db.SaveChanges();
        }
    }
 }
}