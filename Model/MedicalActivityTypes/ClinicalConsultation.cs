using System;
using System.Collections.Generic;
using System.Text;

namespace EssensysHospitalWPF.Model.MedicalActivityTypes
{
    class ClinicalConsultation : MedicalActivity
    {
        private int _priceIndividual;
        private int _priceRegular;
        private float _consultationDiscount;
            
        public ClinicalConsultation(int id, string pacientName, string pacientForname, DateTime pacientBirthDay, bool chronic)
        {
            //base fields
            Id = id;
            PacientName = pacientName;
            PacientForname = pacientForname;
            PatientBirthday = pacientBirthDay;
            HasChronicDiseases = chronic;

            //private fields
            _priceIndividual = 100;
            _priceRegular = 95;
            _consultationDiscount = 0.15f;

        }
        public bool Regular { get; set; }
        public int Frequency { get; set; } //frecventa in luni

        public float CalculatePrice()
        {   //TODO: Add age discount
            float _price;
            if (Regular)
            {
               _price = _priceRegular * Frequency;
            }
            else
            {
                _price = _priceIndividual * Frequency;
            }

            if(GetPatientAge() >= 65)
            {
                _price -= (_price * _consultationDiscount);
            }

            return _price;
        }

        public int GetPatientAge()
        {
            int age;
            var today = DateTime.Today;
            age = (today.Year - PatientBirthday.Year);
            return age;
        }
    }
}
