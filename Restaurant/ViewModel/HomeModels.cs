using Restaurant.Models;

namespace Restaurant.ViewModels
{
    public class HomeModels
    {
        public List<MasterMenu> ListMasterMenu { get; set; }

        public List<MasterSlider> ListMasterSlider { get; set; }

        public SystemSetting SystemSetting { get; set; }

        public List<MasterItemMenu> ListMasterItemMenu { get; set; }

        public MasterOffer MasterOffer { get; set; }

        public List<MasterPartner> ListMasterPartner { get; set; }

        public TransactionContactU TransactionContactU { get; set; }

        public TransactionBookTable TransactionBookTable { get; set; }

        public List<MasterWorkingHour> ListMasterWorkingHour { get; set;} 

        public TransactionNewsletter TransactionNewsletter { get; set; }

        public List<MasterService> ListMasterService { get; set; }  

        public List<MasterCategoryMenu> ListMasterCategoryMenu { get; set;}

        public MasterCategoryMenu MasterCategoryMenu { get; set; }

        public List<MasterContactUsInformation> ListMasterContactUsInformation { get; set; }

        public List<MasterSocialMedium> ListMasterSocialMedium { get; set;}

      


    }
}
