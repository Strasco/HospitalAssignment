﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EssensysHospitalWPF.Model.MedicalActivityTypes
{
    class RecuparationActivity : MedicalActivity
    {
        private int _price;
        private float _discount;
        private float _discountedPrice;
        public int DurationInWeeks { get; set; }
        

        public RecuparationActivity(string pacientName, string pacientForname, DateTime pacientBirthDay, bool chronic)
        {
            //base fields
            PacientName = pacientName;
            PacientForname = pacientForname;
            PatientBirthday = pacientBirthDay;
            HasChronicDiseases = chronic;
            
            _price = 100;
            _discount = 0.35f;
            _discountedPrice = _price - (_price * 0.35f);

            //private fields

        }

        public float CalculatePrice()
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
                else if(i>10 && i % 5 == 0)//daca e mai mare de 10 si este si multiplu de 6 pret cu discount
                {
                    finalPrice += _discountedPrice;
                }
            }
            return finalPrice;
        }
        
    }
}