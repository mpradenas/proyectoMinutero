using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Controlador
{
    public class MenuDiario
    {
        string cnn = null;

        public MenuDiario(string ConnectionString) 
        {
            cnn = ConnectionString;
        }

        public bool GuardaMenuDiario(int id_menuDiario, int id_PPrincipal, int id_PAcomp, int id_Bebestible,string detalleUsuarioEmpresa,DateTime FechaMenu) 
        {
            Modelo.objMenuDiario ElmenuDiario = new Modelo.objMenuDiario();
            Modelo.platoPrincipal pPrincip = new Modelo.platoPrincipal(cnn);
            Modelo.platoAcompanamiento pAcomp = new Modelo.platoAcompanamiento(cnn);
            Modelo.Bebestibles Bebest = new Modelo.Bebestibles(cnn);
            Modelo.MenuDiario MenuDiario = new Modelo.MenuDiario(cnn);

            ElmenuDiario = MenuDiario.GetMenuDiario(id_menuDiario);
            if (ElmenuDiario != null) 
            {
                return modificaElMenudiario(id_menuDiario, id_PPrincipal, id_PAcomp, id_Bebestible,detalleUsuarioEmpresa, FechaMenu);

            }
            ElmenuDiario.id_Menu=id_menuDiario;
            ElmenuDiario.idP_Principal = pPrincip.GetPlatoPrincipal(id_PPrincipal);
            ElmenuDiario.idP_Acomp = pAcomp.GetElAcompanamiento(id_PAcomp);
            ElmenuDiario.id_Bebestible = Bebest.getBebestible(id_Bebestible);
            ElmenuDiario.DetalleEmpresa = detalleUsuarioEmpresa;
            ElmenuDiario.Fecha_menu = FechaMenu;

            return MenuDiario.SetMenuDiario(ElmenuDiario);
        }

        public bool modificaElMenudiario(int id_menuDiario, int id_PPrincipal, int id_PAcomp, int id_Bebestible, string detalleUsuarioEmpresa, DateTime FechaMenu)
        {
            Modelo.objMenuDiario ElmenuDiario = new Modelo.objMenuDiario();
            Modelo.platoPrincipal pPrincip = new Modelo.platoPrincipal(cnn);
            Modelo.platoAcompanamiento pAcomp = new Modelo.platoAcompanamiento(cnn);
            Modelo.Bebestibles Bebest = new Modelo.Bebestibles(cnn);
            Modelo.MenuDiario MenuDiario = new Modelo.MenuDiario(cnn);

            ElmenuDiario.id_Menu = id_menuDiario;
            ElmenuDiario.idP_Principal = pPrincip.GetPlatoPrincipal(id_PPrincipal);
            ElmenuDiario.idP_Acomp = pAcomp.GetElAcompanamiento(id_PAcomp);
            ElmenuDiario.id_Bebestible = Bebest.getBebestible(id_Bebestible);
            ElmenuDiario.DetalleEmpresa = detalleUsuarioEmpresa;
            ElmenuDiario.Fecha_menu = FechaMenu;

            return MenuDiario.SetMenuDiario(ElmenuDiario);

        }

        public bool EliminaMenu(int id_menudiario) 
        {
            Modelo.objMenuDiario ElmenuDiario = new Modelo.objMenuDiario();
            
            Modelo.MenuDiario MenuDiario = new Modelo.MenuDiario(cnn);

            ElmenuDiario = MenuDiario.GetMenuDiario(id_menudiario);

            return MenuDiario.DeleteMenuDiario(ElmenuDiario);
        }
    }
}
