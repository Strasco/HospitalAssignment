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

        public bool Regular { get; set; }
        public int Frequency { get; set; } //frecventa in luni
        protected override float InsuranceDiscountAmount => 0.07f;

        public ClinicalConsultation(string pacientName, string pacientForname, DateTime pacientBirthDay, bool chronic, int frequency)
        {
            //base fields
            PacientName = pacientName;
            PacientForname = pacientForname;
            PatientBirthday = pacientBirthDay;
            HasChronicDiseases = chronic;
            Frequency = frequency;

            //private fields
            _priceIndividual = 100;
            _priceRegular = 95;
            _consultationDiscount = 0.15f;

        }
        


        public override float CalculatePrice()
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

            if (MEDICAL_INSURANCE)
                return _price - (_price*InsuranceDiscountAmount);

            return _price;
        }

        public int GetPatientAge()
        {
            int age;
            var today = DateTime.Today;
            age = (today.Year - PatientBirthday.Year);
            return age;
        }

        public override int TimeToComplete()
        {
            return 3000;
        }
    }
}
