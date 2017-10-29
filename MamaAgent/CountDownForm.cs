using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MamaAgent
{
    public partial class CountDownForm : Form
    {

        public CountDownForm()
        {
            InitializeComponent();
            wkrTimeCountDown.RunWorkerAsync();

        }
        private void wkrTimeCountDown_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            for (int i = 10; (i >= 0); i--)
            {
                // Perform a time consuming operation and report progress.
                System.Threading.Thread.Sleep(1000);
                Invoke(new Action( () => changeLabelTxt(i)));
               // worker.ReportProgress(i * 10);
               // System.Console.WriteLine("Count down {0} ", i);
            }
        }

        private void changeLabelTxt(int i)
        {
            TxtCountDownSec.Text = i + "";
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void TxtCountDownSec_Click(object sender, EventArgs e)
        {

        }

        private void wkrTimeCountDown_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void lblExplanation_Click(object sender, EventArgs e)
        {

        }

    }
}
