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

        public TryAdmitAbiturient(Abiturient abiturient)
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
            AbiturientsInShortList.Remove(last);
        }

        private void addAbiturientToShortList(Abiturient abiturient)
        {
            AbiturientsInShortList.Add(abiturient);
            abiturient.onTheEnrollmentList = true;
            AbiturientsInShortList.Sort(rules.Comparator);
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
            UniversityList.Remove(item);
        }

        public bool isEmpty()
        {
            return UniversityList.Count() == 0;
        }

        public bool areVacanciesAvaible()
        {
            bool areVacanciesAvaible = false;
            foreach(university in UniversityList)
            {
                areVacanciesAvaible |= university.areVacanciesAvaible();
                if(areVacanciesAvaible)
                {
                    break;
                }
            }
        }
    }
}