using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for AllDoctorsWindow.xaml
    /// </summary>
    public partial class AllDoctorsWindow : Window
    {
        public AllDoctorsWindow()
        {
            InitializeComponent();
            ListOfDoctors allDocs = FileOperations.ReadXML();
            foreach (var doctor in allDocs.doctors)
            {
                allDoctorsRichText.AppendText(doctor.ToString() + "\r");
            }
        }

        private void BackToMain(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
