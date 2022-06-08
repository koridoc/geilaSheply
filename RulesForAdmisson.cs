
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
                return sumB - sumA;

            if (a.Informatics != b.Informatics)
                return b.Informatics - a.Informatics;

            if (a.Math != b.Math)
                return b.Math - a.Math;

            if (a.RussianLang != b.RussianLang)
                return b.RussianLang - a.RussianLang;
            
            return 0;

        }

        public static int Sum(ExamResult a, ExamResult b)
        {
            int sumA = a.Physics + a.Math + a.RussianLang;
            int sumB = b.Physics + b.Math + b.RussianLang;

            return sumB - sumA;
        }
        public static int PhysicsMathRussianLang(ExamResult a, ExamResult b)
        {
            int sumA = a.Physics + a.Math + a.RussianLang;
            int sumB = b.Physics + b.Math + b.RussianLang;

            if (sumA != sumB)
                return sumB - sumA;

            if (a.Physics != b.Physics)
                return b.Physics - a.Physics;

            if (a.Math != b.Math)
                return b.Math - a.Math;

            if (a.RussianLang != b.RussianLang)
                return b.RussianLang - a.RussianLang;
            
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
        public readonly ExamResult MinimumScore;
        
        public int Limits{get;}
        public AbiturientComparer Comparator{get;}

        public string ComparatorName { get; }

        public RulesForAdmission(int limits, ExamResult minimumScore, AbiturientComparer comparator, string compName)
        {
            Limits = limits;
            MinimumScore = minimumScore;
            Comparator = comparator;
            ComparatorName = compName;
        }

        public bool isMinumumScorePassed(ExamResult score)
        {
            return score.Math >= MinimumScore.Math
                && score.RussianLang >= MinimumScore.RussianLang
                && score.Physics >= MinimumScore.Physics
                && score.Informatics >= MinimumScore.Informatics;
        }
    }
}