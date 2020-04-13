using System;
using System.Collections.Generic;
using System.Text;

namespace EssensysHospitalWPF.Model
{
    class Medic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ForName { get; set; }
        public string CNP { get; set; }
        public DateTime HiredDate { get; set; }
        public string UniversityGraduated { get; set; }
        public int ResidencyYearDuration { get; set; } //Durata rezidentiatului in ani
        public float ResidencyGrade { get; set; }//punctajul la rezidentiat
        public float RiskFactor { get; set; }//factorul de risc
            
    }
}
