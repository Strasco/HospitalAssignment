using System;
using System.Collections.Generic;
using System.Text;

namespace EssensysHospitalWPF.Model.MedicTypes
{
    class InternalMedicineDoctor : Doctor
    {
        public override float RiskFactor => throw new NotImplementedException();

        public InternalMedicineDoctor(int id, string name, string forName, string cnp, DateTime hiredDate, string universityGraduated, int residencyDuration, float residencyGrade)
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
