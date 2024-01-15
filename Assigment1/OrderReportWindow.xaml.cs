﻿using Microsoft.EntityFrameworkCore;
using Session2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
                DateTime startDate = datePickerStartDate.SelectedDate ?? DateTime.MinValue;
                DateTime endDate = datePickerEndDate.SelectedDate ?? DateTime.MaxValue;

                var orders = context.Orders
                    .Include(x => x.Member)
                    .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                    .ToList();

                lvOrders.ItemsSource = orders;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Order Report");
            }
        }

        private void lvOrders_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           
            if(lvOrders.SelectedItem != null)
            {
                Order selectedOrder = (Order)lvOrders.SelectedItem;
                ShowOrderDetails(selectedOrder.OrderId);
            }
        }

        private void ShowOrderDetails(int orderId)
        {
            List<OrderDetail> detailsList = context.OrderDetails
                                                    .Where(o => o.OrderId == orderId)
                                                    .Include(p => p.Product)
                                                    .ToList();
            lvOrderDetails.ItemsSource = detailsList;

        }
    }
}
