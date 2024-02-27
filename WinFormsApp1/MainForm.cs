using System.Diagnostics;
using WinFormsControlLibrary1;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void DistanceConverter_CentimetersDistanceChanged(object sender, DistanceChangedEventArgs e)
        {
            double newCentimetersDistance = e.NewDistance;
            Debug.WriteLine($"Centimeters distance changed: {newCentimetersDistance}");
        }

        private void DistanceConverter_InchesDistanceChanged(object sender, DistanceChangedEventArgs e)
        {
            double newInchesDistance = e.NewDistance;
            Debug.WriteLine($"Inches distance changed: {newInchesDistance}");
        }
    }
}