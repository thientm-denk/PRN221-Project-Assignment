using System;
using System.Collections.Generic;
using System.Windows;
using BussinessObject.Models;
using Repositories;
using Repositories.Implementation;

namespace TranMinhThienWPF
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Window
    {
        #region Attributes

        private Customer          _user;
        private List<Order>       _orders = new List<Order>();
        private List<OrderDetail> _orderDetails = new List<OrderDetail>();
        private List<FlowerBouquet>   _flowerBouque = new List<FlowerBouquet>();
        private IOrderRepository _orderRepository = new OrderRepository();
        private IOrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
        private IFlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepository();

        #endregion
        
        public CustomerView(Customer user)
        {
            InitializeComponent();
            _user = user;
            UserDisplayName.Text = user.CustomerName;
            
            LoadDataOrder();
            UpdateOrderListView();
        }

        private void UpdateOrderListView()
        {
            if (_orders != null)
            {
                OrderView.ItemsSource = _orders;
            }
            else
            {
                MessageBox.Show("You do not have any order", "Message");
            }
            
        }
        
        #region Repositories interaction

        private void LoadDataOrder()
        {
            try
            {
                _orders = _orderRepository.GetOrdersByCustomer(_user.CustomerId);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }
        private void LoadDataOrderDetail(int id)
        {
            try
            {
                _orderDetails = _orderDetailRepository.GetOrderDetailById(_user.CustomerId);
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

        #endregion
        
        #region Event

        private void OnClickUpdate(object sender, RoutedEventArgs e)
        {
        }

        #endregion
    }
}