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
    /// Interaction logic for product.xaml
    /// </summary>
    public partial class product : Window
    {
        public product()
        {
            InitializeComponent();
            LoadGrid();
        }
        public void LoadGrid()
        {
            Context c = new Context();
            var values = c.employees.ToList();
            datagrid2.ItemsSource = values;
        }

        private void btn_med_save_Click(object sender, RoutedEventArgs e)
        {
            Context c = new Context();
            Employee emp = new Employee();

            emp.employe_name = txt_name.Text;
            emp.age = txt_age.Text;
            emp.department = txt_department.Text;
            emp.phone_number = txt_phone.Text;


            c.employees.Add(emp);
            c.SaveChanges();

            txt_age.Clear();
            txt_department.Clear();
            txt_phone.Clear();
            txt_name.Clear();

            var values = c.employees.ToList();

            LoadGrid();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            Context c = new Context();
            int idtxt = Convert.ToInt16(txt_id.Text);
            var value = c.employees.Find(idtxt);
            c.employees.Remove(value);
            c.SaveChanges();
            txt_id.Clear();
            LoadGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Context c = new Context();
            int idtxt = Convert.ToInt16(txt_id.Text); //int veri tipinde idtxt değişkeni olusturup id gir textboxına girilen degeri integera convert edip atadık
            var value = c.employees.Find(idtxt); //var veri tipinde value degiskeni olusturup, c nesnesi ile publisher tablomuza erişip find metodu ile idtxt degerini aradık
            //ve value ya atamış olduk.
            txt_name.Text = value.employe_name; //textboxlarımıza o id ye ait bilgilerin getirilmesibi sağladık.
            txt_phone.Text = value.phone_number;
            txt_department.Text = value.department;
            txt_age.Text = value.age;

            c.employees.Update(value); //c nesnesi ile publishers tablomuza erişip update metodu ile güncelledik.
            c.SaveChanges();//savechange metodu ile işlemleri kaydettik.
            txt_id.Clear();//id gir textboımızı temizledik.
            LoadGrid();//tablomuzun son halini gösterdik
        }
    }
}
