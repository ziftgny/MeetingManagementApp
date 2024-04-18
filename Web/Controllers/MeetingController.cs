using Microsoft.AspNetCore.Mvc;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    public class MeetingController : Controller
    {
        ApplicationDbContext _db;
        public MeetingController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Meeting> meetingList = _db.Meetings.ToList();
            return View(meetingList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Meeting obj)
        {
            if (ModelState.IsValid)
            {
                _db.Meetings.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View();
        }
    }
}
