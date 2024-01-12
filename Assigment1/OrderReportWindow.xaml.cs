using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for OrderReportWindow.xaml
    /// </summary>
    public partial class OrderReportWindow : Window
    {
        eStoreContext context;
        public OrderReportWindow()
        {
            InitializeComponent();
            context = new eStoreContext();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Lấy ngày bắt đầu và ngày kết thúc từ DatePicker
                DateTime startDate = datePickerStartDate.SelectedDate ?? DateTime.MinValue;
                DateTime endDate = datePickerEndDate.SelectedDate ?? DateTime.MaxValue;

                // Lấy danh sách đơn đặt hàng theo khoảng thời gian
                var orders = context.Orders
                    .Include(x => x.Member)
                    .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                    .ToList();

                // Gán danh sách đơn đặt hàng cho ItemsSource của ListView
                lvOrders.ItemsSource = orders;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Order Report");
            }
        }
    }
}
