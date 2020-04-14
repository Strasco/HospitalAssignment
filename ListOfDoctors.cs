using EssensysHospitalWPF.Model;
using EssensysHospitalWPF.Model.MedicTypes;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EssensysHospitalWPF
{
    [XmlInclude(typeof(CardiologistDoctor))]
    [XmlInclude(typeof(InternalMedicineDoctor))]
    [XmlInclude(typeof(OrthopedicDoctor))]
    [XmlRoot("Doctors")]
    public class ListOfDoctors
    {
        
        public List<Doctor> doctors;
        private int currentId;
        public ListOfDoctors()
        {
            doctors = new List<Doctor>();
        }
        public ListOfDoctors(List<Doctor> doctors)
        {
            this.doctors = doctors;
            foreach (var doctor in this.doctors) //incrementare automata de fiecare data cand lucram cu lista de doctori
            {
                doctor.Id = currentId;
                currentId++;
            }
        }

        public void GetNewIds()
        {
            int id = 0;
            foreach (var doctor in doctors)
            {
                doctor.Id = id;
                id++;
            }
        }
    }
}
