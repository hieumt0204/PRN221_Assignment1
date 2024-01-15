using Microsoft.EntityFrameworkCore;
using Session2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Session2
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        eStoreContext context;
        private int memberId;
        public OrderWindow(int memberId)
        {
            InitializeComponent();
            context = new eStoreContext();
            this.memberId = memberId;
            LoadOrderList(memberId);
            cboProductId.ItemsSource = context.Products.ToList();
            dpOrderDate.SelectedDate = DateTime.Now;
            dpShippedDate.SelectedDate = DateTime.Now.AddDays(7);

        }
        public void LoadOrderList(int memberID)
        {
            listOrder.ItemsSource = context.Orders.Where(x=> x.MemberId == memberID).ToList();
        }
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order order = null;
                
                order = new Order
                {
                    MemberId = memberId,
                    OrderDate = dpOrderDate.SelectedDate ?? DateTime.Now,
                    RequiredDate = dpRequireDate.SelectedDate,
                    ShippedDate = dpShippedDate.SelectedDate ?? DateTime.Now.AddDays(3),
                    
                    
                };
                context.Orders.Add(order);
                context.SaveChanges();
                MessageBox.Show("Add order successfully", "Add order");
                LoadOrderList(memberId);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Order");
            }
        }

        public void listOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listOrder.SelectedItem != null)
            {
                Order selectedOrder = (Order)listOrder.SelectedItem;

                ShowOrderDetails(selectedOrder.OrderId);
                
            }
        }

        public void ShowOrderDetails(int orderId)
        {
            List<OrderDetail> detailList = context.OrderDetails
                                                .Where(x => x.OrderId == orderId)
                                                .Include(p => p.Product) 
                                                .ToList();

            //cboProductId.ItemsSource = detailList.Select(x => x.Product).ToList();
            listOrderDetails.ItemsSource = detailList;
            

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order selectedOrder = (Order)listOrder.SelectedItem;
                if(selectedOrder != null)
                {
                    selectedOrder.OrderDate = dpOrderDate.SelectedDate ?? DateTime.Now;
                    selectedOrder.RequiredDate = dpRequireDate.SelectedDate;
                    selectedOrder.ShippedDate = dpShippedDate.SelectedDate ?? DateTime.Now;
                    context.Orders.Update(selectedOrder);
                    context.SaveChanges();
                    MessageBox.Show($"Update OrderId =  {selectedOrder.OrderId} successfully", "Update order");
                    LoadOrderList(selectedOrder.MemberId);
                      
                }
                else
                {
                    MessageBox.Show("Please select a order you want update", "Update order");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Update order");
            }
        }

        private void btnAddDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(listOrder.SelectedItem != null)
                {
                    Order selectedOrder = (Order)listOrder.SelectedItem;
                    if(cboProductId.SelectedItem != null)
                    {
                        Product selectedProduct = (Product)cboProductId.SelectedItem;
                        OrderDetail orderDetail = new OrderDetail
                        {
                            OrderId = selectedOrder.OrderId,
                            ProductId = selectedProduct.ProductId,
                            UnitPrice = int.Parse(txtUnitPrice.Text),
                            Quantity = int.Parse(txtQuantity.Text),
                            Discount = int.Parse(txtDiscount.Text)
                        };
                        context.OrderDetails.Add(orderDetail);
                        context.SaveChanges();
                        MessageBox.Show("Add order details successfully", "Add Order Details");
                        ShowOrderDetails(selectedOrder.OrderId);
                    }
                    else
                    {
                        MessageBox.Show("Please select a product", "Add Order Details");
                    }
                }
                else
                {
                    MessageBox.Show("Please select an order before adding order details", "Add Order Details");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Details Order");
            }
        }

        private void btnUpdateDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listOrderDetails.SelectedItem != null)
                {
                    OrderDetail selectedOrderDetail = (OrderDetail)listOrderDetails.SelectedItem;

                    if (cboProductId.SelectedItem != null)
                    {
                        Product selectedProduct = (Product)cboProductId.SelectedItem;

                        selectedOrderDetail.ProductId = selectedProduct.ProductId;
                        selectedOrderDetail.UnitPrice = int.Parse(txtUnitPrice.Text); 
                        selectedOrderDetail.Quantity = int.Parse(txtQuantity.Text);    
                        selectedOrderDetail.Discount = int.Parse(txtDiscount.Text);    

                        context.OrderDetails.Update(selectedOrderDetail);
                        context.SaveChanges();

                        ShowOrderDetails(selectedOrderDetail.OrderId);

                        MessageBox.Show("Update order details successfully", "Update Order Details");
                    }
                    else
                    {
                        MessageBox.Show("Please select a product.", "Update Order Details");
                    }
                }
                else
                {
                    MessageBox.Show("Please select an order detail before updating.", "Update Order Details");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Order Details");
            }
        }

        private void btnDeleteDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listOrderDetails.SelectedItem != null)
                {
                    OrderDetail selectedOrderDetail = (OrderDetail)listOrderDetails.SelectedItem;

                    MessageBoxResult result = MessageBox.Show($"Do you want to delete OrderDetailId = {selectedOrderDetail.OrderDetailId}?", "Delete Order Detail", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        context.OrderDetails.Remove(selectedOrderDetail);
                        context.SaveChanges();

                        ShowOrderDetails(selectedOrderDetail.OrderId);

                        MessageBox.Show($"Delete OrderDetailId = {selectedOrderDetail.OrderDetailId} successfully", "Delete Order Detail");
                    }
                }
                else
                {
                    MessageBox.Show("Please select an order detail to delete.", "Delete Order Detail");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Order Detail");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order selectedOrder = (Order )listOrder.SelectedItem;
                if(selectedOrder != null)
                {
                    var result = MessageBox.Show($"Do you want delete orderId = {selectedOrder.OrderId} ?", "Delete order", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if(result == MessageBoxResult.Yes)
                    {
                        context.Orders.Remove(selectedOrder);
                        context.SaveChanges();
                        MessageBox.Show($"Delete orderId = {selectedOrder.OrderId} successfully", "Delete order");
                        LoadOrderList(memberId);
                    }
                }
                else
                {
                    MessageBox.Show("Plese select an order you want delete", "Delete order");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete order");
            }
        }
    }
}
