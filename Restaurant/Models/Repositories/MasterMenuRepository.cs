
using Restaurant.Areas.Admin.ViewModel;
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class MasterMenuRepository : IRepository<MasterMenu>
    {
        private readonly AppDbContext db;

        public MasterMenuRepository(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var Data = Find(Id);
            Data.IsActive = !Data.IsActive;

            Data.EditDate = DateTime.Now;
            db.MasterMenus.Update(Data);
            db.SaveChanges();

        }

        public void Add(MasterMenu entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            entity.CreateId = "1";
            entity.EditId = "1";
            db.MasterMenus.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterMenu entity)
        {
            var Data = Find(Id);
            Data.IsDelete = true;

            Data.EditDate = DateTime.Now;
            db.MasterMenus.Update(Data);
            db.SaveChanges();
        }

        public MasterMenu Find(int Id)
        {
            return db.MasterMenus.SingleOrDefault(x => x.MasterMenuId == Id);
        }

        public void Update(int Id, MasterMenu entity)
        {
            var Data = Find(Id);
            Data.MasterMenuName = entity.MasterMenuName;
            Data.MasterMenuUrl = entity.MasterMenuUrl;

            Data.EditDate = DateTime.Now;
            db.MasterMenus.Update(Data);
            db.SaveChanges();
            
        }

        public List<MasterMenu> View()
        {
            return db.MasterMenus.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterMenu> ViewClient()
        {
            return db.MasterMenus.Where(x => x.IsDelete == false && x.IsActive == true).ToList();

        }
    }
}
