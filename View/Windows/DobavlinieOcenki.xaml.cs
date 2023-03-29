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
    /// Логика взаимодействия для DobavlinieOcenki.xaml
    /// </summary>
    public partial class DobavlinieOcenki : Window
    {
        public DobavlinieOcenki()
        {
            InitializeComponent();
            AppData.ModelHelper.entities = new Models.Koshevoi_3isEntities();
            GridOcenki.ItemsSource = AppData.ModelHelper.entities.Ocenki.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(TbOcenka.Text))
                mes += "Введите оценку\n";


            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Models.Ocenki ocenki = new Models.Ocenki()
            {
                Ocenka = TbOcenka.Text,

            };

            AppData.ModelHelper.entities.Ocenki.Add(ocenki);
            AppData.ModelHelper.entities.SaveChanges();
            MessageBox.Show("Добавлено");
            TbOcenka.Text = "";
            GridOcenki.ItemsSource = AppData.ModelHelper.entities.Ocenki.ToList();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
