namespace help_me_fractals_
{
    partial class Form2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.roughnessTextBox = new System.Windows.Forms.TextBox();
            this.detailLevelBar = new System.Windows.Forms.TrackBar();
            this.drawButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailLevelBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(652, 375);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // roughnessTextBox
            // 
            this.roughnessTextBox.Location = new System.Drawing.Point(674, 12);
            this.roughnessTextBox.Name = "roughnessTextBox";
            this.roughnessTextBox.Size = new System.Drawing.Size(114, 20);
            this.roughnessTextBox.TabIndex = 1;
            this.roughnessTextBox.Text = "50";
            // 
            // detailLevelBar
            // 
            this.detailLevelBar.Location = new System.Drawing.Point(12, 393);
            this.detailLevelBar.Maximum = 20;
            this.detailLevelBar.Name = "detailLevelBar";
            this.detailLevelBar.Size = new System.Drawing.Size(776, 45);
            this.detailLevelBar.TabIndex = 2;
            this.detailLevelBar.Value = 10;
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(674, 38);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(114, 23);
            this.drawButton.TabIndex = 3;
            this.drawButton.Text = "Построить";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(674, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Звезды";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.detailLevelBar);
            this.Controls.Add(this.roughnessTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailLevelBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox roughnessTextBox;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.TrackBar detailLevelBar;
        private System.Windows.Forms.Button button1;
    }
}