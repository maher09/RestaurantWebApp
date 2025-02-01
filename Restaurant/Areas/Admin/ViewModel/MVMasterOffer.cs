namespace Restaurant.Areas.Admin.ViewModel
{
    public class MVMasterOffer : MVBaseEntity
    {

        public int MasterOfferId { get; set; }

        public string? MasterOfferTitle { get; set; }

        public string? MasterOfferBreef { get; set; }

        public string? MasterOfferDesc { get; set; }

        public string? MasterOfferImageUrl { get; set; }

        public IFormFile File { get; set; }
    }
}
