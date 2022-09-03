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
    /// Interaction logic for medicine.xaml
    /// </summary>
    public partial class medicine : Window
    {
        public medicine()
        {
            InitializeComponent();
            LoadGrid();
        }
        public void LoadGrid() //loadgrid fonksiyonu olusturup 
        {
            Context c = new Context(); //context sınııfan nesne olsturduk
            var values = c.medicines.ToList();//c nesnesi ile medicine tablosuna erişip tüm degerleri tolist ile cekiyoruz ve values a atıyroruz.
            datagrid1.ItemsSource = values; //datagrid tablousundaki deger yerlerine cektigimiz verileri atıyoruz.
        }


        private void btn_med_save_Click(object sender, RoutedEventArgs e)
        {
            Context c = new Context(); //context sınııfan nesne olsturduk
            Medicine med = new Medicine(); //medicine sınııfan nesne olsturduk

            med.med_name = txt_medicine_name.Text; //medicine classımızdaki degerlerimize textboxlarla girilen degerleri atıyoruz.
            med.med_price = txt_medicen_price.Text;
            med.med_miligram = txt_medicine_mg.Text;
            med.usage_area = txt_medicine_area.Text;


            c.medicines.Add(med);//add metodu ile medicine tablosuna bu verileri insert ettik.
            c.SaveChanges();//degisiklikleri kaydettik


            txt_medicine_name.Clear();//textboxları temizledik
            txt_medicen_price.Clear();
            txt_medicine_mg.Clear();
        
            var values = c.medicines.ToList();

            LoadGrid();//loadgrid fonk cagırdık bu sekilde son tablo halini ekranda gösterdik

        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            Context c = new Context();
            int idtxt = Convert.ToInt16(txt_id.Text);//int veri tipinde idtxt değişkeni olusturup id gir textboxına girilen degeri integera convert edip atadık
            var value = c.medicines.Find(idtxt);//var veri tipinde value degiskeni olusturup, c nesnesi ile publisher tablomuza erişip find metodu ile idtxt degerini aradık ve value ya atadık
            c.medicines.Remove(value); //bu value degerinide sonra remove metodu ile sildik 
            c.SaveChanges();//degisiklikleri kaydedip
            txt_id.Clear();//textboxtımızı temizleidk
            LoadGrid();//ve son tablo halini ekranda gösterdik.
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Context c = new Context();
            int idtxt = Convert.ToInt16(txt_id.Text); //int veri tipinde idtxt değişkeni olusturup id gir textboxına girilen degeri integera convert edip atadık
            var value = c.medicines.Find(idtxt); //var veri tipinde value degiskeni olusturup, c nesnesi ile publisher tablomuza erişip find metodu ile idtxt degerini aradık
            //ve value ya atamış olduk.
            txt_medicine_name.Text = value.med_name; //textboxlarımıza o id ye ait bilgilerin getirilmesibi sağladık.
            txt_medicine_mg.Text = value.med_miligram;
            txt_medicine_area.Text = value.usage_area;
            txt_medicen_price.Text = value.med_price;

            c.medicines.Update(value); //c nesnesi ile publishers tablomuza erişip update metodu ile güncelledik.
            c.SaveChanges();//savechange metodu ile işlemleri kaydettik.
            txt_id.Clear();//id gir textboımızı temizledik.
            LoadGrid();//tablomuzun son halini gösterdik
        }
    }
}
