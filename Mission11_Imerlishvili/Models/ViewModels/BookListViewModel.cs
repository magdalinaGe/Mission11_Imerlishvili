namespace Mission11_Imerlishvili.Models.ViewModels
{
    public class BookListViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PageinationInfo PageinationInfo { get; set; } = new PageinationInfo();
    }
}
