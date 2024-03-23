using Microsoft.AspNetCore.Mvc;
using Mission11_Imerlishvili.Models;
using Mission11_Imerlishvili.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Imerlishvili.Controllers
{
    public class HomeController : Controller
    {
        
        private IBookStoreRepository _repo;

        public HomeController(IBookStoreRepository temp)
        {
           
            _repo = temp;
        }

        public IActionResult Index(int PageNum)
        {

            int PageSize = 10;
          
            var blah = new BookListViewModel
            {
                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((PageNum - 1) * PageSize)
                .Take(PageSize),

                PageinationInfo = new PageinationInfo
                {
                    CurrentPage = PageNum,
                    ItemsPerPage = PageSize,
                    TotalItems = _repo.Books.Count()
                }

            }; 


            return View(blah);
        }


      
    }
}
