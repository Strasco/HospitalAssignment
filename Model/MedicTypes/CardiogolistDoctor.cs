using System;
using System.Collections.Generic;
using System.Text;

namespace EssensysHospitalWPF.Model.MedicTypes
{
    class CardiogolistDoctor : Doctor
    {
        public override float RiskFactor => 1.75f;

        public CardiogolistDoctor(int id, string name, string forName, string cnp, DateTime hiredDate, string universityGraduated, int residencyDuration, float residencyGrade)
        {
            Id = id;
            Name = name;
            ForName = forName;
            CNP = cnp;
            HiredDate = hiredDate;
            UniversityGraduated = universityGraduated;
            ResidencyYearDuration = residencyDuration;
            ResidencyGrade = residencyGrade;
        }

        
    }
}
