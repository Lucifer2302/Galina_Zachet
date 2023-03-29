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

namespace Koshevoi_Jurnal.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для DobavlenieStudenta.xaml
    /// </summary>
    public partial class DobavlenieStudenta : Window
    {
        public DobavlenieStudenta()
        {
            InitializeComponent();
            AppData.ModelHelper.entities = new Models.Koshevoi_3isEntities();
            GridStudent.ItemsSource = AppData.ModelHelper.entities.Student.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(TbFam.Text))
                mes += "Введите колчиество этажей\n";
            if (string.IsNullOrWhiteSpace(TbIma.Text))
                mes += "Выберите дату поставки\n"; 
            if (string.IsNullOrWhiteSpace(TbOtche.Text))
                mes += "Выберите дату поставки\n";

            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }



            Models.Student student = new Models.Student()
            {
                Familiya = TbFam.Text,
                Ima = TbIma.Text,
                Otchestvo = TbOtche.Text,


            };

            AppData.ModelHelper.entities.Student.Add(student);
            AppData.ModelHelper.entities.SaveChanges();
            MessageBox.Show("Добавлено");
            TbFam.Text = ""; 
            TbIma.Text = "";
            TbOtche.Text = "";

            GridStudent.ItemsSource = AppData.ModelHelper.entities.Student.ToList();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
