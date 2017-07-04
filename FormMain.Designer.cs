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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxuBloxHeading = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxuBloxSpeed = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxuBloxSatNr = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxuBloxTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxComPortListTiva = new System.Windows.Forms.ComboBox();
            this.buttonCommConnectTiva = new System.Windows.Forms.Button();
            this.serialPortTiva = new System.IO.Ports.SerialPort(this.components);
            this.textBoxTivaDataSent = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxTivaDataSentFreq = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.buttonCommConnectuBlox.Click += new System.EventHandler(this.buttonCommConnectuBlox_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(16, 295);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxuBloxHeading);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBoxuBloxSpeed);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxuBloxSatNr);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBoxuBloxTime);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(326, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 169);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "u-Blox";
            // 
            // textBoxuBloxHeading
            // 
            this.textBoxuBloxHeading.Location = new System.Drawing.Point(87, 130);
            this.textBoxuBloxHeading.Name = "textBoxuBloxHeading";
            this.textBoxuBloxHeading.Size = new System.Drawing.Size(165, 26);
            this.textBoxuBloxHeading.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Heading:";
            // 
            // textBoxuBloxSpeed
            // 
            this.textBoxuBloxSpeed.Location = new System.Drawing.Point(74, 99);
            this.textBoxuBloxSpeed.Name = "textBoxuBloxSpeed";
            this.textBoxuBloxSpeed.Size = new System.Drawing.Size(178, 26);
            this.textBoxuBloxSpeed.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Speed:";
            // 
            // textBoxuBloxSatNr
            // 
            this.textBoxuBloxSatNr.Location = new System.Drawing.Point(74, 67);
            this.textBoxuBloxSatNr.Name = "textBoxuBloxSatNr";
            this.textBoxuBloxSatNr.Size = new System.Drawing.Size(178, 26);
            this.textBoxuBloxSatNr.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Sat#:";
            // 
            // textBoxuBloxTime
            // 
            this.textBoxuBloxTime.Location = new System.Drawing.Point(74, 35);
            this.textBoxuBloxTime.Name = "textBoxuBloxTime";
            this.textBoxuBloxTime.Size = new System.Drawing.Size(178, 26);
            this.textBoxuBloxTime.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Time:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 20);
            this.label11.TabIndex = 12;
            this.label11.Text = "Tiva Board";
            // 
            // comboBoxComPortListTiva
            // 
            this.comboBoxComPortListTiva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComPortListTiva.FormattingEnabled = true;
            this.comboBoxComPortListTiva.Location = new System.Drawing.Point(12, 175);
            this.comboBoxComPortListTiva.Name = "comboBoxComPortListTiva";
            this.comboBoxComPortListTiva.Size = new System.Drawing.Size(188, 28);
            this.comboBoxComPortListTiva.TabIndex = 11;
            // 
            // buttonCommConnectTiva
            // 
            this.buttonCommConnectTiva.Location = new System.Drawing.Point(206, 166);
            this.buttonCommConnectTiva.Name = "buttonCommConnectTiva";
            this.buttonCommConnectTiva.Size = new System.Drawing.Size(86, 45);
            this.buttonCommConnectTiva.TabIndex = 10;
            this.buttonCommConnectTiva.Text = "Connect";
            this.buttonCommConnectTiva.UseVisualStyleBackColor = true;
            this.buttonCommConnectTiva.Click += new System.EventHandler(this.buttonCommConnectTiva_Click);
            // 
            // textBoxTivaDataSent
            // 
            this.textBoxTivaDataSent.Location = new System.Drawing.Point(400, 175);
            this.textBoxTivaDataSent.Name = "textBoxTivaDataSent";
            this.textBoxTivaDataSent.Size = new System.Drawing.Size(178, 26);
            this.textBoxTivaDataSent.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(334, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 20);
            this.label12.TabIndex = 14;
            this.label12.Text = "Sent:";
            // 
            // textBoxTivaDataSentFreq
            // 
            this.textBoxTivaDataSentFreq.Location = new System.Drawing.Point(400, 207);
            this.textBoxTivaDataSentFreq.Name = "textBoxTivaDataSentFreq";
            this.textBoxTivaDataSentFreq.Size = new System.Drawing.Size(178, 26);
            this.textBoxTivaDataSentFreq.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(334, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 20);
            this.label13.TabIndex = 16;
            this.label13.Text = "Freq:";
            // 
            // FormADR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 498);
            this.Controls.Add(this.textBoxTivaDataSentFreq);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxTivaDataSent);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBoxComPortListTiva);
            this.Controls.Add(this.buttonCommConnectTiva);
            this.Controls.Add(this.groupBox2);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxuBloxHeading;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxuBloxSpeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxuBloxSatNr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxuBloxTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxComPortListTiva;
        private System.Windows.Forms.Button buttonCommConnectTiva;
        private System.IO.Ports.SerialPort serialPortTiva;
        private System.Windows.Forms.TextBox textBoxTivaDataSent;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxTivaDataSentFreq;
        private System.Windows.Forms.Label label13;
    }
}

