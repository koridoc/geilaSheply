using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{
    public class Abiturient
    {
        public string FullName{get;}
        public bool onTheEnrollmentList { get; set; }

        public Universities UniversitiesForAdmission { get; }
        public ExamResult Result { get; private set; }


        public Abiturient(string fullName, ExamResult examResult)
        {
            FullName = fullName;
            Result = examResult;
            onTheEnrollmentList = false;
            UniversitiesForAdmission = new Universities();
        }

        public void AddUniversityForAdmission(University university)
        {
            UniversitiesForAdmission.Add(university);
        }

        public void RemoveUniversityForAdmission(University university)
        {
            UniversitiesForAdmission.Remove(university);
        }

        public bool haveUniversitiesForAdmission()
        {
            return UniversitiesForAdmission.isEmpty();
        }

        public University getFirstPriorityUniversity()
        {
            return UniversitiesForAdmission.First();
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
