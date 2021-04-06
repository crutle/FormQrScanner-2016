namespace FormQrScanner
{
    partial class FormQrScanner
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
            this.components = new System.ComponentModel.Container();
            this.comboBoxCameraSource = new System.Windows.Forms.ComboBox();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.buttonCapture = new System.Windows.Forms.Button();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.pictureBoxSource = new System.Windows.Forms.PictureBox();
            this.pictureBoxCaptured = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.eventIdText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptured)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCameraSource
            // 
            this.comboBoxCameraSource.FormattingEnabled = true;
            this.comboBoxCameraSource.Location = new System.Drawing.Point(12, 429);
            this.comboBoxCameraSource.Name = "comboBoxCameraSource";
            this.comboBoxCameraSource.Size = new System.Drawing.Size(435, 24);
            this.comboBoxCameraSource.TabIndex = 0;
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Location = new System.Drawing.Point(12, 489);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(435, 23);
            this.buttonStartStop.TabIndex = 1;
            this.buttonStartStop.Text = "Start Stop";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // buttonCapture
            // 
            this.buttonCapture.Location = new System.Drawing.Point(12, 518);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(435, 23);
            this.buttonCapture.TabIndex = 2;
            this.buttonCapture.Text = "Capture";
            this.buttonCapture.UseVisualStyleBackColor = true;
            this.buttonCapture.Click += new System.EventHandler(this.buttonCapture_Click);
            // 
            // buttonDecode
            // 
            this.buttonDecode.Location = new System.Drawing.Point(12, 547);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(435, 23);
            this.buttonDecode.TabIndex = 3;
            this.buttonDecode.Text = "Decode";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // pictureBoxSource
            // 
            this.pictureBoxSource.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxSource.Name = "pictureBoxSource";
            this.pictureBoxSource.Size = new System.Drawing.Size(599, 411);
            this.pictureBoxSource.TabIndex = 4;
            this.pictureBoxSource.TabStop = false;
            // 
            // pictureBoxCaptured
            // 
            this.pictureBoxCaptured.Location = new System.Drawing.Point(617, 12);
            this.pictureBoxCaptured.Name = "pictureBoxCaptured";
            this.pictureBoxCaptured.Size = new System.Drawing.Size(582, 411);
            this.pictureBoxCaptured.TabIndex = 6;
            this.pictureBoxCaptured.TabStop = false;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(453, 429);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(746, 141);
            this.textBoxMessage.TabIndex = 7;
            // 
            // eventIdText
            // 
            this.eventIdText.Location = new System.Drawing.Point(12, 461);
            this.eventIdText.Name = "eventIdText";
            this.eventIdText.Size = new System.Drawing.Size(435, 22);
            this.eventIdText.TabIndex = 8;
            this.eventIdText.Text = "Event Id";
            // 
            // FormQrScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 582);
            this.Controls.Add(this.eventIdText);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.pictureBoxCaptured);
            this.Controls.Add(this.pictureBoxSource);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.buttonCapture);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.comboBoxCameraSource);
            this.Name = "FormQrScanner";
            this.Text = "FormQrScanner";
            this.Load += new System.EventHandler(this.FormQrScanner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaptured)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCameraSource;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Button buttonCapture;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.PictureBox pictureBoxSource;
        private System.Windows.Forms.PictureBox pictureBoxCaptured;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.TextBox eventIdText;
    }
}

