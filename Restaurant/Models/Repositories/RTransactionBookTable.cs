
using Restaurant.Data;

namespace Restaurant.Models.Repositories
{
    public class RTransactionBookTable : IRepository<TransactionBookTable>
    {
        private readonly AppDbContext db;

        public RTransactionBookTable(AppDbContext _db)
        {
            db = _db;
        }
        public void Active(int Id)
        {
            throw new NotImplementedException();
        }

        public void Add(TransactionBookTable entity)
        {
            entity.CreateId = "1";
            entity.EditId = "1";
            entity.IsActive = true;
            entity.IsDelete = false;
            entity.CreateDate = DateTime.Now;
            entity.EditDate = DateTime.Now;

            entity.TransactionBookTableMobileNumber = entity.TransactionBookTableMobileNumber;
            entity.TransactionBookTableFullName = entity.TransactionBookTableFullName;
            entity.TransactionBookTableEmail = entity.TransactionBookTableEmail;
            entity.TransactionBookTableDate = entity.TransactionBookTableDate;
            

            db.TransactionBookTables.Add(entity);
            db.SaveChanges();
            
        }

        public void Delete(int Id, TransactionBookTable entity)
        {
            throw new NotImplementedException();
        }

        public TransactionBookTable Find(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, TransactionBookTable entity)
        {
            throw new NotImplementedException();
        }

        public List<TransactionBookTable> View()
        {
            return db.TransactionBookTables.ToList();
        }

        public List<TransactionBookTable> ViewClient()
        {
            return db.TransactionBookTables.ToList();
        }
    }
}
