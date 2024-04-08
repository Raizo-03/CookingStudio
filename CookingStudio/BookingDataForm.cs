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
    public partial class BookingDataForm : Form
    {
        public BookingDataForm()
        {
            InitializeComponent();

            this.FormClosing += BookingDataForm_FormClosing;
            this.StartPosition = FormStartPosition.CenterScreen;


        }
        private void BookingDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure that the application exits when the main form is closed
            Application.Exit();
        }

        private void overviewButton_Click(object sender, EventArgs e)
        {
            BookingOverviewForm bookingOverview = new BookingOverviewForm();
            bookingOverview.Show();
            this.Hide();
        }

        private void BookingDataForm_Load(object sender, EventArgs e)
        {

        }
    }
}
