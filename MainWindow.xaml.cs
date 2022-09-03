using fikriye.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fikriye
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //context ve login classlarımızdan nesne ürettik.
            Context c = new Context(); 
            Login log = new Login();

            //usr ve ps adında iki değişken oluşturup bunlara login sayfasında ki textboxlarımıza girilen veriyi atadık.
            string usr = txt_username.Text;
            string ps = txt_pass.Password.ToString(); //passwordbox kullandıgımız için girilen şifreyi stringe çevirmesini söyledik.

            bool found = c.logins.Any(user => user.username == usr && user.password == ps);//girilen degerler veritabanımızdaki deger ile aynı ise true degeri döndürüyoruz.

            if (found) 
            {
                //deger true ise mainpage e yönlendirme yapıyouruz.
                MainPage fm = new MainPage();
                fm.Show();
                this.Hide(); //hide metodu ilede yönlendirlen sayfaya girdkten sonra login sayfasını kapatıyoruz
            }
            else
            {
                MessageBox.Show("error");
            }

        }
    }
}
