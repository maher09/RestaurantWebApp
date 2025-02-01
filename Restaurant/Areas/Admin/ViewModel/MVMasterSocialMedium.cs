namespace Restaurant.Areas.Admin.ViewModel
{
    public class MVMasterSocialMedium : MVBaseEntity
    {
        public int MasterSocialMediumId { get; set; }

        public string MasterSocialMediaImageUrl { get; set; } = null!;

        public string MasterSocialMediaUrl { get; set; } = null!;

        public IFormFile File { get; set; }
    }
}
