using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{
    class University
    {
        public int _limits { get; }
        public ExamResult minimalResult { get; }

        public ComparatorPrioritySubject Comparator;
        public List<Abiturient> abiturientsInShortList { get; }

    }
}
