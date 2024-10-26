using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class HospitalInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
        
        public HospitalInfoViewModel()
        {
            
        }
        public HospitalInfoViewModel(HospitalInfo models)
        {
            Id = models.Id;
            Name = models.Name;
            Type = models.Type;
            City = models.City;
            PinCode = models.PinCode;
            Country = models.Country;
        }
        public HospitalInfo ConvertViewModel  (HospitalInfoViewModel models)
        {
            return new HospitalInfo {
                Id = models.Id,
                Name = models.Name,
                Type = models.Type,
                City = models.City,
                PinCode = models.PinCode,
                Country = models.Country,
            };
        }
    }
}
