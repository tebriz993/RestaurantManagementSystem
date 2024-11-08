using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RestaurantManagementSystem.Entities;

namespace RestaurantManagementSystem.WinForms
{
    public partial class Login : Form 
    {
        private List<User> users;

        public Login()
        {
            InitializeComponent();
            InitializeUsers();
            checkShowPassword.CheckedChanged += new EventHandler(ShowPassword); 
            btnLogin.Click += new EventHandler(button1_Click); 
            btnCancel.Click += new EventHandler(btnCancel_Click); 
        }

        private void InitializeUsers()
        {
            users = new List<User>
            {
                new User("admin", "admin123", "Admin"),
                new User("user1", "password1"),
                new User("user2", "password2")
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim(); 
            string password = txtPassword.Text;        

            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                User authenticatedUser = users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (authenticatedUser != null)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void ShowPassword(object sender, EventArgs e)
        {
            if (checkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Show password
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Mask password again
            }
        }

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            checkShowPassword.Checked = false; 
            txtPassword.PasswordChar = '*'; 
        }

        
    }
}
