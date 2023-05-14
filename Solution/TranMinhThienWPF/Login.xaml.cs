using System;
using System.Windows;
using System.Windows.Input;
using Repositories.Implementation;

namespace TranMinhThienWPF
{
    public partial class Login : Window
    {
        private CustomerRepository _customerRepository = new CustomerRepository();
        
        public Login()
        {
            InitializeComponent();
        }

        private void OnClickLogin(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = _customerRepository.Login(Email.Text, Password.Password.ToString());
                if (user != null)
                {
                    if (user.CustomerId == -1)
                    {
                        
                        MessageBox.Show("Hello Admin", "Hi");
                    }
                    else
                    {
                        CustomerView customerView = new CustomerView(user);
                        customerView.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong email or password", "Alert");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR");
            }
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // click to drag form to anywhere
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}