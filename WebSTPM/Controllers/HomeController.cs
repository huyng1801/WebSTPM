using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebSTPM.Models;
using WebSTPM.ViewModels;

namespace WebSTPM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contests(string searchTerm = "", int page = 1, int pageSize = 5)
        {
            var query = _context.Contests.Include(c => c.Teams).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(c => c.ContestName.Contains(searchTerm));
            }

            var totalContests = query.Count();
            var contests = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling(totalContests / (double)pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.SearchTerm = searchTerm;

            return View(contests);
        }


        public IActionResult ContestDetails(int id)
        {
            var contest = _context.Contests.FirstOrDefault(c => c.ContestId == id);
            if (contest == null)
            {
                return NotFound();
            }
            return View(contest);
        }
        public IActionResult NewsEvents()
        {
            var newsEvents = _context.NewsEvents.ToList();
            return View(newsEvents);
        }

        public IActionResult NewsEventDetails(int id)
        {
            var newsEvent = _context.NewsEvents.FirstOrDefault(ne => ne.NewsEventID == id);
            if (newsEvent == null)
            {
                return NotFound();
            }
            newsEvent.Views++;
            _context.SaveChanges();
            return View(newsEvent);
        }

        public IActionResult ContestRegister(int id)
        {
            var contest = _context.Contests.FirstOrDefault(c => c.ContestId == id);
            if (contest == null)
            {
                return NotFound();
            }
            var model = new TeamViewModel { ContestId = id };
            return View(model);
        }

        [HttpPost]
        public IActionResult ContestRegister(TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var team = new Team
                {
                    TeamMember = model.TeamMember,
                    ProjectName = model.ProjectName,
                    ClassName = model.ClassName,
                    InstructorName = model.InstructorName,
                    Description = model.Description,
                    ContestId = model.ContestId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Teams.Add(team);
                _context.SaveChanges();
                return RedirectToAction("RegisterSuccess");
            }
            return View(model);
        }
        public IActionResult RegisterSuccess()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
