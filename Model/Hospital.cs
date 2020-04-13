using EssensysHospitalWPF.Model.MedicTypes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EssensysHospitalWPF.Model
{
    class Hospital
    {
        private static Hospital hospitalInstance = null;
        public bool IsOpen { 
            get {
                    if (Doctors.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                } 
        }//Calculate based on number of docs
        public List<Doctor> Doctors { get; set; }

        private Hospital()
        {
            Doctors = new List<Doctor>();
        }

        public static Hospital GetInstance()
        {
            if (hospitalInstance == null)
            {
                hospitalInstance = new Hospital();
            }
            return hospitalInstance;
        }

        //TODO: Get next available ID for a doctor
        public void HireDoctor(string name, string forName, string cnp, DateTime birthDay, DateTime hireDate, string universityGraduated, int residencyDuration, float residencyGrade, string doctorType)
        {
            int id = 1;

            if(CanHireDoctor(cnp, hireDate, residencyGrade))
            {
                switch (doctorType)
                {
                    case "Orthopedic":
                        Doctor doc1 = new OrthopedicDoctor(id, name, forName, cnp, hireDate, universityGraduated, residencyDuration,residencyGrade);
                        Doctors.Add(doc1);
                        break;

                    case "Internal":
                        Doctor doc2 = new InternalMedicineDoctor(id, name, forName, cnp, hireDate, universityGraduated, residencyDuration, residencyGrade);
                        Doctors.Add(doc2);
                        break;

                    case "Cardiologist":
                        Doctor doc3 = new CardiogolistDoctor(id, name, forName, cnp, hireDate, universityGraduated, residencyDuration, residencyGrade);
                        Doctors.Add(doc3);
                        break;
                    default:
                        break;

                }
                
            }

        }

        public List<Doctor> GetAllDoctors()
        {
            return Doctors;
        }

        private bool CanHireDoctor(string docCNP, DateTime hireDate, float residencyGrade)
        {
            int age = CNPToAge(docCNP);
            if (age < 28
                || residencyGrade < 75
                || hireDate > DateTime.Now)
                return false;

            return true;
        }

        private int CNPToAge(string cnp)
        {
            string birthDayString = cnp.Substring(1, 6);
            int year = CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(Int32.Parse(birthDayString.Substring(0, 2)));
            int month = Int32.Parse(birthDayString.Substring(2,2));
            int day = Int32.Parse(birthDayString.Substring(4, 2));
            
            DateTime birthDay = new DateTime(year, month, day);
            var today = DateTime.Today;

            int age = today.Year - birthDay.Year;

            return age;
        }
    }
}
