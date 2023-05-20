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

        private Customer _user;
        private List<Order> _orders = new List<Order>();
        private List<OrderDetail> _orderDetails = new List<OrderDetail>();
        private List<FlowerBouquet> _flowerBouque = new List<FlowerBouquet>();
        private IOrderRepository _orderRepository = new OrderRepository();
        private IOrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
        private IFlowerBouquetRepository _flowerBouquetRepository = new FlowerBouquetRepository();

        private int _orderSlectedIndex = -1;
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
        private void UpdateOrderDetailListView()
        {
            var viewModel = new List<OrderDetailViewModel>();
            foreach (OrderDetail detail in _orderDetails)
            {
                viewModel.Add(new(detail.OrderId, GetFlowerName(detail.FlowerBouquetId), detail.UnitPrice, detail.Quantity, detail.Discount));
            }

            OrderDetailView.ItemsSource = viewModel;
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
        private void LoadDataOrderDetail()
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
                return name ?? "";
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
        private void OnChangeSelectedOrder(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(_orderSlectedIndex != OrderView.SelectedIndex)
            {
                _orderSlectedIndex = OrderView.SelectedIndex;
                LoadDataOrderDetail();
            }
         
        }
        #endregion


    }


    public class OrderDetailViewModel{
        public int OrderId { get; set; }
        public string FlowerBouquetName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public OrderDetailViewModel(int orderId, string flowerBouquetName, decimal unitPrice, int quantity, double discount)
        {
            OrderId = orderId;
            FlowerBouquetName = flowerBouquetName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discount = discount;
        }
    }

}