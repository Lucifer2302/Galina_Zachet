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
    /// Логика взаимодействия для Jurnal.xaml
    /// </summary>
    public partial class Jurnal : Window
    {
        public Jurnal()
        {
            InitializeComponent();
            AppData.ModelHelper.entities = new Models.Koshevoi_3isEntities();
            GridJurnal.ItemsSource = AppData.ModelHelper.entities.Jurnal.ToList();

            CmbFam.SelectedValuePath = "id";
            CmbFam.DisplayMemberPath = "Familiya";
            CmbFam.ItemsSource = AppData.ModelHelper.entities.Student.ToList();

            CmbDisc.SelectedValuePath = "id";
            CmbDisc.DisplayMemberPath = "Name_Disciplina";
            CmbDisc.ItemsSource = AppData.ModelHelper.entities.Disciplina.ToList();

            CmbOcen.SelectedValuePath = "id";
            CmbOcen.DisplayMemberPath = "Ocenka";
            CmbOcen.ItemsSource = AppData.ModelHelper.entities.Ocenki.ToList();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DobavlenieStudenta dobavlenieStudenta = new DobavlenieStudenta();
            dobavlenieStudenta.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DobavlinieDisciplini dobavlinieDisciplini = new DobavlinieDisciplini();
            dobavlinieDisciplini.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DobavlinieOcenki dobavlinieOcenki = new DobavlinieOcenki();
            dobavlinieOcenki.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(CmbFam.Text))
                mes += "Выберите студента\n";
            if (string.IsNullOrWhiteSpace(CmbDisc.Text))
                mes += "Выберите дисциплину\n";
            if (string.IsNullOrWhiteSpace(CmbOcen.Text))
                mes += "Выберите оценку\n"; 
            if (string.IsNullOrWhiteSpace(DtPick.Text))
                mes += "Выберите дату\n";

            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Models.Jurnal jurnal= new Models.Jurnal()
            {
                Student = CmbFam.SelectedItem as Models.Student,
                Disciplina = CmbDisc.SelectedItem as Models.Disciplina,
                Ocenki = CmbOcen.SelectedItem as Models.Ocenki,
                data = (DateTime)DtPick.SelectedDate,

            };
            AppData.ModelHelper.entities.Jurnal.Add(jurnal);
            AppData.ModelHelper.entities.SaveChanges();
            MessageBox.Show("Добавлено");
            CmbFam.Text = "";
            CmbDisc.Text = "";
            CmbOcen.Text = "";
            DtPick.Text = "";

            GridJurnal.ItemsSource = AppData.ModelHelper.entities.Jurnal.ToList();




        }
    }
}
