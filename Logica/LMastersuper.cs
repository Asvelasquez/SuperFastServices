using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Utilitarios;


namespace Logica
{
   public class LMastersuper
    {
        UMac datos = new UMac();
        public UMac LBT_Inicio_Click(UUsuario usuario)
        {
            if (usuario == null)
            {
                datos.Url="inicio.aspx";

            }
            else if (usuario.Id_rol == 1)
            {
                datos.Url = "inicio.aspx";
            }
            else if (usuario.Id_rol == 2)
            {
                datos.Url = "pedidosaliado.aspx";
            }
            else if (usuario.Id_rol == 3)
            {
                datos.Url = "Domiciliario.aspx";
            }
            else if (usuario.Id_rol == 4)
            {
                datos.Url = "administrador.aspx";
            }
            return datos;
        }
    }
}
