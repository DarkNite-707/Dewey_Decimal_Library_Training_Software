using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Dewey_Decimal_System_POE_Task1.Forms
{
    public partial class Identifying_Areas_____Question_3 : Form
    {
        private Form Operational_Form;

        public Identifying_Areas_____Question_3()
        {
            InitializeComponent();
        }


        int Score_Count = 0;


        private void EnableControls()
        {
            Call_Numb_Ans_1.ReadOnly = false;
            Call_Numb_Ans_2.ReadOnly = false;
            Call_Numb_Ans_3.ReadOnly = false;
            Call_Numb_Ans_4.ReadOnly = false;
        }

        private void DisableControls()
        {
            Call_Numb_Ans_1.ReadOnly = true;
            Call_Numb_Ans_2.ReadOnly = true;
            Call_Numb_Ans_3.ReadOnly = true;
            Call_Numb_Ans_4.ReadOnly = true;

           
        }

        private void ClearControlsData()
        {
            //clear all controls
            Call_Numb_Ans_1.Text = "";
            Call_Numb_Ans_2.Text = "";
            Call_Numb_Ans_3.Text = "";
            Call_Numb_Ans_4.Text = "";
            Score_Count = 0;
            Score_Tally.Text = null;
            Call_Numb_Ans_1.Focus();
            Wrong_Attempts.DataSource = null;
            Correct_Attempts_Q3.DataSource = null;
        }


        private void Load_Random_Questions()
        {
            //clear all controls



            List<Image> MyImage_Ques = new List<Image>()
                {
                    global::Dewey_Decimal_System_POE_Task1.Properties.Resources.Rnd_Ques_2,
                    global::Dewey_Decimal_System_POE_Task1.Properties.Resources.Rnd_Ques_3,
                    global::Dewey_Decimal_System_POE_Task1.Properties.Resources.Rnd_Ques_1,
                    global::Dewey_Decimal_System_POE_Task1.Properties.Resources.Rnd_Ques_2,
                    global::Dewey_Decimal_System_POE_Task1.Properties.Resources.Rnd_Ques_3,
                    global::Dewey_Decimal_System_POE_Task1.Properties.Resources.Rnd_Ques_1,
                };

            Random _Rnd_Question_Generator = new Random();

            My_Question3_PictureBox1.Image = MyImage_Ques.ElementAt(_Rnd_Question_Generator.Next(MyImage_Ques.Count));
            ;


        }


   
        private void Evalute_Answer__Test()
        {

            List<string> Wrong_Match_Attempts = new List<string>();
            List<string> Correct_Match_Attempts = new List<string>();

            Dictionary<string, string> Call_Numb_Identifier_Dictionary = new Dictionary<string, string>()
            {
                {
                    "000","G"

                } ,
                {
                    "100","E"
                },
                {
                    "200","C"
                },
                {
                    "300","A"
                },
                {
                    "400","I"
                },
                {
                    "500","M"
                },
                {
                    "600","N"
                },

                {
                    "700","L"
                },
                {
                    "800","Q"
                },
                {
                    "900","S"
                }
            };







            // This method was Adapted from Youtube
            // https://www.youtube.com/watch?v=RgL6bozhM-c
            // Sanad Mahfoudh
            //https://www.youtube.com/c/SanadAbdulrahmanBinShuaib

            foreach (Control child in this.Call_Numb_Panel.Controls)
            {

                if (child is TextBox)
                {
                    TextBox textBox = child as TextBox;

                    if (string.IsNullOrEmpty(textBox.Text))
                    {

                        MessageBox.Show("Fields can't be empty, Please");

                        break;
                    }

                }

                foreach (KeyValuePair<string, string> keyValue in Call_Numb_Identifier_Dictionary)
                    {

                    // This method was Adapted from geeksforgeeks
                    //https://www.geeksforgeeks.org/string-split-method-in-c-sharp-with-examples/
                    //geeksforgeeks
                    //https://www.geeksforgeeks.org/string-split-method-in-c-sharp-with-examples/

                    Char Char_Splitter_Symbol = '=';
                    String[] Split_Outcome = child.Text.Split(Char_Splitter_Symbol);
                    if (child is TextBox && Split_Outcome[1] != Split_Outcome[1].ToUpper())
                    {
                       
                            MessageBox.Show("Please make sure your Letter Identifier is in UpperCase");

                        break;
                    }

                    // This method was Adapted from geeksforgeeks
                    //https://www.geeksforgeeks.org/string-split-method-in-c-sharp-with-examples/
                    //geeksforgeeks
                    //https://www.geeksforgeeks.org/string-split-method-in-c-sharp-with-examples/

                    // This statement was Adapted from W3schools
                    //https://www.w3schools.com/cs/cs_conditions.php
                    //W3schools
                    //https://www.w3schools.com/cs/cs_conditions.php

                    Call_Numb_Identifier_Dictionary.TryGetValue(Call_Numb_Identifier_Dictionary.ElementAt(0).Key, out string SV_1).ToString();
                    if (Split_Outcome[0] == keyValue.Key)
                    {
                        if (Split_Outcome[0] == Call_Numb_Identifier_Dictionary.ElementAt(0).Key)
                        {

                            if (SV_1 == Split_Outcome[1])
                            {
                                //MessageBox.Show("000 was matched well");
                                Correct_Match_Attempts.Add("Call Number 000 was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("Call Number 000 was Incorrectly matched  to description!!!!");


                            }


                        }


                    }


                    Call_Numb_Identifier_Dictionary.TryGetValue(Call_Numb_Identifier_Dictionary.ElementAt(1).Key, out string SV_2).ToString();

                    if (Split_Outcome[0] == keyValue.Key)
                    {
                        if (Split_Outcome[0] == Call_Numb_Identifier_Dictionary.ElementAt(1).Key)
                        {

                            if (SV_2 == Split_Outcome[1])
                            {
                                Correct_Match_Attempts.Add("Call Number 100 was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("Call Number 100 was Incorrectly matched  to description!!!!");


                            }


                        }


                    }

                    Call_Numb_Identifier_Dictionary.TryGetValue(Call_Numb_Identifier_Dictionary.ElementAt(2).Key, out string SV_3).ToString();

                    if (Split_Outcome[0] == keyValue.Key)
                    {
                        if (Split_Outcome[0] == Call_Numb_Identifier_Dictionary.ElementAt(2).Key)
                        {

                            if (SV_3 == Split_Outcome[1])
                            {
                                Correct_Match_Attempts.Add("Call Number 200 was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("Call Number 200 was Incorrectly matched  to description!!!!");


                            }


                        }


                    }


                    Call_Numb_Identifier_Dictionary.TryGetValue(Call_Numb_Identifier_Dictionary.ElementAt(3).Key, out string SV_4).ToString();

                    if (Split_Outcome[0] == keyValue.Key)
                    {
                        if (Split_Outcome[0] == Call_Numb_Identifier_Dictionary.ElementAt(3).Key)
                        {

                            if (SV_4 == Split_Outcome[1])
                            {
                                Correct_Match_Attempts.Add("Call Number 300 was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("Call Number 300 was Incorrectly matched  to description!!!!");


                            }


                        }


                    }



                    Call_Numb_Identifier_Dictionary.TryGetValue(Call_Numb_Identifier_Dictionary.ElementAt(4).Key, out string SV_5).ToString();

                    if (Split_Outcome[0] == keyValue.Key)
                    {
                        if (Split_Outcome[0] == Call_Numb_Identifier_Dictionary.ElementAt(4).Key)
                        {

                            if (SV_5 == Split_Outcome[1])
                            {
                                Correct_Match_Attempts.Add("Call Number 400 was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("Call Number 400 was Incorrectly matched  to description!!!!");


                            }


                        }


                    }


                    Call_Numb_Identifier_Dictionary.TryGetValue(Call_Numb_Identifier_Dictionary.ElementAt(5).Key, out string SV_6).ToString();

                    if (Split_Outcome[0] == keyValue.Key)
                    {
                        if (Split_Outcome[0] == Call_Numb_Identifier_Dictionary.ElementAt(5).Key)
                        {

                            if (SV_6 == Split_Outcome[1])
                            {
                                Correct_Match_Attempts.Add("Call Number 500 was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("Call Number 500 was Incorrectly matched  to description!!!!");


                            }


                        }


                    }


                    Call_Numb_Identifier_Dictionary.TryGetValue(Call_Numb_Identifier_Dictionary.ElementAt(6).Key, out string SV_7).ToString();

                    if (Split_Outcome[0] == keyValue.Key)
                    {
                        if (Split_Outcome[0] == Call_Numb_Identifier_Dictionary.ElementAt(6).Key)
                        {

                            if (SV_7 == Split_Outcome[1])
                            {
                                Correct_Match_Attempts.Add("Call Number 600 was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("Call Number 600 was Incorrectly matched  to description!!!!");


                            }


                        }


                    }

                    Call_Numb_Identifier_Dictionary.TryGetValue(Call_Numb_Identifier_Dictionary.ElementAt(7).Key, out string SV_8).ToString();

                    if (Split_Outcome[0] == keyValue.Key)
                    {
                        if (Split_Outcome[0] == Call_Numb_Identifier_Dictionary.ElementAt(7).Key)
                        {

                            if (SV_8 == Split_Outcome[1])
                            {
                                Correct_Match_Attempts.Add("Call Number 700 was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("Call Number 700 was Incorrectly matched  to description!!!!");


                            }


                        }


                    }

                    Call_Numb_Identifier_Dictionary.TryGetValue(Call_Numb_Identifier_Dictionary.ElementAt(8).Key, out string SV_9).ToString();

                    if (Split_Outcome[0] == keyValue.Key)
                    {
                        if (Split_Outcome[0] == Call_Numb_Identifier_Dictionary.ElementAt(8).Key)
                        {

                            if (SV_9 == Split_Outcome[1])
                            {
                                Correct_Match_Attempts.Add("Call Number 800 was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("Call Number 800 was Incorrectly matched  to description!!!!");


                            }


                        }


                    }


                    Call_Numb_Identifier_Dictionary.TryGetValue(Call_Numb_Identifier_Dictionary.ElementAt(9).Key, out string SV_10).ToString();

                    if (Split_Outcome[0] == keyValue.Key)
                    {
                        if (Split_Outcome[0] == Call_Numb_Identifier_Dictionary.ElementAt(9).Key)
                        {

                            if (SV_10 == Split_Outcome[1])
                            {
                                Correct_Match_Attempts.Add("Call Number 900 was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("Call Number 900 was Incorrectly matched  to description!!!!");


                            }


                        }


                    }

                }

            }
            Wrong_Attempts.DataSource = Wrong_Match_Attempts;
            Correct_Attempts_Q3.DataSource = Correct_Match_Attempts;
            DisableControls();

            if (Correct_Match_Attempts.Count() == 4)
            {

                MessageBox.Show("Well Done!!! All Call Numbers were Matched Correctly and Maximum Score Points were Accumilated ");

                Score_Count = +10;

                Score_Tally.Text = Score_Count.ToString();
                Score_Tally.ReadOnly = true;


            }

            if (Correct_Match_Attempts.Count() == 1)
            {
                MessageBox.Show("OOps!, seems like you only matched one correctly,try Again for Perfect score!!");


                Score_Count = 1;

                Score_Tally.Text = Score_Count.ToString();
                Score_Tally.ReadOnly = true;


            }

            if (Correct_Match_Attempts.Count() == 2)
            {
                MessageBox.Show("OOps!, seems like you only matched two correctly,try Again for Perfect score!!");


                Score_Count = 4;

                Score_Tally.Text = Score_Count.ToString();
                Score_Tally.ReadOnly = true;


            }

            if (Correct_Match_Attempts.Count() == 3)
            {

                MessageBox.Show("OOps!, seems like you matched 3 correctly,try Again for Perfect score!!");

                Score_Count = +7;

                Score_Tally.Text = Score_Count.ToString();
                Score_Tally.ReadOnly = true;


            }

        }


        // This Class was Adapted from Youtube
        // https://www.youtube.com/watch?v=BtOEztT1Qzk&t=116s
        // RJ Code Advance EN
        //https://www.youtube.com/c/RJCodeAdvanceEN

        Identifying_Areas_____Question_2 fsOpen_Qs2 = null;
        private void Initialize_Sub_Form_Ques2()
        {
            fsOpen_Qs2 = new Identifying_Areas_____Question_2();


            if (Operational_Form != null)
                Operational_Form.Close();
            Operational_Form = fsOpen_Qs2;
            fsOpen_Qs2.TopLevel = false;
            fsOpen_Qs2.AutoScroll = true;
            fsOpen_Qs2.FormBorderStyle = FormBorderStyle.None;
            fsOpen_Qs2.Dock = DockStyle.Fill;
            fsOpen_Qs2.AutoScaleMode = AutoScaleMode.None;
            this.Question_1_Panel.Controls.Add(fsOpen_Qs2);
            this.Question_1_Panel.Tag = fsOpen_Qs2;
            if (fsOpen_Qs2.Handle.ToInt32() > 0)
            {
                fsOpen_Qs2.Show();
            }
            //fsOpen_Qs2.Show();
            fsOpen_Qs2.BringToFront();
        }



        Identifying_Areas fsOpen = null;

        private void Initialize_Sub_Form()
        {
            fsOpen = new Identifying_Areas();


            if (Operational_Form != null)
                Operational_Form.Close();
            Operational_Form = fsOpen;
            fsOpen.TopLevel = false;
            fsOpen.AutoScroll = true;
            fsOpen.FormBorderStyle = FormBorderStyle.None;
            fsOpen.Dock = DockStyle.Fill;
            fsOpen.AutoScaleMode = AutoScaleMode.None;
            this.Question_1_Panel.Controls.Add(fsOpen);
            this.Question_1_Panel.Tag = fsOpen;
            if (fsOpen.Handle.ToInt32() > 0)
            {
                fsOpen.Show();
            }
            //fsOpen.Show();
            fsOpen.BringToFront();
        }

        Help_Guide HGOpen = null;

        private void Initialize_Help_Form()
        {
            HGOpen = new Help_Guide();


            if (Operational_Form != null)
                Operational_Form.Close();
            Operational_Form = HGOpen;
            HGOpen.TopLevel = false;
            HGOpen.AutoScroll = true;
            HGOpen.FormBorderStyle = FormBorderStyle.None;
            HGOpen.Dock = DockStyle.Fill;
            HGOpen.AutoScaleMode = AutoScaleMode.None;
            this.Question_1_Panel.Controls.Add(HGOpen);
            this.Question_1_Panel.Tag = HGOpen;
            if (HGOpen.Handle.ToInt32() > 0)
            {
                HGOpen.Show();
            }
            //fsOpen.Show();
            HGOpen.BringToFront();
        }


        private void button4_Click(object sender, EventArgs e)
        {

        }

   

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

   

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        
        
       
        private void Identifying_Areas_____Question_3_Load(object sender, EventArgs e)
        {

            Load_Random_Questions();
        }

        private void Call_Numb_Ans_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Evalute_Answer__Test();

        }

        private void Try_Again_Click_1(object sender, EventArgs e)
        {
            ClearControlsData();
            EnableControls();
        }

        private void bck_btn_Q3_Click(object sender, EventArgs e)
        {
            Initialize_Sub_Form();
        }

        private void Alter_Q3_Click(object sender, EventArgs e)
        {
            Initialize_Sub_Form_Ques2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Initialize_Help_Form();
        }
    }
}


namespace CustomExtensions
{
    // Extension methods must be defined in a static class.
    public static class DicExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        public static bool ContainsPair<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
                                                TKey key,
                                                TValue value,
                                                IComparer<TValue> comparer)
        {
            return dictionary.TryGetValue(key, out var found) && comparer.Compare(found, value) == 0;
        }
    }
}



//https://stackoverflow.com/questions/9650355/how-to-check-if-a-key-value-pair-exists-in-a-dictionary

