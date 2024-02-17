using Agorro.Identity.Entity;
using Agorro.Identity.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Reflection.Emit;

namespace Agorro.Identity.Data
{
    public class DMenu : IMenu
    {
        readonly IConfiguration _configuration;
        public DMenu (IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task<IEnumerable<EMenu>> Get(int idRole)
        {
            try
			{
                using (IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    dbConnection.Open();
                    var parameters = new
                    {
                        @id_role = idRole,
                    };

                    IEnumerable <EMenuData> response = new List<EMenuData>();
                    response = dbConnection.Query<EMenuData>("sp_menu_list_role", parameters, commandType: CommandType.StoredProcedure);

                    List<EMenu> listMenu= new List<EMenu>();

                    string menuValidation = string.Empty;

                    foreach (var item in response)
                    {
                        EMenu Menu = new EMenu();
                        if (menuValidation != item.module_description)
                        {
                            Menu.label = item.module_description;
                            Menu.icon = item.module_icon;

                            var listSubMenu = response.Where(x => x.module_description == item.module_description);

                            List<ESubMenu> subMenus = new List<ESubMenu>();
                            foreach (var subItem in listSubMenu)
                            {
                                ESubMenu subMenu = new ESubMenu();
                                subMenu.label = subItem.sub_module_description;
                                subMenu.routerLink = subItem.sub_module_url;
                                subMenu.icon = subItem.sub_module_icon;
                                subMenus.Add(subMenu);
                            }
                            Menu.items = subMenus;
                            listMenu.Add(Menu);
                        }
                        
                        menuValidation = item.module_description;  
                    }
                    return listMenu;
                }
            }
			catch (Exception ex)
			{

				throw ex;
			}
        }
    }
}
