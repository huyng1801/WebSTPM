using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSTPM.Models;
using WebSTPM.ViewModels;
using System.Linq;

namespace WebSTPM.Controllers
{

    public class ContestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, string searchTerm = "")
        {
            int pageSize = 10;
            var contests = _context.Contests.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                contests = contests.Where(c => c.ContestName.Contains(searchTerm));
            }

            var totalItems = contests.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            contests = contests.Skip((page - 1) * pageSize).Take(pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.SearchTerm = searchTerm;

            return View(contests.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContestViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contest = new Contest
                {
                    ContestName = model.ContestName,
                    Introduce = model.Introduce,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.Contests.Add(contest);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var contest = _context.Contests.FirstOrDefault(c => c.ContestId == id);
            if (contest == null)
            {
                return NotFound();
            }

            var model = new ContestViewModel
            {
                ContestId = contest.ContestId,
                ContestName = contest.ContestName,
                Introduce = contest.Introduce,
                Description = contest.Description,
                StartDate = contest.StartDate,
                EndDate = contest.EndDate
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ContestViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contest = _context.Contests.FirstOrDefault(c => c.ContestId == model.ContestId);
                if (contest != null)
                {
                    contest.ContestName = model.ContestName;
                    contest.Introduce = model.Introduce;
                    contest.Description = model.Description;
                    contest.StartDate = model.StartDate;
                    contest.EndDate = model.EndDate;
                    contest.UpdatedAt = DateTime.Now;

                    _context.Contests.Update(contest);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var contest = _context.Contests.FirstOrDefault(c => c.ContestId == id);
            if (contest == null)
            {
                return NotFound();
            }

            return View(contest);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var contest = _context.Contests.FirstOrDefault(c => c.ContestId == id);
            if (contest != null)
            {
                _context.Contests.Remove(contest);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var contest = _context.Contests
                .Include(c => c.Teams)
                .FirstOrDefault(c => c.ContestId == id);

            if (contest == null)
            {
                return NotFound();
            }

            return View(contest);
        }
    }
}
