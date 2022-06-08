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

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace geilaSheply
{
    /// <summary>
    /// Логика взаимодействия для AddUniversity.xaml
    /// </summary>
    public partial class AddUniversity : Window
    {

        private AddUniversityViewModel _Vmodel;
        private DataGrid UniversitiesGrid;
        public AddUniversity(Universities universities, DataGrid UniversitiesGrid)
        {
            this.UniversitiesGrid = UniversitiesGrid;
            _Vmodel = new AddUniversityViewModel(universities);
            InitializeComponent();
            this.DataContext = _Vmodel;
            SubjectsBox.ItemsSource = new List<string>() {"Мат. Инф. Русск.", "Мат. Физ. Русск." };
            SubjectsBox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SubjectsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _Vmodel.TypePriorSubj = SubjectsBox.SelectedIndex;
            if (SubjectsBox.SelectedIndex == 0) 
            {
                MinResultPhys.Text = "0";
                MinResultPhys.IsEnabled = false;
                MinResultInf.IsEnabled = true;
            }
            else 
            {
                MinResultInf.Text = "0";
                MinResultPhys.IsEnabled = true;
                MinResultInf.IsEnabled = false;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool added = _Vmodel.AddUniversityToList();

            if (added) 
            {
                UniversitiesGrid.ItemsSource = _Vmodel.SetUniversities.getListUniversities();
                this.Close();
            }

        }
    }

    public class AddUniversityViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public Universities SetUniversities;
        public AddUniversityViewModel(Universities universities)
        {
            SetUniversities = universities;
            Name = String.Empty;
        }

        public string Name { get; set; }
        public int Quantity { get; set; }

        public int TypePriorSubj { get; set; }

        public int MinResultMath { get; set; }
        public int MinResultRus { get; set; }
        public int MinResultPhys { get; set; }
        public int MinResultInf { get; set; }

 
        public bool AddUniversityToList() 
        {
            bool errors = _hasErrors();

            if (errors) 
            {
                MessageBox.Show("Проверьте правильность заполненных данных");
                return false;
            }

            RulesForAdmission rules;

            if (TypePriorSubj == 0) 
            {
                rules = new RulesForAdmission(Quantity,
                             new ExamResult(MinResultMath, MinResultRus, MinResultPhys, MinResultInf)
                            ,new AbiturientComparer(Comaprators.InformaticsMathRussianLang, SumSubjects.InformaticsMathRussianLang)
                            ,"abiturientComparerInformatics"
                        );
            }
            else 
            {
                rules = new RulesForAdmission(Quantity,
                                 new ExamResult(MinResultMath, MinResultRus, MinResultPhys, MinResultInf)
                                , new AbiturientComparer(Comaprators.PhysicsMathRussianLang, SumSubjects.PhysicsMathRussianLang)
                                , "abiturientComparerPhysics"
                            );
            }

            University university = new University(Name, rules);
            SetUniversities.Add(university);
            return true;
        }

        private bool _hasErrors() 
        {
            bool error = false;

            error = MinResultMath < 0 || MinResultMath > 100 ||
                            MinResultRus < 0 || MinResultRus > 100 ||
                            MinResultInf < 0 || MinResultInf > 100 ||
                            MinResultPhys < 0 || MinResultPhys > 100;
            error |= Quantity < 0;
            error |= Name == String.Empty;

            return error;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName) 
                {
                    case "MinResultMath":
                    case "MinResultRus":
                    case "MinResultInf":
                    case "MinResultPhys":
                        if (MinResultMath < 0 || MinResultMath > 100 ||
                            MinResultRus < 0 || MinResultRus > 100 ||
                            MinResultInf < 0 || MinResultInf > 100 ||
                            MinResultPhys < 0 || MinResultPhys > 100) 
                        {
                            error = "Минимальный балл должен быть в диапазоне от 0 до 100";
                        }

                        break;
                    case "Quantity":
                        if(Quantity < 0) 
                        {
                            error = "Кол-во мест должно быть неотрицательным";
                        }
                        break;
                    case "Name":
                        if (Name == "") 
                        {
                            error = "Наименование должно быть заполнено";
                        }
                        break;
                }
                return error;
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}
