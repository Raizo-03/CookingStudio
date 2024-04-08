using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CookingStudio
{
    public partial class ChooseCourseForm : Form
    {
        public ChooseCourseForm()
        {
            InitializeComponent();
            //Code that makes the form in the center
            this.StartPosition = FormStartPosition.CenterScreen;

            this.FormClosing += CourseForm_FormClosing;

        }
        private void CourseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure that the application exits when the main form is closed
            Application.Exit();
        }
        private void ChooseCourseForm_Load(object sender, EventArgs e)
        {

        }

        private void overviewButton_Click(object sender, EventArgs e)
        {

        }

        private void furtherButton_Click(object sender, EventArgs e)
        {
            BookingDataForm bookingData = new BookingDataForm();
            bookingData.Show();
            this.Hide();
        }
    }
}
