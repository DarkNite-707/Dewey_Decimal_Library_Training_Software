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
    public partial class Identifying_Areas : Form
    {

        private Form Operational_Form;

        public Identifying_Areas()
        {
            InitializeComponent();
        }

        private Form1 mainForm = null;
        public Identifying_Areas(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }



        Identifying_Areas____Question_1 fsOpen = null;

        private void Initialize_Sub_Form_Q1()
        {
            fsOpen = new Identifying_Areas____Question_1();


            if (Operational_Form != null)
                Operational_Form.Close();
            Operational_Form = fsOpen;
            fsOpen.TopLevel = false;
            fsOpen.AutoScroll = true;
            fsOpen.FormBorderStyle = FormBorderStyle.None;
            fsOpen.Dock = DockStyle.Fill;
            fsOpen.AutoScaleMode = AutoScaleMode.None;
            this.Identifying_Areas_Interface.Controls.Add(fsOpen);
            this.Identifying_Areas_Interface.Tag = fsOpen;
            if (fsOpen.Handle.ToInt32() > 0)
            {
                fsOpen.Show();
            }
            //fsOpen.Show();
            fsOpen.BringToFront();
        }




        Identifying_Areas_____Question_2 fsOpen_2 = null;

        private void Initialize_Sub_Form_Q2()
        {
            fsOpen_2 = new Identifying_Areas_____Question_2();


            if (Operational_Form != null)
                Operational_Form.Close();
            Operational_Form = fsOpen_2;
            fsOpen_2.TopLevel = false;
            fsOpen_2.AutoScroll = true;
            fsOpen_2.FormBorderStyle = FormBorderStyle.None;
            fsOpen_2.Dock = DockStyle.Fill;
            fsOpen_2.AutoScaleMode = AutoScaleMode.None;
            this.Identifying_Areas_Interface.Controls.Add(fsOpen_2);
            this.Identifying_Areas_Interface.Tag = fsOpen_2;
            if (fsOpen_2.Handle.ToInt32() > 0)
            {
                fsOpen_2.Show();
            }
            //fsOpen_2.Show();
            fsOpen_2.BringToFront();
        }


        Identifying_Areas_____Question_3 fsOpen_3 = null;

        private void Initialize_Sub_Form_Q3()
        {
            fsOpen_3 = new Identifying_Areas_____Question_3();

            if (Operational_Form != null)
                Operational_Form.Close();
            Operational_Form = fsOpen_3;
            fsOpen_3.TopLevel = false;
            fsOpen_3.AutoScroll = true;
            fsOpen_3.FormBorderStyle = FormBorderStyle.None;
            fsOpen_3.Dock = DockStyle.Fill;
            fsOpen_3.AutoScaleMode = AutoScaleMode.None;
            this.Identifying_Areas_Interface.Controls.Add(fsOpen_3);
            this.Identifying_Areas_Interface.Tag = fsOpen_3;
            if (fsOpen_3.Handle.ToInt32() > 0)
            {
                fsOpen_3.Show();
            }
            //fsOpen_3.Show();
            fsOpen_3.BringToFront();
        }




        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Initialize_Sub_Form_Q3();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Initialize_Sub_Form_Q1();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Initialize_Sub_Form_Q2();
        }
    }
}
