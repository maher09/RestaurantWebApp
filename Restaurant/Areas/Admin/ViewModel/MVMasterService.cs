namespace Restaurant.Areas.Admin.ViewModel
{
    public class MVMasterService : MVBaseEntity
    {
        public int MasterServiceId { get; set; }

        public string? MasterServicesTitle { get; set; }

        public string? MasterServicesDesc { get; set; }

        public string? MasterServicesImage { get; set; }

        /*ublic IFormFile File { get; set; }*/
    }
}
