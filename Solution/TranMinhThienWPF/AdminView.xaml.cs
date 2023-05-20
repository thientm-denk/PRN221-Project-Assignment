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
    /// Interaction logic for AdminView.xaml
    /// </summary>
    /// 
    public partial class AdminView : Window
    {
        private ShowName currentShow = ShowName.Customer;

        public AdminView()
        {
            InitializeComponent();
        }

        private void OnClickUpdate(object sender, RoutedEventArgs e)
        {

        }
        private void OnClickCustomer(object sender, RoutedEventArgs e)
        {
            if (currentShow != ShowName.Order)
            {
                ResetDisplay();
                CustomerBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                currentShow = ShowName.Customer;
            }
        }
        private void OnClickOder(object sender, RoutedEventArgs e)
        {
            if (currentShow != ShowName.Order)
            {
                ResetDisplay();
                OrderBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                currentShow = ShowName.Order;
            }

        }
        private void OnClickFlowerBouquet(object sender, RoutedEventArgs e)
        {
            if(currentShow != ShowName.Flower)
            {
                ResetDisplay();
                FlowerBouquetBtn.Style = (Style)Application.Current.Resources["MenuButtonActive"];
                currentShow = ShowName.Flower;
            }
        }

        private void ResetDisplay()
        {
            switch (currentShow)
            {
                case ShowName.Customer:
                    {
                        CustomerBtn.Style = (Style)Application.Current.Resources["MenuBtn"];
                   
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
       
        private enum ShowName{
            Customer,
            Order,
            Flower
        }
      
    }
}
