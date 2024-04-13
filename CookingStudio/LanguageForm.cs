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
        //These are the variables so that it can detect what language does the user chose
        private bool englishLanguage = false;
        private bool spanishLanguage = false;
        private bool germanLanguage = false;

        public LanguageForm()
        {
            InitializeComponent();

            //This code is for the form to be in the center position
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        //This code block ensure that the application exits when the main form is closed
        private void Language_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //This code block executes the functions embedded in it when the form is loaded
        private void LanguageForm_Load(object sender, EventArgs e)
        {
           //This is the instance of form when closing- it calls the method Language_FormClosing
            this.FormClosing += Language_FormClosing;

            //This code ensures that the form is not resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }



        //This code block is for the functions of the english language button
        private void englishLanguageButton_Click_1(object sender, EventArgs e)
        {

            englishLanguage = true;
            String language = LanguageChecker();

            //Creates an instance of the booking data form so that it loads the  booking data form
            ChooseCourseForm courseForm = new ChooseCourseForm(language);
            courseForm.Show();
            this.Hide();
        }
        //This code block is for the functions of the spanish language button

        private void spanishLanguageButton_Click_1(object sender, EventArgs e)
        {
            spanishLanguage = true;
            String language = LanguageChecker();

            //Creates an instance of the booking data form so that it loads the  booking data form
            ChooseCourseForm courseForm = new ChooseCourseForm(language);
            courseForm.Show();
            this.Hide();
        }

        //This code block is for the functions of the spanish language button
        private void germanLanguageButton_Click_1(object sender, EventArgs e)
        {
            germanLanguage = true;
            String language = LanguageChecker();

            //Creates an instance of the booking data form so that it loads the  booking data form
            ChooseCourseForm courseForm = new ChooseCourseForm(language);
            courseForm.Show();
            this.Hide();
        }

        //This code block is used to check what is the language that user chose
        //It returns a string on what language they have chosen
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
