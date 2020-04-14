using EssensysHospitalWPF.Model.MedicTypes;
using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace EssensysHospitalWPF.Model
{
    public abstract class Doctor
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//pentru logging

        public int Id { get; set; }
        public string Name { get; set; }
        public string ForName { get; set; }
        public string CNP { get; set; }
        public DateTime HiredDate { get; set; }
        public string UniversityGraduated { get; set; }
        public int ResidencyYearDuration { get; set; } //Durata rezidentiatului in ani
        public float ResidencyGrade { get; set; }//punctajul la rezidentiat
        public abstract float RiskFactor { get;}//factorul de risc
        protected float BaseSalary { get { return 1500; } }
        public float CalculateSalary()//se calculeaza salariul in baza factorilor enumerati
        {
            float salary;
            var today = DateTime.Today;
            int years = today.Year - HiredDate.Year;

            salary = BaseSalary * years * RiskFactor;
            return salary;
        }
        private const int maxConsultations = 10;//numarul maxim de activitati pe fiecare ramura pe care le poate face un medic
        private int currentConsultations;

        private const int maxSurgeries = 2;
        private int currentSurgeries;

        private const int maxRecuperations = 15;
        private int currentRecuperations;

        private ConcurrentQueue<MedicalActivity> _jobs = new ConcurrentQueue<MedicalActivity>();//lista thread safe pentru medici
        public Doctor()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            log4net.Config.XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

        }
        public void OnStart()
        {
            while (true)
            {
                if (_jobs.TryDequeue(out MedicalActivity result))//cand un medic isi termina treaba aceasta metoda se cheama
                {
                    Thread.Sleep(result.TimeToComplete());//doarme numarul de secunde estimate in functie de fiecare activitate
                      log.Info("Doctorul " + Name + " a terminat cu pacientul " + result.PacientName + " " + result.PacientForname + "\r");
                    switch (result.GetType().Name)
                    {
                        case "ClinicalConsultation":
                                currentConsultations--;//decrementarea activitatilor curente
                            break;
                        case "SurgeryActivity":
                                currentSurgeries--;
                            break;
                        case "RecuperationActivity":
                                currentRecuperations--;
                            break;
                    }
                }
            }
        }

        public void Enqueue(MedicalActivity job)//de fiecare daca cand vine un pacient nou, metoda aceasta se cheama
        {

            switch (job.GetType().Name)//in functie de ce vrea pacientul se personalizeaza functie Enqueue
            {
                case "ClinicalConsultation":
                    if (currentConsultations < maxConsultations)
                        currentConsultations++;
                        _jobs.Enqueue(job);
                    break;
                case "SurgeryActivity":
                    if (currentSurgeries < maxSurgeries)
                        currentSurgeries++;
                        _jobs.Enqueue(job);
                    break;
                case "RecuperationActivity":
                    if (currentRecuperations < maxRecuperations)
                        currentRecuperations++;
                        _jobs.Enqueue(job);
                    break;
            }
            
            //daca ajungem aici inseamna ca doctorul este supra aglomerat
            
        }
        public float GetTotalQueueTime()//timpul total al tuturor activitatilor al acestui medic
        {
            float totalTime = 0;
            foreach (var job in _jobs)
            {
                totalTime += job.TimeToComplete();
            }

            return totalTime;
        }


    }
}
