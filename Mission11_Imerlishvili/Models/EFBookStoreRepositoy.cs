namespace Mission11_Imerlishvili.Models
{
    public class EFBookStoreRepository : IBookStoreRepository
    {
        private BookstoreContext _context;
        public EFBookStoreRepository(BookstoreContext temp)
        {
            _context = temp;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
