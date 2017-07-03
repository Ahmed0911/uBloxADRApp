namespace uBloxADRTester
{
    partial class FormADR
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
            this.comboBoxComPortListTelit = new System.Windows.Forms.ComboBox();
            this.buttonCommConnectTelit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxComPortListuBlox = new System.Windows.Forms.ComboBox();
            this.buttonCommConnectuBlox = new System.Windows.Forms.Button();
            this.serialPortTelit = new System.IO.Ports.SerialPort(this.components);
            this.serialPortuBlox = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxTelitHeading = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTelitSpeed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTelitSatNr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTelitTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxComPortListTelit
            // 
            this.comboBoxComPortListTelit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComPortListTelit.FormattingEnabled = true;
            this.comboBoxComPortListTelit.Location = new System.Drawing.Point(12, 50);
            this.comboBoxComPortListTelit.Name = "comboBoxComPortListTelit";
            this.comboBoxComPortListTelit.Size = new System.Drawing.Size(188, 28);
            this.comboBoxComPortListTelit.TabIndex = 3;
            // 
            // buttonCommConnectTelit
            // 
            this.buttonCommConnectTelit.Location = new System.Drawing.Point(206, 41);
            this.buttonCommConnectTelit.Name = "buttonCommConnectTelit";
            this.buttonCommConnectTelit.Size = new System.Drawing.Size(86, 45);
            this.buttonCommConnectTelit.TabIndex = 2;
            this.buttonCommConnectTelit.Text = "Connect";
            this.buttonCommConnectTelit.UseVisualStyleBackColor = true;
            this.buttonCommConnectTelit.Click += new System.EventHandler(this.buttonCommConnectTelit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Telit GPS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "uBlox GPS";
            // 
            // comboBoxComPortListuBlox
            // 
            this.comboBoxComPortListuBlox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComPortListuBlox.FormattingEnabled = true;
            this.comboBoxComPortListuBlox.Location = new System.Drawing.Point(12, 116);
            this.comboBoxComPortListuBlox.Name = "comboBoxComPortListuBlox";
            this.comboBoxComPortListuBlox.Size = new System.Drawing.Size(188, 28);
            this.comboBoxComPortListuBlox.TabIndex = 6;
            // 
            // buttonCommConnectuBlox
            // 
            this.buttonCommConnectuBlox.Location = new System.Drawing.Point(206, 107);
            this.buttonCommConnectuBlox.Name = "buttonCommConnectuBlox";
            this.buttonCommConnectuBlox.Size = new System.Drawing.Size(86, 45);
            this.buttonCommConnectuBlox.TabIndex = 5;
            this.buttonCommConnectuBlox.Text = "Connect";
            this.buttonCommConnectuBlox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxTelitHeading);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxTelitSpeed);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxTelitSatNr);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxTelitTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(16, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 169);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Telit";
            // 
            // textBoxTelitHeading
            // 
            this.textBoxTelitHeading.Location = new System.Drawing.Point(87, 130);
            this.textBoxTelitHeading.Name = "textBoxTelitHeading";
            this.textBoxTelitHeading.Size = new System.Drawing.Size(165, 26);
            this.textBoxTelitHeading.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Heading:";
            // 
            // textBoxTelitSpeed
            // 
            this.textBoxTelitSpeed.Location = new System.Drawing.Point(74, 99);
            this.textBoxTelitSpeed.Name = "textBoxTelitSpeed";
            this.textBoxTelitSpeed.Size = new System.Drawing.Size(178, 26);
            this.textBoxTelitSpeed.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Speed:";
            // 
            // textBoxTelitSatNr
            // 
            this.textBoxTelitSatNr.Location = new System.Drawing.Point(74, 67);
            this.textBoxTelitSatNr.Name = "textBoxTelitSatNr";
            this.textBoxTelitSatNr.Size = new System.Drawing.Size(178, 26);
            this.textBoxTelitSatNr.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Sat#:";
            // 
            // textBoxTelitTime
            // 
            this.textBoxTelitTime.Location = new System.Drawing.Point(74, 35);
            this.textBoxTelitTime.Name = "textBoxTelitTime";
            this.textBoxTelitTime.Size = new System.Drawing.Size(178, 26);
            this.textBoxTelitTime.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Time:";
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            this.timerMain.Interval = 20;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // FormADR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 498);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxComPortListuBlox);
            this.Controls.Add(this.buttonCommConnectuBlox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxComPortListTelit);
            this.Controls.Add(this.buttonCommConnectTelit);
            this.Name = "FormADR";
            this.Text = "uBlox ADR Tester ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormADR_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxComPortListTelit;
        private System.Windows.Forms.Button buttonCommConnectTelit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxComPortListuBlox;
        private System.Windows.Forms.Button buttonCommConnectuBlox;
        private System.IO.Ports.SerialPort serialPortTelit;
        private System.IO.Ports.SerialPort serialPortuBlox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxTelitSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTelitSatNr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTelitTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.TextBox textBoxTelitHeading;
        private System.Windows.Forms.Label label6;
    }
}

