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
    /// Логика взаимодействия для DobavlinieDisciplini.xaml
    /// </summary>
    public partial class DobavlinieDisciplini : Window
    {
        public DobavlinieDisciplini()
        {
            InitializeComponent();
            AppData.ModelHelper.entities = new Models.Koshevoi_3isEntities();
            GridDisciplina.ItemsSource = AppData.ModelHelper.entities.Disciplina.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(TbDiscip.Text))
                mes += "Введите название дисциплины\n";


            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Models.Disciplina disciplina = new Models.Disciplina()
            {
                Name_Disciplina = TbDiscip.Text,

            };

            AppData.ModelHelper.entities.Disciplina.Add(disciplina);
            AppData.ModelHelper.entities.SaveChanges();
            MessageBox.Show("Добавлено");
            TbDiscip.Text = "";
            GridDisciplina.ItemsSource = AppData.ModelHelper.entities.Disciplina.ToList();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
