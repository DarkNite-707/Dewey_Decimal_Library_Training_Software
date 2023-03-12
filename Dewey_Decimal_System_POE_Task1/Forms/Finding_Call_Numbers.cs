using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dewey_Decimal_System_POE_Task1.Forms
{
    public partial class Finding_Call_Numbers : Form
    {
        private Button currentButton;
        private Random Random_Colour_Obj;
        private Color Randomized_Color;
        private int tempIndex;
        private string Button_Input;
        private Form Operational_Form;



        public Finding_Call_Numbers()
        {
            InitializeComponent();
            

        }

        string labelIndex = "";
        int Score_Count = 0;
        Binary_Tree My_Binary_Tree = new Binary_Tree("Root") { };


        //This function Loads Multilevel listed data into memory to be used for the Quiz

        // This method was Adapted from StackOverflow
        //https://stackoverflow.com/questions/39945520/reading-data-from-a-text-file-into-a-struct-with-different-data-types-c-sharp
        //John D
        //https://stackoverflow.com/users/6212666/john-d

        private List<Dewey_Data> Data_Loader() 
        {
            string labelIndex = "";

            var DLL = new List<Dewey_Data>();
            string line;
            string fileName = @"Resources/My_Dewey_Data.txt";
            StreamReader file = new StreamReader(fileName);

            var item = new Dewey_Data();
            //var item = new cars();
            int idx = 0;
            while ((line = file.ReadLine()) != null)
            {
                idx++;
                switch (idx)
                {
                    case 1: item.Top_level = line; break;
                    case 2: item.Second_Tier = line; break;
                    case 3: item.Third_Tier = line; break;
                    case 4: item.Fourth_Tier = line; break;
                    case 5: item.Fifth_Tier = line; break;
                    case 6: item.Sixth_Tier = line; break;
                    case 7: item.Seventh_Tier = line; break;
                    case 8: item.Eigth_Tier = line; break;
                    case 9: item.Nineth_Tier = line; break;
                    case 10: item.Tenth_Tier = line; break;
                }
                if (line == "" && idx > 0)
                {
                    DLL.Add(item);
                    idx = 0;
                    item = new Dewey_Data();  // create new cars item
                }
                if (DLL.Count == 10)
                    break;
            }
            // pick up the last one if not saved
            if (idx > 0)
                DLL.Add(item);

                return DLL;
        }


        //This function Is used to call populate data from memory into the Tree data structure 
        private Binary_Tree Binary_Tree_Loader() 
        {

            foreach (var i in Data_Loader())
            {

                My_Binary_Tree.Add(new Binary_Tree(i.Top_level) 
                {          new Binary_Tree(i.Second_Tier),
                           new Binary_Tree(i.Third_Tier),
                           new Binary_Tree(i.Fourth_Tier),
                           new Binary_Tree(i.Fifth_Tier),
                           new Binary_Tree(i.Sixth_Tier),
                           new Binary_Tree(i.Seventh_Tier),
                           new Binary_Tree(i.Eigth_Tier),
                           new Binary_Tree(i.Nineth_Tier),
                           new Binary_Tree(i.Tenth_Tier), }

                 );

            }


            return My_Binary_Tree ;

        }


        // Data is loaded from the Tree data structure into the respective button objects in the UI
        private void Finding_Call_Numbers_Load(object sender, EventArgs e)
        {
            foreach (var i in Data_Loader())
            {

                My_Binary_Tree.Add(new Binary_Tree(i.Top_level)
                {          new Binary_Tree(i.Second_Tier),
                           new Binary_Tree(i.Third_Tier),
                           new Binary_Tree(i.Fourth_Tier),
                           new Binary_Tree(i.Fifth_Tier),
                           new Binary_Tree(i.Sixth_Tier),
                           new Binary_Tree(i.Seventh_Tier),
                           new Binary_Tree(i.Eigth_Tier),
                           new Binary_Tree(i.Nineth_Tier),
                           new Binary_Tree(i.Tenth_Tier), }

                 );

            }
            //MessageBox.Show("Welcome!, The Main Goal of the Quiz is to Attain a Maximum of 40 points ! " +
            //    "\n This can only be Achieved when All levels of The Game are completed successfully Without Failing any level!" +
            //    "\nIf a Level is Failed you will Loose points and will be promted to restart The Quiz! ");
            Load_TopLevel_Dewey();

        }




        Dictionary<string, string> newDict = new Dictionary<string, string>();

        //This function Materializes Level 1 of the quiz game using data loaded into memory in conjunction with The tree data structure Game
        // This method was Adapted from StackOverflow
        //https://stackoverflow.com/questions/66893/tree-data-structure-in-c-sharp
        //moien
        //https://stackoverflow.com/users/5592276/moien
        private void Load_TopLevel_Dewey()
        {

            Dictionary<string, Dewey_Data> My_Ordering_Structure = new Dictionary<string, Dewey_Data>();
            List<string> Label_List = new List<string>();


            for (int idex = 0; idex < Data_Loader().Count; idex++)
            {
                My_Ordering_Structure.Add(Data_Loader().ElementAt(idex).Third_Tier.ToString(), Data_Loader()[idex]);
            }

             newDict = My_Ordering_Structure.ToDictionary(
            kvp => kvp.Key,
            kvp => kvp.Value.Top_level.ToString());

            var My_Third_Tier = new List<string>();
            var My_Top_Tier = new List<string>();
           

            for (int i = 0; i < My_Binary_Tree.Count; i++)
            {
                //My_Top_Tier.Add(Data_Loader().ElementAt(i).Top_level.ToString());
                My_Top_Tier.Add(My_Binary_Tree.ElementAt(i).Parent.ElementAt(i).ID.ToString());
                
            }

            Random _Rnd_Ansr_Option = new Random();
            Random _Rnd_Ansr_Distiguisher = new Random();
            Random Thee_Rnd_Colour_Option = new Random();

            List<Button> Bttn_List = new List<Button>();


            foreach (Button Dewey_Numb in this.Quiz_Game_TopLevel_Opts.Controls)
            {

                //loops through the list of randomly generated Dewey Call numbers and populates 
                //buttons on the UI matrix from the list of randomly Generated call numbers
                Bttn_List.Add(Dewey_Numb);
                My_Loop:
                labelIndex = My_Top_Tier.ElementAt(_Rnd_Ansr_Option.Next(My_Top_Tier.Count)).ToString();
                Load_Button_Theme();

                foreach (Button Dewey_item in this.Quiz_Game_TopLevel_Opts.Controls)
                {
                    if (labelIndex == Dewey_item.Text)
                    {
                        goto My_Loop;
                    }

                }
                Dewey_Numb.Text = labelIndex;

                Label_List.Add(Dewey_Numb.Text);

            }

            
                int Bttn_List_idx = Thee_Rnd_Colour_Option.Next(Bttn_List.Count);

                Button AnsBttn = Bttn_List.ElementAt(Thee_Rnd_Colour_Option.Next(Bttn_List.Count));

                //AnsBttn.Text.
                Random Thee_Rnd_Ansr_Option = new Random();
                int bttn_Label_index = Thee_Rnd_Ansr_Option.Next(newDict.Count);
                string Answer = newDict.Values.ElementAt(bttn_Label_index).ToString();
                button7.Text = newDict.Keys.ElementAt(bttn_Label_index).ToString();

            for (int i = 0; i < Label_List.Count; i++)
            {

                if (!Label_List.Contains(Answer))
                {
                    AnsBttn.Text = newDict.Values.ElementAt(bttn_Label_index).ToString();
                }
            }

        }


        //This function Materializes Level 2 of the quiz game using data loaded into memory in conjunction with The tree data structure Game

        private void Load_Second_Level_Dewey()
        {
            List<string> Label_List = new List<string>();

            Dictionary<string, Dewey_Data> My_Ordering_Structure = new Dictionary<string, Dewey_Data>();

            for (int idex = 0; idex < Data_Loader().Count; idex++)
            {
                My_Ordering_Structure.Add(Data_Loader().ElementAt(idex).Third_Tier.ToString(), Data_Loader()[idex]);
            }

            newDict = My_Ordering_Structure.ToDictionary(
           kvp => kvp.Key,
           kvp => kvp.Value.Second_Tier.ToString());
          
            var My_Third_Tier = new List<string>();
            var My_Second_Tier = new List<string>();

            for (int i = 0; i < Data_Loader().Count; i++)
            {
                My_Second_Tier.Add(Data_Loader().ElementAt(i).Second_Tier.ToString());
            }

            Random _Rnd_Ansr_Option = new Random();
            Random _Rnd_Ansr_Distiguisher = new Random();
            Random Thee_Rnd_Colour_Option = new Random();

            List<Button> Bttn_List = new List<Button>();


            foreach (Button Dewey_Numb in this.Quiz_Game_TopLevel_Opts.Controls)
            {

                //loops through the list of randomly generated Dewey Call numbers and populates 
                //buttons on the UI matrix from the list of randomly Generated call numbers
                Bttn_List.Add(Dewey_Numb);
            My_Loop:
                labelIndex = My_Second_Tier.ElementAt(_Rnd_Ansr_Option.Next(My_Second_Tier.Count)).ToString();
                Load_Button_Theme();

                foreach (Button Dewey_item in this.Quiz_Game_TopLevel_Opts.Controls)
                {
                    if (labelIndex == Dewey_item.Text)
                    {
                        goto My_Loop;
                    }

                }
                Dewey_Numb.Text = labelIndex;

                Label_List.Add(Dewey_Numb.Text);

            }


            int Bttn_List_idx = Thee_Rnd_Colour_Option.Next(Bttn_List.Count);

            Button AnsBttn = Bttn_List.ElementAt(Thee_Rnd_Colour_Option.Next(Bttn_List.Count));

            //AnsBttn.Text.
            Random Thee_Rnd_Ansr_Option = new Random();
            int bttn_Label_index = Thee_Rnd_Ansr_Option.Next(newDict.Count);
            string Answer = newDict.Values.ElementAt(bttn_Label_index).ToString();
            button7.Text = newDict.Keys.ElementAt(bttn_Label_index).ToString();

            for (int i = 0; i < Label_List.Count; i++)
            {

                if (!Label_List.Contains(Answer))
                {
                    AnsBttn.Text = newDict.Values.ElementAt(bttn_Label_index).ToString();
                }
            }

        }



        //This function Materializes Level 3 of the quiz game using data loaded into memory in conjunction with The tree data structure Game

        private void Load_Third_Level_Dewey()
        {
            Dictionary<string, Dewey_Data> My_Ordering_Structure = new Dictionary<string, Dewey_Data>();
            List<string> Label_List = new List<string>();


            for (int idex = 0; idex < Data_Loader().Count; idex++)
            {
                My_Ordering_Structure.Add(Data_Loader().ElementAt(idex).Third_Tier.ToString(), Data_Loader()[idex]);
            }

            newDict = My_Ordering_Structure.ToDictionary(
           kvp => kvp.Key,
           kvp => kvp.Value.Third_Tier.ToString());
           
            var My_Third_Tier = new List<string>();
            var My_Third_Tier_lst = new List<string>();

            for (int i = 0; i < Data_Loader().Count; i++)
            {
                My_Third_Tier_lst.Add(Data_Loader().ElementAt(i).Third_Tier.ToString());
            }




            Random _Rnd_Ansr_Option = new Random();
            Random _Rnd_Ansr_Distiguisher = new Random();
            Random Thee_Rnd_Colour_Option = new Random();

            List<Button> Bttn_List = new List<Button>();


            foreach (Button Dewey_Numb in this.Quiz_Game_TopLevel_Opts.Controls)
            {

                //loops through the list of randomly generated Dewey Call numbers and populates 
                //buttons on the UI matrix from the list of randomly Generated call numbers
                Bttn_List.Add(Dewey_Numb);
            My_Loop:
                labelIndex = My_Third_Tier_lst.ElementAt(_Rnd_Ansr_Option.Next(My_Third_Tier_lst.Count)).ToString();
                Load_Button_Theme();

                foreach (Button Dewey_item in this.Quiz_Game_TopLevel_Opts.Controls)
                {
                    if (labelIndex == Dewey_item.Text)
                    {
                        goto My_Loop;
                    }

                }
                Dewey_Numb.Text = labelIndex;

                Label_List.Add(Dewey_Numb.Text);

            }


            int Bttn_List_idx = Thee_Rnd_Colour_Option.Next(Bttn_List.Count);

            Button AnsBttn = Bttn_List.ElementAt(Thee_Rnd_Colour_Option.Next(Bttn_List.Count));

            //AnsBttn.Text.
            Random Thee_Rnd_Ansr_Option = new Random();
            int bttn_Label_index = Thee_Rnd_Ansr_Option.Next(newDict.Count);
            string Answer = newDict.Values.ElementAt(bttn_Label_index).ToString();
            button7.Text = newDict.Keys.ElementAt(bttn_Label_index).ToString();

            for (int i = 0; i < Label_List.Count; i++)
            {

                if (!Label_List.Contains(Answer))
                {
                    AnsBttn.Text = newDict.Values.ElementAt(bttn_Label_index).ToString();
                }
            }

        }


        //This function Materializes Level 4 of the quiz game using data loaded into memory in conjunction with The tree data structure Game
        private void Load_Fourth_Level_Dewey() 
        {
            Dictionary<string, Dewey_Data> My_Ordering_Structure = new Dictionary<string, Dewey_Data>();
            List<string> Label_List = new List<string>();


            for (int idex = 0; idex < Data_Loader().Count; idex++)
            {
                My_Ordering_Structure.Add(Data_Loader().ElementAt(idex).Third_Tier.ToString(), Data_Loader()[idex]);
            }

            newDict = My_Ordering_Structure.ToDictionary(
           kvp => kvp.Key,
           kvp => kvp.Value.Fourth_Tier.ToString());
        
            var My_Third_Tier = new List<string>();
            var My_Fourth_Tier = new List<string>();

            for (int i = 0; i < Data_Loader().Count; i++)
            {
                My_Fourth_Tier.Add(Data_Loader().ElementAt(i).Fourth_Tier.ToString());
            }

            Random _Rnd_Ansr_Option = new Random();
            Random _Rnd_Ansr_Distiguisher = new Random();
            Random Thee_Rnd_Colour_Option = new Random();

            List<Button> Bttn_List = new List<Button>();


            foreach (Button Dewey_Numb in this.Quiz_Game_TopLevel_Opts.Controls)
            {

                //loops through the list of randomly generated Dewey Call numbers and populates 
                //buttons on the UI matrix from the list of randomly Generated call numbers
                Bttn_List.Add(Dewey_Numb);
            My_Loop:
                labelIndex = My_Fourth_Tier.ElementAt(_Rnd_Ansr_Option.Next(My_Fourth_Tier.Count)).ToString();
                Load_Button_Theme();

                foreach (Button Dewey_item in this.Quiz_Game_TopLevel_Opts.Controls)
                {
                    if (labelIndex == Dewey_item.Text)
                    {
                        goto My_Loop;
                    }

                }
                Dewey_Numb.Text = labelIndex;

                Label_List.Add(Dewey_Numb.Text);

            }


            int Bttn_List_idx = Thee_Rnd_Colour_Option.Next(Bttn_List.Count);

            Button AnsBttn = Bttn_List.ElementAt(Thee_Rnd_Colour_Option.Next(Bttn_List.Count));

            //AnsBttn.Text.
            Random Thee_Rnd_Ansr_Option = new Random();
            int bttn_Label_index = Thee_Rnd_Ansr_Option.Next(newDict.Count);
            string Answer = newDict.Values.ElementAt(bttn_Label_index).ToString();
            button7.Text = newDict.Keys.ElementAt(bttn_Label_index).ToString();

            for (int i = 0; i < Label_List.Count; i++)
            {

                if (!Label_List.Contains(Answer))
                {
                    AnsBttn.Text = newDict.Values.ElementAt(bttn_Label_index).ToString();
                }
            }

        }


        private void DDS_LBL_Click(object sender, EventArgs e)
        {

        }

        int B1_Click_Count = 0;
        int Correct_Ques_Count = 0;

        private void button1_Click(object sender, EventArgs e)
        {

            B1_Click_Count++;
            bool My_Correct_Ques_Bool = false;

            foreach (KeyValuePair<string, string> Call_Numb_Identifier_Dictionary in newDict)
            {
                newDict.TryGetValue(button7.Text, out string SV_1).ToString();

                if (button7.Text == Call_Numb_Identifier_Dictionary.Key)
                {
                    if (My_Ans_B1.Text == SV_1)
                    {
                        Correct_Ques_Count++;
                        My_Correct_Ques_Bool = true;
                        break;
                    }
                    else
                    {
                        break;
                    }

                }

            }

            if ( My_Correct_Ques_Bool is true)
            {
                switch (Correct_Ques_Count)
                {
                    case 1:
                        MessageBox.Show("Well Done for Completing Level 1, You've earned your level 1 points !!!!");
                        Score_Count = +10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show("Now Begin Level 2!!!!");
                        Load_Second_Level_Dewey();
                        break;

                    case 2:
                        MessageBox.Show("Well Done for Completing Level 2, You've earned your level 2 points !!!!");
                        Score_Count = Score_Count + 10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show("Now Begin Level 3!!!!");
                        Load_Third_Level_Dewey();
                        break;

                    case 3:
                        MessageBox.Show("Well Done for Completing Level 3, You've earned your level 3 points !!!!");
                        Score_Count = Score_Count + 10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show("Now Begin Level 4!!!!");
                        Load_Fourth_Level_Dewey();
                        break;

                    case 4:
                        MessageBox.Show("Well Done for Completing Level 4, You've earned your level 4 points !!!!");
                        Score_Count = Score_Count + 10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show(" Congrats All Levels have been Completed Successfully ,And Maximum points were Achieved!!!!");
                        MessageBox.Show(" Restart Quiz for a fresh challenge Now!!!!");
                        Correct_Ques_Count = 0;
                        Initialize_FindingCallNumbers_();
                        //Finding_Call_Numbers finding_Call_Numbers = new Finding_Call_Numbers() { };

                        //finding_Call_Numbers.InitializeComponent();
                        //finding_Call_Numbers.Show();


                        break;

                        //break;
                }

            }
            else
            {
                MessageBox.Show("Opps Seems like your attempt is incorrect!!!");
                Score_Count = 0;
                Quiz_Tally.Text = Score_Count.ToString();
                Quiz_Tally.ReadOnly = true;
                Correct_Ques_Count = 0;
                MessageBox.Show("Your points have been depleted, Begin from Level 1 Again!!!");
                Initialize_FindingCallNumbers_();
            }


        }


        int B2_Click_Count = 0;
        private void My_Ans_B2_Click(object sender, EventArgs e)
        {

            B2_Click_Count++;
            bool My_Correct_Ques_Bool = false;

            foreach (KeyValuePair<string, string> Call_Numb_Identifier_Dictionary in newDict)
            {
                newDict.TryGetValue(button7.Text, out string SV_1).ToString();

                if (button7.Text == Call_Numb_Identifier_Dictionary.Key)
                {
                    if (My_Ans_B2.Text == SV_1)
                    {
                        Correct_Ques_Count++;
                        My_Correct_Ques_Bool = true;
                        break;
                    }
                    else
                    {
                        break;
                    }

                }

            }

            if ( My_Correct_Ques_Bool is true)
            {
                switch (Correct_Ques_Count)
                {
                    case 1:
                        MessageBox.Show("Well Done for Completing Level 1, You've earned your level 1 points !!!!");
                        Score_Count = +10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show("Now Begin Level 2!!!!");
                        Load_Second_Level_Dewey();
                        break;

                    case 2:
                        MessageBox.Show("Well Done for Completing Level 2, You've earned your level 2 points !!!!");
                        Score_Count = Score_Count + 10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show("Now Begin Level 3!!!!");
                        Load_Third_Level_Dewey();
                        break;

                    case 3:
                        MessageBox.Show("Well Done for Completing Level 3, You've earned your level 3 points !!!!");
                        Score_Count = Score_Count + 10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show("Now Begin Level 4!!!!");
                        Load_Fourth_Level_Dewey();
                        break;

                    case 4:
                        MessageBox.Show("Well Done for Completing Level 4, You've earned your level 4 points !!!!");
                        Score_Count = Score_Count + 10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show(" Congrats All Levels have been Completed Successfully ,And Maximum points were Achieved!!!!");
                        MessageBox.Show(" Restart Quiz for a fresh challenge Now!!!!");
                        Correct_Ques_Count = 0;
                        Initialize_FindingCallNumbers_();
                        //Finding_Call_Numbers finding_Call_Numbers = new Finding_Call_Numbers() { };

                        //finding_Call_Numbers.InitializeComponent();
                        //finding_Call_Numbers.Show();

                        break;

                        //break;
                }

            }
            else
            {
                MessageBox.Show("Opps Seems like your attempt is incorrect!!!");
                Score_Count = 0;
                Quiz_Tally.Text = Score_Count.ToString();
                Quiz_Tally.ReadOnly = true;
                Correct_Ques_Count = 0;
                MessageBox.Show("Your points have been depleted, Begin from Level 1 Again!!!");
                Initialize_FindingCallNumbers_();
            }

        }



        int B3_Click_Count = 0;
        private void My_Ans_B3_Click(object sender, EventArgs e)
        {
            B3_Click_Count++;
            bool My_Correct_Ques_Bool = false;

            foreach (KeyValuePair<string, string> Call_Numb_Identifier_Dictionary in newDict)
            {
                newDict.TryGetValue(button7.Text, out string SV_1).ToString();

                if (button7.Text == Call_Numb_Identifier_Dictionary.Key)
                {
                    if (My_Ans_B3.Text == SV_1)
                    {
                        Correct_Ques_Count++;
                        My_Correct_Ques_Bool = true;
                        break;
                    }
                    else
                    {
                        break;
                    }

                }

            }

            if ( My_Correct_Ques_Bool is true)
            {
                switch (Correct_Ques_Count)
                {
                    case 1:
                        MessageBox.Show("Well Done for Completing Level 1, You've earned your level 1 points !!!!");
                        Score_Count = +10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show("Now Begin Level 2!!!!");
                        Load_Second_Level_Dewey();
                        break;

                    case 2:
                        MessageBox.Show("Well Done for Completing Level 2, You've earned your level 2 points !!!!");
                        Score_Count = Score_Count + 10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show("Now Begin Level 3!!!!"); Load_Third_Level_Dewey();
                        break;

                    case 3:
                        MessageBox.Show("Well Done for Completing Level 3, You've earned your level 3 points !!!!");
                        Score_Count = Score_Count + 10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show("Now Begin Level 4!!!!");
                        Load_Fourth_Level_Dewey();
                        break;

                    case 4:
                        MessageBox.Show("Well Done for Completing Level 4, You've earned your level 4 points !!!!");
                        Score_Count = Score_Count + 10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show(" Congrats All Levels have been Completed Successfully ,And Maximum points were Achieved!!!!");
                        MessageBox.Show(" Restart Quiz for a fresh challenge Now!!!!");
                        Correct_Ques_Count = 0;
                        Initialize_FindingCallNumbers_();
                        //Finding_Call_Numbers finding_Call_Numbers = new Finding_Call_Numbers() { };

                        //finding_Call_Numbers.InitializeComponent();
                        //finding_Call_Numbers.Show();

                        break;

                        //break;
                }

            }
            else
            {

                MessageBox.Show("Opps Seems like your attempt is incorrect!!!");
                Score_Count = 0;
                Quiz_Tally.Text = Score_Count.ToString();
                Quiz_Tally.ReadOnly = true;
                Correct_Ques_Count = 0;
                MessageBox.Show("Your points have been depleted, Begin from Level 1 Again!!!");
                Initialize_FindingCallNumbers_();
            }

        }

        int B4_Click_Count = 0;

        private void My_Ans_B4_Click(object sender, EventArgs e)
        {

            B4_Click_Count++;
            bool My_Correct_Ques_Bool = false;

            foreach (KeyValuePair<string, string> Call_Numb_Identifier_Dictionary in newDict)
            {
                newDict.TryGetValue(button7.Text, out string SV_1).ToString();

                if (button7.Text == Call_Numb_Identifier_Dictionary.Key)
                {
                    if (My_Ans_B4.Text == SV_1)
                    {
                        Correct_Ques_Count++;
                        My_Correct_Ques_Bool = true;
                        break;
                    }
                    else
                    {
                        break;
                    }

                }

            }

            if (My_Correct_Ques_Bool is true)
            {
                switch (Correct_Ques_Count)
                {
                    case 1:
                       MessageBox.Show("Well Done for Completing Level 1, You've earned your level 1 points !!!!");
                        Score_Count =+10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show("Now Begin Level 2!!!!");
                        Load_Second_Level_Dewey();
                        break;

                    case 2:
                        MessageBox.Show("Well Done for Completing Level 2, You've earned your level 2 points !!!!");
                        Score_Count = Score_Count + 10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show("Now Begin Level 3!!!!");
                        Load_Third_Level_Dewey();
                        break ;

                    case 3:
                        MessageBox.Show("Well Done for Completing Level 3, You've earned your level 3 points !!!!");
                        Score_Count = Score_Count + 10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show("Now Begin Level 4!!!!");
                        Load_Fourth_Level_Dewey();
                        break;

                    case 4:
                        MessageBox.Show("Well Done for Completing Level 4, You've earned your level 4 points !!!!");
                        Score_Count = Score_Count + 10;
                        Quiz_Tally.Text = Score_Count.ToString();
                        Quiz_Tally.ReadOnly = true;
                        MessageBox.Show(" Congrats All Levels have been Completed Successfully ,And Maximum points were Achieved!!!!");
                        MessageBox.Show(" Restart Quiz for a fresh challenge Now!!!!");
                        Correct_Ques_Count = 0;
                        Initialize_FindingCallNumbers_();
                        //Finding_Call_Numbers finding_Call_Numbers = new Finding_Call_Numbers() { };
                        //finding_Call_Numbers.InitializeComponent();
                        //finding_Call_Numbers.Show();
                        break ;
                       

                        //break;
                }

            }
            else 
            {

                MessageBox.Show("Opps Seems like your attempt is incorrect!!!");
                Score_Count = 0;
                Quiz_Tally.Text = Score_Count.ToString();
                Quiz_Tally.ReadOnly = true;
                Correct_Ques_Count = 0;
                MessageBox.Show("Your points have been depleted, Begin from Level 1 Again!!!");
                Initialize_FindingCallNumbers_();
            }

        }


        Finding_Call_Numbers fsOpen = null;
        private void Initialize_FindingCallNumbers_()
        {
           var fsOpen_IA = new Finding_Call_Numbers();


            if (Operational_Form != null)
                Operational_Form.Close();
            Operational_Form = fsOpen_IA;
            fsOpen_IA.TopLevel = false;
            fsOpen_IA.AutoScroll = true;
            fsOpen_IA.FormBorderStyle = FormBorderStyle.None;
            fsOpen_IA.Dock = DockStyle.Fill;
            fsOpen_IA.AutoScaleMode = AutoScaleMode.None;
            this.Thee_Quiz_Game_Pnl.Controls.Add(fsOpen_IA);
            this.Thee_Quiz_Game_Pnl.Tag = fsOpen_IA;
            if (fsOpen_IA.Handle.ToInt32() > 0)
            {
                fsOpen_IA.Show();
            
            }
            fsOpen_IA.BringToFront();

        }



        // This Method was Adapted from Youtube
        // https://www.youtube.com/watch?v=BtOEztT1Qzk&t=116s
        // RJ Code Advance EN
        //https://www.youtube.com/c/RJCodeAdvanceEN
        private void Load_Button_Theme()
        {

            List<string> MyImage_Ques = new List<string>()
                {
                                                                    "#3F51B5",
                                                                    "#009688",
                                                                    "#FF5722",
                                                                    "#607D8B",
                                                                    "#FF9800",
                                                                    "#9C27B0",
                                                                    "#2196F3",
                                                                    "#EA676C",
                                                                    "#E41A4A",
                                                                    "#5978BB",
                                                                    "#018790",
                                                                    "#0E3441",
                                                                    "#00B0AD",
                                                                    "#721D47",
                                                                    "#EA4833",
                                                                    "#EF937E",
                                                                    "#F37521",
                                                                    "#A12059",
                                                                    "#126881",
                                                                    "#8BC240",
                                                                    "#364D5B",
                                                                    "#C7DC5B",
                                                                    "#0094BC",
                                                                    "#E4126B",
                                                                    "#43B76E",
                                                                    "#7BCFE9",
                                                                    "#B71C46"
                };

            Random _Rnd_Question_Generator = new Random();

            foreach (Button Dewey_Numb in this.Quiz_Game_TopLevel_Opts.Controls)
            {

                Dewey_Numb.BackColor = ColorTranslator.FromHtml(MyImage_Ques.ElementAt(_Rnd_Question_Generator.Next(MyImage_Ques.Count)));

            }

            foreach (Button Dewey_Numb in this.Third_Level__Dewey_CN.Controls)
            {

                Dewey_Numb.BackColor = ColorTranslator.FromHtml(MyImage_Ques.ElementAt(_Rnd_Question_Generator.Next(MyImage_Ques.Count)));

            }


        }
    }
}






