using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace geilaSheply
{
    public class MainModelView: INotifyPropertyChanged, IDataErrorInfo
    {

        public List<Abiturient> AbiturientsCollection;
        public List<University> UniversitiesCollection;
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;

                switch (columnName) 
                {
                    case "QuantityAbiturients":
                        if(QuantityAbiturients < 0) 
                        {
                            return "���������� ������ ���� ���������������";
                        }
                        break;
                }

                return error;
            }
        }
        public int QuantityAbiturients 
        {
            get
            {
                return _quantityAbiturients;
            }
            set 
            {
                _quantityAbiturients = value;
                OnPropertyChanged("QuantityAbiturients");
            }
        }
        private int _quantityAbiturients;

        public Universities SetUniversity;
        private Abiturients _setAbiturient;
        private AlgGeilaSheply _AlgGeilaSheply;

        private GenerateUniversities _generateUniversities;
        private GeneratorAbiturient _generatorAbiturient;

        public MainModelView()
        {
            _generateUniversities = new GenerateUniversities();
            _generatorAbiturient = new GeneratorAbiturient();
            _quantityAbiturients = 10;
            SetUniversity = _generateUniversities.GetUniversities();
            AbiturientsCollection = new List<Abiturient>();
            UniversitiesCollection = new List<University>(SetUniversity.getListUniversities());

        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        private void addNotAdmitted() 
        {
            University nonUniversity = new University("�� ���������", 
                new RulesForAdmission(
                    int.MaxValue, 
                    new ExamResult(0,0,0,0), 
                    new AbiturientComparer(Comaprators.Sum, SumSubjects.Sum),
                    "Sum"
                )
            );

            List<Abiturient> notAdmited = _setAbiturient.AbiturientList.Where(x => x.onTheEnrollmentList == false).ToList();
            nonUniversity.AbiturientsInShortList.AbiturientList = notAdmited;
            UniversitiesCollection.Add(nonUniversity);
        }

        public void RunAlgGeilaSheply() 
        {
            SetUniversity.ClearInUniversitiesShotList();
            _AlgGeilaSheply = new AlgGeilaSheply(_setAbiturient, SetUniversity);
            _AlgGeilaSheply.Run();
            UniversitiesCollection = new List<University>(SetUniversity.getListUniversities());
            addNotAdmitted();
        }
        public void CreateListAbiturients() 
        {
            _generatorAbiturient.SetAvaibleUniversities(SetUniversity);
            _setAbiturient = _generatorAbiturient.GetAbiturients(QuantityAbiturients);
            AbiturientsCollection = _setAbiturient.AbiturientList;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }

    

}