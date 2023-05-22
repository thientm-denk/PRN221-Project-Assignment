using System;
using System.Collections.Generic;
using System.Windows;
using BussinessObject.Models;
using Repositories;
using Repositories.Implementation;

namespace TranMinhThienWPF
{
    public partial class FlowerEditor : Window
    {
        private Action _onFinish;
        private FlowerBouquet _updateFlower;
        private bool _isUpdate;
        private IFlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepository();
        private ICategoryRepository _categoryRepository = new CategoryRepository();
        private ISupplierRepository _supplierRepository = new SupplierRepository();

        private List<Category> _categories = new();
        private List<Supplier> _suppliers = new();
        public FlowerEditor()
        {
            InitializeComponent();
            InitCategoryComboBox();
            InitSupplierComboBox();
        }
        public FlowerEditor(FlowerBouquet ?updateFlower, Action onFinishUpdate)
        {
            InitializeComponent();
            _onFinish = onFinishUpdate;
            
            if (updateFlower != null)
            {
                _updateFlower = updateFlower;
                ShowOldInformation();
                _isUpdate = true;
            }
            else
            {
                _isUpdate = false;
            }
        }


        private void ShowOldInformation()
        {
            
        }

        private void InitSupplierComboBox()
        {
            _suppliers = _supplierRepository.GetAllSupplier();
            List<string> displayString = new List<string>();
            displayString.Add("None");
            foreach (var supplier in _suppliers)
            {
                displayString.Add(supplier.SupplierName);
            }

            Supplier.ItemsSource = displayString;
            
        }
        private void InitCategoryComboBox()
        {
            _categories = _categoryRepository.GetAllCategory();
            List<string> displayString = new List<string>();
            foreach (var category in _categories)
            {
                displayString.Add(category.CategoryName);
            }

            Category.ItemsSource = displayString;
        }
        private int GetSupplierId()
        {
            if (Supplier.SelectedIndex == -1 || Supplier.SelectedIndex == 0)
            {
                return -1;
            }
            return _suppliers[Supplier.SelectedIndex - 1].SupplierId;
        }
        private int GetCategoryId()
        {
            if (Supplier.SelectedIndex == -1)
            {
                return -1;
            }

            return _categories[Supplier.SelectedIndex].CategoryId;
        }

        private void UpdateFlower()
        {
            try
            {
                // var message = _flowerBouquetRepository.UpdateFlower(_updateFlower, 0, FlowerName.Text, FlowerDes.Text, FlowerPrice.Text, FlowerUnitsInStock.Text, 1,  0);
                // if (!string.IsNullOrEmpty(message)) // ERROR
                // {
                //     MessageBox.Show(message, "ERROR");
                //     return;
                // }
                //
                // MessageBox.Show("Update success fully");
                // _onFinish?.Invoke();
                // Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
           
        }
        private void CreateFlower()
        {
            try
            {
                // var message = _flowerBouquetRepository.CreateFlower();
                // if (!string.IsNullOrEmpty(message)) // ERROR
                // {
                //     MessageBox.Show(message, "ERROR");
                //     return;
                // }
                //
                // MessageBox.Show("Update success fully");
                // _onFinish?.Invoke();
                // Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
            
        }
        
        #region Event
        private void Awake(object sender, RoutedEventArgs e)
        {
           
        }
        private void OnClickSubmit(object sender, RoutedEventArgs e)
        {
            if (_isUpdate)
            {
                UpdateFlower();
            }
            else
            {
                CreateFlower();
            }
        }
        

        #endregion
        
       

       
    }
}