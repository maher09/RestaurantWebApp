using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using Restaurant.ViewModels;
using Microsoft.AspNetCore.Identity;
using Restaurant.Areas.Admin.ViewModel;
using System.Linq;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<MasterSlider> MasterSlider { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<MasterOffer> MasterOffer { get; }
        public IRepository<TransactionBookTable> TransactionBookTable { get; }
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<MasterPartner> MasterPartner { get; }
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }
        public IRepository<MasterService> MasterService { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public IRepository<TransactionContactU> TransactionContactUs { get; }
        public IRepository<MasterSocialMedium> MasterSocialMedium { get; }

        public HomeController(IRepository<MasterMenu> _MasterMenu,
            IRepository<MasterSlider> _MasterSlider ,IRepository<SystemSetting> _SystemSetting ,
            IRepository<MasterOffer> _MasterOffer ,
            IRepository<TransactionBookTable> _TransactionBookTable ,
            IRepository<MasterItemMenu> _MasterItemMenu,
            IRepository<MasterPartner> _MasterPartner,
            IRepository<MasterWorkingHour> _MasterWorkingHour,
            IRepository<TransactionNewsletter> _TransactionNewsletter,
            IRepository<MasterService> _MasterService,
            IRepository<MasterCategoryMenu> _MasterCategoryMenu,
            IRepository<MasterContactUsInformation> _MasterContactUsInformation,
            IRepository<TransactionContactU> _TransactionContactUs,
            IRepository<MasterSocialMedium> _MasterSocialMedium

            )
        {
            MasterMenu = _MasterMenu;
            MasterSlider = _MasterSlider;
            SystemSetting = _SystemSetting;
            MasterOffer = _MasterOffer;
            TransactionBookTable = _TransactionBookTable;
            MasterItemMenu = _MasterItemMenu;
            MasterPartner = _MasterPartner;
            MasterWorkingHour = _MasterWorkingHour;
            TransactionNewsletter = _TransactionNewsletter;
            MasterService = _MasterService;
            MasterCategoryMenu = _MasterCategoryMenu;
            MasterContactUsInformation = _MasterContactUsInformation;
            TransactionContactUs  = _TransactionContactUs;
            MasterSocialMedium = _MasterSocialMedium;
        }


        public IActionResult Index()
        {
            var Data = new HomeModels
            {
                ListMasterMenu = MasterMenu.ViewClient(),
                ListMasterSlider = MasterSlider.ViewClient(),
                SystemSetting = SystemSetting.ViewClient().FirstOrDefault(),
                MasterOffer = MasterOffer.ViewClient().FirstOrDefault(),
                ListMasterItemMenu = MasterItemMenu.ViewClient().Take(5).ToList(),
                ListMasterPartner = MasterPartner.ViewClient(),
                ListMasterWorkingHour = MasterWorkingHour.ViewClient(),
                TransactionContactU = new TransactionContactU(),
                ListMasterContactUsInformation = MasterContactUsInformation.ViewClient(),
                ListMasterSocialMedium = MasterSocialMedium.ViewClient(),




            };

            return View(Data);
        }

        public IActionResult About()
        {
            var Data = new HomeModels
            {
                ListMasterMenu = MasterMenu.ViewClient(),
                ListMasterWorkingHour = MasterWorkingHour.ViewClient(),
                ListMasterService = MasterService.ViewClient(),
                SystemSetting = SystemSetting.ViewClient().FirstOrDefault(),
                ListMasterContactUsInformation = MasterContactUsInformation.ViewClient(),
                ListMasterSocialMedium = MasterSocialMedium.ViewClient(),



            };

            return View(Data);
        }

        public IActionResult Menu()
        {
            var Data = new HomeModels
            {
                ListMasterMenu = MasterMenu.ViewClient(),
                ListMasterItemMenu = MasterItemMenu.ViewClient(),
                ListMasterWorkingHour = MasterWorkingHour.ViewClient(),
                ListMasterCategoryMenu = MasterCategoryMenu.ViewClient().TakeLast(5).ToList(),
                MasterCategoryMenu = MasterCategoryMenu.ViewClient().FirstOrDefault(),
                ListMasterSocialMedium = MasterSocialMedium.ViewClient(),
            };

            return View(Data);
        }


        public IActionResult Contact()
        {
            var Data = new HomeModels
            {
                ListMasterMenu = MasterMenu.ViewClient(),
                ListMasterWorkingHour = MasterWorkingHour.ViewClient(),
                SystemSetting = SystemSetting.ViewClient().FirstOrDefault(),
                ListMasterContactUsInformation = MasterContactUsInformation.ViewClient(),
                TransactionContactU = new TransactionContactU(),
                ListMasterSocialMedium = MasterSocialMedium.ViewClient(),



            };

            return View(Data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTransactionBookTable(HomeModels collection)
        {
            try
            {


                if (!ModelState.IsValid)
                {

                    var data = new TransactionBookTable()
                    {
                        CreateId = "1",
                        CreateDate = DateTime.Now,
                        EditId = "1",
                        EditDate = DateTime.Now,
                        IsActive = true,
                        IsDelete = false,

                        TransactionBookTableDate = collection.TransactionBookTable.TransactionBookTableDate,
                        TransactionBookTableEmail = collection.TransactionBookTable.TransactionBookTableEmail,
                        TransactionBookTableFullName = collection.TransactionBookTable.TransactionBookTableFullName,
                        TransactionBookTableMobileNumber = collection.TransactionBookTable.TransactionBookTableMobileNumber,



                    };

                    TransactionBookTable.Add(data);
                }
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTransactionNewsletter(HomeModels collection)
        {
            try
            {


                if (!ModelState.IsValid)
                {

                    var data = new TransactionNewsletter()
                    {
                        CreateId = "1",
                        CreateDate = DateTime.Now,
                        EditId = "1",
                        EditDate = DateTime.Now,
                        IsActive = true,
                        IsDelete = false,

                        TransactionNewsletterEmail = collection.TransactionNewsletter.TransactionNewsletterEmail,

                    };
                    TransactionNewsletter.Add(data);
                   
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTransactionContactUs(HomeModels collection)
        {
            try
            {


                if (!ModelState.IsValid)
                {

                    var data = new TransactionContactU()
                    {
                        CreateId = "1",
                        CreateDate = DateTime.Now,
                        EditId = "1",
                        EditDate = DateTime.Now,
                        IsActive = true,
                        IsDelete = false,
                        
                        TransactionContactUsEmail = collection.TransactionContactU.TransactionContactUsEmail,
                        TransactionContactUsFullName = collection.TransactionContactU.TransactionContactUsFullName,
                        TransactionContactUsMessage = collection.TransactionContactU.TransactionContactUsMessage,
                        TransactionContactUsSubject = collection.TransactionContactU.TransactionContactUsSubject,


                    };
                    TransactionContactUs.Add(data);

                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
