using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Specialist { get; set; }

        public ApplicationUserViewModel()
        {
                
        }
        public ApplicationUserViewModel(ApplicationUser user)
        {
            Name = user.Name;
            Gender = user.Gender;
            Specialist = user.Specialist;
            Email = user.Email;
                
        }
        public ApplicationUser ConverViewModelToModel(ApplicationUserViewModel user)
        {
            return new ApplicationUser
            {
                Name = user.Name,
                Gender = user.Gender,
                Specialist = user.Specialist,
                Email = user.Email
            };
        }
        public List<ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();
    }
   
}
