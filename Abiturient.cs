using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace geilaSheply
{
    public class Abiturient
    {
        public uint Id { get; }
        public string FullName{get;}
        public bool onTheEnrollmentList { get; set; }


        private Universities _universitiesForAdmission;

        private List<University> _universitiesForAdmissionBefore;
        public ExamResult Result { get; private set; }

        private static uint _maxId = 0;

        public Abiturient(string fullName, ExamResult examResult)
        {
            Id = _maxId++;
            FullName = fullName;
            Result = examResult;
            onTheEnrollmentList = false;
            _universitiesForAdmission = new Universities();
            _universitiesForAdmissionBefore = new List<University>();
        }

        public void AddUniversityForAdmission(University university)
        {
            _universitiesForAdmission.Add(university);
            _universitiesForAdmissionBefore.Add(university);
        }

        public void RemoveUniversityForAdmission(University university)
        {
            _universitiesForAdmission.Remove(university);
        }

        public bool haveUniversitiesForAdmission()
        {
            return !_universitiesForAdmission.isEmpty();
        }

        public University getFirstPriorityUniversity()
        {
            return _universitiesForAdmission.First();
        }

        public List<University> getUniversitiesForAdmissionBefore() 
        {
            return _universitiesForAdmissionBefore;
        }
    }

    public class Abiturients
    {
        public List<Abiturient> AbiturientList;


        public Abiturients() 
        {
            AbiturientList = new List<Abiturient>();
        }
        public void AddAbiturient(Abiturient abiturient)
        {
            AbiturientList.Add(abiturient);
        }

        public void RemoveAbiturient(Abiturient abiturient)
        {
            AbiturientList.Remove(abiturient);
        }

        public int Count()
        {
            return AbiturientList.Count();
        }

        public bool haveNotEnrolledAbiturients()
        {
            return AbiturientList.Where( x => x.onTheEnrollmentList == false).Count() > 0;
        }

        public bool haveNotEnrolledAbiturientsUniversitiesForAdmission() 
        {
            return AbiturientList.Where(x => x.onTheEnrollmentList == false &&  x.haveUniversitiesForAdmission()).Count() > 0;
        }

        public Abiturient Last() 
        {
            return AbiturientList.Last();
        }
        public void Sort(AbiturientComparer comparator)
        {
            AbiturientList.Sort(comparator);
        }

        public void Clear() 
        {
            AbiturientList.Clear();
        }
    }


    public class AbiturientViewModel : INotifyPropertyChanged
    {
        public uint Id => _model.Id;
        public string Name => _model.FullName;
        public int ResultMath => _model.Result.Math;
        public int ResultRussianLang => _model.Result.RussianLang;
        public int ResultPhysics => _model.Result.Physics;
        public int ResultInformatics => _model.Result.Informatics;
        public int SumResult => _fSumResult(_model);
        public List<University> Universities => _model.getUniversitiesForAdmissionBefore();
        private Abiturient _model;
        private Func<Abiturient, int> _fSumResult;
        public AbiturientViewModel(Abiturient abiturientModel, Func<Abiturient, int> fSumResult) 
        {
            _model = abiturientModel;
            _fSumResult = fSumResult;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
