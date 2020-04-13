using System;
using System.Collections.Generic;
using System.Text;

namespace EssensysHospitalWPF.Model.MedicalActivityTypes
{
    class ClinicalConsultation : MedicalActivity
    {
        private int _priceIndividual;
        private int _priceRegular;
            
        public ClinicalConsultation(string pacientName, string pacientForname, DateTime pacientBirthDay, bool chronic)
        {
            //base fields
            PacientName = pacientName;
            PacientForname = pacientForname;
            PatientBirthday = pacientBirthDay;
            HasChronicDiseases = chronic;

            //private fields
            _priceIndividual = 100;
            _priceRegular = 95;

        }
        public bool Regular { get; set; }
        public int Frequency { get; set; } //frecventa in luni

        public float CalculatePrice()
        {   //TODO: Add age discount
            if (Regular)
            {
               return _priceRegular * Frequency;
            }
            else
            {
                return _priceIndividual * Frequency;
            }
        }
    }
}
