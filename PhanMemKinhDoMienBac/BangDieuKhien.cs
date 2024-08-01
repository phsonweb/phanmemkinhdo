using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhanMemKinhDoMienBac
{
    public partial class BangDieuKhien : Form
    {
        private bool statusAuto = false;
        private bool statusManual = false;
        private int changeAuto = 0;
        public BangDieuKhien()
        {
            InitializeComponent();
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if(changeAuto == 0)
            {
                changeAuto = 1;
                btnAuto.Text = "Auto";
                btnAuto.BackColor = Color.Blue;
                standardControl1.DiscreteValue1 = true;
                standardControl1.DiscreteValue2 = false;
                standardControl1.DiscreteValue3 = false;
            }
            else if(changeAuto == 1)
            {
                changeAuto = 2;
                btnAuto.Text = "Manual";
                btnAuto.BackColor = Color.DarkCyan;
                standardControl1.DiscreteValue1 = false;
                standardControl1.DiscreteValue2 = true;
                standardControl1.DiscreteValue3 = false;
            }
            else if (changeAuto == 2)

            {
                changeAuto = 0;
                btnAuto.Text = "Local";
                btnAuto.BackColor = Color.Gray;
                standardControl1.DiscreteValue1 = false;
                standardControl1.DiscreteValue2 = false;
                standardControl1.DiscreteValue3 = true;
            }
        }

        private void btnRunAuto_Click(object sender, EventArgs e)
        {
            statusAuto = !statusAuto;
            if(statusAuto ==  false)
            {
                btnRunAuto.Text = "Start";
                btnRunAuto.BackColor = Color.Blue;
                standardControl2.DiscreteValue1 = false;
                standardControl2.DiscreteValue2 = true;
            }
            else
            {
                btnRunAuto.Text = "Stop";
                btnRunAuto.BackColor = Color.WhiteSmoke;
                standardControl2.DiscreteValue1 = true;
                standardControl2.DiscreteValue2 = false;
            }

        }

        private void btnRunManual_Click(object sender, EventArgs e)
        {
            statusManual = !statusManual;
            if (statusManual == false)
            {
                btnRunManual.Text = "Start";
                btnRunManual.BackColor = Color.Blue;
                standardControl3.DiscreteValue1 = false;
                standardControl3.DiscreteValue2 = true;
            }
            else
            {
                btnRunManual.Text = "Stop";
                btnRunManual.BackColor = Color.WhiteSmoke;
                standardControl3.DiscreteValue1 = true;
                standardControl3.DiscreteValue2 = false;
            }
        }

        private void standardControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
