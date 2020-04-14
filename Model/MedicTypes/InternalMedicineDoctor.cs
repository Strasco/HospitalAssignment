using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EssensysHospitalWPF.Model.MedicTypes
{
    public class InternalMedicineDoctor : Doctor
    {
        public InternalMedicineDoctor() { }
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

            var thread = new Thread(new ThreadStart(OnStart));
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
