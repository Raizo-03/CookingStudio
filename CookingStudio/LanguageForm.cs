using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookingStudio
{
    public partial class LanguageForm : Form
    {
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
            ChooseCourseForm courseForm = new ChooseCourseForm();
            courseForm.Show();
            this.Hide();
        }
    }
}
