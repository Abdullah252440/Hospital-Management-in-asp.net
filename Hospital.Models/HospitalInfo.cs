﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class HospitalInfo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PinCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
