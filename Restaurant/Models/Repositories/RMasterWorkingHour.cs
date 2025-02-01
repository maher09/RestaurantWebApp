
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class RMasterWorkingHour : IRepository<MasterWorkingHour>
    {
        private readonly AppDbContext db;

        public RMasterWorkingHour(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var Data = Find(Id);
            Data.IsActive = !Data.IsActive;

            Data.EditDate = DateTime.Now;
            db.MasterWorkingHours.Update(Data);
            db.SaveChanges();
        }

        public void Add(MasterWorkingHour entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            entity.CreateId = "1";
            entity.EditId = "1";

            db.MasterWorkingHours.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterWorkingHour entity)
        {
            var Data = Find(Id);
            Data.IsDelete = true;

            Data.EditDate = DateTime.Now;
            db.MasterWorkingHours.Update(Data);
            db.SaveChanges();
        }

        public MasterWorkingHour Find(int Id)
        {
            return db.MasterWorkingHours.SingleOrDefault(x => x.MasterWorkingHourId == Id);
        }

        public void Update(int Id, MasterWorkingHour entity)
        {
            var Data = Find(Id);

            Data.MasterWorkingHoursIdName = entity.MasterWorkingHoursIdName;
            Data.MasterWorkingHoursIdTimeFormTo = entity.MasterWorkingHoursIdTimeFormTo;


            Data.EditDate = DateTime.Now;
            db.MasterWorkingHours.Update(Data);
            db.SaveChanges();
        }

        public List<MasterWorkingHour> View()
        {
            return db.MasterWorkingHours.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterWorkingHour> ViewClient()
        {
            return db.MasterWorkingHours.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
