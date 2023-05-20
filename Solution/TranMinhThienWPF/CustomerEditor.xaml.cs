using BussinessObject.Models;

using System.Text.RegularExpressions;

using System.Windows;


namespace TranMinhThienWPF
{
    /// <summary>
    /// Interaction logic for CustomerEditor.xaml
    /// </summary>
    public partial class CustomerEditor : Window
    {
        private Customer _updateCustomer;

        private bool _isUpdate;

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
       
     

        private void UpdateCustomer(Customer customer)
        {
        }

        private void CreateCustomer(Customer customer)
        {
        }

        
        #region Event

        private void OnClickSubmit(object sender, RoutedEventArgs e)
        {
            ValidationInformation();
            if (_isUpdate)
            {
            }
            else
            {
            }
        }

        #endregion

        #region Validation information
        private Customer ValidationInformation()
        {
            Customer newCustomer = null;

            // Fill all the * information
            if (string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Name.Text) ||
                string.IsNullOrEmpty(City.Text) || string.IsNullOrEmpty(Country.Text) ||
                string.IsNullOrEmpty(Password.Password) || string.IsNullOrEmpty(ConfirmPassword.Password))
            {
                MessageBox.Show("Required information cannot empty", "ERROR");
                return null;
            }
            
            // Check Email
            var error = IsEmailValid(Email.Text);
            if (error != 0)
            {
                switch (error)
                {
                    case 1:
                    {
                        MessageBox.Show("Email must contain '@' character!", "Error");
                        break;
                    }
                    case 2:
                    {
                        MessageBox.Show("Email must below 50 character!", "Error");
                        break;
                    }
                    case 3:
                        MessageBox.Show("Email must not contain special character!", "Error");
                        break;
                    case 4:
                    {
                        MessageBox.Show("Email Tail not valid or email contain special character!", "Error");
                        break;
                    }
                }
                return null;
            }

            error = IsValidPassWord(Password.Password, ConfirmPassword.Password);
            if (error != 0)
            {
                switch (error)
                {
                    case 1:
                    {
                        MessageBox.Show("Passwords does not match!", "Error");
                        break;
                    }
                    case 2:
                    {
                        MessageBox.Show("Password is too short, at least 8 character!", "Error");
                        break;
                    }
                    case 3:
                    case 4:
                    {
                        MessageBox.Show("Password must contain digit and letter!", "Error");
                        break;
                    }
                }
                return null;
            }

            MessageBox.Show("Nice Information!");
            return newCustomer;
        }
        private int IsEmailValid(string input)
        {
            // check for @
            if (!input.Contains("@"))
            {
                return 1;
            }

            // check length
            if (input.Length > 50)
            {
                return 2;
            }

            // check space
            if (input.Contains(" "))
            {
                return 3;
            }

            // check for special character
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(input))
            {
                return 4;
            }

            return 0;
        } 
        private int IsValidPassWord(string pass, string confirmPass)
        {
            if (pass.Equals(confirmPass))
            {
                // Check password criteria
                if (pass.Length < 8)
                {
                    // Password is too short
                    return 2;
                }

                if (!Regex.IsMatch(pass, @"\d"))
                {
                    // Password doesn't contain a digit
                    return 3;
                }

                if (!Regex.IsMatch(pass, @"[a-zA-Z]"))
                {
                    // Password doesn't contain a letter
                    return 4;
                }

                // Additional criteria can be added as needed

                return 0; // Password is valid
            }

            return 1; // Passwords don't match
        }


        #endregion
    }
}