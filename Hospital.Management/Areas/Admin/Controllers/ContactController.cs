using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Management.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contact;
        private readonly IHospitalInfo _hospital;
        public ContactController(IContactService contact,IHospitalInfo hospital)
        {
            _contact = contact;
            _hospital = hospital;
        }

        public IActionResult Index(int pageNumber = 1 , int pageSize = 10)
        {
            return View(_contact.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _contact.GetContactById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(ContactViewModel vm)
        {
            _contact.UpdateContact(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            int pageNumber = 1; int pageSize = 10;
            ViewBag.hospital = _hospital.GetAll(pageNumber, pageSize);
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactViewModel vm)
        {
            _contact.InsertContact(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _contact.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
