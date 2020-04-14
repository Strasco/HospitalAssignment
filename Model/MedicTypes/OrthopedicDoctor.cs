using System;
using System.Threading;

namespace EssensysHospitalWPF.Model.MedicTypes
{
    public class OrthopedicDoctor : Doctor
    {
        public OrthopedicDoctor() { }
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

            var thread = new Thread(new ThreadStart(OnStart));
            thread.IsBackground = true;
            thread.Start();
        }
        public override float RiskFactor => 1.25f;
    }
}
