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
    public partial class BookingOverviewForm : Form
    {
        public BookingOverviewForm()
        {
            InitializeComponent();
            this.FormClosing += BookingOverviewForm_FormClosing;
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private void BookingOverviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure that the application exits when the main form is closed
            Application.Exit();
        }

        private void BookingOverviewForm_Load(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            ConfirmationForm confirm = new ConfirmationForm();
            confirm.Show();
            this.Hide();
        }
    }
}
