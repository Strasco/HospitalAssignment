using EssensysHospitalWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace EssensysHospitalWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Hospital hospital = Hospital.GetInstance();
        public MainWindow()
        {
            InitializeComponent();
            DateTime myBirthDay = new DateTime(1980, 3, 1);
            DateTime hireDate = new DateTime(1990, 3, 1);
            hospital.HireDoctor("vlad", "Zaharia","1800301204105", myBirthDay, hireDate, "VIA", 7, 90, "Orthopedic");
            hospital.HireDoctor("Alex", "Zaharia", "1960301204105", myBirthDay, hireDate, "VIA", 7, 90, "Interna");
            hospital.HireDoctor("Maria", "Zaharia", "1800301204105", myBirthDay, hireDate, "VIA", 7, 90, "Cardiologist");
            hospital.HireDoctor("Paul", "Zaharia", "1960301204105", myBirthDay, hireDate, "VIA", 7, 90, "Orthopedic");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AllDoctors.Document.Blocks.Clear();
            List<Doctor> allDoctors = hospital.GetAllDoctors();
            foreach (var doctor in allDoctors)
            {
                AllDoctors.AppendText(doctor.Name + "\r");
            }
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
