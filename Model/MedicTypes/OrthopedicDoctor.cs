using System;
using System.Collections.Generic;
using System.Text;

namespace EssensysHospitalWPF.Model.MedicTypes
{
    class OrthopedicDoctor : Doctor
    {

        public OrthopedicDoctor(int id, string name, string forName, string cnp, DateTime hiredDate, string universityGraduated, int residencyDuration, float residencyGrade)
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
        public override float RiskFactor => 1.25f;
    }
}
