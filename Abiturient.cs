using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return _universitiesForAdmission.isEmpty();
        }

        public University getFirstPriorityUniversity()
        {
            return _universitiesForAdmission.First();
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

        public Abiturient Last() 
        {
            return AbiturientList.Last();
        }
        public void Sort(AbiturientComparer comparator)
        {
            AbiturientList.Sort(comparator);
        }
    }

}
