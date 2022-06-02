using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{
    public class University
    {
        private int _limits { get; }
        private RulesForAdmission Rules;

        public Abiturients AbiturientsInShortList { get; }

        public University(int limits, RulesForAdmission Rules)
        {
            _limits = limits;
            Comparator = comparator;
        }

        public bool areVacanciesAvaible() {
            return AbiturientsInShortList.Count() <= _limits;
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