
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class RMasterCategoryMenu : IRepository<MasterCategoryMenu>
    {
        private readonly AppDbContext db;

        public RMasterCategoryMenu(AppDbContext _db)
        {
            db = _db;
        }

        public void Active(int Id)
        {
            var Data = Find(Id);
            Data.IsActive = !Data.IsActive;

            Data.EditDate = DateTime.Now;
            db.MasterCategoryMenus.Update(Data);
            db.SaveChanges();
        }

        public void Add(MasterCategoryMenu entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            entity.CreateId = "1";
            entity.EditId = "1";
            db.MasterCategoryMenus.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterCategoryMenu entity)
        {
            var Data = Find(Id);
            Data.IsDelete = true;

            Data.EditDate = DateTime.Now;
            db.MasterCategoryMenus.Update(Data);
            db.SaveChanges();
        }

        public MasterCategoryMenu Find(int Id)
        {
            return db.MasterCategoryMenus.SingleOrDefault(x => x.MasterCategoryMenuId == Id);
        }

        public void Update(int Id, MasterCategoryMenu entity)
        {
            //var Data = Find(Id);
            //Data.MasterCategoryMenuName = entity.MasterCategoryMenuName;

            entity.IsActive = true;
            entity.EditDate = DateTime.Now;
            entity.IsDelete = false;
            db.MasterCategoryMenus.Update(entity);
            db.SaveChanges();
            //Data.EditDate = DateTime.Now;
            //db.MasterCategoryMenus.Update(Data);
            //db.SaveChanges();
           
        }

        public List<MasterCategoryMenu> View()
        {
            return db.MasterCategoryMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterCategoryMenu> ViewClient()
        {
            return db.MasterCategoryMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
