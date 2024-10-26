using Hospital.Models;
using Hospital.Repositeries.Interfaces;
using Hospital.Utility;
using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void DeleteDoctor(int Id)
        {
            var model = _unitOfWork.GenericRepository<Doctor>().GetById(Id);
            _unitOfWork.GenericRepository<Doctor>().Delete(model);
            _unitOfWork.Save();
        }

        public void EditDoctor(DoctorViewModel doctor)
        {
            var model = new DoctorViewModel().ConvertModelToViewModel(doctor);
            var ModelById = _unitOfWork.GenericRepository<Doctor>().GetById(model.Id);
            ModelById.Name = doctor.Name;
            ModelById.Email = doctor.Email;
            ModelById.Speciality = doctor.Speciality;
            ModelById.PictureUrl = doctor.Photo;

           _unitOfWork.GenericRepository<Doctor>().Update(ModelById);
            _unitOfWork.Save();
        }

        public PagedResult<DoctorViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new DoctorViewModel();
            int totalCount;
            List<DoctorViewModel> vmList = new List<DoctorViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;


                var modelList = _unitOfWork.GenericRepository<Doctor>().GetAll()
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Doctor>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception)
            {

                throw;
            }
            var Result = new PagedResult<DoctorViewModel>()
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return Result;
        }


        public DoctorViewModel GetDoctorById(int DoctorId)
        {
            var model = _unitOfWork.GenericRepository<Doctor>().GetById(DoctorId);
            var vm = new DoctorViewModel(model);
            return vm;
        }

        public void RegisterDoctor(DoctorViewModel doctor)
        {
            var model = new DoctorViewModel().ConvertModelToViewModel(doctor);
            _unitOfWork.GenericRepository<Doctor>().Add(model);
            _unitOfWork.Save();
        }
        private List<DoctorViewModel> ConvertModelToViewModelList(List<Doctor> modelList)
        {
            return modelList.Select(x => new DoctorViewModel(x)).ToList();
        }


    }
}
