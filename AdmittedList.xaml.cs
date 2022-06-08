using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для AdmittedList.xaml
    /// </summary>
    public partial class AdmittedList : Window
    {
        List<AbiturientViewModel> abiturientViewModel;

        public AdmittedList( List<University> universities)
        {
            InitializeComponent();
            selectUniversityBox.ItemsSource = universities;
            abiturientViewModel = new List<AbiturientViewModel>();
        }

        private void selectUniversityBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            University university = (University)selectUniversityBox.SelectedItem;

            var rules = university.Rules;

            Func<ExamResult, int> sumFunc;


            if (rules.ComparatorName == "abiturientComparerInformatics")
            {
                sumFunc = (result) => result.Informatics + result.Math + result.RussianLang;
            }
            else if (rules.ComparatorName == "abiturientComparerPhysics")
            {
                sumFunc = (result) => result.Physics + result.Math + result.RussianLang;
            }
            else
            {
                sumFunc = (result) => 0;
            }

            abiturientViewModel.Clear();
            foreach (var abit in university.AbiturientsInShortList.AbiturientList)
            {
                abiturientViewModel.Add(new AbiturientViewModel(abit, sumFunc));
            }

            admittedAbiturientsGrid.Columns.Clear();
            admittedAbiturientsGrid.Items.Refresh();
            admittedAbiturientsGrid.UpdateLayout();

            admittedAbiturientsGrid.ItemsSource = abiturientViewModel;

            addColumnsToDatagrid("№", "Id");
            addColumnsToDatagrid("ФИО", "Name");

            if (rules.ComparatorName != "Sum") 
            { 
                addColumnsToDatagrid("Сумма баллов", "SumResult");
            }

            addColumnsToDatagrid("Математика", "ResultMath");

            if (rules.ComparatorName == "abiturientComparerPhysics" || rules.ComparatorName == "Sum")
            {
                addColumnsToDatagrid("Физика", "ResultPhysics");
            }
            if (rules.ComparatorName == "abiturientComparerInformatics" || rules.ComparatorName == "Sum")
            {
                addColumnsToDatagrid("Информатика", "ResultInformatics");
            }
            addColumnsToDatagrid("Русский язык", "ResultRussianLang");
            admittedAbiturientsGrid.Items.Refresh();
            admittedAbiturientsGrid.UpdateLayout();
        }

        private void addColumnsToDatagrid(string header, string binding)
        {
            DataGridTextColumn c = new DataGridTextColumn();
            c.Binding = new Binding(binding);
            c.Header = header;

            admittedAbiturientsGrid.Columns.Add(c);
        }

        private void admittedAbiturientsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AbiturientViewModel abiturientViewModel = (AbiturientViewModel)admittedAbiturientsGrid.SelectedItem;
            if (admittedAbiturientsGrid.SelectedItem != null)
            {
                InfoAbiturient infoAbiturient = new InfoAbiturient(abiturientViewModel);
                infoAbiturient.Show();
            }
        }
    }


}
