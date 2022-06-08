using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace geilaSheply
{
    /// <summary>
    /// Логика взаимодействия для SettingsUniversity.xaml
    /// </summary>
    public partial class SettingsUniversity : Window
    {
        public Universities SetUniversities;
        public SettingsUniversity(Universities universities)
        {
            InitializeComponent();

            SetUniversities = universities;
            DataContext = SetUniversities;
            ListUniversitiesGrid.ItemsSource = SetUniversities.getListUniversities();
            addColumnsToDatagrid("ID", "Id");
            addColumnsToDatagrid("Название", "Name");
            addColumnsToDatagrid("Кол-во мест", "Rules.Limits");
            addColumnsToDatagrid("Математика", "Rules.MinimumScore.Math");
            addColumnsToDatagrid("Русский язык", "Rules.MinimumScore.RussianLang");
            addColumnsToDatagrid("Физика", "Rules.MinimumScore.Physics");
            addColumnsToDatagrid("Информатка", "Rules.MinimumScore.Informatics");
        }


        private void addColumnsToDatagrid(string header, string binding)
        {
            DataGridTextColumn c = new DataGridTextColumn();
            c.Binding = new Binding(binding);
            c.Header = header;

            ListUniversitiesGrid.Columns.Add(c);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            University university = (University)ListUniversitiesGrid.SelectedItem;

            if (university != null) 
            {
                SetUniversities.Remove(university);
            }
            ListUniversitiesGrid.ItemsSource = SetUniversities.getListUniversities();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddUniversity addUniversityWindow = new AddUniversity(SetUniversities, ListUniversitiesGrid);
            addUniversityWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SetUniversities.Clear();
            ListUniversitiesGrid.ItemsSource = SetUniversities.getListUniversities();
            ListUniversitiesGrid.Items.Refresh();
        }
    }
}



