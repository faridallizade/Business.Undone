using Business.P_1.DAL;
using Business.P_1.Models;
using Business.P_1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Business.P_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger,AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            HomeVm vm = new HomeVm()
            {
                Blogs = await _context.blogs.ToListAsync(),
            };
            return View(vm);
        }

      
    }
}