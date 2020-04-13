using System;
using System.Collections.Generic;
using System.Text;

namespace EssensysHospitalWPF.Model
{
    class MedicalActivity
    {
        public int Id { get; set; }
        public string PacientName {get; set;}
        public string PacientForname {get; set;}
        public DateTime PatientBirthday {get; set;}
        public bool HasChronicDiseases {get; set;}
        public bool MEDICAL_INSURANCE { get; set; }
    }
}
