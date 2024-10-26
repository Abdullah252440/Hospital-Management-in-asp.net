﻿namespace Hospital.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int BillNumber { get; set; }
        public ApplicationUser Patient { get; set; }
        public int DoctorCharge { get; set; }
        public decimal MedicineCharge { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal OperationCharge { get; set; }
        public int NoOfDays { get; set; }
        public int NursingCharge { get; set;}
        public int Labcharge { get; set; }
        public int Advance { get; set; }
        public decimal TotalBill { get; set; }
    }
}