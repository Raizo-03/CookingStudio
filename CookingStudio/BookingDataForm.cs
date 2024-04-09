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
        String firstName;
        String lastName;
        String email;
        String telephoneNumber;
        int numberOfPeople;
        String chosenCourse;
        int totalPrice;

        public BookingDataForm(String chosenCourse)
        {
            InitializeComponent();

            this.FormClosing += BookingDataForm_FormClosing;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.chosenCourse = chosenCourse;

        }
        private void BookingDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure that the application exits when the main form is closed
            Application.Exit();
        }

        private void overviewButton_Click(object sender, EventArgs e)
        {
            firstName = firstnameTextbox.Text;
            lastName = lastnameTextbox.Text;
            email = emailTextbox.Text;
            telephoneNumber = telephonenumberTextbox.Text;
            numberOfPeople  = Int32.Parse(numofpeopleTextbox.Text);
            chosenCourse = courseTextbox.Text;
            totalPrice = Int32.Parse(totalpriceTextbox.Text);

            BookingOverviewForm bookingOverview = new BookingOverviewForm(firstName, lastName, email, telephoneNumber, numberOfPeople, chosenCourse, totalPrice);
            bookingOverview.Show();
            this.Hide();
        }

        private void BookingDataForm_Load(object sender, EventArgs e)
        {
            if (chosenCourse.Equals("traditional")){
                courseTextbox.Text = "Spanish: Traditional";
            }else if (chosenCourse.Equals("vegetarian"))
            {
                courseTextbox.Text = "Spanish: Vegetarian and Healthy";
            }else if (chosenCourse.Equals("grill")){
                courseTextbox.Text = "Spanish: Healthy and Fresh from Grill";
            }
        }
    }
}
