using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Components
{
    public class MasterMenuComponent : ViewComponent
    {
        private IRepository<MasterMenu> MasterMenu;

        public MasterMenuComponent(IRepository<MasterMenu> _MasterMenu)
        {
            MasterMenu = _MasterMenu;
        }

        public IViewComponentResult Invoke()
        {
            var data = MasterMenu.View();
            return View(data);
        }
    }
}
