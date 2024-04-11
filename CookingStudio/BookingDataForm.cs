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
        DateTime selectedDate;

        public BookingDataForm(String chosenCourse, DateTime selectedDate)
        {
            InitializeComponent();

            this.FormClosing += BookingDataForm_FormClosing;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.chosenCourse = chosenCourse;
            this.selectedDate = selectedDate;
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
            // Parse the number of people from the text box
            if (!int.TryParse(numofpeopleTextbox.Text, out numberOfPeople))
            {
                MessageBox.Show("Please enter a valid number for number of people.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the telephone number
            if (!IsValidPhoneNumber(telephonenumberTextbox.Text))
            {
                MessageBox.Show("Please enter a valid telephone number (numbers only).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate the first name and last name
            if (!IsValidName(firstnameTextbox.Text) || !IsValidName(lastnameTextbox.Text))
            {
                MessageBox.Show("Please enter a valid first name and last name (letters only).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UpdateTotalPrice();
            BookingOverviewForm bookingOverview = new BookingOverviewForm(firstName, lastName, email, telephoneNumber, numberOfPeople, chosenCourse, totalPrice);
            bookingOverview.Show();
            this.Hide();
        }

        private void BookingDataForm_Load(object sender, EventArgs e)
        {
            if (chosenCourse.Equals("traditional")){
                courseTextbox.Text = "Spanish: Traditional ";
            }else if (chosenCourse.Equals("vegetarian"))
            {
                courseTextbox.Text = "Spanish: Vegetarian and Healthy";
            }else if (chosenCourse.Equals("grill")){
                courseTextbox.Text = "Spanish: Healthy and Fresh from Grill";
            }

        }
        private void UpdateTotalPrice()
        {
            // Update the total price based on the chosen course and number of people
            if (chosenCourse.Equals("traditional"))
            {
                totalPrice = numberOfPeople * 40;
            }
            else if (chosenCourse.Equals("vegetarian"))
            {
                totalPrice = numberOfPeople * 50;
            }
            else if (chosenCourse.Equals("grill"))
            {
                totalPrice = numberOfPeople * 80;
            }

            // Update the total price text box
            totalpriceTextbox.Text = "$ " +  totalPrice.ToString();
        }

        private void totalpriceTextbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void numofpeopleTextbox_TextChanged(object sender, EventArgs e)
        {

            // Parse the number of people from the text box
            if (!int.TryParse(numofpeopleTextbox.Text, out numberOfPeople) || numberOfPeople <= 0)
            {
                MessageBox.Show("Please enter a valid number for number of people (greater than zero).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the number of people exceeds the maximum limit
            if (numberOfPeople > 10)
            {
                MessageBox.Show("Maximum of 10 people allowed for registration.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse the number of people from the text box
            if (!int.TryParse(numofpeopleTextbox.Text, out numberOfPeople))
            {
                // If parsing fails, set numberOfPeople to 0
                numberOfPeople = 0;
                MessageBox.Show("Please enter a valid number for number of people.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Update the total price
            UpdateTotalPrice();
        }

        private bool IsValidName(string name)
        {
            // Check if the name contains only letters
            return !string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Check if the phone number contains only numbers
            return !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.All(char.IsDigit);
        }

        private void firstnameTextbox_TextChanged(object sender, EventArgs e)
        {
            // Remove white spaces from the last name
            firstnameTextbox.Text = firstnameTextbox.Text.Trim();

        }

        private void lastnameTextbox_TextChanged(object sender, EventArgs e)
        {
            // Remove white spaces from the last name
            lastnameTextbox.Text = lastnameTextbox.Text.Trim();

        }


        private void telephonenumberTextbox_TextChanged(object sender, EventArgs e)
        {
            // Remove white spaces from the telephone number
            telephonenumberTextbox.Text = telephonenumberTextbox.Text.Trim();
        }
    }
}
