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
    public class MasterOfferController : Controller
    {
        public IRepository<MasterOffer> MasterOfferRepository { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IWebHostEnvironment WebHost { get; }

        public MasterOfferController(IRepository<MasterOffer> _masterOfferRepository , UserManager<IdentityUser> userManager, IWebHostEnvironment webHost)
        {
            MasterOfferRepository = _masterOfferRepository;
            UserManager = userManager;
            WebHost = webHost;
        }
        // GET: MasterOfferController
        public ActionResult Index()
        {
            return View(MasterOfferRepository.View());
        }

     

        // GET: MasterOfferController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterOfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MVMasterOffer collection)
        {
            try
            {
                string ImageUrl = SaveImage(collection.File);

                MasterOffer masterOffer = new MasterOffer()
                {
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferImageUrl = ImageUrl,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    CreateId = UserManager.GetUserId(User),
                };
                MasterOfferRepository.Add(masterOffer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterOfferRepository.Find(id);
            var newData = new MVMasterOffer()
            {
                MasterOfferId = data.MasterOfferId,
                MasterOfferTitle = data.MasterOfferTitle,
                MasterOfferBreef = data.MasterOfferBreef,
                MasterOfferDesc = data.MasterOfferDesc,
            };
            return View(newData);
        }

        // POST: MasterOfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MVMasterOffer collection)
        {
            try
            {
                string ImageUrl = SaveImage(collection.File);

                if (ImageUrl == "")
                {
                    ImageUrl = collection.MasterOfferImageUrl;
                }

                var data = new MasterOffer()
                {
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferImageUrl = ImageUrl,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    EditId = UserManager.GetUserId(User),
                };
                MasterOfferRepository.Update(id,data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete != 0)
            {
                MasterOfferRepository.Delete(idDelete, new Models.MasterOffer());
            }
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Active(int Id)
        {
            MasterOfferRepository.Active(Id);

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
