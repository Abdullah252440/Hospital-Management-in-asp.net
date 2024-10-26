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
    public class ApplicationUserService : IApplicationUserService
    {
        private IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<ApplicationUserViewModel> GetAll(int PageNumber, int PageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * PageNumber) - PageSize;


                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll()
                    .Skip(ExcludeRecords).Take(PageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception)
            {

                throw;
            }
            var Result = new PagedResult<ApplicationUserViewModel>()
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };
            return Result;
        }

       

        public PagedResult<ApplicationUserViewModel> GetAllDoctor(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ApplicationUserViewModel> GetAllPatient(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public PagedResult<ApplicationUserViewModel> SearchDoctor(int PageNumber, int PageSize, string Speciality = null, string City = null)
        {
            throw new NotImplementedException();
        }



        private List<ApplicationUserViewModel> ConvertModelToViewModelList(List<ApplicationUser> modelList)
        {
            return modelList.Select(x => new ApplicationUserViewModel(x)).ToList();
        }
    }
   
}
