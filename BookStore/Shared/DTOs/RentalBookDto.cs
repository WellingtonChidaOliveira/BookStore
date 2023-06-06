using BookStore.Shared.Base;

namespace BookStore.Shared.DTOs
{
    public class RentalBookDto : IDocument
    {
        public string id { get; set; } = string.Empty;
        public string BookId { get; set; }
        public string CustomerId { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; } = DateTime.Now;
        public double TotalPrice { get; set; } = 0;
        public double Penalty { get; set; } = 0;
        public bool IsReturned { get; set; } = false;
    }
}
