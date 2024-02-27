using System.ComponentModel;
using System.Diagnostics;

namespace WinFormsControlLibrary1
{
    // does not work [ToolboxBitmap(typeof(DistanceConverter), "Icon1")]
    // works [ToolboxBitmap("C:\\Users\\Xacker\\source\\repos\\uni\\firstYear\\SWE_Architecture\\Lab1\\WinFormsControlLibrary1\\Icon1.png")]
    // does not work [ToolboxBitmap(typeof(DistanceConverter), "WinFormsControlLibrary1.Resources.Icon1.png")]
    // works [ToolboxBitmap("C:\\Users\\Xacker\\source\\repos\\uni\\firstYear\\SWE_Architecture\\Lab1\\WinFormsControlLibrary1\\Icon1.bmp")]
    [ToolboxBitmap(typeof(DistanceConverter), "Icon1.bmp")]
    public partial class DistanceConverter : UserControl
    {

        private TextBox centimetersTextBox;
        private TextBox inchesTextBox;
        private Label centimetersLabel;
        private Label inchesLabel;

        private string _centimetersDistanceLabel;
        private string _inchesDistanceLabel;
        private double _centimetersDistance;
        private double _inchesDistance;

        public event EventHandler<DistanceChangedEventArgs> CentimetersDistanceChanged;
        public event EventHandler<DistanceChangedEventArgs> InchesDistanceChanged;

        public DistanceConverter()
        {
            InitializeComponent();
            InitializeComponents();
        }

        public double CentimetersDistance
        {
            get
            {                
                return _centimetersDistance;
            }
            set
            {
                
                _centimetersDistance = value;
                _inchesDistance = value / 2.54;
                centimetersTextBox.Text = _centimetersDistance.ToString();
                inchesTextBox.Text = (_inchesDistance).ToString();

         
                 OnCentimetersDistanceChanged(_centimetersDistance);
                 OnInchesDistanceChanged(_inchesDistance);
            }
        }       
        public double InchesDistance
        {
            get
            {               
                return _inchesDistance;
            }
            set
            {
                _inchesDistance = value;
                _centimetersDistance = value * 2.54;
                inchesTextBox.Text = _inchesDistance.ToString();
                centimetersTextBox.Text = (_centimetersDistance).ToString();


                OnInchesDistanceChanged(_inchesDistance);
                OnCentimetersDistanceChanged(_centimetersDistance);
            }
        }

        // [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string InchesDistanceLabel
        {
            get
            {
                return inchesLabel.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("InchesDistanceLabel cannot be null or empty");
                }

                inchesLabel.Text = value;
            }
        }

       // [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CentimetersDistanceLabel
        {
            get
            {
                return centimetersLabel.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("CentimetersDistanceLabel cannot be null or empty");
                }

                centimetersLabel.Text = value;
            }
        }

        private void InitializeComponents()
        {
            centimetersTextBox = new TextBox();
            inchesTextBox = new TextBox();
            centimetersLabel = new Label();
            inchesLabel = new Label();

            centimetersTextBox.KeyUp += CentimetersTextBox_TextChanged;
            inchesTextBox.KeyUp += InchesTextBox_TextChanged;
           
            centimetersLabel.Text = "Введіть сантиметри та натисніть Enter:";
            inchesLabel.Text = "Введіть дюйми та натисніть Enter:";

            centimetersLabel.AutoSize = true;
            inchesLabel.AutoSize = true;
        
            centimetersLabel.Location = new Point(0, 0);
            centimetersTextBox.Location = new Point(0, centimetersLabel.Bottom + 5);

            inchesLabel.Location = new Point(0, centimetersTextBox.Bottom + 5);
            inchesTextBox.Location = new Point(0, inchesLabel.Bottom + 5);

           

            Controls.Add(centimetersTextBox);
            Controls.Add(inchesTextBox);
            Controls.Add(centimetersLabel);
            Controls.Add(inchesLabel);
        }


        private void CentimetersTextBox_TextChanged(object sender, KeyEventArgs e)
        {
            if (double.TryParse(centimetersTextBox.Text, out double centimeters))
            {
                if (e.KeyCode != Keys.Enter)
                {                   
                    return;
                }

                CentimetersDistance = centimeters;
            }
        }
       
        private void InchesTextBox_TextChanged(object sender, KeyEventArgs e)
        {        

            if (double.TryParse(inchesTextBox.Text, out double inches))
            {
                if (e.KeyCode != Keys.Enter)
                {                    
                    return;
                }

                InchesDistance = inches;
            }
        }

        protected virtual void OnCentimetersDistanceChanged(double newCentimetersDistance)
        {
            CentimetersDistanceChanged?.Invoke(this, new DistanceChangedEventArgs(newCentimetersDistance));
        }

        protected virtual void OnInchesDistanceChanged(double newInchesDistance)
        {
            InchesDistanceChanged?.Invoke(this, new DistanceChangedEventArgs(newInchesDistance));
        }
    }
}