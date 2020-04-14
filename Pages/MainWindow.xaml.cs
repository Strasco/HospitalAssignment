using EssensysHospitalWPF.Model;
using EssensysHospitalWPF.Model.MedicalActivityTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using log4net;
using System.IO;
using System.Reflection;
using EssensysHospitalWPF.Model.MedicTypes;

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
  
            Doctor doc = hospital.HireDoctor("Maria", "Zaharia", "1800301204105", hireDate, "VIA", 7, 90, "Cardiologist");//creaza 2 doctori si angajeaza-i direct
            Doctor doc2 = hospital.HireDoctor("Maria", "Alvarez", "1800301204105", hireDate, "VIA", 7, 90, "Cardiologist");
         
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
            switch (randActivity)
            {
                case 0:
                    activity = new ClinicalConsultation(pacientName[randName], pacientForName[randForName], dt, false, 3);
                    break;
                case 1:
                    activity = new SurgeryActivity(pacientName[randName], pacientForName[randForName], dt, false,randMl,SurgeryActivity.Anesthetic.LocalAnesthetic);
                    break;
                case 2:
                    activity = new RecuparationActivity(pacientName[randName], pacientForName[randForName], dt, false, 10);
                    break;
            }
            var doc = hospital.FindFirstAvailableDoctorOfSpecialization(docSpecialization[randSpec]);
            if (doc != null)//daca am gasit doctor pe specializarea cu timpul cel mai mic de completare bagam pacientul in coada
            {
                doc.Enqueue(activity);
            }
            else// daca nu este doctor pe specializare pacientul dispare op
            {
                doctorLog.AppendText("Nu este doctor liber pe specializarea: " + docSpecialization[randSpec] + "\r");
            }
        }

        

        private void ChangeToAddDoctor(object sender, RoutedEventArgs e)
        {
            NewDoctor doctorWindow = new NewDoctor();
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

        }

        private void ShowDoctors(object sender, RoutedEventArgs e)
        {

        }
    }
}
