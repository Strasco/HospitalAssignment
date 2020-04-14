using System.Windows;

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
