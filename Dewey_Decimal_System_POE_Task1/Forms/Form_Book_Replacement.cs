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
    public partial class Form_Book_Replacement : Form
    {
        private Button currentButton;
        private Random Random_Colour_Obj;

        public Form_Book_Replacement()
        {
            InitializeComponent();

        }

        int Move_Count = 0; 
        string labelIndex = "";
       int Usr_Score =0;




        // This method was Adapted from Youtube
        // https://www.youtube.com/watch?v=RgL6bozhM-c
        // Sanad Mahfoudh
        //https://www.youtube.com/c/SanadAbdulrahmanBinShuaib

        //Method to Generate random Dewey call numbers on the puzzle Matrix on UI
        private void Call_Number_Shuffler()
        {
            string labelIndex = "";

            List<string> Label_List = new List<string>();

            foreach (Button Dewey_Numb in this.Game_Interface.Controls)
            {
                //loops through the list of randomly generated Dewey Call numbers and populates 
                //buttons on the UI matrix from the list of randomly Generated call numbers
                while (Label_List.Contains(labelIndex))

                    labelIndex = AlphaNumeric_Randomizer();

                Dewey_Numb.Text = (labelIndex == "") ?  "" : labelIndex + "";
                Dewey_Numb.BackColor = (Dewey_Numb.Text == "") ? Color.DarkCyan : Color.FromKnownColor(KnownColor.ControlLight);
                Label_List.Add(labelIndex);
            }

            Move_Count = 0;

            Move_Counter.Text = "Number of Moves :" + Move_Count;

        }



        // This method was Adapted from Youtube
        // https://www.youtube.com/watch?v=RgL6bozhM-c
        // Sanad Mahfoudh
        //https://www.youtube.com/c/SanadAbdulrahmanBinShuaib
        //On click Method to Enable user to rearrange Dewey number Tiles on UI Matrix
        private void Number_Swaper(Object sender, EventArgs e)
        {
            Button Dewey_Button = (Button)sender;
            if (Dewey_Button.Text == "")
                return;
            
            Button CAYN_Button = null;
            foreach (Button bttn in this.Game_Interface.Controls)
            {
                if (bttn.Text == "")
                {
                    CAYN_Button = bttn;
                    break;
                }
            }
            // Nested if logic to operate the difficulty levels
            if (radioButton1.Checked)
            {

                if (Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 1) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 5) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex + 5) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 6) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex + 6) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 8) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex + 8) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 2) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex + 2) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 1) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 3) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex + 3) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 4) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex + 1) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex + 4))
                {
                    CAYN_Button.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                    Dewey_Button.BackColor = Color.DarkCyan;
                    CAYN_Button.Text = Dewey_Button.Text;
                    Dewey_Button.Text = "";
                    Move_Count++;
                    Move_Counter.Text = "Number of Moves :" + Move_Count;
                }

            }
            else if (radioButton2.Checked)
            {

                if (Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 1) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 2) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex + 2) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 1) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 3) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex + 3) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 4) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex + 1) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex + 4))
                {
                    CAYN_Button.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                    Dewey_Button.BackColor = Color.DarkCyan;
                    CAYN_Button.Text = Dewey_Button.Text;
                    Dewey_Button.Text = "";
                    //Blue_Button1.TabIndex = Dewey_Button.TabIndex;
                    Move_Count++;
                    Move_Counter.Text = "Number of Moves :" + Move_Count;
                }


            }
            else if (radioButton3.Checked)
            {



                if (Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 1) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex - 4) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex + 1) ||
                    Dewey_Button.TabIndex == (CAYN_Button.TabIndex + 4))
                {
                    CAYN_Button.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                    Dewey_Button.BackColor = Color.DarkCyan;
                    CAYN_Button.Text = Dewey_Button.Text;
                    Dewey_Button.Text = "";
                    //Blue_Button1.TabIndex = Dewey_Button.TabIndex;
                    Move_Count++;
                    Move_Counter.Text = "Number of Moves :" + Move_Count;
                }


            }





        }


        //Method formulates Alphanumeric string with a decimal figure and 3 lettred string
        public static string AlphaNumeric_Randomizer()
        {

            string D_Numerics = GenerateRandomDecimal(100, 110, 3).ToString();
            string D_Chars = Generate_RandomAlphaNumeric_String();
            string DeweyDecimal = D_Numerics + "." + D_Chars;

            return DeweyDecimal;


        }






        //This function generates a random decimal numbers to be used as Dewey Numbers for the Game

        // This method was Adapted from StackOverflow
        //https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings 
        //nawfal
        //https://stackoverflow.com/users/661933/nawfal
        static System.Random DeweyDecimal_Generator = new System.Random();
        public static decimal GenerateRandomDecimal(int Minimum_Val, int Maximun_Val, int Decimal_Places)
        {
            return System.Math.Round(Convert.ToDecimal(DeweyDecimal_Generator.NextDouble() * (Maximun_Val - Minimum_Val) + Minimum_Val), Decimal_Places);

        }

        //This function generates a random 3 lettered strings to be used as Dewey Numbers for the Game

        static System.Random DeweyString_Generator = new System.Random();
        public static string Generate_RandomAlphaNumeric_String()
        {
            var Alpha_Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Alpha_Chars.Select(c => Alpha_Chars[DeweyString_Generator.Next(Alpha_Chars.Length)]).Take(3).ToArray());
        }


        //Method to caputure a list of inputs from user's attempt to solve the Dewey decimal puzzle
        //inputs from each Tile on the matrix in the UI is stored in a list
        //Then add range is used to permit the list's contents to be stored in the order the user arranged them
        private List<int> UnSorted_list()
        {

            List<int> BaseList = new List<int>();

            BaseList.Add(Convert.ToInt32(button1.Text.Substring(0, 3)));
            BaseList.Add(Convert.ToInt32(button2.Text.Substring(0, 3)));
            BaseList.Add(Convert.ToInt32(button3.Text.Substring(0, 3)));
            BaseList.Add(Convert.ToInt32(button4.Text.Substring(0, 3)));
            BaseList.Add(Convert.ToInt32(button5.Text.Substring(0, 3)));
            BaseList.Add(Convert.ToInt32(button6.Text.Substring(0, 3)));
            BaseList.Add(Convert.ToInt32(button7.Text.Substring(0, 3)));
            BaseList.Add(Convert.ToInt32(button8.Text.Substring(0, 3)));
            BaseList.Add(Convert.ToInt32(button9.Text.Substring(0, 3)));
            BaseList.Add(Convert.ToInt32(button10.Text.Substring(0, 3)));
            BaseList.Add(Convert.ToInt32(button11.Text.Substring(0, 3)));

            List<int> SortedList_Zero = new List<int>();

            SortedList_Zero.AddRange(BaseList);

            return SortedList_Zero;

        }



        //Function withholding Quick Sort algorithm to take and Sort the list containing user's attempt to solve puzzle
        //and returning the sorted list

        // This method was Adapted from GitHub
        //https://gist.github.com/aleksmitov/4614041
        //Aleks Mitov
        //https://gist.github.com/aleksmitov
        private List<int> QuickSorted_List(List<int> SortedList_Zero)
        {
            if (SortedList_Zero.Count <= 1) return SortedList_Zero;
            int pivotPosition = SortedList_Zero.Count / 2;
            int pivotValue = SortedList_Zero[pivotPosition];
            SortedList_Zero.RemoveAt(pivotPosition);
            List<int> Less_Than_List = new List<int>();
            List<int> Greater_Than_List = new List<int>();
            foreach (int item in SortedList_Zero)
            {
                if (item < pivotValue)
                {
                    Less_Than_List.Add(item);
                }
                else
                {
                    Greater_Than_List.Add(item);
                }
            }
            List<int> sorted = QuickSorted_List(Less_Than_List);
            sorted.Add(pivotValue);
            sorted.AddRange(QuickSorted_List(Greater_Than_List));
            return sorted;
        }







        private void Form_Book_Replacement_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Book Replacing Challenge: Try Challenge yourself by beating your own Score and " +
              "completing Puzzle in least amount of moves");

            MessageBox.Show("Pick a Difficulty Level to Enable Assembling, Challenge yourself by completing a new puzzle for Each Difficulty Level");

            MessageBox.Show("Reset Game for a New puzzle After completing a Level");

            Call_Number_Shuffler();
        }

        private void Game_Interface_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Reset_Game_Click(object sender, EventArgs e)
        {

            Call_Number_Shuffler();

        }


        // This method was Adapted/taken from StackOverflow
        // https://stackoverflow.com/questions/52482451/order-alphanumeric-string-numerically-and-then-by-prefix-suffix
        //author
        //author profile hyperlink
        private void Submit_Attempt_Click(object sender, EventArgs e)
        {
            QuickSorted_List(UnSorted_list());
            UnSorted_list();

            // The two list outputs between the sorted one and the unsorted one containing User input from attempt to solve the puzzle
            //Are then compared and if they are a match
            //it means that user managed to successfully sort call numbers in ascending order
            bool List_Equalizer = Enumerable.SequenceEqual(QuickSorted_List(UnSorted_list()), UnSorted_list());
            if (List_Equalizer)
            {
                Usr_Score++;
                Score_Counter.Text = "User Score :" + Usr_Score;
                
                MessageBox.Show("Assembled Correctly in"+""+Move_Count+ "moves" +": You win!!!, Puzzle is in Ascending Order and all books were replaced");

            }
            else
            {
                MessageBox.Show("Assembled Incorrectly: You lose!, press reset game to try again");
            }

        }
    }
}

