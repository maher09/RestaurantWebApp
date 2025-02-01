namespace Restaurant.Areas.Admin.ViewModel
{
    public class MVTransactionContactU : MVBaseEntity
    {
        public int TransactionContactUId { get; set; }

        public string? TransactionContactUsFullName { get; set; }

        public string? TransactionContactUsEmail { get; set; }

        public string? TransactionContactUsSubject { get; set; }

        public string? TransactionContactUsMessage { get; set; }
    }
}
