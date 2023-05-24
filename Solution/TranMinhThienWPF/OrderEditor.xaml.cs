using System;
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
        private void ShowAllOrderDetail()
        {
            OrderDetailView.ItemsSource = null;
            OrderDetailView.ItemsSource = _listOrderDetail;
            decimal totalPrice = 0;
            foreach (var orderDetail in _listOrderDetail)
            {
                totalPrice += (orderDetail.UnitPrice + decimal.Parse(orderDetail.Quantity.ToString()));
            }
            
            TotalPrice.Text = totalPrice.ToString();
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
            ShipDate.DisplayDateStart = DateTime.Now;
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
            int ?customerId = CustomerName.SelectedIndex > 1
                ? _listCustomer[CustomerName.SelectedIndex].CustomerId
                : null;

            
            var orderId = _orderRepository.AddOrder(customerId, ShipDate.SelectedDate, TotalPrice.Text, "Shipping",
                out var message);
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "ERROR");
                return;
            }

            foreach (var orderDetail in _listOrderDetail)
            {
                orderDetail.OrderId = orderId;
            }

            try
            {
                _orderDetailRepository.AddOrderDetails(_listOrderDetail);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR");
                return;
            }
            
            MessageBox.Show("Create successfully");
        }

        private void OnClickCancel(object sender, RoutedEventArgs e)
        {
           
        }

        private void OnChangeSelectedFlower(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void OnClickRemove(object sender, RoutedEventArgs e)
        {
            if (FlowerView.SelectedIndex != -1)
            {
                foreach (var orderDetail in _listOrderDetail)
                {
                    if (orderDetail.FlowerBouquetId == _listFlowerBouquets[FlowerView.SelectedIndex].FlowerBouquetId)
                    {
                        orderDetail.Quantity--;
                        break;
                    }
                }
            }

            OrderDetail removeItem = null;
            foreach (var orderDetail in _listOrderDetail)
            {
                if (orderDetail.Quantity <= 0)
                {
                    removeItem = orderDetail;
                }
            }

            if (removeItem != null)
            {
                _listOrderDetail.Remove(removeItem);
            }
        
     
            ShowAllOrderDetail();
        }

        private void OnClickAdd(object sender, RoutedEventArgs e)
        {
            if (FlowerView.SelectedIndex != -1)
            {
                foreach (var orderDetail in _listOrderDetail)
                {
                    if (orderDetail.FlowerBouquetId == _listFlowerBouquets[FlowerView.SelectedIndex].FlowerBouquetId)
                    {
                        orderDetail.Quantity++;
                        ShowAllOrderDetail();
                        return;
                    }
                }
                _listOrderDetail.Add(new OrderDetail()
                {
                    Discount = 0,
                    FlowerBouquetId = _listFlowerBouquets[FlowerView.SelectedIndex].FlowerBouquetId,
                    OrderId = -1,
                    UnitPrice = _listFlowerBouquets[FlowerView.SelectedIndex].UnitPrice,
                    Quantity = 1
                });
            }

            ShowAllOrderDetail();

        }

        private void OnClickRemoveAll(object sender, RoutedEventArgs e)
        {
            _listOrderDetail = new List<OrderDetail>();
            ShowAllOrderDetail();
        }

        private void OnClickRemoveOne(object sender, RoutedEventArgs e)
        {
          
        }
        private void OnChangeSelectedDetails(object sender, SelectionChangedEventArgs e)
        {
           
        }
        #endregion

        
    }
}