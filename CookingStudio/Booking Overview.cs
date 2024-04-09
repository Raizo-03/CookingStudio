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
        String firstName;
        String lastName;
        String email;
        String telephoneNumber;
        int numberOfPeople;
        String selectedCourse;
        int totalPrice;
        public BookingOverviewForm(string firstName, string lastName, string email, string telephoneNumber, int numberOfPeople, string selectedCourse, int totalPrice)
        {
            InitializeComponent();
            this.FormClosing += BookingOverviewForm_FormClosing;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.telephoneNumber = telephoneNumber;
            this.numberOfPeople = numberOfPeople;
            this.selectedCourse = selectedCourse;
            this.totalPrice = totalPrice;
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
