using Business.P_1.DAL;
using Business.P_1.Helpers;
using Business.P_1.Models;
using Business.P_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business.P_1.Areas.admin.Controllers
{
        [Area("admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public async Task<IActionResult> Index()
        {
            HomeVm vm = new HomeVm()
            {
                Blogs = await _context.blogs.ToListAsync()
            };
            return View(vm);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogVm createBlog)
        {
            if(createBlog is null ) return NotFound();
            if (!ModelState.IsValid)
            {
                return View();
            };
            if (!createBlog.Image.CheckContent("image/"))
            {
                ModelState.AddModelError("Image", "Invalid file type");
                return View();
            }
            Blog blog = new Blog()
            {
                Title = createBlog.Title,
                Description = createBlog.Description,
                ImageUrl = createBlog.Image.UploadFile(envPath:_env.WebRootPath,"/Upload/Blog")
            };
            await _context.blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Blog blog = _context.blogs.FirstOrDefault(blog => blog.Id == id);
            if (blog == null) return NotFound();
            blog.ImageUrl.RemoveFile(_env.WebRootPath,@"/Upload/Blog");
            _context.blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Update(int id)
        {
            Blog blog = await _context.blogs.Where(bl => bl.Id == id).FirstOrDefaultAsync();
            UpdateBlogVm updateBlog = new UpdateBlogVm()
            {
                Id = id,
                Title = blog.Title,
                Description = blog.Description,
                ImageUrl = blog.ImageUrl
            };
            return View(updateBlog);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogVm updateBlog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!updateBlog.Image.CheckContent("image/"))
            {
                ModelState.AddModelError("Image", "Invalid file type");
                return View();
            }
            Blog blog = _context.blogs.Find(updateBlog.Id);
            blog.Title = updateBlog.Title;
            blog.Description = updateBlog.Description;
            blog.ImageUrl = updateBlog.Image.UploadFile(_env.WebRootPath,"/Upload/Blog/");
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
     
    }
}
