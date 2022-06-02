using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{
    public class University
    {
        private int _limits { get; }
        private RulesForAdmission _rules;

        public Abiturients AbiturientsInShortList { get; }

        public University(int limits, RulesForAdmission rules)
        {
            _limits = limits;
            _rules = rules;
        }

        public void TryAdmitAbiturient(Abiturient abiturient)
        {
            bool minimumScorePassed = _rules.isMinumumScorePassed(abiturient.Result);

            if( this.areVacanciesAvaible() && minimumScorePassed)
            {
                addAbiturientToShortList(abiturient);
            }
            else
            {
                tryReplaceAbiturientInShortList(abiturient);
            }
        }
        public bool areVacanciesAvaible() {
            return AbiturientsInShortList.Count() <= _limits;
        }

        private void tryReplaceAbiturientInShortList(Abiturient abiturient)
        {
            addAbiturientToShortList(abiturient);
            
            Abiturient lastAbiturient = AbiturientsInShortList.Last();
            lastAbiturient.onTheEnrollmentList = false;
            AbiturientsInShortList.RemoveAbiturient(lastAbiturient);
        }

        private void addAbiturientToShortList(Abiturient abiturient)
        {
            AbiturientsInShortList.AddAbiturient(abiturient);
            abiturient.onTheEnrollmentList = true;
            AbiturientsInShortList.Sort(_rules.Comparator);
        }
    }

    public class Universities
    {
        public List<University> UniversityList;

        public Universities()
        {
            UniversityList = new List<University>();
        }

        public void Add(University university)
        {
            UniversityList.Add(university);
        }

        public void Remove(University university)
        {
            UniversityList.Remove(university);
        }

        public University First()
        {
            return UniversityList.First();
        }

        public bool isEmpty()
        {
            return UniversityList.Count() == 0;
        }

        public bool areVacanciesAvaible()
        {
            bool _areVacanciesAvaible = false;
            foreach(var university in UniversityList)
            {
                _areVacanciesAvaible |= university.areVacanciesAvaible();
                if(_areVacanciesAvaible)
                {
                    break;
                }
            }
            return _areVacanciesAvaible;
        }
    }
}