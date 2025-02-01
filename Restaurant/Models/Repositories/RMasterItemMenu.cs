
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class RMasterItemMenu : IRepository<MasterItemMenu>
    {
        private readonly AppDbContext db;

        public RMasterItemMenu(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var Data = Find(Id);
            Data.IsActive = !Data.IsActive;

            Data.EditDate = DateTime.Now;
            db.MasterItemMenus.Update(Data);
            db.SaveChanges();
        }

        public void Add(MasterItemMenu entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            entity.CreateId = "1";
            entity.EditId = "1";

            db.MasterItemMenus.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterItemMenu entity)
        {
            var Data = Find(Id);
            Data.IsDelete = true;

            Data.EditDate = DateTime.Now;
            db.MasterItemMenus.Update(Data);
            db.SaveChanges();
        }

        public MasterItemMenu Find(int Id)
        {
            return db.MasterItemMenus.SingleOrDefault(x => x.MasterItemMenuId== Id);
        }

        public void Update(int Id, MasterItemMenu entity)
        {
            var Data = Find(Id);

            Data.MasterCategoryMenuId = entity.MasterCategoryMenuId;
            Data.MasterItemMenuTitle = entity.MasterItemMenuTitle;
            Data.MasterItemMenuBreef = entity.MasterItemMenuBreef;
            Data.MasterItemMenuDesc = entity.MasterItemMenuDesc;
            Data.MasterItemMenuPrice = entity.MasterItemMenuPrice;
            Data.MasterItemMenuImageUrl = entity.MasterItemMenuImageUrl;
            Data.MasterItemMenuDate = entity.MasterItemMenuDate;

            Data.EditDate = DateTime.Now;
            db.MasterItemMenus.Update(Data);
            db.SaveChanges();

        }


        public List<MasterItemMenu> View()
        {
            return db.MasterItemMenus.Include(x => x.MasterCategoryMenu).Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterItemMenu> ViewClient()
        {
            return db.MasterItemMenus.Include(x => x.MasterCategoryMenu).Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
