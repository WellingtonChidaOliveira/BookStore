using BookStore.Shared.DTOs;

namespace BookStore.Server.UseCases.RentalBookCases
{
    public static class RentalDtoToRentalBook
    {
        public static async Task<RentalBook> Convert(RentalBookDto rentalBookDto, IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            var book = await bookRepository.Get(rentalBookDto.BookId);
            var customer = await customerRepository.Get(rentalBookDto.CustomerId);

            if (book is not null  && customer is not null)
            {
                return new RentalBook
                {
                    Book =book,
                    Customer = customer,
                    RentalDate = rentalBookDto.RentalDate,
                    ReturnDate = rentalBookDto.ReturnDate,
                    TotalPrice = RentalPrice(book.Price, rentalBookDto.RentalDate, rentalBookDto.ReturnDate),
                    Penalty = rentalBookDto.Penalty,
                    IsReturned = rentalBookDto.IsReturned
                };

            }
            return null;
        }

        private static double RentalPrice(double price, DateTime rentalDate, DateTime returnDate)
        {
            var days = (returnDate - rentalDate).TotalDays;
            return price * days;
        }
    }
}
