﻿using System;
using System.Threading;

namespace EssensysHospitalWPF.Model.MedicTypes
{
    public class CardiologistDoctor : Doctor
    {
        public CardiologistDoctor() { }
        public override float RiskFactor => 1.75f;

        public CardiologistDoctor(int id, string name, string forName, string cnp, DateTime hiredDate, string universityGraduated, int residencyDuration, float residencyGrade)
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

        public override string ToString()
        {
            return "ID: " + Id + " Nume: " + Name + " Prenume: " + ForName + " CNP: " + CNP + " Angajat: " + HiredDate + " Universitate: " + UniversityGraduated + " Nota: " + ResidencyGrade;
        }
    }
}
