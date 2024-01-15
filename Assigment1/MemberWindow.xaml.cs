using Session2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        eStoreContext context;
        public MemberWindow()
        {
            InitializeComponent();
            context = new eStoreContext();
            listMember.ItemsSource = context.Members.ToList();
        }
        public void LoadMemberList()
        {
            listMember.ItemsSource = context.Members.ToList();
        }
        public Member GetMemberByEmail(string email)
        {
            return context.Members.SingleOrDefault(x => x.Email == email);
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Member member = null;
            try
            {
                
                member = new Member()
                {
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text
                };
                var _member = GetMemberByEmail(member.Email);
                if(_member == null)
                {
                    context.Members.Add(member);
                    context.SaveChanges();
                    MessageBox.Show($"Add {member.Email} member successfully", "Add member");
                    LoadMemberList();
                }
                else
                {
                    MessageBox.Show($"Email {member.Email} is aleady exsit", "Add Member");
                }
                

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add member");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // lấy các member từ listView 
                Member seletedMember = (Member)listMember.SelectedItem;
                if (seletedMember != null)
                {
                    seletedMember.Email = txtEmail.Text;
                    seletedMember.CompanyName = txtCompanyName.Text;
                    seletedMember.City = txtCity.Text;
                    seletedMember.Country = txtCountry.Text;
                    seletedMember.Password = txtPassword.Text;

                    context.Members.Update(seletedMember);
                    context.SaveChanges();
                    MessageBox.Show($"Update {seletedMember.Email} successfully", "Update member");
                    LoadMemberList();
                }
                else
                {
                    MessageBox.Show("Please a member you want to update", "Update member");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Update member");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member selectedMember = (Member)listMember.SelectedItem;
                if(selectedMember != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Are you want to delete {selectedMember.Email}",
                        "Delete member",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        context.Members.Remove(selectedMember); 
                        context.SaveChanges();
                        MessageBox.Show($"Delete {selectedMember.Email} successfully", "Delete product");
                        LoadMemberList();

                    }
                }
                else
                {
                    MessageBox.Show("Please select a member you want to delete", "Delete member");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete member");
            }
        }
    }
}
