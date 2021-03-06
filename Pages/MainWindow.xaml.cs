﻿using EssensysHospitalWPF.Model;
using EssensysHospitalWPF.Model.MedicalActivityTypes;
using System;
using System.Windows;
using log4net;
using System.IO;
using System.Reflection;
using EssensysHospitalWPF.Pages;

namespace EssensysHospitalWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        Hospital hospital = Hospital.GetInstance();
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MainWindow()
        {
            InitializeComponent();
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            log4net.Config.XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            mainWindow = this;


            DateTime hireDate = new DateTime(1990, 3, 1);

            //De fiecare data cand chemi HireDoctor, se va verifica intai daca doctorul este eligibil pentru angajare. Se va citi fisierul xml de doctori, noul doctor va fi bagat intr-o lista
            // iar acea lista vine iar scrisa intr-un fisier xml cu noul doctor
  
            hospital.HireDoctor("Maria", "Zaharia", "1800301204105", hireDate, "VIA", 7, 90, "Cardiologist");//creaza 2 doctori si angajeaza-i direct
         
            GeneratePacient();
        }

        public static MainWindow _mainWindow;

        public void GeneratePacient()
        {
            string[] docSpecialization = { "CardiologistDoctor", "InternalMedicineDoctor", "OrthopedicDoctor"};
            string[] pacientName = { "Vlad", "Maria", "Alex", "Ion", "Marius", "Viorel", "Daniela", "Ragnar" };
            string[] pacientForName = { "Zaharia", "Jose", "Bezos", "Frusciante", "Zara", "Calugarul", "Toader", "Lothbrok" };
            DateTime dt = new DateTime(1980, 1, 1);

            Random rnd = new Random();
            int randSpec = rnd.Next(0, 3);
            int randActivity = rnd.Next(0,3);
            int randName = rnd.Next(0, 8);
            int randForName = rnd.Next(0, 8);
            int randMl = rnd.Next(1, 60);
            MedicalActivity activity = null;
            
            switch (randActivity)//un pacient vine in spital si cere o anumita activitate (in cazul nostru e una aleatorie)
            {
                case 0:
                    activity = new ClinicalConsultation(pacientName[randName], pacientForName[randForName], dt, false, 3);//consultatie
                    break;
                case 1:
                    activity = new SurgeryActivity(pacientName[randName], pacientForName[randForName], dt, false,randMl,SurgeryActivity.Anesthetic.LocalAnesthetic);//operatie
                    break;
                case 2:
                    activity = new RecuparationActivity(pacientName[randName], pacientForName[randForName], dt, false, 10);//recuperare
                    break;
            }
            //dupa ce s-a stabilit activitatea ce o vrea pacientul, el de asemenea cere si un doctor de specialitate
            //e.g Vrea consultate de la un cardiolog, sau vrea operatie de la un doctor ortoped etc........
            var doc = hospital.FindFirstAvailableDoctorOfSpecialization(docSpecialization[randSpec]);//se alege in mod aleatoriu un doctor de specialitate
            if (doc != null)//daca am gasit doctor pe specializarea cu timpul cel mai mic de completare bagam pacientul in coada
            {
                doctorLog.AppendText("Doctorul " + doc.Name + " pe specialitatea: " + doc.GetType().Name + " a luat pacientul " + activity.PacientName + " " + activity.PacientForname + " urmeaza sa efectueze " + activity.GetType().Name + " pentru pretul de: " + activity.CalculatePrice() + "si dureaza " + activity.TimeToComplete() + "\r");
                doc.Enqueue(activity);
            }
            else// daca nu este doctor pe specializare pacientul dispare
            {
                doctorLog.AppendText("Nu este doctor liber pe specializarea: " + docSpecialization[randSpec] + "\r");
            }
        }

        

        private void ChangeToAddDoctor(object sender, RoutedEventArgs e)
        {
            NewDoctorWindow doctorWindow = new NewDoctorWindow();
            doctorWindow.Show();
        }

        //Cu acest buton se simuleaza ajungerea unui pacient in spital 
        //la care ii se va aloca doctorul de specialitate ce are cea mai 
        //mica durata de terminare a activitatilor lui
        private void EnqueueButton_Click(object sender, RoutedEventArgs e)
        {
            GeneratePacient();
        }

        private void AddDoctor(object sender, RoutedEventArgs e)
        {
            NewDoctorWindow newDoctor = new NewDoctorWindow();
            newDoctor.Show();
        }

        private void ShowDoctors(object sender, RoutedEventArgs e)
        {
            AllDoctorsWindow window = new AllDoctorsWindow();
            window.Show();
        }

        private void deleteDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveDoctorWindow removeDoc = new RemoveDoctorWindow();
            removeDoc.Show();
        }

        private void editDoctorBtn_Click(object sender, RoutedEventArgs e)
        {
            EditDoctor edit = new EditDoctor();
            edit.Show();
        }
    }
}
