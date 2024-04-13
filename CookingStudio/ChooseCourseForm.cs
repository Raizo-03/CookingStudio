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
        //These are the variables needed for the process
        //A string variable for the language chosen
        String language;
        //A String variable for the course chosen
        String course;
        //A DateTime Variable for the chosen date of the course
        DateTime selectedDate;

        //The boolean variable for the course button
        //Course: Spanish-Traditional
        private bool traditionalButtonClicked = false;
        //Course: Spanish- Vegetarian and Healthy
        private bool vegetarianButtonClicked = false;
        //Course: Spanish- Healthy and Fresh from grill
        private bool grillButtonClicked = false;

        public ChooseCourseForm(String Language)
        {
            InitializeComponent();
            this.language = Language;
            //Code that makes the form in the center
            this.StartPosition = FormStartPosition.CenterScreen;

            //This is the instance of form when closing- it calls the method CourseForm_FormClosing
            this.FormClosing += CourseForm_FormClosing;

            //This code ensures that the form is not resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // This two code is use to control the date of the spanish traditional course
            // so that user can only chose date on Mondays of the year
            // It calls the two functions/method traditionalDatePicker_ValueChanged and GetNearestMonday
            traditionalDatePicker.ValueChanged += traditionalDatePicker_ValueChanged;
            traditionalDatePicker.Value = GetNearestMonday(DateTime.Today);

            // This two code is use to control the date of the spanish vegetarian course
            // so that user can only chose date on Wednesdays of the year
            // It calls the two functions vegetarianDatePicker_ValueChanged and GetNearestWednesday
            vegetarianDatePicker.ValueChanged += vegetarianDatePicker_ValueChanged;
            vegetarianDatePicker.Value = GetNearestWednesday(DateTime.Today);

            // This two code is use to control the date of the spanish healthy and fresh from grill course
            // so that user can only chose date on Fridays and Saturdays of the year
            freshfromgrillDatePicker.Value = GetNearestFridayOrSaturday(DateTime.Today);
            freshfromgrillDatePicker.ValueChanged += freshfromgrillDatePicker_ValueChanged;

        }
        private void CourseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure that the application exits when the main form is closed
            Application.Exit();
        }


        //This code is use for the datepicker of the spanish traditional course
        private void traditionalDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Check if the selected date is not Monday
            if (traditionalDatePicker.Value.DayOfWeek != DayOfWeek.Monday)
            {
                if (language.Equals("german"))
                {
                    MessageBox.Show("Sie können nur Daten von Montagen des Jahres auswählen.", "Ungültiges Datum", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (language.Equals("spanish"))
                {
                    MessageBox.Show("Solamente puedes elegir fechas que sean lunes del año.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    // Display error message
                    MessageBox.Show("You can only choose dates from Mondays of the year.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Adjust the date to the nearest Monday
                traditionalDatePicker.Value = GetNearestMonday(traditionalDatePicker.Value);
            }
        }

        // Method to get the nearest Monday to a given date in the spanish traditional course
        private DateTime GetNearestMonday(DateTime date)
        {
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(daysUntilMonday);
        }

        //This code is for the datepicker of the spanish vegetarian and healty course
        private void vegetarianDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Check if the selected date is not Wednesday
            if (vegetarianDatePicker.Value.DayOfWeek != DayOfWeek.Wednesday)
            {
                if (language.Equals("german"))
                {
                    MessageBox.Show("Sie können nur Daten von Mittwochen des Jahres auswählen.", "Ungültiges Datum", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (language.Equals("spanish"))
                {
                    MessageBox.Show("Puedes elegir solamente fechas que sean miércoles del año.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Display error message
                    MessageBox.Show("You can only choose dates from Wednesdays of the year.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Reset the date to the nearest Wednesday
                vegetarianDatePicker.Value = GetNearestWednesday(DateTime.Today);
            }
        }

        // Method to get the nearest Wednesday to a given date for the spanish vegetarian course
        private DateTime GetNearestWednesday(DateTime date)
        {
            int daysUntilWednesday = ((int)DayOfWeek.Wednesday - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(daysUntilWednesday);
        }


        //This code is for the datepicker of the spanish healthy and fresh from grill course
        private void freshfromgrillDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Check if the selected date is not Friday or Saturday
            if (freshfromgrillDatePicker.Value.DayOfWeek != DayOfWeek.Friday &&
                freshfromgrillDatePicker.Value.DayOfWeek != DayOfWeek.Saturday)
            {
                // Display error message
                if (language.Equals("german"))
                {
                    MessageBox.Show("Sie können nur Daten von Freitagen oder Samstagen des Jahres auswählen.", "Ungültiges Datum", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (language.Equals("spanish"))
                {
                    MessageBox.Show("Solo puedes elegir fechas que sean viernes o sábados del año.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("You can only choose dates from Fridays or Saturdays of the year.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Reset the date to the nearest Friday or Saturday
                freshfromgrillDatePicker.Value = GetNearestFridayOrSaturday(DateTime.Today);
            }
        }
        // Method to get the nearest Friday or Saturday to a given date for the spanish healthy and fresh from grill course
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

        //This code block is for the function of the further button
        private void furtherButton_Click(object sender, EventArgs e)
        {
            //This code checks on what is the course that the user have chosen depending on what button they have clicked
            //It prevents the user to proceed to the next form if they haven't chose any course
            if (traditionalButtonClicked)
            {
                course = "traditional";
            }
            else if (vegetarianButtonClicked)
            {
                course = "vegetarian";
            }
            else if (grillButtonClicked)
            {
                course = "grill";
            }
            else
            {
                if (language.Equals("german"))
                {
                    MessageBox.Show("Es wurde kein Kurs ausgewählt.", "Ungültiger Kurs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (language.Equals("spanish"))
                {
                    MessageBox.Show("Ningún curso ha sido seleccionado.", "Curso inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("No course have been chosen.", "Invalid Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //Creates an instance of the booking data form so that it loads the  booking data form
            //Drops the current form (ChooseCourseForm)
            BookingDataForm bookingData = new BookingDataForm(course, selectedDate, language);
            bookingData.Show();
            this.Hide();
        }


        //This is the function if the user chose the spanish traditional
        private void traditionalButton_Click(object sender, EventArgs e)
        {
            //Sets the boolean variable for spanish traditional to true
            traditionalButtonClicked = true;

            //Sets the price when the button is clicked
            if (language.Equals("german"))
            {
                priceTextbox.Text = "€ 40";

            }else if (language.Equals("spanish"))
            {
                priceTextbox.Text = "€ 40";
            }
            else
            {
                priceTextbox.Text = "$ 40";
            }


                selectedDate = traditionalDatePicker.Value;

        }
        //This is the function if the user chose the spanish vegetarian

        private void vegetableButton_Click(object sender, EventArgs e)
        {
            //Sets the boolean variable for spanish vegetarian to true
            vegetarianButtonClicked = true;

            //Sets the price when the button is clicked
            if (language.Equals("german"))
            {
                priceTextbox.Text = "€ 50";

            }
            else if (language.Equals("spanish"))
            {
                priceTextbox.Text = "€ 50";
            }
            else
            {
                priceTextbox.Text = "$ 50";
            }

            //Sets the selected date of the user
            selectedDate = vegetarianDatePicker.Value;

        }
        //This is the function if the user chose the spanish fresh from grill on friday
        private void grillFridayButton_Click(object sender, EventArgs e)
        {
            //Sets the boolean variable for spanish fresh from grill to true
            grillButtonClicked = true;

            //Sets the price when the button is clicked
            if (language.Equals("german"))
            {
                priceTextbox.Text = "€ 80";

            }
            else if (language.Equals("spanish"))
            {
                priceTextbox.Text = "€ 80";
            }
            else
            {
                priceTextbox.Text = "$ 80";
            }

            //Sets the selected date of the user
            selectedDate = freshfromgrillDatePicker.Value;

        }
        //This is the function if the user chose the spanish fresh from grill on saturday

        private void grillSaturdayButton_Click(object sender, EventArgs e)
        {
            //Sets the boolean variable for spanish fresh from grill to true
            grillButtonClicked = true;

            //Sets the price when the button is clicked
            if (language.Equals("german"))
            {
                priceTextbox.Text = "€ 80";

            }
            else if (language.Equals("spanish"))
            {
                priceTextbox.Text = "€ 80";
            }
            else
            {
                priceTextbox.Text = "$ 80";
            }
            //Sets the selected date of the user
            selectedDate = freshfromgrillDatePicker.Value;

        }

        private void ChooseCourseForm_Load(object sender, EventArgs e)
        {
            if (language.Equals("german"))
            {
                GermanTextChanger();
            } else if (language.Equals("spanish"))
            {
                SpanishTextChanger();
            }
        }

        private void GermanTextChanger()
        {

            this.Text = "Wählen Sie Ihren Kurs";
            spanishTraditionalLabel.Text = "Spanisch: Traditionell";
            traditionalButton.Text = "Montag 17:00 bis 20:00";
            spanishVegetarianLabel.Text = "Spanisch: Vegetarisch und Gesund";
            vegetableButton.Text = "Mittwoch 17:00 bis 20:00";
            spanishHealthyGrillLabel.Text = "Spanisch: Gesund und frisch vom Grill";
            grillFridayButton.Text = "Freitag 18:00 bis 22:00";
            grillSaturdayButton.Text = "Samstag 18:00 bis 20:00";
            priceLabel.Text = "Preis pro Person";
            priceTextbox.Text = "Preis in EUR";
            furtherButton.Text = "weiter";
        }

        private void SpanishTextChanger()
        {
            this.Text = "Elige tu curso";
            spanishTraditionalLabel.Text = "Español: Tradicional";
            traditionalButton.Text = "Lunes de 17:00 a 20:00";
            spanishVegetarianLabel.Text = "Español: Vegetariano y Saludable";
            vegetableButton.Text = "Miércoles de 17:00 a 20:00";
            spanishHealthyGrillLabel.Text = "Español: Saludable y fresco a la parrilla";
            grillFridayButton.Text = "Viernes de 18:00 a 22:00";
            grillSaturdayButton.Text = "Sábado de 18:00 a 20:00";
            priceLabel.Text = "Precio por persona";
            priceTextbox.Text = "Precio en EUR";
            furtherButton.Text = "continuar";
        }

    }
}
