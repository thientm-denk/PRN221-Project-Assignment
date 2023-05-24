using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using BussinessObject.Models;
using Repositories;
using Repositories.Implementation;

namespace TranMinhThienWPF
{
    public partial class OrderEditor : Window
    {
        private readonly bool _isUpdate;
        private Order? _updateOrder;
        private List<FlowerBouquet> _listFlowerBouquets = new();
        private List<Customer> _listCustomer = new();
        private List<OrderDetail> _listOrderDetail = new();
        private ICustomerRepository _customerRepository = new CustomerRepository();
        private IFlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepository();
        private IOrderRepository _orderRepository = new OrderRepository();
        private IOrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
        
        public OrderEditor()
        {
            InitializeComponent();
            _updateOrder = null;
            _isUpdate = false;
        }
    
        public OrderEditor(Order updateOrder)
        {
            InitializeComponent();
            _updateOrder = updateOrder;
            _isUpdate = true;
        }

        private void ShowAllFlower()
        {
            FlowerView.ItemsSource = _listFlowerBouquets;
        }
        private void ShowAllCustomer()
        {
            CustomerName.Items.Add("None");
            foreach (var customer in _listCustomer)
            {
                CustomerName.Items.Add(customer.CustomerName);
            }
            
        }
        #region Controller

        private void LoadFlower()
        {
            _listFlowerBouquets = _flowerBouquetRepository.GetAllFlower();
        }
        private void LoadCustomer()
        {
            _listCustomer = _customerRepository.GetAllCustomer();
        }
        private void LoadOderDetails()
        {
            
        }
        #endregion

        #region Event
        private void Awake(object sender, RoutedEventArgs e)
        {
            LoadCustomer();
            LoadFlower();
            LoadOderDetails();
            ShowAllCustomer();
            ShowAllFlower();
            if (_isUpdate)
            {
                LoadOderDetails();
            }
            else
            {
                
            }
        }
        private void OnClickSubmit(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnClickCancel(object sender, RoutedEventArgs e)
        {
           
        }

        private void OnChangeSelectedFlower(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void OnClickRemove(object sender, RoutedEventArgs e)
        {
           
        }

        private void OnClickAdd(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnClickRemoveAll(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnClickRemoveOne(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
        private void OnChangeSelectedDetails(object sender, SelectionChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        
    }
}