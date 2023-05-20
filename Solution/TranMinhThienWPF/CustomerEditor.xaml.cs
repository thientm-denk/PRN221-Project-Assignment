using BussinessObject.Models;
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

namespace TranMinhThienWPF
{
    /// <summary>
    /// Interaction logic for CustomerEditor.xaml
    /// </summary>
    public partial class CustomerEditor : Window
    {
       private Customer _updateCustomer;

        public CustomerEditor()
        {
            InitializeComponent();
        }

        public CustomerEditor(Customer? customer)
        {
            InitializeComponent();
            if (customer != null)
            {
                _updateCustomer = customer;
            }
        }
    }
}
