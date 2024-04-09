﻿using System;
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
        String course;
        private bool traditionalButtonClicked = false;
        private bool vegetableButtonClicked = false;
        private bool grillButtonClicked = false;

        public ChooseCourseForm()
        {
            InitializeComponent();
            //Code that makes the form in the center
            this.StartPosition = FormStartPosition.CenterScreen;

            this.FormClosing += CourseForm_FormClosing;

            // Subscribe to DateChanged event
            traditionalDatePicker.ValueChanged += traditionalDatePicker_ValueChanged;
            traditionalDatePicker.Value = GetNearestMonday(DateTime.Today);

            // Subscribe to DateChanged event for vegetableDatePicker and freshfromgrillDatePicker
            vegetableDatePicker.ValueChanged += vegetableDatePicker_ValueChanged;
            freshfromgrillDatePicker.ValueChanged += freshfromgrillDatePicker_ValueChanged;

            // Set initial dates
            vegetableDatePicker.Value = GetNearestTuesday(DateTime.Today);
            freshfromgrillDatePicker.Value = GetNearestFridayOrSaturday(DateTime.Today);

        }
        private void CourseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure that the application exits when the main form is closed
            Application.Exit();
        }
        private void furtherButton_Click(object sender, EventArgs e)
        {
            if(traditionalButtonClicked)
            {
                course = "traditional";
            }else if (vegetableButtonClicked)
            {
                course = "vegetarian";
            }else if (grillButtonClicked)
            {
                course = "grill";
            }
            else
            {
                MessageBox.Show("No course have been chosen.", "Invalid Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BookingDataForm bookingData = new BookingDataForm(course);
            bookingData.Show();
            this.Hide();
        }

        private void traditionalDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Check if the selected date is not Monday
            if (traditionalDatePicker.Value.DayOfWeek != DayOfWeek.Monday)
            {

                // Display error message
                MessageBox.Show("You can only choose dates from Mondays of the year.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Adjust the date to the nearest Monday
                traditionalDatePicker.Value = GetNearestMonday(traditionalDatePicker.Value);
            }
        }


        // Method to get the nearest Monday to a given date
        private DateTime GetNearestMonday(DateTime date)
        {
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(daysUntilMonday);
        }

        private void vegetableDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Check if the selected date is not Tuesday
            if (vegetableDatePicker.Value.DayOfWeek != DayOfWeek.Tuesday)
            {
                // Display error message
                MessageBox.Show("You can only choose dates from Tuesdays of the year.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Reset the date to the nearest Tuesday
                vegetableDatePicker.Value = GetNearestTuesday(DateTime.Today);
            }
        }
        // Method to get the nearest Tuesday to a given date
        private DateTime GetNearestTuesday(DateTime date)
        {
            int daysUntilTuesday = ((int)DayOfWeek.Tuesday - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(daysUntilTuesday);
        }


        private void freshfromgrillDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Check if the selected date is not Friday or Saturday
            if (freshfromgrillDatePicker.Value.DayOfWeek != DayOfWeek.Friday &&
                freshfromgrillDatePicker.Value.DayOfWeek != DayOfWeek.Saturday)
            {
                // Display error message
                MessageBox.Show("You can only choose dates from Fridays or Saturdays of the year.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Reset the date to the nearest Friday or Saturday
                freshfromgrillDatePicker.Value = GetNearestFridayOrSaturday(DateTime.Today);
            }
        }
        // Method to get the nearest Friday or Saturday to a given date
        private DateTime GetNearestFridayOrSaturday(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday)
            {
                return date;
            }
            else if (date.DayOfWeek < DayOfWeek.Friday)
            {
                return date.AddDays(DayOfWeek.Friday - date.DayOfWeek);
            }
            else // date.DayOfWeek > DayOfWeek.Saturday
            {
                return date.AddDays(6 - (int)date.DayOfWeek + (int)DayOfWeek.Friday);
            }
        }

        private void traditionalButton_Click(object sender, EventArgs e)
        {
            traditionalButtonClicked = true;
            priceTextbox.Text = "$ 40";
        }

        private void vegetableButton_Click(object sender, EventArgs e)
        {
            vegetableButtonClicked = true;
            priceTextbox.Text = "$ 50";

        }

        private void grillFridayButton_Click(object sender, EventArgs e)
        {
            grillButtonClicked = true;
            priceTextbox.Text = "$ 80";

        }

        private void grillSaturdayButton_Click(object sender, EventArgs e)
        {
            grillButtonClicked = true;
            priceTextbox.Text = "$ 80";

        }
    }
}
