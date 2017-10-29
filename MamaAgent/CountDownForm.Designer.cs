namespace MamaAgent
{
    partial class CountDownForm
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
            this.TxtCountDownSec = new System.Windows.Forms.Label();
            this.wkrTimeCountDown = new System.ComponentModel.BackgroundWorker();
            this.lblExplanation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtCountDownSec
            // 
            this.TxtCountDownSec.AutoSize = true;
            this.TxtCountDownSec.Font = new System.Drawing.Font("MS UI Gothic", 250F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtCountDownSec.Location = new System.Drawing.Point(248, 162);
            this.TxtCountDownSec.Name = "TxtCountDownSec";
            this.TxtCountDownSec.Size = new System.Drawing.Size(593, 417);
            this.TxtCountDownSec.TabIndex = 0;
            this.TxtCountDownSec.Text = "10";
            this.TxtCountDownSec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TxtCountDownSec.Click += new System.EventHandler(this.TxtCountDownSec_Click);
            // 
            // wkrTimeCountDown
            // 
            this.wkrTimeCountDown.WorkerReportsProgress = true;
            this.wkrTimeCountDown.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkrTimeCountDown_DoWork);
            this.wkrTimeCountDown.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkrTimeCountDown_RunWorkerCompleted);
            // 
            // lblExplanation
            // 
            this.lblExplanation.AutoSize = true;
            this.lblExplanation.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblExplanation.ForeColor = System.Drawing.Color.Red;
            this.lblExplanation.Location = new System.Drawing.Point(211, 78);
            this.lblExplanation.Name = "lblExplanation";
            this.lblExplanation.Size = new System.Drawing.Size(621, 60);
            this.lblExplanation.TabIndex = 1;
            this.lblExplanation.Text = "Minecraft 終了まで、あと";
            this.lblExplanation.Click += new System.EventHandler(this.lblExplanation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(651, 579);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 60);
            this.label1.TabIndex = 2;
            this.label1.Text = "秒です。";
            // 
            // CountDownForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 701);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblExplanation);
            this.Controls.Add(this.TxtCountDownSec);
            this.Name = "CountDownForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TxtCountDownSec;
        private System.ComponentModel.BackgroundWorker wkrTimeCountDown;
        private System.Windows.Forms.Label lblExplanation;
        private System.Windows.Forms.Label label1;
    }
}