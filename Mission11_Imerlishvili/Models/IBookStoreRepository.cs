namespace Mission11_Imerlishvili.Models
{
    public interface IBookStoreRepository
    {
            // Property to access a collection of books. It returns an IQueryable<Book>, allowing consumers to query the collection.

        public IQueryable<Book> Books { get; }
    }
}
