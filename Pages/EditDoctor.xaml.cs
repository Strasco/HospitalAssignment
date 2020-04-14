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
    /// Interaction logic for EditDoctor.xaml
    /// </summary>
    public partial class EditDoctor : Window
    {
        public EditDoctor()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void EditDoctorDetails_Click(object sender, RoutedEventArgs e)
        {
            string errors = "";
            errorRichText.Document.Blocks.Clear();
            ListOfDoctors docs =  FileOperations.ReadXML();
            if (idTextBox.Text.Length <= 0)
            {
                errors += " Introdu un ID \r";
                errorRichText.AppendText(errors);

                return;
            }
            if(Int32.Parse(idTextBox.Text) > docs.doctors.Count - 1)
            {
                errors += " Id-ul este mai mare decat numarul de doctori din aplicatie \r";
            }
            if(nameTextBox.Text.Length < 4 || forNameTextBox.Text.Length < 4)
            {
                errors += "Numele si prenumele trebuie sa fie mai lungi de 3 caractere \r";
            }

            if (errors.Equals(""))
            {
                Doctor doc = null;
                for (int i = 0; i < docs.doctors.Count; i++)
                {
                    if(docs.doctors[i].Id == Int32.Parse(idTextBox.Text))
                    {
                        docs.doctors[i].Name = nameTextBox.Text;
                        docs.doctors[i].ForName = forNameTextBox.Text;
                        doc = docs.doctors[i];
                        FileOperations.WriteXML(docs);
                        break;
                    }
                }
                foreach (Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        if (doc != null)
                        (window as MainWindow).doctorLog.AppendText("Doctorul cu ID: " + doc.Id + "  i-a fost schimbat numele in: " + nameTextBox.Text + " " + forNameTextBox.Text + " \r");
                        this.Close();
                    }
                }
            }

            
            errorRichText.AppendText(errors);
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
