using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kondominium_Entities.Utilites
{
    public class MenuEntity
    {

        public string UserId { get; set; }
        public int Active { get; set; }
        public string ProfileId { get; set; }
        public int ProfileActive { get; set; }
        public string ProfileDescription { get; set; }
        public int SubMenuPermissionId { get; set; }
        public int SubMenuId { get; set; }
        public int Enabled { get; set; }
        public string SubMenu { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Nullable<int> MainMenuId { get; set; }
        public string MainMenu { get; set; }
        public Nullable<int> Detail { get; set; }
        public string Icon { get; set; }

        public string Agrupacion { get; set; }

    }
}
