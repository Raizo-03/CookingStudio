using Microsoft.Win32;
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
        //These are stores the information of the user
        //String variable for language
        String language;

        //String variable for the firstname
        String firstName;

        //String variable for the lastname
        String lastName;

        //String variable for email
        String email;

        //String variable for the telephone number
        String telephoneNumber;

        //Integer variable for the number of people
        int numberOfPeople;

        //String variable for the chosen course
        String chosenCourse;

        //Integer variable for the total price
        int totalPrice;

        //DateTime variable for the selected date
        DateTime selectedDate;

        public BookingDataForm(String chosenCourse, DateTime selectedDate, String language)
        {
            InitializeComponent();

            //This is the instance of form when closing- it calls the method BookingDataForm_FormClosing
            this.FormClosing += BookingDataForm_FormClosing;

            //This code is for the form to be in the center position
            this.StartPosition = FormStartPosition.CenterScreen;

            //This code ensures that the form is not resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.chosenCourse = chosenCourse;
            this.selectedDate = selectedDate;
            this.language = language;
        }
        private void BookingDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure that the application exits when the main form is closed
            Application.Exit();
        }

        private void overviewButton_Click(object sender, EventArgs e)
        {
            //These variables stores the informations from the textboxes that the user inputted
            firstName = firstnameTextbox.Text;
            lastName = lastnameTextbox.Text;
            email = emailTextbox.Text;
            telephoneNumber = telephonenumberTextbox.Text;

            // Parse/Converts the number of people from the text box from String to Integer
            if (!int.TryParse(numofpeopleTextbox.Text, out numberOfPeople))
            {
                if (language.Equals("german"))
                {
                    MessageBox.Show("Bitte geben Sie eine gültige Zahl für die Anzahl der Personen ein.", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (language.Equals("spanish"))
                {
                    MessageBox.Show("Please enter a valid number for number of people.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa un número válido para la cantidad de personas.", "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Check if the number of people exceeds the maximum limit of 10
            if (numberOfPeople > 10)
            {
                if (language.Equals("german"))
                {
                    MessageBox.Show("Maximal 10 Personen zur Anmeldung erlaubt.", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (language.Equals("spanish"))
                {
                    MessageBox.Show("Máximo de 10 personas permitidas para el registro.", "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Maximum of 10 people allowed for registration.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Validate the telephone number if user only inputted number
            if (!IsValidPhoneNumber(telephonenumberTextbox.Text))
            {
                if (language.Equals("german"))
                {
                    MessageBox.Show("Bitte geben Sie eine gültige Telefonnummer ein (nur Zahlen).", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (language.Equals("spanish"))
                {
                    MessageBox.Show("Por favor, ingresa un número de teléfono válido (solo números).", "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Please enter a valid telephone number (numbers only).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Validate the first name and last name if user only inputted text/String value
            if (!IsValidName(firstnameTextbox.Text) || !IsValidName(lastnameTextbox.Text))
            {
                if (language.Equals("german"))
                {
                    MessageBox.Show("Bitte geben Sie einen gültigen Vor- und Nachnamen ein (nur Buchstaben).", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (language.Equals("spanish"))
                {
                    MessageBox.Show("Por favor, ingresa un nombre y apellido válidos (solo letras).", "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Please enter a valid first name and last name (letters only).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //Calls the function for updating the total price whenever the user inputted number of people
            UpdateTotalPrice();

            //Calls an instance of the booking overview and sends the information of the user to the second form and shows it to the screen
            //Also hides the current form (bookingdataform)
            BookingOverviewForm bookingOverview = new BookingOverviewForm(firstName, lastName, email, telephoneNumber, numberOfPeople, chosenCourse, totalPrice, language, selectedDate);
            bookingOverview.Show();
            this.Hide();
        }

        private void BookingDataForm_Load(object sender, EventArgs e)
        {

            //For setting the language

            if (language.Equals("german")){
                GermanTextChanger();

                //This control flow statements (if-else) updates the course on the textbox depending on what course that use choses on the previous form
                if (chosenCourse.Equals("traditional"))
                {
                    courseTextbox.Text = "Spanisch: Traditionell";
                }
                else if (chosenCourse.Equals("vegetarian"))
                {
                    courseTextbox.Text = "Spanisch: Vegetarisch und Gesund";
                }
                else if (chosenCourse.Equals("grill"))
                {
                    courseTextbox.Text = "Spanisch: Gesund und Frisch vom Grill";
                }
                totalpriceTextbox.Text = "Preis";
                overviewButton.Text = "Weiter zur Übersicht";
            }
            else if (language.Equals("spanish"))
            {
                SpanishTextChanger();
                if (chosenCourse.Equals("traditional"))
                {
                    courseTextbox.Text = "Español: Tradicional ";
                }
                else if (chosenCourse.Equals("vegetarian"))
                {
                    courseTextbox.Text = "Español: Vegetariano y Saludable";
                }
                else if (chosenCourse.Equals("grill"))
                {
                    courseTextbox.Text = "Español: Saludable y Fresco de la Parrilla";
                }
                totalpriceTextbox.Text = "Precio";
                overviewButton.Text = "Continuar a la vista general";
            }
            else
            {
                if (chosenCourse.Equals("traditional"))
                {
                    courseTextbox.Text = "Spanish: Traditional ";
                }
                else if (chosenCourse.Equals("vegetarian"))
                {
                    courseTextbox.Text = "Spanish: Vegetarian and Healthy";
                }
                else if (chosenCourse.Equals("grill"))
                {
                    courseTextbox.Text = "Spanish: Healthy and Fresh from Grill";
                }

            }
        }

        //Functions the updates the total price
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
            if (language.Equals("german"))
            {
                totalpriceTextbox.Text = "€ " + totalPrice.ToString();

            }
            else if (language.Equals("spanish"))
            {
                totalpriceTextbox.Text = "€ " + totalPrice.ToString();
            }
            else
            {
                totalpriceTextbox.Text = "$ " + totalPrice.ToString();

            }

        }

        private void numofpeopleTextbox_TextChanged(object sender, EventArgs e)
        {

            // Parse the number of people from the text box
            if (!int.TryParse(numofpeopleTextbox.Text, out numberOfPeople) || numberOfPeople <= 0)
            {
                if (language.Equals("german"))
                {
                    MessageBox.Show("Bitte geben Sie eine gültige Zahl für die Anzahl der Personen ein (größer als Null).", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else if (language.Equals("spanish")){

                    MessageBox.Show("Por favor, ingresa un número válido para la cantidad de personas (mayor que cero).", "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Please enter a valid number for number of people (greater than zero).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
      
            }
            // Check if the number of people exceeds the maximum limit of 10
            if (numberOfPeople > 10)
            {
                if (language.Equals("german"))
                {
                    MessageBox.Show("Maximal 10 Personen zur Anmeldung erlaubt.", "Ungültige Eingabe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (language.Equals("spanish"))
                {
                    MessageBox.Show("Máximo de 10 personas permitidas para el registro.", "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Maximum of 10 people allowed for registration.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            // Parse the number of people from the text box
            if (!int.TryParse(numofpeopleTextbox.Text, out numberOfPeople))
            {
                // If parsing fails, set numberOfPeople to 0
                numberOfPeople = 0;
                if (language.Equals("german"))
                {
                    MessageBox.Show("Bitte geben Sie eine gültige Zahl für die Anzahl der Personen ein.", "Ungültige Eingabes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (language.Equals("spanish"))
                {
                    MessageBox.Show("Por favor, introduce un número válido para la cantidad de personas", "Entrada no válida", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Please enter a valid number for number of people.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void GermanTextChanger()
        {
            this.Text = "Buchungsdaten";
            firstnameLabel.Text = "Vorname";
            lastnameLabel.Text = "Nachname";
            emailLabel.Text = "E-Mail Adresse";
            numberLabel.Text = "Telefonnumer";
            peopleLabel.Text = "Anzahl der Personen";
            courseLabel.Text = "Ausgewählter Kurs";
            totalpriceLabel.Text = "Gesammt Preis";
        }

        private void SpanishTextChanger()
        {
            this.Text = "Datos de Reserva";
            firstnameLabel.Text = "Nombre";
            lastnameLabel.Text = "Apellido";
            emailLabel.Text = "Correo electrónico";
            numberLabel.Text = "Número de teléfono";
            peopleLabel.Text = "Cantidad de personas";
            courseLabel.Text = "Curso seleccionado";
            totalpriceLabel.Text = "Precio total";
        }
    }
}
