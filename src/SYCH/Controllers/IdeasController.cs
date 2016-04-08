using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using SYCH.Models;
using System;

namespace SYCH.Controllers
{
    public class IdeasController : Controller
    {
        private ApplicationDbContext _context;

        public IdeasController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Ideas
        public IActionResult Index(string searchString)
        {
            var ideas = from i in _context.Idea
                         select i;
            if (!String.IsNullOrEmpty(searchString))
            {
                ideas = ideas.Where(s => s.Description.Contains(searchString));
            }

            return View(_context.Idea.ToList());
        }

        // GET: Ideas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Idea idea = _context.Idea.Single(m => m.ID == id);
            if (idea == null)
            {
                return HttpNotFound();
            }

            return View(idea);
        }

        // GET: Ideas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ideas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Idea idea)
        {
            if (ModelState.IsValid)
            {
                _context.Idea.Add(idea);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idea);
        }

        // GET: Ideas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Idea idea = _context.Idea.Single(m => m.ID == id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        // POST: Ideas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Idea idea)
        {
            if (ModelState.IsValid)
            {
                _context.Update(idea);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idea);
        }

        // Get Vote
        public IActionResult Vote(int? id)
        {
            Idea idea = _context.Idea.Single(m => m.ID == id);
            return View(idea);
        }

        // POST: Vote up
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Vote(Idea idea)
        {
            if(ModelState.IsValid)
            {
                idea.Votes++;
                idea.Description = idea.Description +"";
                idea.Industry = idea.Industry + "";
                _context.Update(idea);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idea);
        }

        // GET: Ideas/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Idea idea = _context.Idea.Single(m => m.ID == id);
            if (idea == null)
            {
                return HttpNotFound();
            }

            return View(idea);
        }

        // POST: Ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Idea idea = _context.Idea.Single(m => m.ID == id);
            _context.Idea.Remove(idea);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
