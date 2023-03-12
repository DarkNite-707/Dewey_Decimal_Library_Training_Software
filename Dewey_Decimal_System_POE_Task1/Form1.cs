using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dewey_Decimal_System_POE_Task1.Forms;

namespace Dewey_Decimal_System_POE_Task1
{
    public partial class Form1 : Form
    {

        //Fields
        private Button currentButton;
        private Random Random_Colour_Obj;
        private int tempIndex;
        private Form Operational_Form;


        public Form1()
        {
            InitializeComponent();
            Random_Colour_Obj = new Random();


        }


        // This Method was Adapted from Youtube
        // https://www.youtube.com/watch?v=BtOEztT1Qzk&t=116s
        // RJ Code Advance EN
        //https://www.youtube.com/c/RJCodeAdvanceEN
        private Color Theme_Selector()
        {
            int index = Random_Colour_Obj.Next(ThemeClass.Theme_Colours.Count);
            while (tempIndex == index)
            {
                index = Random_Colour_Obj.Next(ThemeClass.Theme_Colours.Count);
            }
            tempIndex = index;
            string color = ThemeClass.Theme_Colours[index];
            return ColorTranslator.FromHtml(color);
        }


        // This Class was Adapted from Youtube
        // https://www.youtube.com/watch?v=BtOEztT1Qzk&t=116s
        // RJ Code Advance EN
        //https://www.youtube.com/c/RJCodeAdvanceEN
        private void Button_Activatior(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    Button_Deactivation();
                    Color MyButton_Colour = Theme_Selector();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = MyButton_Colour;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Impact", 12.5F, System.Drawing.FontStyle.Italic);
                    ImageAsset.BackColor = MyButton_Colour;
                    Titile_Bar.BackColor = ThemeClass.Brightness_Controller(MyButton_Colour, -0.3);
                    //ThemeColor.PrimaryColor = color;
                    //ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //btnCloseChildForm.Visible = true;
                }

              
            }
        }


        private void Button_Deactivation()
        {
            foreach (Control Prior_Btn in GameMenu.Controls)
            {
                if (Prior_Btn.GetType() == typeof(Button))
                {
                    Prior_Btn.BackColor = Color.FromArgb(64, 64, 64);
                    Prior_Btn.ForeColor = Color.Gainsboro;
                    Prior_Btn.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Italic);
                }
            }
        }


        // This Class was Adapted from Youtube
        // https://www.youtube.com/watch?v=BtOEztT1Qzk&t=116s
        // RJ Code Advance EN
        //https://www.youtube.com/c/RJCodeAdvanceEN
        private void Initialize_Sub_Form(Form Sub_Form, object btnSender)
        {
            if (Operational_Form != null)
                Operational_Form.Close();
            Button_Activatior(btnSender);
            Operational_Form = Sub_Form;
            Sub_Form.TopLevel = false;
            Sub_Form.FormBorderStyle = FormBorderStyle.None;
            Sub_Form.Dock = DockStyle.Fill;
            this.HME_Content.Controls.Add(Sub_Form);
            this.HME_Content.Tag = Sub_Form;
            Sub_Form.BringToFront();
            Sub_Form.Show();
            HME_LBL.Text = Sub_Form.Text;
        }


        private void Replace_Books_Click(object sender, EventArgs e)
        {


            Initialize_Sub_Form(new Forms.Form_Book_Replacement(), sender);

        }

        private void Identifying_Genres_Click(object sender, EventArgs e)
        {
            //Button_Activatior(sender);

            Initialize_Sub_Form(new Forms.Identifying_Areas(), sender);


        }

        private void Call_Number_Finder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome!, The Main Goal of the Quiz is to Attain a Maximum of 40 points ! " +
              "\n This can only be Achieved when All levels of The Game are completed successfully Without Failing any level!" +
              "\nIf a Level is Failed you will Loose points and will be promted to restart The Quiz! ");
            Initialize_Sub_Form(new Forms.Finding_Call_Numbers(), sender);

        }
        private void  button3_Click (object sender, EventArgs e)
        {
            Button_Activatior(sender);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.panel1.AutoScroll = true;
        }
    }
}
