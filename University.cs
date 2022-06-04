using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{
    public class University
    {
        private readonly RulesForAdmission _rules;
        public uint Id { get; }
        public string Name { get; }
        public Abiturients AbiturientsInShortList { get; }

        private static uint _maxId = 0;

        public University(string name, RulesForAdmission rules)
        {
            Id = _maxId++;
            Name = name;
            _rules = rules;
            AbiturientsInShortList = new Abiturients();
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
            return AbiturientsInShortList.Count() < _rules.Limits;
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
        private List<University> UniversityList;

        public Universities()
        {
            UniversityList = new List<University>();
        }

        public List<University> getListUniversities() 
        {
            return new List<University>(UniversityList);
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

        public void Shuflle() 
        {
            Random _random = new Random();
            UniversityList = UniversityList.OrderBy((item) => _random.Next()).ToList();
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