
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class RMasterSlider : IRepository<MasterSlider>
    {
        private readonly AppDbContext db;

        public RMasterSlider(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            var Data = Find(Id);
            Data.IsActive = !Data.IsActive;

            Data.EditDate = DateTime.Now;
            db.MasterSliders.Update(Data);
            db.SaveChanges();
        }

        public void Add(MasterSlider entity)
        {
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;
            entity.CreateId = "1";
            entity.EditId = "1";




            db.MasterSliders.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, MasterSlider entity)
        {
            var Data = Find(Id);
            Data.IsDelete = true;

            Data.EditDate = DateTime.Now;
            db.MasterSliders.Update(Data);
            db.SaveChanges();
        }

        public MasterSlider Find(int Id)
        {
            return db.MasterSliders.SingleOrDefault(x => x.MasterSliderId == Id);
        }

        public void Update(int Id, MasterSlider entity)
        {
            var Data = Find(Id);

            Data.IsActive = entity.IsActive;
            Data.IsDelete = entity.IsDelete;

            Data.MasterSliderTitle = entity.MasterSliderTitle;
            Data.MasterSliderBreef = entity.MasterSliderBreef;
            Data.MasterSliderDesc = entity.MasterSliderDesc;
            Data.MasterSliderUrl = entity.MasterSliderUrl;

            Data.EditDate = DateTime.Now;
            db.MasterSliders.Update(Data);
            db.SaveChanges();
        }

        public List<MasterSlider> View()
        {
            return db.MasterSliders.Where(x => x.IsDelete == false).ToList();
        }

        public List<MasterSlider> ViewClient()
        {
            return db.MasterSliders.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
        }
    }
}
