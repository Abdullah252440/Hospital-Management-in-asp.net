using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Management.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Route("Area/")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DoctorController(IDoctorService doctor, IWebHostEnvironment webHostEnvironment)
        {
            _doctor = doctor;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_doctor.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(DoctorViewModel model)
        {
            _doctor.RegisterDoctor(model);
            RedirectToAction("Index");
            return View();

        }
        [HttpPost]
        public IActionResult UploadImage(DoctorViewModel model)
        {
            if (model.Photo != null && model.Photo.Length > 0)
            {
                // Create a directory if it doesn't exist
                var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }

                // Generate a unique file name for the image to avoid overwriting
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

                // Combine the path and file name
                var filePath = Path.Combine(uploadsDirectory, uniqueFileName);

                // Copy the uploaded file to the target directory
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                     model.Photo.CopyToAsync(fileStream);
                }

                return RedirectToAction("Register");

            }
            return View(model);
        }
    }
        
}
