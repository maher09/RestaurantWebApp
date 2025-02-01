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
    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartnerRepository { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IWebHostEnvironment WebHost { get; }

        public MasterPartnerController(IRepository<MasterPartner> _masterPartnerRepository , UserManager<IdentityUser> userManager, IWebHostEnvironment webHost)
        {
            MasterPartnerRepository = _masterPartnerRepository;
            UserManager = userManager;
            WebHost = webHost;
        }
        // GET: MasterPartnerController
        public ActionResult Index()
        {
            return View(MasterPartnerRepository.View());
        }

     

        // GET: MasterPartnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterPartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MVMasterPartner collection)
        {
            try
            {
                string ImageUrl = SaveImage(collection.File);

                MasterPartner masterPartner = new MasterPartner()
                {
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerLogoImageUrl = ImageUrl,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                    CreateId = UserManager.GetUserId(User),
                };
                MasterPartnerRepository.Add(masterPartner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterPartnerRepository.Find(id);
            var newdata = new MVMasterPartner()
            {
                MasterPartnerId = data.MasterPartnerId,
                MasterPartnerName = data.MasterPartnerName,
                MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl,
                MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl,
            };
            return View(newdata);
        }

        // POST: MasterPartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MVMasterPartner collection)
        {
            try
            {
                string ImageUrl = SaveImage(collection.File);

                if (ImageUrl == "")
                {
                    ImageUrl = collection.MasterPartnerWebsiteUrl;
                }

                var data = new MasterPartner()
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerLogoImageUrl = ImageUrl,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                };
                MasterPartnerRepository.Update(id, data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete != 0)
            {
                MasterPartnerRepository.Delete(idDelete, new Models.MasterPartner());
            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Active(int Id)
        {
            MasterPartnerRepository.Active(Id);

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
