using Microsoft.Extensions.Configuration;
using Session2;
using Session2.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        eStoreContext context;
        Settings settings;
        public LoginWindow()
        {
            InitializeComponent();
            context = new eStoreContext();
       
        }
        private Member GetMember(string email, string password)
        {
            Member member = null;
            try
            {
                member = context.Members.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
       
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtEmail.Text.Length == 0)
            {
                errorMessage.Text = "Enter an email!";
                txtEmail.Focus();
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errorMessage.Text = "Enter a valid email!";
                txtEmail.Select(0, txtEmail.Text.Length);
                txtEmail.Focus();
            }
            else if (txtPassword.Password.Length == 0)
            {
                errorMessage.Text = "Enter a password!";
                txtPassword.Focus();
            }
            else
            {

                var email = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DefaultAccount:Email").Value;
                var password = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DefaultAccount:Password").Value;
              
                var member = GetMember(txtEmail.Text, txtPassword.Password);
                if(txtEmail.Text.Equals(email) && txtPassword.Password.Equals(password))
                {
                    MessageBox.Show("Welcome Admin", "Login");
                    MainWindow mainwindow = new MainWindow();
                    mainwindow.Show();
                    
                    this.Close();
                } else if(member != null)
                {
                    MessageBox.Show($"Welcome {member.Email}", "Login");
                    
                    OrderWindow orderWindow = new OrderWindow(member.MemberId);
                    orderWindow.Show();
                    this.Close();
                }
                else 
                {
                    errorMessage.Text = "Login fail!";
                }

            }
        }

        
    }
}
