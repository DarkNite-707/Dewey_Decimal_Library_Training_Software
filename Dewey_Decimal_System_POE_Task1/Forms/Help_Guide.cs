using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dewey_Decimal_System_POE_Task1.Forms
{
    public partial class Help_Guide : Form
    {
        private Form Operational_Form;

        public Help_Guide()
        {
            InitializeComponent();
        }


        Identifying_Areas fsOpen_IA = null;

        private void Initialize_Sub_Form()
        {
            fsOpen_IA = new Identifying_Areas();


            if (Operational_Form != null)
                Operational_Form.Close();
            Operational_Form = fsOpen_IA;
            fsOpen_IA.TopLevel = false;
            fsOpen_IA.AutoScroll = true;
            fsOpen_IA.FormBorderStyle = FormBorderStyle.None;
            fsOpen_IA.Dock = DockStyle.Fill;
            fsOpen_IA.AutoScaleMode = AutoScaleMode.None;
            this.Guide_pnl.Controls.Add(fsOpen_IA);
            this.Guide_pnl.Tag = fsOpen_IA;
            if (fsOpen_IA.Handle.ToInt32() > 0)
            {
                fsOpen_IA.Show();
            }
            fsOpen_IA.BringToFront();
        }


        private void Exit_solution_Click(object sender, EventArgs e)
        {
            Initialize_Sub_Form();
        }
    }
}