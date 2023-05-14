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
using BussinessObject.Models;
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
        private List<Order> _orders;
        private List<OrderDetail> _orderDetails;
        private List<FlowerBouquet>   _flowerBouquets;
        private OrderRepository       _orderRepository;
        private OrderDetailRepository _orderDetailRepository;
        private FlowerBouquetRepository _flowerBouquetRepository;

        #endregion
        
        public CustomerView(Customer user)
        {
            _user = user;
            InitializeComponent();
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
            return "";
        }

        #endregion
        
        #region Event

        private void OnClickUpdate(object sender, RoutedEventArgs e)
        {
        }

        #endregion
    }
}