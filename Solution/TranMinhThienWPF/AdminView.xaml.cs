using BussinessObject.Models;
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
        private ShowName _currentShow = ShowName.Customer;
        private ICustomerRepository _customerRepository = new CustomerRepository();
        private List<Customer> _listCustomer = new();

        private int _indexSelect = -1;

        public AdminView()
        {
            InitializeComponent();
        }

        #region View Manager

        private void OnClickCustomer(object sender, RoutedEventArgs e)
        {
            if (_currentShow != ShowName.Customer)
            {
                ResetDisplay();
                CustomerBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                _currentShow = ShowName.Customer;
                CustomerManagement.Visibility = Visibility.Visible;
                ShowAllCustomer();
            }
        }

        private void OnClickOder(object sender, RoutedEventArgs e)
        {
            if (_currentShow != ShowName.Order)
            {
                ResetDisplay();
                OrderBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                _currentShow = ShowName.Order;
            }
        }

        private void OnClickFlowerBouquet(object sender, RoutedEventArgs e)
        {
            if (_currentShow != ShowName.Flower)
            {
                ResetDisplay();
                FlowerBouquetBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                _currentShow = ShowName.Flower;
            }
        }

        private void ResetDisplay()
        {
            switch (_currentShow)
            {
                case ShowName.Customer:
                {
                    CustomerBtn.Style = (Style)Application.Current.Resources["MenuBtn"];
                    CustomerManagement.Visibility = Visibility.Collapsed;
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

        #endregion

        #region Customer Manager

        private void ShowAllCustomer()
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

        #endregion

        #region Event

        // CUSTOMER
        private void OnChangeSelectedCustomer(object sender, SelectionChangedEventArgs e)
        {
            _indexSelect = CustomerView.SelectedIndex;
        }

        private void OnClickShowAllCustomer(object sender, RoutedEventArgs e)
        {
            ShowAllCustomer();
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
                        ShowAllCustomer();
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
            ShowAllCustomer();
            _indexSelect = -1;
            CustomerView.SelectedIndex = -1;
        }

        private void OnFinishUpdateCustomer(Customer? newCustomer)
        {
            Show();
            ShowAllCustomer();
            _indexSelect = -1;
            CustomerView.SelectedIndex = -1;
        }

        #endregion
    }
}