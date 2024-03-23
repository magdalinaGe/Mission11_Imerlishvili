namespace Mission11_Imerlishvili.Models
{
    public interface IBookStoreRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
