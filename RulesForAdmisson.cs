
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{
    delegate bool ComparatorPrioritySubject(ExamResult a, ExamResult b);

    public class RulesForAdmission
    {
        private ExamResult _minimumScore;
        private ComparatorPrioritySubject _comparator;

        public RulesForAdmission(ExamResult minimumScore, ComparatorPrioritySubject comparator)
        {
            _minimumScore = minimumScore;
            _comparator = comparator;
        }

        public bool CompareResults(ExamResult a, ExamResult b)
        {
            return _comparator(a, b);
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