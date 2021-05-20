using Utilitarios;
/// <summary>
/// Descripción breve de DAOAliado
/// </summary>
/// 

namespace DataNC
{
    class DAOAliado{
    public void insertAliado(UAliado aliado){
        using (var db = new Mapeo()){
            db.aliad.Add(aliado);
            db.SaveChanges();
        }
    }
 }
}