using Microsoft.AspNetCore.Mvc;
using MeetingManagementApp.DataAccess.Data;
using MeetingManagementApp.Models;
using MeetingManagementApp.DataAccess.Repository.IRepository;

namespace Web.Controllers
{
    public class MeetingController : Controller
    {
        IMeetingRepository _meetingRepository;
        IWebHostEnvironment _webHostEnvironment;
        public MeetingController(IMeetingRepository db, IWebHostEnvironment webHostEnvironment)
        {
            _meetingRepository = db;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            List<Meeting> meetingList = _meetingRepository.GetAll().ToList();
            return View(meetingList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Meeting obj,IFormFile? file)
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
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename= Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
                    string productpath = Path.Combine(wwwRootPath, @"Documents\Meeting");

                 


                    using (var fileStream = new FileStream(Path.Combine(productpath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    obj.DocumentURL = @"\Documents\Meeting" + filename;
                }
               
    
                _meetingRepository.Add(obj);
                _meetingRepository.Save();
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
            Meeting? meeting = _meetingRepository.Get(u=>u.Id==id);
            if(meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }
        [HttpPost]
        public IActionResult Edit(Meeting obj, IFormFile? file)
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
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productpath = Path.Combine(wwwRootPath, @"Documents\Meeting");

                    var oldImagePath = Path.Combine(wwwRootPath, obj.DocumentURL.TrimStart('\\'));
                   
                    System.IO.File.Delete(oldImagePath);
                    


                    using (var fileStream = new FileStream(Path.Combine(productpath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    obj.DocumentURL = @"\Documents\Meeting" + filename;
                }


                _meetingRepository.Update(obj);
                _meetingRepository.Save();
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
            Meeting? meeting = _meetingRepository.Get(u => u.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Meeting? meeting = _meetingRepository.Get(u => u.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }
            _meetingRepository.Remove(meeting);
            _meetingRepository.Save();
            TempData["success"] = "Meeting deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
