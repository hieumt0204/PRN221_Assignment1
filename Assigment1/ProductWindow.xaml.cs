using Assignment1;
using Microsoft.EntityFrameworkCore;
using Session2.Models;
using System;
using System.Linq;
using System.Windows;

namespace Session2
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    /// 

    public partial class ProductWindow : Window
    {
        eStoreContext context;
        public ProductWindow()
        {
            InitializeComponent();
            context = new eStoreContext();
            LoadProductList();
            cboCategoryId.ItemsSource = context.Categories.ToList();
        }
        //private Product GetProductObject()
        //{
        //    Product product = null;
        //    try
        //    {
        //        product = new Product()
        //        {
        //            ProductName = txtProductName.Text,
        //            CategoryId = int.Parse(cboCategoryId.SelectedValuePath),
        //            Weight = float.Parse(txtWeight.Text),
        //            UnitPrice = int.Parse(txtUnitPrice.Text),
        //            UnitInStock = int.Parse(txtUnitInStock.Text),
        //            ProductId = product.ProductId
        //        };
        //    }catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Get Product");
        //    }
        //    return product;
        //}
        public void LoadProductList()
        {
            ListProduct.ItemsSource = context.Products.Include(p => p.Category).ToList();
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Product product = null;
            try
            {
                product = new Product()
                {
                    CategoryId = (int)cboCategoryId.SelectedValue,
                    ProductName = txtProductName.Text,
                    Weight = float.Parse(txtWeight.Text),
                    UnitPrice = int.Parse(txtUnitPrice.Text),
                    UnitInStock = int.Parse(txtUnitInStock.Text),
                };
                context.Products.Add(product);
                context.SaveChanges();
                LoadProductList();
                MessageBox.Show($"{product.ProductName} inserted sucessfully", "Insert product");

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Product");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //lấy các sản phẩm từ listview
                Product selectedProduct = (Product)ListProduct.SelectedItem;

                if(selectedProduct != null)
                {
                    selectedProduct.CategoryId = (int)cboCategoryId.SelectedValue;
                    selectedProduct.ProductName = txtProductName.Text;
                    selectedProduct.Weight = float.Parse(txtWeight.Text);
                    selectedProduct.UnitPrice = int.Parse(txtUnitPrice.Text);
                    selectedProduct.UnitInStock = int.Parse(txtUnitInStock.Text);

                    context.Update(selectedProduct);
                    context.SaveChanges();
                    LoadProductList();

                    MessageBox.Show($"{selectedProduct.ProductName} updated successfully", "Update product");

                }
                else
                {
                    MessageBox.Show("Please select a product to update", "Update product");
                }


            }catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Update product");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // lấy sản phẩm từ listView
                Product selectedProduct = (Product)ListProduct.SelectedItem;

                if(selectedProduct != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {selectedProduct.ProductName}",
                        "Confirm delete producrt",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);


                    if(result == MessageBoxResult.Yes)
                    {
                        context.Products.Remove(selectedProduct);
                        context.SaveChanges();
                        MessageBox.Show($"{selectedProduct.ProductName} deleted successfully", "Delete product");
                        LoadProductList();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product to delete", "Delete product");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete product");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var searchProductName = txtProductNameSearch.Text;
                var searchUnitPrice = int.TryParse(txtPriceSearch.Text, out _) ? txtPriceSearch.Text : ""; 

                var result = context.Products.Where(p => p.ProductName.Contains(searchProductName) && p.UnitPrice.ToString().Contains(searchUnitPrice)).ToList();


                ListProduct.ItemsSource = result;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Search Product");
            }
        }
    }
}
