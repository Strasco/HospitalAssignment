﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EssensysHospitalWPF.Model.MedicalActivityTypes
{
    class SurgeryActivity : MedicalActivity
    {
        private int _priceLocal;
        private int _priceGeneral;
        private Anesthetic _anestheticUsed;

        public SurgeryActivity(int id, string pacientName, string pacientForname, DateTime pacientBirthDay, bool chronic, float ml, Anesthetic anesthetic)
        {
            Id = id;
            PacientName = pacientName;
            PacientForname = pacientForname;
            PatientBirthday = pacientBirthDay;
            HasChronicDiseases = chronic;
            Ml = ml; //mililiters
            _anestheticUsed = anesthetic;

            _priceLocal = 150;
            _priceGeneral = 200;
        }

        public enum Anesthetic {LocalAnesthetic, GeneralAnesthetic}
        public float Ml { get; set; }//dozajul
        public float CalculatePrice()
        {
            
            //TODO: Add age discount
            switch (_anestheticUsed)
            {
                case Anesthetic.LocalAnesthetic:
                    return _priceLocal * Ml;
                
                case Anesthetic.GeneralAnesthetic:
                    return _priceGeneral * Ml;
                default:
                    break;
            }
            return 0;
            
        }
    }
}