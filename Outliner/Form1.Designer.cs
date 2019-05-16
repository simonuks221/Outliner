namespace Outliner
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.SensitivitySlider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensitivitySlider)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.Location = new System.Drawing.Point(12, 12);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(272, 147);
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.TabStop = false;
            // 
            // SensitivitySlider
            // 
            this.SensitivitySlider.Location = new System.Drawing.Point(471, 311);
            this.SensitivitySlider.Name = "SensitivitySlider";
            this.SensitivitySlider.Size = new System.Drawing.Size(253, 45);
            this.SensitivitySlider.TabIndex = 1;
            this.SensitivitySlider.ValueChanged += new System.EventHandler(this.SensitivitySlider_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 368);
            this.Controls.Add(this.SensitivitySlider);
            this.Controls.Add(this.MainPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SensitivitySlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.TrackBar SensitivitySlider;
    }
}

