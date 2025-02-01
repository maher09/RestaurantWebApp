namespace Restaurant.Areas.Admin.ViewModel
{
    public class MVMasterSlider : MVBaseEntity
    {

        public int MasterSliderId { get; set; }

        public string? MasterSliderTitle { get; set; }

        public string? MasterSliderBreef { get; set; }

        public string? MasterSliderDesc { get; set; }

        public string? MasterSliderUrl { get; set; }

        public IFormFile File { get; set; }

      
    }
}
