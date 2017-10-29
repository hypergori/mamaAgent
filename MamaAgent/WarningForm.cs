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
    public partial class WarningForm : Form
    {
        public WarningForm()
        {
            InitializeComponent();
        }
        public void SetTimeLbl(DateTime settime)
        {
            TimeSpan ts = settime.Subtract(DateTime.Now);

            lblWarning.Text = String.Format(lblWarning.Text, (Math.Round(ts.TotalSeconds / 60, 0)));

        }

        private void WarningForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
