using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CinemaDrape.Forms
{
    public partial class Password_Login : Form
    {
        private MainForm MainFormInstance { get; set; }
        private int childVariable;
        public static int x;
        public Password_Login(MainForm mainFormInstance)
        {
            InitializeComponent();
            MainFormInstance = mainFormInstance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredPassword = Ptxt.Text;
            //bool passwordIsValid = ValidatePassword();
            // Read the saved password from the file
            string savedPassword = ReadSavedPassword();
            

            // Compare the entered password with the saved password
            if (enteredPassword == savedPassword)
            {
                MessageBox.Show("Login successful!");
                MainFormInstance.SetLoginStatus(true);  // Pass true to MainForm
                Close();
            }
            else
            {
                MessageBox.Show("Login failed. Incorrect password.");
                MainFormInstance.SetLoginStatus(false);
                Close();// Pass false to MainForm
            }
             
    }
        public int ChildVariable
        {
            get { return childVariable; }
            set { childVariable = x; }
        }

        private string ReadSavedPassword()
        {
            try
            {
                // Assuming Userdata.txt is in the root directory
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UserData.txt");
                // Read the password from the file
                if (File.Exists(filePath))
                {
                   
                    return File.ReadAllText(filePath);
                }
                else
                {
                    MessageBox.Show("Userdata.txt not found. Cannot check password.");
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reading the password: {ex.Message}");
                return string.Empty;
            }
        }
        public static Password_Login Create(MainForm mainFormInstance)
        {
            Password_Login passwordLogin = new Password_Login(mainFormInstance);
            passwordLogin.Owner = mainFormInstance;  // Set the owner
            return passwordLogin;
        }
    }
}
