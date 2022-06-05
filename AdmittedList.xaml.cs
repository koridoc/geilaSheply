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
    /// Логика взаимодействия для AdmittedList.xaml
    /// </summary>
    public partial class AdmittedList : Window
    {
        List<AbiturientViewModel> abiturientViewModel;

        private bool infHide;
        public AdmittedList( List<University> universities)
        {
            InitializeComponent();
            selectUniversityBox.ItemsSource = universities;
            abiturientViewModel = new List<AbiturientViewModel>();
        }

        private void selectUniversityBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            University university = (University)selectUniversityBox.SelectedItem;

            var cmp = university.Rules.Comparator;
            ComparatorPrioritySubject cmpInf = Comaprators.InformaticsMathRussianLang;
            ComparatorPrioritySubject cmpPhys = Comaprators.PhysicsMathRussianLang;

            Func<ExamResult, int> sumFunc;

            
            if(cmp.Equals(cmpInf)) 
            {
                sumFunc = (result) => result.Informatics + result.Math + result.RussianLang;
                infHide = false;
            }
            else
            {
                sumFunc = (result) => result.Physics + result.Math + result.RussianLang;
                infHide = true;
            }

            abiturientViewModel.Clear();
            foreach (var abit in university.AbiturientsInShortList.AbiturientList) 
            {
                abiturientViewModel.Add(new AbiturientViewModel(abit, sumFunc));
            }

            admittedAbiturientsGrid.ItemsSource = abiturientViewModel;
            admittedAbiturientsGrid.Items.Refresh();
            //admittedAbiturientsGrid.Columns[0].Visibility
        }

        private void hideUnusedColums() 
        {
            
        }
    }


}
