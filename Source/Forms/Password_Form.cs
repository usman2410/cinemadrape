using Aurelitec.Reuse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CinemaDrape.Forms
{
    public partial class Password_Form : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Password_Form"/> class.
        /// </summary>

        public string Password { get; private set; }

        private TextBox passwordTextBox;
        private Button okButton;
        private Button cancelButton;
        public Password_Form()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Creates a new instance of the quick start form, with the specified owner.
        /// </summary>
        /// <param name="owner">The owner of the quick start form.</param>
        /// <returns>The quick start form instance.</returns>
        public static Password_Form Create(Form owner)
        {
            Password_Form passwordForm = new Password_Form();
            passwordForm.Owner = owner;
           // passwordForm.SetDefaultLocation();
            return passwordForm;
        }

        private void SetDefaultLocation()
        {
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Left + ((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2), 10);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Get values from the textboxes
            string username = txtUsername.Text;
            txtPassword.PasswordChar = '*';
            string password = txtPassword.Text;
            txtConfirmPassword.PasswordChar = '*';
            string confirmPassword = txtConfirmPassword.Text;
            

            // Validate the input
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!String.Equals(password, confirmPassword))
            {
                MessageBox.Show("Password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save the data to a file (for simplicity, a text file is used)
            SaveUserData(username, password);

            // Inform the user about successful registration
            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the textboxes
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form when the "Cancel" button is clicked
            this.Close();
        }

        private void SaveUserData(string username, string password)
        {
            // Save the user data to a text file (for simplicity)
            string filePath = "UserData.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(password);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}