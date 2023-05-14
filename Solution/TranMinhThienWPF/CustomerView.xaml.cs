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

namespace TranMinhThienWPF
{
    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : Window
    {
        private Customer _user;

        public CustomerView(Customer user)
        {
            _user = user;
            InitializeComponent();
        }

        private void OnClickUpdate(object sender, RoutedEventArgs e)
        {

        }
        
        
    }
}
