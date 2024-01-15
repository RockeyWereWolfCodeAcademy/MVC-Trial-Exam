using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Trial_Exam.Areas.Admin.ViewModels;
using MVC_Trial_Exam.Contexts;
using MVC_Trial_Exam.ViewModels;
//using MVC_Trial_Exam.Models;
using System.Diagnostics;

namespace MVC_Trial_Exam.Controllers
{
    public class HomeController : Controller
    {
        readonly BusinessDbContext _context;

        public HomeController(BusinessDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult>  Index()
        {
            var vm = await _context.Blogs.Select(b =>
            new BlogListVM
            {
                Title = b.Title,
                Author = b.Author,
                ImgUrl = b.ImgUrl,
                Description = b.Description,
            }).ToListAsync();
            return View(vm);
        }
    }
}