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

namespace fikriye
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void calisan_btn_Click(object sender, RoutedEventArgs e)
        {
            medicine cls = new medicine();  //medicine penceresinden nesne üretip show metodu ile gösterdik.
            cls.Show();
        }

        private void recete_btn_Click(object sender, RoutedEventArgs e)
        {
            product pr = new product();
            pr.Show();
        }

        private void is_btn_Click(object sender, RoutedEventArgs e)
        {
            stock st = new stock();
            st.Show();
        }
    }
}
