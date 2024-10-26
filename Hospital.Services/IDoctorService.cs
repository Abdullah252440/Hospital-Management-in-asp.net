using Hospital.Utility;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public interface IDoctorService
    {
        PagedResult<DoctorViewModel> GetAll(int pageNumber, int pageSize);
        DoctorViewModel GetDoctorById(int DoctorId);
        void EditDoctor(DoctorViewModel doctor);
        void RegisterDoctor(DoctorViewModel doctor);
        void DeleteDoctor(int Id);
    }
}
