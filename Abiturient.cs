using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{
    public class Abiturient
    {

        public bool onTheEnrollmentList { get; }

        public Universities UniversitiesForAdmission { get; }
        public ExamResult Result { get; private set; }


        public Abiturient(ExamResult examResult)
        {
            Result = examResult;
            onTheEnrollmentList = false;
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

    }

    public class Abiturients
    {
        public List<Abiturient> AbiturientList;

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

        public void Sort(ExamResultComparer comparator)
        {
            AbiturientList.Sort(comparator);
        }
    }

}
