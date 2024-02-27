namespace WinFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            distanceConverter1 = new WinFormsControlLibrary1.DistanceConverter();
            SuspendLayout();
            // 
            // distanceConverter1
            // 
             distanceConverter1.Location = new Point(257, 171);
            distanceConverter1.Name = "distanceConverter1";
            distanceConverter1.Size = new Size(328, 126);
            distanceConverter1.TabIndex = 0;
            distanceConverter1.CentimetersDistanceChanged += DistanceConverter_CentimetersDistanceChanged;
            distanceConverter1.InchesDistanceChanged += DistanceConverter_InchesDistanceChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(distanceConverter1);
            Name = "MainForm";
            Text = "Lab1 Pavlo Kolodka";
            ResumeLayout(false);
        }

        #endregion

        private WinFormsControlLibrary1.DistanceConverter distanceConverter1;
    }
}