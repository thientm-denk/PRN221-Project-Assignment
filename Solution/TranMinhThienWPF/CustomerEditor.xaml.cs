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
        }

        public CustomerEditor(Customer? customer)
        {
            InitializeComponent();
            if (customer != null)
            {
                Title.Text = "Customer Update";
                _isUpdate = true;
                _updateCustomer = customer;
            }
            else
            {
                Title.Text = "Customer Creator";
            }
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