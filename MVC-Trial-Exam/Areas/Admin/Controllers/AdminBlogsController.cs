using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Trial_Exam.Areas.Admin.ViewModels;
using MVC_Trial_Exam.Contexts;
using MVC_Trial_Exam.Models;

namespace MVC_Trial_Exam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogsController : Controller
    {
        readonly BusinessDbContext _context;

        public AdminBlogsController(BusinessDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult>  Index()
        {
            var vm = await _context.Blogs.Select(b=>
            new AdminBlogListVM
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ImgUrl = b.ImgUrl,
            }).ToListAsync();
            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AdminBlogCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var blog = new Blog
            {
                Title = vm.Title,
                Description = vm.Description,
                Author = vm.Author,
                ImgUrl = vm.ImgUrl,
            };
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _context.Blogs.FindAsync(id);
            if (data == null) return NotFound();
            _context.Blogs.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult>  Update(int? id)
        {
            if (id == null) return BadRequest();
            var data = await _context.Blogs.FindAsync(id);
            if (data == null) return NotFound();
            return View(new AdminBlogUpdateVM
            {
                Title = data.Title,
                Author = data.Author,
                ImgUrl = data.ImgUrl,
                Description = data.Description,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminBlogUpdateVM vm, int? id)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var data = await _context.Blogs.FindAsync(id);
            if (data == null) return NotFound();
            data.Author = vm.Author;
            data.Title = vm.Title;
            data.Description = vm.Description;
            data.ImgUrl = vm.ImgUrl;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
