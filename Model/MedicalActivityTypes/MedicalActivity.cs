using System;
using System.Collections.Generic;
using System.Text;

namespace EssensysHospitalWPF.Model
{
    public abstract class MedicalActivity
    {
        public int Id { get; set; }
        public string PacientName { get; set; }
        public string PacientForname { get; set; }
        public DateTime PatientBirthday { get; set; }
        public bool HasChronicDiseases { get; set; }
        public bool MEDICAL_INSURANCE { get; set; }
        protected abstract float InsuranceDiscountAmount { get;}
        public abstract float CalculatePrice();
        public abstract int TimeToComplete();//time in seconds to complete this medical activity;
    }
}
