
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{

    public delegate int  ComparatorPrioritySubject(ExamResult a, ExamResult b);

    public static class Comaprators
    {
        public static int InformaticsMathRussianLang(ExamResult a, ExamResult b)
        {
            int sumA = a.Informatics + a.Math + a.RussianLang;
            int sumB = b.Informatics + b.Math + b.RussianLang;

            if (sumA != sumB)
                return sumA - sumB;

            if (a.Informatics != b.Informatics)
                return a.Informatics - b.Informatics;

            if (a.Math != b.Math)
                return a.Math - b.Math;

            if (a.RussianLang != b.RussianLang)
                return a.RussianLang - b.RussianLang;
            
            return 0;

        }

        public static int PhysicsMathRussianLang(ExamResult a, ExamResult b)
        {
            int sumA = a.Physics + a.Math + a.RussianLang;
            int sumB = b.Physics + b.Math + b.RussianLang;

            if (sumA != sumB)
                return sumA - sumB;

            if (a.Physics != b.Physics)
                return a.Physics - b.Physics;

            if (a.Math != b.Math)
                return a.Math - b.Math;

            if (a.RussianLang != b.RussianLang)
                return a.RussianLang - b.RussianLang;
            
            return 0;
        }

    }


    public class AbiturientComparer: IComparer<Abiturient>
    {
        private ComparatorPrioritySubject _comparator;

        public AbiturientComparer(ComparatorPrioritySubject comparator)
        {
            _comparator = comparator;
        }

        public int Compare (Abiturient a, Abiturient b)
        {
            if(a is null || b is null) 
                throw new ArgumentException("Некорректное значение параметра");
            
            return _comparator(a.Result, b.Result);
        }
    }

    public class RulesForAdmission
    {
        private ExamResult _minimumScore;
        
        public int Limits{get;}
        public AbiturientComparer Comparator{get;}

        public RulesForAdmission(int limits, ExamResult minimumScore, AbiturientComparer comparator)
        {
            Limits = limits;
            _minimumScore = minimumScore;
            Comparator = comparator;
        }

        public bool isMinumumScorePassed(ExamResult score)
        {
            return score.Math >= _minimumScore.Math
                && score.RussianLang >= _minimumScore.RussianLang
                && score.Physics >= _minimumScore.Physics
                && score.Informatics >= _minimumScore.Informatics;
        }
    }
}