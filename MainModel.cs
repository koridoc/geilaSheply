using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace geilaSheply
{
    public class MainModelView: INotifyPropertyChanged
    {

        public List<Abiturient> AbiturientsCollection;
        public List<University> UniversitiesCollection;
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

        private Universities _setUniversity;
        private Abiturients _setAbiturient;
        private AlgGeilaSheply _AlgGeilaSheply;

        private GenerateUniversities _generateUniversities;
        private GeneratorAbiturient _generatorAbiturient;

        public MainModelView()
        {
            _generateUniversities = new GenerateUniversities();
            _generatorAbiturient = new GeneratorAbiturient();
            _quantityAbiturients = 10;
            _setUniversity = _generateUniversities.GetUniversities();
            AbiturientsCollection = new List<Abiturient>();
            UniversitiesCollection = new List<University>(_setUniversity.getListUniversities());

        }

        private void addNotAdmitted() 
        {
            University nonUniversity = new University("Не поступили", 
                new RulesForAdmission(
                    int.MaxValue, 
                    new ExamResult(0,0,0,0), 
                    new AbiturientComparer(Comaprators.Sum)
                )
            );

            List<Abiturient> notAdmited = _setAbiturient.AbiturientList.Where(x => x.onTheEnrollmentList == false).ToList();
            nonUniversity.AbiturientsInShortList.AbiturientList = notAdmited;
            UniversitiesCollection.Add(nonUniversity);
        }

        public void RunAlgGeilaSheply() 
        {
            _AlgGeilaSheply = new AlgGeilaSheply(_setAbiturient, _setUniversity);
            _AlgGeilaSheply.Run();
            addNotAdmitted();
        }
        public void CreateListAbiturients() 
        {
            _generatorAbiturient.SetAvaibleUniversities(_setUniversity);
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