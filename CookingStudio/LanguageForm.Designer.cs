namespace CookingStudio
{
    partial class LanguageForm
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
            this.germanLanguageButton = new System.Windows.Forms.Button();
            this.englishLanguageButton = new System.Windows.Forms.Button();
            this.spanishLanguageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // germanLanguageButton
            // 
            this.germanLanguageButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.germanLanguageButton.Location = new System.Drawing.Point(530, 57);
            this.germanLanguageButton.Name = "germanLanguageButton";
            this.germanLanguageButton.Size = new System.Drawing.Size(143, 33);
            this.germanLanguageButton.TabIndex = 5;
            this.germanLanguageButton.Text = "German";
            this.germanLanguageButton.UseVisualStyleBackColor = true;
            // 
            // englishLanguageButton
            // 
            this.englishLanguageButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.englishLanguageButton.Location = new System.Drawing.Point(310, 57);
            this.englishLanguageButton.Name = "englishLanguageButton";
            this.englishLanguageButton.Size = new System.Drawing.Size(143, 33);
            this.englishLanguageButton.TabIndex = 4;
            this.englishLanguageButton.Text = "English";
            this.englishLanguageButton.UseVisualStyleBackColor = true;
            this.englishLanguageButton.Click += new System.EventHandler(this.englishLanguageButton_Click_1);
            // 
            // spanishLanguageButton
            // 
            this.spanishLanguageButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spanishLanguageButton.Location = new System.Drawing.Point(99, 57);
            this.spanishLanguageButton.Name = "spanishLanguageButton";
            this.spanishLanguageButton.Size = new System.Drawing.Size(143, 33);
            this.spanishLanguageButton.TabIndex = 3;
            this.spanishLanguageButton.Text = "Spanish";
            this.spanishLanguageButton.UseVisualStyleBackColor = true;
            // 
            // LanguageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 146);
            this.Controls.Add(this.germanLanguageButton);
            this.Controls.Add(this.englishLanguageButton);
            this.Controls.Add(this.spanishLanguageButton);
            this.Name = "LanguageForm";
            this.Text = "Please select a language";
            this.Load += new System.EventHandler(this.LanguageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button germanLanguageButton;
        private System.Windows.Forms.Button englishLanguageButton;
        private System.Windows.Forms.Button spanishLanguageButton;
    }
}