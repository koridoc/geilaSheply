
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{
    public delegate int  ComparatorPrioritySubject(ExamResult a, ExamResult b);


    public class ExamResultComparer: IComparer<ExamResult>
    {
        private ComparatorPrioritySubject _comparator;

        public ExamResultComparer(ComparatorPrioritySubject comparator)
        {
            _comparator = comparator;
        }

        public int Compare (ExamResult a, ExamResult b)
        {
            if(a is null || b is null) 
                throw new ArgumentException("Некорректное значение параметра");
            
            return _comparator(a, b);
        }
    }

    public class RulesForAdmission
    {
        private ExamResult _minimumScore;
        public ExamResultComparer Comparator{get;}

        public RulesForAdmission(ExamResult minimumScore, ExamResultComparer comparator)
        {
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