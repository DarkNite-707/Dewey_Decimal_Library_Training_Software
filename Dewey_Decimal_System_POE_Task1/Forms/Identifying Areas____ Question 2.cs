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
    public partial class Identifying_Areas_____Question_2 : Form
    {
        private Form Operational_Form;
        public Identifying_Areas_____Question_2()
        {
            InitializeComponent();

            Score_Tally.ReadOnly = true;

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
            Correct_Attempts.DataSource = null;
        }



        private void Validate_Key_Input()
        {
            Dictionary<string, string> Call_Numb_Identifier_Dictionary = new Dictionary<string, string>()
            {
                {
                    //Computer Science info, & General Works
                    "G","000"

                } ,
                {
                    //Philosophy & Psychology
                    "E","100"
                },
                {
                    //Religion
                    "C","200"
                },
                {
                    //Social Sciences
                    "A","300"
                },
                {
                    //Language
                    "I","400"
                },
                {
                    //Science
                    "M","500"
                },
                {
                    //Technology
                    "N","600"
                },

                {
                    //Arts and Recreation
                    "L","700"
                },
                {
                    //Literature
                    "Q","800"
                },
                {
                    //History & Geography
                    "S","900"
                }
            };


            foreach (Control ctrl_child_txt_ in this.Call_Numb_Panel.Controls)
            {
                if (ctrl_child_txt_ is TextBox)
                {
                    TextBox textBox = ctrl_child_txt_ as TextBox;

                    if (string.IsNullOrEmpty(textBox.Text))
                    {

                        MessageBox.Show("Fields can't be empty, Please");

                        break;
                    }

                }

            }

            // This method was Adapted from geeksforgeeks
            //https://www.geeksforgeeks.org/string-split-method-in-c-sharp-with-examples/
            //geeksforgeeks
            //https://www.geeksforgeeks.org/string-split-method-in-c-sharp-with-examples/
            bool MyBool = false;

            foreach (Control ctrl_txt_ in this.Call_Numb_Panel.Controls)
            {
                if (ctrl_txt_ is TextBox)
                {
                    TextBox textBox = ctrl_txt_ as TextBox;

                    if (string.IsNullOrEmpty(textBox.Text) is false)
                    {
                        foreach (KeyValuePair<string, string> K_V_P in Call_Numb_Identifier_Dictionary)
                        {
                            Char Char_Splitter_S = '=';
                            String[] Split_Outcome__ = ctrl_txt_.Text.Split(Char_Splitter_S);
                            //X=700
                            if (Split_Outcome__[0] != K_V_P.Key)
                            {
                                MyBool = true;
                                break;
                            }
                        }
                    }
                   
                }
            }
            
            if (MyBool)
            {

                MessageBox.Show("It seems one or more of your fields contains an invalid Letter identifier(Call Description)");
                MessageBox.Show("Please only utilize letter Identifiers provided in the Question,Try Again!!!");

            }
            else
            {
                MessageBox.Show(" Input is Valid !!!");
            }

        }


        private void Evalute_Answer__Test()
        {

            List<string> Wrong_Match_Attempts = new List<string>();
            List<string> Correct_Match_Attempts = new List<string>();
            Dictionary<string,string> My_Dic_Instance = null;
            Control Ctrl_instance=null; 

            Dictionary<string, string> Call_Numb_Identifier_Dictionary = new Dictionary<string, string>()
            {
                {
                    //Computer Science info, & General Works
                    "G","000"

                } ,
                {
                    //Philosophy & Psychology
                    "E","100"
                },
                {
                    //Religion
                    "C","200"
                },
                {
                    //Social Sciences
                    "A","300"
                },
                {
                    //Language
                    "I","400"
                },
                {
                    //Science
                    "M","500"
                },
                {
                    //Technology
                    "N","600"
                },

                {
                    //Arts and Recreation
                    "L","700"
                },
                {
                    //Literature
                    "Q","800"
                },
                {
                    //History & Geography
                    "S","900"
                }
            };


            foreach (Control child in this.Call_Numb_Panel.Controls)
                {

                foreach (KeyValuePair<string, string> keyValue in Call_Numb_Identifier_Dictionary)
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

                    // This method was Adapted from geeksforgeeks
                    //https://www.geeksforgeeks.org/string-split-method-in-c-sharp-with-examples/
                    //geeksforgeeks
                    //https://www.geeksforgeeks.org/string-split-method-in-c-sharp-with-examples/

                    Char Char_Splitter_Symbol = '=';
                    String[] Split_Outcome = child.Text.Split(Char_Splitter_Symbol);

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
                                Correct_Match_Attempts.Add("'G'- 'Computer Science info, & General Works', was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("'G'- 'Computer Science info, & General Works',was Incorrectly matched !!!!");


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
                                Correct_Match_Attempts.Add("'E'-'Philosophy & Psychology', was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("'E'- 'Philosophy & Psychology',was Incorrectly matched !!!!");


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
                                Correct_Match_Attempts.Add("'C'-'Religion', was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("'C'-'Religion',was Incorrectly matched !!!!");


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
                                Correct_Match_Attempts.Add("'A'-'Social Sciences', was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("'A'-'Social Sciences',was Incorrectly matched !!!!");


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
                                Correct_Match_Attempts.Add("'I'-'Language', was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("'I'-'Language',was Incorrectly matched !!!!");


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
                                Correct_Match_Attempts.Add("'M'-'Science', was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("'M'-'Science',was Incorrectly matched !!!!");


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
                                Correct_Match_Attempts.Add("'N'-'Technology', was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("'N'-'Technology',was Incorrectly matched !!!!");


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
                                Correct_Match_Attempts.Add("'L'-'Arts & Recreation', was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("'L'-'Arts & Recreation',was Incorrectly matched !!!!");


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
                                Correct_Match_Attempts.Add("'Q'-'Literature', was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("'Q'-'Literature',was Incorrectly matched !!!!");


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
                                Correct_Match_Attempts.Add("'S'-'History & Geography', was Correctly matched !!!!");

                            }
                            else
                            {

                                Wrong_Match_Attempts.Add("'S'-'History & Geography',was Incorrectly matched !!!!");


                            }


                        }


                    }

                }

            }
            Wrong_Attempts.DataSource = Wrong_Match_Attempts;
            Correct_Attempts.DataSource = Correct_Match_Attempts;
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
            this.panel2.Controls.Add(fsOpen);
            this.panel2.Tag = fsOpen;
            if (fsOpen.Handle.ToInt32() > 0)
            {
                fsOpen.Show();
            }
            //fsOpen.Show();
            fsOpen.BringToFront();

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
            this.panel2.Controls.Add(fsOpen_IA);
            this.panel2.Tag = fsOpen_IA;
            if (fsOpen_IA.Handle.ToInt32() > 0)
            {
                fsOpen_IA.Show();
            }
            fsOpen_IA.BringToFront();
        }





        private void Load_Random_Questions()
        {
       
            List<Image> MyImage_Ques = new List<Image>()
                {
                    global::Dewey_Decimal_System_POE_Task1.Properties.Resources.Reverse_Q1,
                    global::Dewey_Decimal_System_POE_Task1.Properties.Resources.Reverse_Q3,
                    global::Dewey_Decimal_System_POE_Task1.Properties.Resources.Reverse_Q2,
                    global::Dewey_Decimal_System_POE_Task1.Properties.Resources.Reverse_Q3,
                    global::Dewey_Decimal_System_POE_Task1.Properties.Resources.Reverse_Q1,
                    global::Dewey_Decimal_System_POE_Task1.Properties.Resources.Reverse_Q2,
                };

            Random _Rnd_Question_Generator = new Random();

            My_Question2_PictureBox1.Image = MyImage_Ques.ElementAt(_Rnd_Question_Generator.Next(MyImage_Ques.Count));
;
            ;


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


        private void Identifying_Areas_____Question_2_Load(object sender, EventArgs e)
        {
            Load_Random_Questions();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Evalute_Answer__Test();
        }

        private void Try_Again_Click(object sender, EventArgs e)
        {
            ClearControlsData();
            EnableControls();
        }

        private void Bck_Ques_2_Click(object sender, EventArgs e)
        {
            Initialize_Sub_Form();
        }

        private void Alter_Q2_Bttn_Click(object sender, EventArgs e)
        {
            Initialize_Sub_Form_Q1();
        }

        private void Input_Validation_Click(object sender, EventArgs e)
        {
            Validate_Key_Input();
        }

        private void the_Hlp_gde_Click(object sender, EventArgs e)
        {
            Initialize_Help_Form();
        }
    }
}
