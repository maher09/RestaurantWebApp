using Microsoft.AspNetCore;
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
    public class MasterContactUsInformationController : Controller
    {
        public IRepository<MasterContactUsInformation> masterContactUsInformation { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IWebHostEnvironment WebHost { get; }

        public MasterContactUsInformationController(IRepository<MasterContactUsInformation> _masterContactUsInformation, UserManager<IdentityUser> userManager , IWebHostEnvironment webHost)
        {
            masterContactUsInformation = _masterContactUsInformation;
            UserManager = userManager;
            WebHost = webHost;
        }
        // GET: MasterContactUsInformationController
        public ActionResult Index()
        {
            return View(masterContactUsInformation.View());
        }

     

        // GET: MasterContactUsInformationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterContactUsInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MVMasterContactUsInformation collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //string ImageUrl = SaveImage(collection.File);

                    MasterContactUsInformation data = new MasterContactUsInformation()
                    {
                        MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                        MasterContactUsInformationImageUrl = collection.MasterContactUsInformationImageUrl,
                        MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
                        CreateId = UserManager.GetUserId(User),
                    };
                    masterContactUsInformation.Add(data);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = masterContactUsInformation.Find(id);
            var newData = new MVMasterContactUsInformation()
            {
                MasterContactUsInformationId = data.MasterContactUsInformationId,
                MasterContactUsInformationIdesc = data.MasterContactUsInformationIdesc,
                MasterContactUsInformationImageUrl = data.MasterContactUsInformationImageUrl,
                MasterContactUsInformationRedirect = data.MasterContactUsInformationRedirect,
            };
            return View(newData);
        }

        // POST: MasterContactUsInformationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MVMasterContactUsInformation collection)
        {
            try
            {
                //string ImageUrl = SaveImage(collection.File);

                //if (ImageUrl == "")
                //{
                //    ImageUrl = collection.MasterContactUsInformationImageUrl;
                //}

                var data = new MasterContactUsInformation()
                {
                    MasterContactUsInformationId = collection.MasterContactUsInformationId,
                    MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                    MasterContactUsInformationImageUrl = collection.MasterContactUsInformationImageUrl,
                    MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
                    EditId = UserManager.GetUserId(User),
                };
                masterContactUsInformation.Update(id, data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete != 0)
            {
                masterContactUsInformation.Delete(idDelete, new Models.MasterContactUsInformation());
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int Id)
        {
            masterContactUsInformation.Active(Id);

            return RedirectToAction(nameof(Index));

        }


        //string SaveImage(IFormFile File)
        //{
        //    string ImageUrl = "";
        //    if (File != null)
        //    {
        //        //"C://wwroot/Image"+ "/Image"
        //        string PatheImage = Path.Combine(WebHost.WebRootPath + "/Images");
        //        FileInfo f = new FileInfo(File.FileName);
        //        ImageUrl = "Images_" + Guid.NewGuid().ToString() + f.Extension;
        //        string FullPath = Path.Combine(PatheImage, ImageUrl);

        //        File.CopyTo(new FileStream(FullPath, FileMode.Create));
        //    }
        //    return ImageUrl;
        //}



    }
}
