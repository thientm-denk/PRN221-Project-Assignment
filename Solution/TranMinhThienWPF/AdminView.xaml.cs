﻿using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Repositories;
using Repositories.Implementation;

namespace TranMinhThienWPF
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    /// 
    public partial class AdminView : Window
    {
        private ShowName _currentShow;
        // Customer
        private ICustomerRepository _customerRepository = new CustomerRepository();
        private List<Customer> _listCustomer = new();
        
        // Flower
        private IFlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepository();
        private List<FlowerBouquet> _listFlower = new ();
        
        // Order
        private List<Order> _listOrder = new();
        private List<OrderDetail> _listOrderDetails = new();
        private readonly IOrderRepository _orderRepository = new OrderRepository();
        private readonly IOrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
        
        private int _indexSelect = -1;

        public AdminView()
        {
            InitializeComponent();
            ResetDisplay();
            CustomerBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
            _currentShow = ShowName.Customer;
            CustomerManagement.Visibility = Visibility.Visible;
            LoadAndShowAllCustomer();
        }

        #region View Manager
        // View event
        private void OnClickCustomer(object sender, RoutedEventArgs e)
        {
            if (_currentShow != ShowName.Customer)
            {
                ResetDisplay();
                CustomerBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                _currentShow = ShowName.Customer;
                CustomerManagement.Visibility = Visibility.Visible;
                LoadAndShowAllCustomer();
            }
        }

        private void OnClickOder(object sender, RoutedEventArgs e)
        {
            if (_currentShow != ShowName.Order)
            {
                ResetDisplay();
                OrderBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                _currentShow = ShowName.Order;
                OrderManagement.Visibility = Visibility.Visible;
                LoadDataOrder();
                ShowOrder();
            }
        }

        private void OnClickFlowerBouquet(object sender, RoutedEventArgs e)
        {
            if (_currentShow != ShowName.Flower)
            {
                ResetDisplay();
                FlowerBouquetBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                FlowerManagement.Visibility = Visibility.Visible;
                _currentShow = ShowName.Flower;
                LoadAndShowAllFlower();
            }
        }

        private void ResetDisplay()
        {
            CustomerManagement.Visibility = Visibility.Collapsed;
            OrderManagement.Visibility = Visibility.Collapsed;
            FlowerManagement.Visibility = Visibility.Collapsed;
            _indexSelect = -1;
            switch (_currentShow)
            {
                case ShowName.Customer:
                {
                    CustomerBtn.Style = (Style)Application.Current.Resources["MenuBtn"];
                    CustomerView.SelectedIndex = -1;
                    break;
                }
                case ShowName.Order:
                {
                    OrderBtn.Style = (Style)Application.Current.Resources["MenuBtn"];
                    break;
                }
                case ShowName.Flower:
                {
                    FlowerBouquetBtn.Style = (Style)Application.Current.Resources["MenuBtn"];
                    FlowerView.SelectedIndex = -1;
                    break;
                }
            }
        }

        private enum ShowName
        {
            Customer,
            Order,
            Flower
        }
        
        // Oder

        private void ShowOrderDetail()
        {
            var viewModel = new List<OrderDetailViewModel>();
            foreach (OrderDetail detail in _listOrderDetails)
            {
                viewModel.Add(new(detail.OrderId, GetFlowerName(detail.FlowerBouquetId), detail.UnitPrice, detail.Quantity, detail.Discount));
            }

            OrderDetailView.ItemsSource = viewModel;
        }
        private void ShowOrder()
        {
            OrderView.ItemsSource = _listOrder;
        }
        
        #endregion

        #region Controller
        private void LoadDataOrder()
        {
            try
            {
                _listOrder = _orderRepository.GetAllOrders();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }
    
        private string GetFlowerName(int id)
        {
            try
            {
                var name = _flowerBouquetRepository.GetFlowerName(id);
                return name;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
                return "";
            }
            
        }
        private void LoadDataOrderDetail(int id)
        {
            try
            {
                _listOrderDetails = _orderDetailRepository.GetOrderDetailById(id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }
        private void ShowAllFlower()
        {
            try
            {
                FlowerView.ItemsSource = _listFlower;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }
        private void ShowAllCustomer()
        {
            try
            {
                CustomerView.ItemsSource = _listCustomer;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }
        private void LoadAndShowAllCustomer()
        {
            try
            {
                _listCustomer = _customerRepository.GetAllCustomer();
                CustomerView.ItemsSource = _listCustomer;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        private void LoadAndShowAllFlower()
        {
            try
            {
                _listFlower = _flowerBouquetRepository.GetAllFlower();
                FlowerView.ItemsSource = _listFlower;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }
        #endregion

        #region CUSTOMER Event
        private void OnClickSearchCustomer(object sender, RoutedEventArgs routedEventArgs)
        {
            try
            {
                _listCustomer = _customerRepository.FindCustomer(4, SearchValueCustomer.Text);
                ShowAllCustomer();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR");
            }
        }

        private void OnChangeSelectedCustomer(object sender, SelectionChangedEventArgs e)
        {
            _indexSelect = CustomerView.SelectedIndex;
        }

        private void OnClickShowAllCustomer(object sender, RoutedEventArgs e)
        {
            LoadAndShowAllCustomer();
        }

        private void OnClickDeleteCustomer(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                MessageBoxResult result =
                    MessageBox.Show("Are you sure to delete " + _listCustomer[_indexSelect].CustomerName,
                        "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _customerRepository.DeleteCustomer(_listCustomer[_indexSelect].CustomerId);
                        MessageBox.Show("Delete successfully ", "Notification");
                        LoadAndShowAllCustomer();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Delete fail: " + exception.Message, "ERROR");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an customer", "Warning");
            }
        }

        private void OnClickUpdateCustomer(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                CustomerEditor customerEditor = new CustomerEditor(_listCustomer[_indexSelect], OnFinishUpdateCustomer);
                customerEditor.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Please select an customer", "Warning");
            }
        }

        private void OnClickAddNewCustomer(object sender, RoutedEventArgs e)
        {
            CustomerEditor customerEditor = new CustomerEditor(null, OnFinishCreateCustomer);
            customerEditor.Show();
            Hide();
        }

        private void OnFinishCreateCustomer(Customer? newCustomer)
        {
            Show();
            LoadAndShowAllCustomer();
            _indexSelect = -1;
            CustomerView.SelectedIndex = -1;
        }

        private void OnFinishUpdateCustomer(Customer? newCustomer)
        {
            Show();
            LoadAndShowAllCustomer();
            _indexSelect = -1;
            CustomerView.SelectedIndex = -1;
        }

        #endregion

        #region Flower Event
        private void OnClickSearchFlower(object sender, RoutedEventArgs routedEventArgs)
        {
            try
            {
                _listFlower = _flowerBouquetRepository.FindFlower(0, SearchValueFlower.Text);
                ShowAllFlower();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR");
            }
        }

        private void OnClickShowAllFlower(object sender, RoutedEventArgs e)
        {
            LoadAndShowAllFlower();
        }

        private void OnClickDeleteFlower(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                MessageBoxResult result =
                    MessageBox.Show("Are you sure to delete " + _listFlower[_indexSelect].FlowerBouquetName,
                        "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _flowerBouquetRepository.DeleteFlower(_listFlower[_indexSelect].FlowerBouquetId);
                        MessageBox.Show("Delete successfully ", "Notification");
                        LoadAndShowAllFlower();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Delete fail: " + exception.Message, "ERROR");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an customer", "Warning");
            }
        }

        private void OnClickUpdateFlower(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                FlowerEditor flowerEditor = new FlowerEditor(_listFlower[_indexSelect], OnFinishEditFlower);
                flowerEditor.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Please select a flower", "Warning");
            }
        }

        private void OnClickAddNewFlower(object sender, RoutedEventArgs e)
        {
            FlowerEditor flowerEditor = new FlowerEditor(null, OnFinishEditFlower);
            flowerEditor.Show();
            Hide();
        }

        private void OnFinishEditFlower()
        {
            Show();
            LoadAndShowAllFlower();
            _indexSelect = -1;
            FlowerView.SelectedIndex = -1;
        }

        private void OnSelectionChangedFlower(object sender, SelectionChangedEventArgs e)
        {
            _indexSelect = FlowerView.SelectedIndex;
        }
        #endregion


        #region Order Event

        private void OnChangeSelectedOrder(object sender, SelectionChangedEventArgs e)
        {
            if(_indexSelect != OrderView.SelectedIndex)
            {
               
                _indexSelect = OrderView.SelectedIndex;
                LoadDataOrderDetail(_listOrder[_indexSelect].OrderId);
                ShowOrderDetail();
            }
        }
        
        private void OnClickSearchOrder(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnClickShowAllOrder(object sender, RoutedEventArgs e)
        {
            LoadDataOrder();
            ShowOrder();
        }

        private void OnClickDeleteOrder(object sender, RoutedEventArgs e)
        {
            if (_indexSelect != -1)
            {
                MessageBoxResult result =
                    MessageBox.Show("Are you sure to delete " + _listOrder[_indexSelect].OrderId,
                        "Confirm delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _flowerBouquetRepository.DeleteFlower(_listFlower[_indexSelect].FlowerBouquetId);
                        MessageBox.Show("Delete successfully ", "Notification");
                        LoadAndShowAllFlower();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Delete fail: " + exception.Message, "ERROR");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an customer", "Warning");
            }
        }

        private void OnClickUpdateOrder(object sender, RoutedEventArgs e)
        {
            
        }

        private void OnClickAddNewOrder(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion

     
    }
}