using Restaurant.Areas.Admin.ViewModel;


namespace Restaurant.Areas.Admin.ViewModel;

public partial class MVMasterContactUsInformation : MVBaseEntity
{
    public int MasterContactUsInformationId { get; set; }

    public string? MasterContactUsInformationIdesc { get; set; }

    public string? MasterContactUsInformationImageUrl { get; set; }



    public string? MasterContactUsInformationRedirect { get; set; }
}
