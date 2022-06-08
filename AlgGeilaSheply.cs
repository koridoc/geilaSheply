using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{
    public class AlgGeilaSheply
    {
        public Abiturients abiturients;
        public Universities universities;

        public AlgGeilaSheply(Abiturients abiturients, Universities universities)
        {
            this.abiturients = abiturients;
            this.universities = universities;
        }

        public void Run()
        {
            bool haveNotEnrolledAbiturients = abiturients.haveNotEnrolledAbiturients();
            bool haveNotEnrolledAbiturientsUniversities = abiturients.haveNotEnrolledAbiturientsUniversitiesForAdmission();
            bool areVacanciesAvaible = universities.areVacanciesAvaible();

            while(haveNotEnrolledAbiturients && areVacanciesAvaible && haveNotEnrolledAbiturientsUniversities)
            {
                tryToEnrollAbiturients();
                haveNotEnrolledAbiturients &= abiturients.haveNotEnrolledAbiturients();
                areVacanciesAvaible &= universities.areVacanciesAvaible();
                haveNotEnrolledAbiturientsUniversities &= abiturients.haveNotEnrolledAbiturientsUniversitiesForAdmission();
            }
        }


        private void tryToEnrollAbiturients()
        {
            foreach(var abiturient in abiturients.AbiturientList)
            {
                bool haveUniversities = abiturient.haveUniversitiesForAdmission();

                if (!haveUniversities || abiturient.onTheEnrollmentList) 
                {
                    continue;
                }

                var abitPriorUniversity = abiturient.getFirstPriorityUniversity();
                
                abitPriorUniversity.TryAdmitAbiturient(abiturient);
                abiturient.RemoveUniversityForAdmission(abitPriorUniversity);
            }
        }


    }
}