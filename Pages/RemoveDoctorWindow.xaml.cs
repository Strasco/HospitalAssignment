using EssensysHospitalWPF.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EssensysHospitalWPF.Pages
{
    /// <summary>
    /// Interaction logic for RemoveDoctorWindow.xaml
    /// </summary>
    public partial class RemoveDoctorWindow : Window
    {
        public RemoveDoctorWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DeleteDoctor(object sender, RoutedEventArgs e)
        {
            errorTextBox.Document.Blocks.Clear();
            string error = "";
            if (idTextBox.Text.Length == 0)
            {
                error = "Introdu un ID";
                errorTextBox.AppendText(error);
                return;
            }
            if (Int32.Parse(idTextBox.Text) < 0)
            {
                error += "Id-ul trebuie sa fie un numar pozitiv";
                errorTextBox.AppendText(error);
                return;
            }
            ListOfDoctors docs = FileOperations.ReadXML();

            if (Int32.Parse(idTextBox.Text) > docs.doctors.Count-1)
            {
                error += "Id-ul e mai mare decat numarul de doctori din aplicatie";
                errorTextBox.AppendText(error);
                return;
            }
            Doctor doc =null;
            for (int i = 0; i < docs.doctors.Count; i++)
            {
                if(docs.doctors[i].Id == Int32.Parse(idTextBox.Text))
                {
                    doc = docs.doctors[i];
                    docs.doctors.Remove(docs.doctors[i]);
                    break;
                }
            }
            if (doc != null)
            {
                foreach (Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {

                        (window as MainWindow).doctorLog.AppendText("Doctorul " + doc.Name + " " + doc.ForName + " a fost sters din sistem " + "\r");
                        this.Close();
                    }
                }
            }
                
            FileOperations.WriteXML(docs);
            
            this.Close();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
