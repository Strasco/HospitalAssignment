using System;

namespace EssensysHospitalWPF.Model.MedicalActivityTypes
{
    class RecuparationActivity : MedicalActivity
    {
        private int _price;
        private float _discount;
        private float _discountedPrice;
        public int DurationInWeeks { get; set; }

        protected override float InsuranceDiscountAmount => 0.1f;

        public RecuparationActivity(string pacientName, string pacientForname, DateTime pacientBirthDay, bool chronic, int weekDuration)
        {
            //base fields
            PacientName = pacientName;
            PacientForname = pacientForname;
            PatientBirthday = pacientBirthDay;
            HasChronicDiseases = chronic;
            DurationInWeeks = weekDuration;
            _price = 100;
            _discount = 0.35f;
            _discountedPrice = _price - (_price * _discount);

            //private fields

        }

        public override float CalculatePrice()
        {
            float finalPrice = 0;
            for (int i = 0; i < DurationInWeeks; i++)
            {
                //daca numarul de sedinte este mai mic decat zece - pret normal
                //SAU daca # de sedinte este mai mare decat zece dar nu este multiplu de 5 - pret normal
                if (i <= 10 || (i>10 && i%5 != 0)) 
                {
                    finalPrice += _price;
                }
                else if(i>10 && i % 5 == 0)//daca e mai mare de 10 si este si multiplu de 5 pret cu discount
                {
                    finalPrice += _discountedPrice;
                }
            }
            if (MEDICAL_INSURANCE)
                return finalPrice - (finalPrice * InsuranceDiscountAmount);

            return finalPrice;
        }

        public override int TimeToComplete()
        {
            return 5000;
        }
    }
}
