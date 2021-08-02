
namespace TennisParser
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.matchesListBox = new System.Windows.Forms.ListBox();
            this.startButton = new System.Windows.Forms.Button();
            this.concreteMatchInfoListBox = new System.Windows.Forms.ListBox();
            this.analyzedPointsListBox = new System.Windows.Forms.ListBox();
            this.currentSetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numberSetLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.currentSetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // matchesListBox
            // 
            this.matchesListBox.FormattingEnabled = true;
            this.matchesListBox.ItemHeight = 20;
            this.matchesListBox.Location = new System.Drawing.Point(12, 12);
            this.matchesListBox.Name = "matchesListBox";
            this.matchesListBox.ScrollAlwaysVisible = true;
            this.matchesListBox.Size = new System.Drawing.Size(357, 384);
            this.matchesListBox.TabIndex = 0;
            this.matchesListBox.SelectedIndexChanged += new System.EventHandler(this.matchesListBox_SelectedIndexChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(570, 459);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(94, 29);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // concreteMatchInfoListBox
            // 
            this.concreteMatchInfoListBox.FormattingEnabled = true;
            this.concreteMatchInfoListBox.ItemHeight = 20;
            this.concreteMatchInfoListBox.Location = new System.Drawing.Point(399, 12);
            this.concreteMatchInfoListBox.Name = "concreteMatchInfoListBox";
            this.concreteMatchInfoListBox.Size = new System.Drawing.Size(245, 384);
            this.concreteMatchInfoListBox.TabIndex = 2;
            this.concreteMatchInfoListBox.SelectedIndexChanged += new System.EventHandler(this.concreteMatchInfoListBox_SelectedIndexChanged);
            // 
            // analyzedPointsListBox
            // 
            this.analyzedPointsListBox.FormattingEnabled = true;
            this.analyzedPointsListBox.ItemHeight = 20;
            this.analyzedPointsListBox.Location = new System.Drawing.Point(670, 12);
            this.analyzedPointsListBox.Name = "analyzedPointsListBox";
            this.analyzedPointsListBox.Size = new System.Drawing.Size(84, 324);
            this.analyzedPointsListBox.TabIndex = 3;
            this.analyzedPointsListBox.SelectedIndexChanged += new System.EventHandler(this.analyzedPointsListBox_SelectedIndexChanged);
            // 
            // currentSetNumericUpDown
            // 
            this.currentSetNumericUpDown.Location = new System.Drawing.Point(670, 369);
            this.currentSetNumericUpDown.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.currentSetNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.currentSetNumericUpDown.Name = "currentSetNumericUpDown";
            this.currentSetNumericUpDown.Size = new System.Drawing.Size(84, 27);
            this.currentSetNumericUpDown.TabIndex = 4;
            this.currentSetNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.currentSetNumericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numberSetLabel
            // 
            this.numberSetLabel.AutoSize = true;
            this.numberSetLabel.Location = new System.Drawing.Point(695, 346);
            this.numberSetLabel.Name = "numberSetLabel";
            this.numberSetLabel.Size = new System.Drawing.Size(32, 20);
            this.numberSetLabel.TabIndex = 5;
            this.numberSetLabel.Text = "Сет";
            this.numberSetLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(784, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(917, 374);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1713, 512);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.numberSetLabel);
            this.Controls.Add(this.currentSetNumericUpDown);
            this.Controls.Add(this.analyzedPointsListBox);
            this.Controls.Add(this.concreteMatchInfoListBox);
            this.Controls.Add(this.matchesListBox);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currentSetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox matchesListBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ListBox concreteMatchInfoListBox;
        private System.Windows.Forms.ListBox analyzedPointsListBox;
        private System.Windows.Forms.NumericUpDown currentSetNumericUpDown;
        private System.Windows.Forms.Label numberSetLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

