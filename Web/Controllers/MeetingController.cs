using Microsoft.AspNetCore.Mvc;
using MeetingManagementApp.DataAccess.Data;
using MeetingManagementApp.Models;

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
            if (DateTime.Compare(DateTime.Now, obj.EndTime) > 0)
            {
                ModelState.AddModelError("EndTime", "Please enter a valid date");
            }
            if (DateTime.Compare(DateTime.Now, obj.StartTime) > 0)
            {
                ModelState.AddModelError("StartTime", "Please enter a valid date");
            }
            if (DateTime.Compare(obj.StartTime, obj.EndTime) >= 0)
            {
                ModelState.AddModelError("EndTime", "Ending Time cant be earlier than Starting Time");
            }
            if (ModelState.IsValid)
            {
                _db.Meetings.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Meeting created successfully";
                return RedirectToAction("Index");
            }
           return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id==0 || id == null)
            {
                return NotFound();
            }
            Meeting? meeting = _db.Meetings.FirstOrDefault(u=>u.Id==id);
            if(meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }
        [HttpPost]
        public IActionResult Edit(Meeting obj)
        {
            if(DateTime.Compare(DateTime.Now, obj.EndTime) > 0)
            {
                ModelState.AddModelError("EndTime", "Please enter a valid date");
            }
            if (DateTime.Compare(DateTime.Now, obj.StartTime) > 0)
            {
                ModelState.AddModelError("StartTime", "Please enter a valid date");
            }
            if (DateTime.Compare(obj.StartTime, obj.EndTime) >= 0)
            {
                ModelState.AddModelError("EndTime", "Ending Time cant be earlier than Starting Time");
            }
            if (ModelState.IsValid)
            {
                _db.Meetings.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Meeting updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Meeting? meeting = _db.Meetings.FirstOrDefault(u => u.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Meeting? meeting = _db.Meetings.FirstOrDefault(u => u.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }
            _db.Meetings.Remove(meeting);
            _db.SaveChanges();
            TempData["success"] = "Meeting deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
