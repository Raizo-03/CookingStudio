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
    public partial class ConfirmationForm : Form
    {
        string language;
        public ConfirmationForm(string language)
        {
            InitializeComponent();

            //This code is for the form to be in the center position
            this.StartPosition = FormStartPosition.CenterScreen;

            //This is the instance of form when closing- it calls the method ConfirmationForm_FormClosing
            this.FormClosing += ConfirmationForm_FormClosing;

            //This code ensures that the form is not resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.language = language;
        }
        private void ConfirmationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure that the application exits when the main form is closed
            Application.Exit();
        }
        private void ConfirmationForm_Load(object sender, EventArgs e)
        {
            if (language.Equals("german"))
            {
                label1.Text = "Vielen Dank für Ihre Buchung.";
            }else if (language.Equals("spanish")){
                label1.Text = "Muchas gracias por su reserva.";

            }
            else
            {
                label1.Text = "Thank you for your booking.";
            }
        }

        
    }
}
