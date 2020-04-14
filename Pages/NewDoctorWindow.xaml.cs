using EssensysHospitalWPF.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace EssensysHospitalWPF
{
    /// <summary>
    /// Interaction logic for NewDoctor.xaml
    /// </summary>
    public partial class NewDoctorWindow : Window
    {
        Hospital hospital = Hospital.GetInstance();

        public NewDoctorWindow()
        {
            InitializeComponent();
        }

        private void BackToMain(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void AddDoctor(object sender, RoutedEventArgs e)
        {
            errorRichText.Document.Blocks.Clear();
            string errors = "";
            if (nameDoctorText.Text.Length < 4)
                errors += "Numele trebuie sa fie mai lung de 3 caractere \r";
            if(forNameDoctorText.Text.Length<4)
                errors += "Numele trebuie sa fie mai lung de 3 caractere \r ";
            if (cnpDoctorText.Text.Length != 13)
                errors += "CNP incorect \r";
            if (UniversityTextBox.Text.Equals(""))
                errors += "Campul de Universitate este gol \r";
            if (datePicker.SelectedDate == DateTime.MinValue)
                errors += "Alege o data corecta \r";
            if (Int32.Parse(residencyDurationTextBox.Text) <= 0)
                errors += "Residentiatul in ani trebuie sa fie un numar pozitiv \r";
            if (Int32.Parse(residencyGradeTextBox.Text) <= 0)
                errors += "Nota rezidentiatului trebuie sa fie un numar pozitiv \r";
            if (cardioBtn.IsChecked == false && internalBtn.IsChecked == false && orthoBtn.IsChecked == false)
                errors += "Selecteaza o specializare \r";
            
            Doctor doc = null;
            if (errors.Equals(""))
            {
                
                if (cardioBtn.IsChecked == true)
                {
                    doc = hospital.HireDoctor(nameDoctorText.Text, forNameDoctorText.Text, cnpDoctorText.Text, (DateTime)datePicker.SelectedDate, UniversityTextBox.Text, Int32.Parse(residencyDurationTextBox.Text), Int32.Parse(residencyGradeTextBox.Text), "Cardiologist");
                }else if (orthoBtn.IsChecked == true)
                {
                    doc = hospital.HireDoctor(nameDoctorText.Text, forNameDoctorText.Text, cnpDoctorText.Text, (DateTime)datePicker.SelectedDate, UniversityTextBox.Text, Int32.Parse(residencyDurationTextBox.Text), Int32.Parse(residencyGradeTextBox.Text), "Orthopedic");
                }else if (internalBtn.IsChecked == true)
                {
                    doc = hospital.HireDoctor(nameDoctorText.Text, forNameDoctorText.Text, cnpDoctorText.Text, (DateTime)datePicker.SelectedDate, UniversityTextBox.Text, Int32.Parse(residencyDurationTextBox.Text), Int32.Parse(residencyGradeTextBox.Text), "Internal");
                }
                if (doc == null)
                {
                    errors += "Doctorul nu este eligibil pentru angajare \r";
                    return;
                }
                
            }
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).doctorLog.AppendText("Doctorul " + nameDoctorText.Text + " " + forNameDoctorText.Text + " pe specialziarea: " + doc.GetType().Name + " a fost angajat" + "\r");
                    this.Close();
                }
            }
            errorRichText.AppendText(errors);
            
        }
    }
}
