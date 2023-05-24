using System.Windows;
using System.Windows.Controls;
using BussinessObject.Models;

namespace TranMinhThienWPF
{
    public partial class OrderEditor : Window
    {
        private readonly bool _isUpdate;
        private Order? _updateOrder;
        
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
        private void Awake(object sender, RoutedEventArgs e)
        {
            if (_isUpdate)
            {
                
            }
            else
            {
                
            }
        }

        #region Event

        private void OnClickSubmit(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnClickCancel(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnChangeSelectedOrder(object sender, SelectionChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void OnClickRemove(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
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

        #endregion
    }
}