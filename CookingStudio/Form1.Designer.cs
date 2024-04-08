namespace CookingStudio
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.spanishLanguageButton = new System.Windows.Forms.Button();
            this.englishLanguageButton = new System.Windows.Forms.Button();
            this.germanLanguageButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.germanLanguageButton);
            this.panel1.Controls.Add(this.englishLanguageButton);
            this.panel1.Controls.Add(this.spanishLanguageButton);
            this.panel1.Location = new System.Drawing.Point(-3, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 156);
            this.panel1.TabIndex = 0;
            // 
            // spanishLanguageButton
            // 
            this.spanishLanguageButton.Location = new System.Drawing.Point(129, 70);
            this.spanishLanguageButton.Name = "spanishLanguageButton";
            this.spanishLanguageButton.Size = new System.Drawing.Size(143, 33);
            this.spanishLanguageButton.TabIndex = 0;
            this.spanishLanguageButton.Text = "Spanish";
            this.spanishLanguageButton.UseVisualStyleBackColor = true;
            // 
            // englishLanguageButton
            // 
            this.englishLanguageButton.Location = new System.Drawing.Point(330, 70);
            this.englishLanguageButton.Name = "englishLanguageButton";
            this.englishLanguageButton.Size = new System.Drawing.Size(143, 33);
            this.englishLanguageButton.TabIndex = 1;
            this.englishLanguageButton.Text = "English";
            this.englishLanguageButton.UseVisualStyleBackColor = true;
            // 
            // germanLanguageButton
            // 
            this.germanLanguageButton.Location = new System.Drawing.Point(526, 70);
            this.germanLanguageButton.Name = "germanLanguageButton";
            this.germanLanguageButton.Size = new System.Drawing.Size(143, 33);
            this.germanLanguageButton.TabIndex = 2;
            this.germanLanguageButton.Text = "German";
            this.germanLanguageButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Cooking Studio on Mallorca";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button germanLanguageButton;
        private System.Windows.Forms.Button englishLanguageButton;
        private System.Windows.Forms.Button spanishLanguageButton;
        private System.Windows.Forms.Label label1;
    }
}

