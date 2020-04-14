using EssensysHospitalWPF.Model.MedicTypes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EssensysHospitalWPF.Model
{
    class Hospital
    {
        private static Hospital hospitalInstance = null;
        public bool IsOpen { //get based on number of docs
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
        }
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

        public Doctor FindFirstAvailableDoctorOfSpecialization(string specialization)
        {
            Doctor firstAvailableDoc = null;
            float currentLowestTime = float.MaxValue;
            foreach (var doctor in Doctors)
            {
                if (doctor.GetType().Name.Equals(specialization) && doctor.GetTotalQueueTime() < currentLowestTime)
                {
                    firstAvailableDoc = doctor;
                }
            }
            return firstAvailableDoc;
        }

        public Doctor HireDoctor(string name, string forName, string cnp, DateTime hireDate, string universityGraduated, int residencyDuration, float residencyGrade, string doctorType)
        {
            int id = 1;//useless
            Doctor doc1 = null;//ca sa nu folosesc mai multe variabile
            ListOfDoctors allDocs = FileOperations.ReadXML();//citesc fisierul sa vad daca mai sunt doctori pentru a-l putea baga pe acesta in continuarea listei
            
            if (CanHireDoctor(cnp, hireDate, residencyGrade))
            {
                switch (doctorType)//in functie de tip filtram ce tip de doctor creem.
                {
                    case "Orthopedic":
                        doc1 = new OrthopedicDoctor(id, name, forName, cnp, hireDate, universityGraduated, residencyDuration,residencyGrade);
                        allDocs.doctors.Add(doc1);//adaugam in lista de doctori
                        allDocs.GetNewIds();//generam Id-uri noi
                        FileOperations.WriteXML(allDocs);//scrie noul fisier cu ultimul doctor bagat
                        Doctors.Add(doc1);
                        return doc1;

                    case "Internal":
                        doc1 = new InternalMedicineDoctor(id, name, forName, cnp, hireDate, universityGraduated, residencyDuration, residencyGrade);
                        allDocs.doctors.Add(doc1);
                        allDocs.GetNewIds();
                        FileOperations.WriteXML(allDocs);
                        Doctors.Add(doc1);
                        return doc1;

                    case "Cardiologist":
                        doc1 = new CardiologistDoctor(id, name, forName, cnp, hireDate, universityGraduated, residencyDuration, residencyGrade);
                        allDocs.doctors.Add(doc1);
                        allDocs.GetNewIds();
                        FileOperations.WriteXML(allDocs);
                        Doctors.Add(doc1);
                        return doc1;
                    default:
                        break;
                }
            }
            return null;
        }

        public List<Doctor> GetAllDoctors()
        {
            return Doctors;
        }
        //verificare daca doctorul este eligibil pentru angajare
        private bool CanHireDoctor(string docCNP, DateTime hireDate, float residencyGrade)
        {
            int age = CNPToAge(docCNP);//transform cnp-ul in varsta
            if (age < 28 
                || residencyGrade < 75
                || hireDate > DateTime.Now)
                return false;

            return true;
        }

        private int CNPToAge(string cnp)
        {
            string birthDayString = cnp.Substring(1, 6);//subset cnp 
            int year = CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(Int32.Parse(birthDayString.Substring(0, 2)));//transforma anul din 2 in 4 cifre
            int month = Int32.Parse(birthDayString.Substring(2,2));//la fel pentru luna si zi
            int day = Int32.Parse(birthDayString.Substring(4, 2));
            DateTime birthDay = new DateTime(year, month, day);
            
            var today = DateTime.Today;
            int age = today.Year - birthDay.Year;//varsta in ani

            return age;
        }
    }
}
