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
using System.Windows.Shapes;

namespace fikriye
{
    /// <summary>
    /// Interaction logic for stock.xaml
    /// </summary>
    public partial class stock : Window
    {
        public stock()
        {
            InitializeComponent();
            LoadGrid();
        }
        public void LoadGrid()
        {
            Context c = new Context();
            var values = c.stock__Trackings.ToList();
            datagrid2.ItemsSource = values;
        }

        private void btn_med_save_Click(object sender, RoutedEventArgs e)
        {
            Context c = new Context();
            Stock__tracking st = new Stock__tracking();

            st.name = txt_name.Text;
            st.quantity= txt_quantitty.Text;
            st.unit_price= txt_price.Text;
            st.barcode = txt_barcode.Text;


            c.stock__Trackings.Add(st);
            c.SaveChanges();

            txt_barcode.Clear();
            txt_name.Clear();
            txt_price.Clear();
            txt_quantitty.Clear();

            var values = c.stock__Trackings.ToList();

            LoadGrid();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            Context c = new Context();
            int idtxt = Convert.ToInt16(txt_id.Text);
            var value = c.stock__Trackings.Find(idtxt);
            c.stock__Trackings.Remove(value);
            c.SaveChanges();
            txt_id.Clear();
            LoadGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Context c = new Context();
            int idtxt = Convert.ToInt16(txt_id.Text); //int veri tipinde idtxt değişkeni olusturup id gir textboxına girilen degeri integera convert edip atadık
            var value = c.stock__Trackings.Find(idtxt); //var veri tipinde value degiskeni olusturup, c nesnesi ile publisher tablomuza erişip find metodu ile idtxt degerini aradık
            //ve value ya atamış olduk.
            txt_name.Text = value.name; //textboxlarımıza o id ye ait bilgilerin getirilmesibi sağladık.
            txt_quantitty.Text = value.quantity;
            txt_price.Text = value.unit_price;
            txt_barcode.Text = value.barcode;

            c.stock__Trackings.Update(value); //c nesnesi ile publishers tablomuza erişip update metodu ile güncelledik.
            c.SaveChanges();//savechange metodu ile işlemleri kaydettik.
            txt_id.Clear();//id gir textboımızı temizledik.
            LoadGrid();//tablomuzun son halini gösterdik
        }
    }
}
