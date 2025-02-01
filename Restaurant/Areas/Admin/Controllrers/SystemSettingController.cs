using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Restaurant.Areas.Admin.ViewModel;
using Restaurant.Models;
using Restaurant.Models.Repositories;

namespace Restaurant.Areas.Admin.Controllrers
{
    [Area("admin")]
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSettingRepository { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IWebHostEnvironment WebHost { get; }

        public SystemSettingController( IRepository<SystemSetting> _systemSettingRepository, UserManager<IdentityUser> userManager, IWebHostEnvironment webHost)
        {
            SystemSettingRepository = _systemSettingRepository;
            UserManager = userManager;
            WebHost = webHost;
        }
        // GET: SystemSettingController
        public ActionResult Index()
        {
            return View(SystemSettingRepository.View());
        }

       

        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MVSystemSetting collection)
        {
            try
            {
                string ImageUrl = SaveImage(collection.File);

                SystemSetting systemSetting = new SystemSetting()
                {
                    SystemSettingLogoImageUrl = ImageUrl,
                    SystemSettingLogoImageUrl2 = ImageUrl,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteImageUrl = ImageUrl,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    CreateId = UserManager.GetUserId(User),
                };
                SystemSettingRepository.Add(systemSetting);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = SystemSettingRepository.Find(id);
            var newData = new MVSystemSetting()
            {
                SystemSettingId = data.SystemSettingId,
                SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl,
                SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2,
                SystemSettingMapLocation = data.SystemSettingMapLocation,
                SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef,
                SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc,
                SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle,
                SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl,
                SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl,
                SystemSettingCopyright = data.SystemSettingCopyright,
            };
            return View(newData);
        }

        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MVSystemSetting collection)
        {
            if (id != collection.SystemSettingId)
            {
                return NotFound();
            }
            try
            {
                string ImageUrl = SaveImage(collection.File);

                if (ImageUrl == "")
                {
                    ImageUrl = collection.SystemSettingLogoImageUrl;
                }

                else if (ImageUrl == "")
                {
                    ImageUrl = collection.SystemSettingLogoImageUrl2;
                }

                else if (ImageUrl == "")
                {
                    ImageUrl = collection.SystemSettingWelcomeNoteImageUrl;
                }

                var data = new SystemSetting()
                {
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingLogoImageUrl = ImageUrl,
                    SystemSettingLogoImageUrl2 = ImageUrl,
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteImageUrl = ImageUrl,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    CreateId = UserManager.GetUserId(User),
                };
                SystemSettingRepository.Update(id, data);

            

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete != 0)
            {
                SystemSettingRepository.Delete(idDelete, new Models.SystemSetting());
            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Active(int Id)
        {
            SystemSettingRepository.Active(Id);

            return RedirectToAction(nameof(Index));

        }


        string SaveImage(IFormFile File)
        {
            string ImageUrl = "";
            if (File != null)
            {
                //"C://wwroot/Image"+ "/Image"
                string PatheImage = Path.Combine(WebHost.WebRootPath + "/Images");
                FileInfo f = new FileInfo(File.FileName);
                ImageUrl = "Images_" + Guid.NewGuid().ToString() + f.Extension;
                string FullPath = Path.Combine(PatheImage, ImageUrl);

                File.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageUrl;
        }

    }
}
