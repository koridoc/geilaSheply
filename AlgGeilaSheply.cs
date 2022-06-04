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
            bool areVacanciesAvaible = universities.areVacanciesAvaible();

            while(haveNotEnrolledAbiturients && areVacanciesAvaible)
            {
                tryToEnrollAbiturients();
                haveNotEnrolledAbiturients &= abiturients.haveNotEnrolledAbiturients();
                areVacanciesAvaible &= universities.areVacanciesAvaible();   
            }
        }

        private void tryToEnrollAbiturients()
        {
            foreach(var abiturient in abiturients.AbiturientList)
            {
                var abitPriorUniversity = abiturient.getFirstPriorityUniversity();
                
                abitPriorUniversity.TryAdmitAbiturient(abiturient);
                abiturient.RemoveUniversityForAdmission(abitPriorUniversity);
            }
        }


    }
}