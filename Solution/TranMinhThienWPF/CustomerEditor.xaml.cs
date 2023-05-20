using BussinessObject.Models;
using System.Text.RegularExpressions;
using System.Windows;
using Repositories;
using Repositories.Implementation;


namespace TranMinhThienWPF
{
    /// <summary>
    /// Interaction logic for CustomerEditor.xaml
    /// </summary>
    public partial class CustomerEditor : Window
    {
        private Customer _updateCustomer;

        private bool _isUpdate;

        private ICustomerRepository _customerRepository = new CustomerRepository();

        public CustomerEditor()
        {
            InitializeComponent();
            InitCreateView();
        }

        public CustomerEditor(Customer? customer)
        {
            InitializeComponent();
            if (customer != null)
            {
                Title.Text = "Customer Update";
                _isUpdate = true;
                InitUpdateView();
                _updateCustomer = customer;
            }
            else
            {
                InitCreateView();
                Title.Text = "Customer Creator";
            }
        }
        private void InitCreateView()
        {
            OldPassword.Visibility = Visibility.Collapsed;
            OldPasswordText.Visibility = Visibility.Collapsed;
            CreateSms1.Visibility = Visibility.Visible;
            CreateSms2.Visibility = Visibility.Visible;
            CreateSms3.Visibility = Visibility.Visible;
            UpdateSms1.Visibility = Visibility.Collapsed;
            UpdateSms2.Visibility = Visibility.Collapsed;
            UpdateSms3.Visibility = Visibility.Collapsed;
        }
        private void InitUpdateView()
        {
            OldPassword.Visibility = Visibility.Visible;
            OldPasswordText.Visibility = Visibility.Visible;
            CreateSms1.Visibility = Visibility.Collapsed;
            CreateSms2.Visibility = Visibility.Collapsed;
            CreateSms3.Visibility = Visibility.Collapsed;
            UpdateSms1.Visibility = Visibility.Visible;
            UpdateSms2.Visibility = Visibility.Visible;
            UpdateSms3.Visibility = Visibility.Visible;
        }

        #region Event

        private void OnClickSubmit(object sender, RoutedEventArgs e)
        {
            if (_isUpdate)
            {
                UpdateCustomer();
                return;
            }

            CreateCustomer();

        }

        #endregion

        #region Validation information

        private void UpdateCustomer()
        {
            
        }
        private void CreateCustomer()
        {
            var message = _customerRepository.CreateCustomer(Email.Text, Password.Password, ConfirmPassword.Password,
                Name.Text, City.Text, Country.Text, null);
            if (!string.IsNullOrEmpty(message)) // ERROR
            {
                MessageBox.Show(message, "ERROR");
                return;
            }
            
            // SUCCESS, Do something
            
        }
        #endregion
    }
}