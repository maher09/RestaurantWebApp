using Restaurant.Models;

namespace Restaurant.Areas.Admin.ViewModel
{
    public class MVMasterCategoryMenu : MVBaseEntity
    {
        public int MasterCategoryMenuId { get; set; }

        public string MasterCategoryMenuName { get; set; } = null!;
    }
}
