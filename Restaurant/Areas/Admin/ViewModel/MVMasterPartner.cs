namespace Restaurant.Areas.Admin.ViewModel
{
    public class MVMasterPartner : MVBaseEntity
    {
        public int MasterPartnerId { get; set; }

        public string? MasterPartnerName { get; set; }

        public string? MasterPartnerLogoImageUrl { get; set; }

        public string? MasterPartnerWebsiteUrl { get; set; }

        public IFormFile File { get; set; }
    }
}
