using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookingStudio
{
    public partial class LanguageForm : Form
    {
        //language Checker
        private bool englishLanguage = false;
        private bool spanishLanguage = false;
        private bool germanLanguage = false;

        public LanguageForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.FormClosing += Language_FormClosing;

        }
        private void spanishLanguageButton_Click(object sender, EventArgs e)
        {
            // Switch to the course panel TabPage
        }

        private void germanLanguageButton_Click(object sender, EventArgs e)
        {
            // Switch to the course panel TabPage
        }

        private void Language_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure that the application exits when the main form is closed
            Application.Exit();
        }


        private void LanguageForm_Load(object sender, EventArgs e)
        {
           
        }

        private void englishLanguageButton_Click_1(object sender, EventArgs e)
        {
            englishLanguage = true;
            String language = LanguageChecker();


            ChooseCourseForm courseForm = new ChooseCourseForm(language);
            courseForm.Show();
            this.Hide();
        }

        private void spanishLanguageButton_Click_1(object sender, EventArgs e)
        {
            spanishLanguage = true;
        }


        private void germanLanguageButton_Click_1(object sender, EventArgs e)
        {
            germanLanguage = true;
        }

        //This code block is used to check what is the language that user chose
        private String LanguageChecker()
        {
            String ChosenLanguage = " ";

            //Language Checker
            if (englishLanguage)
            {
                ChosenLanguage = "english";
            }
            else if (spanishLanguage)
            {
                ChosenLanguage = "spanish";
            }
            else if (germanLanguage)
            {
                ChosenLanguage = "german";
            }
            else
            {
                MessageBox.Show("No language have been chosen.", "Invalid Choice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ChosenLanguage;
        }
    }
}
