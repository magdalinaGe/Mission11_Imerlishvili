namespace Mission11_Imerlishvili.Models.ViewModels
{
    public class PageinationInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumPages => (int)(Math.Ceiling((decimal)TotalItems / ItemsPerPage));
    }
}
