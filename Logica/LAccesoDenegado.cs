using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Utilitarios;
namespace Logica{
    
    public class LAccesoDenegado {
        string redireccion;
        public string LButton(int idrol1){
            if (idrol1 == 0)
            {
                redireccion="inicio.aspx";
            }
            if (idrol1 == 1){
                redireccion="inicio.aspx";
             }
            else if (idrol1 == 2){
                redireccion = "Aliado.aspx";
            }
            else if (idrol1 == 3){
                redireccion = "administrador.aspx";
            }
            else if (idrol1 == 4){
                redireccion = "administrador.aspx";
            }
            return redireccion;
        }
    }
}
