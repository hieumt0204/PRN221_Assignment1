using Assignment1;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Session2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Settings settings;
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        
        private void mnuProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow();

            productWindow.Show();

        }

        private void mnuCategory_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow categoryWindow = new CategoryWindow();
            categoryWindow.Show();
        }

        private void mnuMember_Click(object sender, RoutedEventArgs e)
        {
           MemberWindow member = new MemberWindow();
            member.Show();
          
        }

        private void mnuLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

      
        private void mnuOrderReport_Click(object sender, RoutedEventArgs e)
        {
            OrderReportWindow orderReportWindow = new OrderReportWindow();
            orderReportWindow.Show();
        }
    }
}
