using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace DiaryApp.Controllers
{
    public class DiaryEntriesController : Controller
    {

        private readonly ApplicationDbContext _db;

        public DiaryEntriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            List<DiaryEntry> objDiaryEntryList  = _db.DiaryEntries.ToList();
            return View(objDiaryEntryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Creates new entry and sends to the database
        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {

            if(obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "The Title is too short!");
            }
            if (ModelState.IsValid)
            {
                //Adds the entry to the database
                _db.DiaryEntries.Add(obj);

                //Saves the changes to the database
                _db.SaveChanges();

                //Redirects us to the main page
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {

            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "The Title is too short!");
            }
            if (ModelState.IsValid)
            {
                //Updates the entry to the database
                _db.DiaryEntries.Update(obj);

                //Saves the changes to the database
                _db.SaveChanges();

                //Redirects us to the main page
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? diaryEntry = _db.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }

            return View(diaryEntry);
        }

        [HttpPost]
        public IActionResult Delete(DiaryEntry obj)
        {
           
                //Deletes the entry from the database
                _db.DiaryEntries.Remove(obj);

                //Saves the changes to the database
                _db.SaveChanges();

                //Redirects us to the main page
                return RedirectToAction("Index");
            
            
        }



    }
}
