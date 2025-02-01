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
    public class MasterWorkingHourController : Controller
    {
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }
        public UserManager<IdentityUser> UserManager { get; }

        public MasterWorkingHourController(IRepository<MasterWorkingHour> _masterWorkingHour, UserManager<IdentityUser> userManager)
        {
            MasterWorkingHour = _masterWorkingHour;
            UserManager = userManager;
        }
        // GET: MasterWorkingHourController
        public ActionResult Index()
        {
            return View(MasterWorkingHour.View());
        }

    

        // GET: MasterWorkingHourController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterWorkingHourController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MVMasterWorkingHour collection)
        {
            try
            {
                MasterWorkingHour masterWorkingHour = new MasterWorkingHour()
                {
                    MasterWorkingHoursIdName = collection.MasterWorkingHoursIdName,
                    MasterWorkingHoursIdTimeFormTo = collection.MasterWorkingHoursIdTimeFormTo,
                    CreateId = UserManager.GetUserId(User),
                };
                MasterWorkingHour.Add(masterWorkingHour);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHourController/Edit/5
        public ActionResult Edit(int id)
        {
            var Data = MasterWorkingHour.Find(id);  
            var newdata = new MVMasterWorkingHour()
            {
                MasterWorkingHourId = Data.MasterWorkingHourId,
                MasterWorkingHoursIdName = Data.MasterWorkingHoursIdName,
                MasterWorkingHoursIdTimeFormTo = Data.MasterWorkingHoursIdTimeFormTo,
            };  
            return View(newdata);
           
        }

        // POST: MasterWorkingHourController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MVMasterWorkingHour collection)
        {
            try
            {
                var data = new MasterWorkingHour()
                {
                    MasterWorkingHourId = collection.MasterWorkingHourId,
                    MasterWorkingHoursIdName = collection.MasterWorkingHoursIdName,
                    MasterWorkingHoursIdTimeFormTo = collection.MasterWorkingHoursIdTimeFormTo,
                    EditId = UserManager.GetUserId(User),
                };
                MasterWorkingHour.Update(id, data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: MasterWorkingHourController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            if (idDelete != 0)
            {
                MasterWorkingHour.Delete(idDelete, new Models.MasterWorkingHour());
            }
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int Id)
        {
            MasterWorkingHour.Active(Id);

            return RedirectToAction(nameof(Index));

        }


    }
}
