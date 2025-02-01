namespace Restaurant.Areas.Admin.ViewModel
{
    public class MVMasterMenu : MVBaseEntity
    
    {
        public int MasterMenuId { get; set; }

        public string MasterMenuName { get; set; } = null!;

        public string MasterMenuUrl { get; set; } = null!;


    }
}
