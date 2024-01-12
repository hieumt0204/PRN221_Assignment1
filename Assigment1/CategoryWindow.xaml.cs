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

namespace Session2
{
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        eStoreContext context;
        public CategoryWindow()
        {
            InitializeComponent();
            context = new eStoreContext();
            LoadCategoryList();
        }
        public void LoadCategoryList()
        {
            listCategory.ItemsSource = context.Categories.ToList();
        }
        public Category GetCategoryByName(string categoryName)
        {
            return context.Categories.SingleOrDefault(x => x.CategoryName == categoryName);
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Category category = null;
            try
            {
                var _category = GetCategoryByName(txtCategoryName.Text);
                if(_category == null)
                {
                    category = new Category()
                    {
                        CategoryName = txtCategoryName.Text,
                    };
                    context.Categories.Add(category);
                    context.SaveChanges();
                    MessageBox.Show($"Add {category.CategoryName} inserted successfully", "Insert category");
                    LoadCategoryList();
                }
                else
                {
                    MessageBox.Show("Category Name already exsit", "Add category");
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Category");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //lay data tu list Product
                Category selectedCategory = (Category)listCategory.SelectedItem;
                if(selectedCategory != null)
                {
                    selectedCategory.CategoryName = txtCategoryName.Text;

                    context.Categories.Update(selectedCategory);
                    context.SaveChanges();
                    MessageBox.Show($"Update {selectedCategory.CategoryName} is successfully", "Update product");
                    LoadCategoryList();
                }
                else
                {
                    MessageBox.Show("Please select category to update", "Update category");
                }
            }catch(Exception ex )
            {
                MessageBox.Show($"{ex.Message}", "Update category");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Category selectedCategory = (Category)listCategory.SelectedItem;
                if(selectedCategory != null)
                {
                    var result = MessageBox.Show($"Do you want to delete {selectedCategory.CategoryName}",
                        "Delete category",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);
                    if(result == MessageBoxResult.Yes)
                    {
                        context.Categories.Remove(selectedCategory);
                        context.SaveChanges();
                        MessageBox.Show($"Delete {selectedCategory.CategoryName} successfully", "Delete category");
                        LoadCategoryList();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a category to delete", "Delete category");
                }
            }catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Delete category");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
