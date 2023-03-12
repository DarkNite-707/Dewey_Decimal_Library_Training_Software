namespace Dewey_Decimal_System_POE_Task1.Forms
{
    partial class Help_Guide
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Exit_solution = new System.Windows.Forms.Button();
            this.Guide_pnl = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Guide_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Exit_solution
            // 
            this.Exit_solution.Location = new System.Drawing.Point(11, 549);
            this.Exit_solution.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Exit_solution.Name = "Exit_solution";
            this.Exit_solution.Size = new System.Drawing.Size(167, 38);
            this.Exit_solution.TabIndex = 1;
            this.Exit_solution.Text = "Back";
            this.Exit_solution.UseVisualStyleBackColor = true;
            this.Exit_solution.Click += new System.EventHandler(this.Exit_solution_Click);
            // 
            // Guide_pnl
            // 
            this.Guide_pnl.Controls.Add(this.pictureBox1);
            this.Guide_pnl.Controls.Add(this.Exit_solution);
            this.Guide_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Guide_pnl.Location = new System.Drawing.Point(0, 0);
            this.Guide_pnl.Name = "Guide_pnl";
            this.Guide_pnl.Size = new System.Drawing.Size(964, 749);
            this.Guide_pnl.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Dewey_Decimal_System_POE_Task1.Properties.Resources.Guide;
            this.pictureBox1.Location = new System.Drawing.Point(11, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(866, 541);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Help_Guide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 749);
            this.Controls.Add(this.Guide_pnl);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Help_Guide";
            this.Text = "Help_Guide";
            this.Guide_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Exit_solution;
        private System.Windows.Forms.Panel Guide_pnl;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}