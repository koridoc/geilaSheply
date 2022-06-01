using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{

    enum Subject
    {
        Math,
        RussanLang,
        Physics,
        Informatics
    }

    class Abiturient
    {
        public Abiturient(ExamResult examResult)
        {
            ExamResult = examResult;
        }

        public bool onTheEnrollmentList { get; }

        public List<University> ListUniversities { get; }
        public ExamResult ExamResult { get; private set; }
    }

    class ExamResult
    {
        public int Math { get; private set; }
        public int RussianLang { get; private set; }
        public int Physics { get; private set; }
        public int Informatics { get; private set; }

        public  ExamResult(int math, int russianLang, int physics, int informatics) 
        {
            Math = math;
            RussianLang = russianLang;
            Physics = physics;
            Informatics = informatics;
        }

    }

    delegate bool ComparePrioritySubject(ExamResult a, ExamResult b);


    class UniversityPrioritySubject {
        private ComparePrioritySubject _compare;
        public UniversityPrioritySubject(ComparePrioritySubject compare) 
        {
            _compare = compare;
        }
        public bool Compare(ExamResult a, ExamResult b)
        {
            return _compare(a,b);
        }
    }

    class University
    {
        public int _limits { get; }
        public ExamResult minimalResult { get; }

        public UniversityPrioritySubject Prioryty{get; }
        public List<Abiturient> abiturientsInShortList { get; }

    }
}
