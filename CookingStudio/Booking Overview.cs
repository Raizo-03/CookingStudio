using CookingStudio.database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookingStudio
{
    public partial class BookingOverviewForm : Form
    {
        //Variables that stores information
        //String variable for language
        String language;

        //String variable to store the first name
        String firstName;

        //String variable to store the last name
        String lastName;

        //String variable to store the email
        String email;

        //String a to store the telephone number
        String telephoneNumber;

        //Integer variable to store the number of people
        int numberOfPeople;

        //String variable that stores the selected course of the user
        String selectedCourse;

        // Integer variable to store the total price
        int totalPrice;

        //DateTime variable for booking date
        DateTime selectedDate;
        public BookingOverviewForm(string firstName, string lastName, string email, string telephoneNumber, int numberOfPeople, string selectedCourse, int totalPrice, string language, DateTime selectedDate)
        {
            InitializeComponent();

            //This is the instance of form when closing- it calls the method BookingOverviewForm_FormClosing
            this.FormClosing += BookingOverviewForm_FormClosing;

            //This code is for the form to be in the center position
            this.StartPosition = FormStartPosition.CenterScreen;

            //This code ensures that the form is not resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.telephoneNumber = telephoneNumber;
            this.numberOfPeople = numberOfPeople;
            this.selectedCourse = selectedCourse;
            this.totalPrice = totalPrice;
            this.language = language;
            this.selectedDate = selectedDate;
        }
        private void BookingOverviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure that the application exits when the main form is closed
            Application.Exit();
        }

        private void BookingOverviewForm_Load(object sender, EventArgs e)
        {

            //Gets the value of the variables from the booking data form and sets it to the labels
            //Sets the first name label
            UsersFName.Text = firstName;
            //Sets the last name label
            UsersLName.Text = lastName;

            //Sets the email label
            UsersEmail.Text = email;

            //Sets the telephone number label
            UsersTelephone.Text = telephoneNumber;

            //Sets the number of people label
            UsersNumPeople.Text = numberOfPeople.ToString();


            if (language.Equals("german"))
            {
                GermanTextChanger();
                //This control flow statements (if-else) updates the course on the textbox depending on what course that use choses on the previous form
                if (string.Equals(selectedCourse, "traditional", StringComparison.OrdinalIgnoreCase))
                {
                    UserChosenCourse.Text = "Spanisch: Traditionell";
                }
                else if (string.Equals(selectedCourse, "vegetarian", StringComparison.OrdinalIgnoreCase))
                {
                    UserChosenCourse.Text = "Spanisch: Vegetarisch und Gesund";
                }
                else if (string.Equals(selectedCourse, "grill", StringComparison.OrdinalIgnoreCase))
                {
                    UserChosenCourse.Text = "Spanisch: Gesund und Frisch vom Grill";
                }
                //Sets the total price label 
                UsersTotalPrice.Text = "€ " + totalPrice.ToString();

            }
            else if (language.Equals("spanish"))
            {
                SpanishTextChanger();
                //This control flow statements (if-else) updates the course on the textbox depending on what course that use choses on the previous form
                if (string.Equals(selectedCourse, "traditional", StringComparison.OrdinalIgnoreCase))
                {
                    UserChosenCourse.Text = "Español: Tradicional";
                }
                else if (string.Equals(selectedCourse, "vegetarian", StringComparison.OrdinalIgnoreCase))
                {
                    UserChosenCourse.Text = "Español: Vegetariano y Saludable";
                }
                else if (string.Equals(selectedCourse, "grill", StringComparison.OrdinalIgnoreCase))
                {
                    UserChosenCourse.Text = "Español: Saludable y Fresco de la Parrilla";
                }
                //Sets the total price label 
                UsersTotalPrice.Text = "€ " + totalPrice.ToString();

            }
            else
            {

                //Control structure to set the chosen course label depending on the choice on the previous form
                if (string.Equals(selectedCourse, "traditional", StringComparison.OrdinalIgnoreCase))
                {
                    UserChosenCourse.Text = "Spanish: Traditional ";
                }
                else if (string.Equals(selectedCourse, "vegetarian", StringComparison.OrdinalIgnoreCase))
                {
                    UserChosenCourse.Text = "Spanish: Vegetarian and Healthy";
                }
                else if (string.Equals(selectedCourse, "grill", StringComparison.OrdinalIgnoreCase))
                {
                    UserChosenCourse.Text = "Spanish: Healthy and Fresh from Grill";
                }
                //Sets the total price label 
                UsersTotalPrice.Text = "€ " + totalPrice.ToString();
            }

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            // Create an instance of DatabaseManager class
            DatabaseManager dbManager = new DatabaseManager("Server=localhost;Database=cookingstudio;Uid=root;Pwd='';");

            // Format the selected course based on the user's choice
            string formattedCourse = "";
            if (string.Equals(selectedCourse, "traditional", StringComparison.OrdinalIgnoreCase))
            {
                formattedCourse = "Spanish: Traditional";
            }
            else if (string.Equals(selectedCourse, "vegetarian", StringComparison.OrdinalIgnoreCase))
            {
                formattedCourse = "Spanish: Vegetarian and Healthy";
            }
            else if (string.Equals(selectedCourse, "grill", StringComparison.OrdinalIgnoreCase))
            {
                formattedCourse = "Spanish: Healthy and Fresh from Grill";
            }

            // SQL query to insert the booking information into the Bookings table
            string query = @"INSERT INTO Bookings (FirstName, LastName, Email, Telephone, NumberOfPeople, SelectedCourse, TotalPrice, SelectedDate)
                             VALUES (@FirstName, @LastName, @Email, @Telephone, @NumberOfPeople, @SelectedCourse, @TotalPrice, @SelectedDate)";

            // Parameters for the SQL query
            MySqlParameter[] parameters = {
                new MySqlParameter("@FirstName", MySqlDbType.VarChar) { Value = firstName },
                new MySqlParameter("@LastName", MySqlDbType.VarChar) { Value = lastName },
                new MySqlParameter("@Email", MySqlDbType.VarChar) { Value = email },
                new MySqlParameter("@Telephone", MySqlDbType.VarChar) { Value = telephoneNumber },
                new MySqlParameter("@NumberOfPeople", MySqlDbType.Int32) { Value = numberOfPeople },
                new MySqlParameter("@SelectedCourse", MySqlDbType.VarChar) { Value = formattedCourse },
                new MySqlParameter("@TotalPrice", MySqlDbType.Decimal) { Value = totalPrice },
                new MySqlParameter("@SelectedDate", MySqlDbType.Date) { Value = selectedDate }
            };

            try
            {
                // Execute the SQL query
                dbManager.ExecuteNonQuery(query, parameters);

                // Show confirmation message to the user
                ConfirmationForm confirm = new ConfirmationForm(language);
                confirm.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                // Show error message if an exception occurs
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the current form
                this.Hide();
            }
        }

        private void GermanTextChanger()
        {
            this.Text = "Buchungsübersicht";
            firstnameLabel.Text = "Vorname";
            lastnameLabel.Text = "Nachname";
            emailLabel.Text = "E-Mail Adresse";
            numberLabel.Text = "Telefonnumer";
            peopleLabel.Text = "Anzahl der Personen";
            courseLabel.Text = "Ausgewählter Kurs";
            totalpriceLabel.Text = "Gesammt Preis";
            confirmLabel.Text = "Durch Bestätigen verpflichten Sie sich, am ausgewählten Kurs teilzunehmen.";
            confirmButton.Text = "Bestätigen";
        }
        private void SpanishTextChanger()
        {
            this.Text = "Resumen de Reserva";
            firstnameLabel.Text = "Nombre";
            lastnameLabel.Text = "Apellido";
            emailLabel.Text = "Correo electrónico";
            numberLabel.Text = "Número de teléfono";
            peopleLabel.Text = "Cantidad de personas";
            courseLabel.Text = "Curso seleccionado";
            totalpriceLabel.Text = "Precio total";
            confirmLabel.Text = "Al confirmar, usted se compromete a participar en el curso seleccionado.";
            confirmButton.Text = "Confirmar";
        }

    }
}
