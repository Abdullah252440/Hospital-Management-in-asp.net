﻿using Hospital.Models;
using Hospital.Repositeries.Implementation;
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
    public class ContactService : IContactService
    {
        private IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteContact(int Id)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(Id);
            _unitOfWork.GenericRepository<Contact>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ContactViewModel();
            int totalCount;
            List<ContactViewModel> vmList = new List<ContactViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;


                var modelList = _unitOfWork.GenericRepository<Contact>().GetAll(includeProperties: "Hospital")
                    .Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Contact>().GetAll().ToList().Count;

                vmList = ConvertModelToViewModelList(modelList);

            }
            catch (Exception)
            {

                throw;
            }
            var Result = new PagedResult<ContactViewModel>()
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return Result;
        }


        public ContactViewModel GetContactById(int ContactId)
        {
            var model = _unitOfWork.GenericRepository<Contact>().GetById(ContactId);
            var vm = new ContactViewModel(model);
            return vm;
        }

        public void InsertContact(ContactViewModel contact)
        {
            var model = new ContactViewModel().ConvertViewModel(contact);
            _unitOfWork.GenericRepository<Contact>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateContact(ContactViewModel contact)
        {
            var model = new ContactViewModel().ConvertViewModel(contact);
            var ModelById = _unitOfWork.GenericRepository<Contact>().GetById(model.Id);
            ModelById.Phone = contact.Phone;
            ModelById.Email = contact.Email;

            _unitOfWork.GenericRepository<Contact>().Update(ModelById);
            _unitOfWork.Save();
        }
        private List<ContactViewModel> ConvertModelToViewModelList(List<Contact> modelList)
        {
            return modelList.Select(x => new ContactViewModel(x)).ToList();
        }
    }
  
}
