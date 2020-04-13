using System;
using System.Collections.Generic;
using System.Text;

namespace EssensysHospitalWPF.Model
{
    abstract class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ForName { get; set; }
        public string CNP { get; set; }
        public DateTime HiredDate { get; set; }
        public string UniversityGraduated { get; set; }
        public int ResidencyYearDuration { get; set; } //Durata rezidentiatului in ani
        public float ResidencyGrade { get; set; }//punctajul la rezidentiat
        public abstract float RiskFactor { get;}//factorul de risc
        protected float BaseSalary { get { return 1500; } }
        public float CalculateSalary()
        {
            float salary;
            var today = DateTime.Today;
            int years = today.Year - HiredDate.Year;

            salary = BaseSalary * years * RiskFactor;
            return salary;
        }
    }
}
