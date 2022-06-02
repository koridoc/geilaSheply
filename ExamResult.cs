using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{
    public class ExamResult
    {
        public int Math { get; private set; }
        public int RussianLang { get; private set; }
        public int Physics { get; private set; }
        public int Informatics { get; private set; }

        public ExamResult(int math, int russianLang, int physics, int informatics)
        {
            Math = math;
            RussianLang = russianLang;
            Physics = physics;
            Informatics = informatics;
        }

    }

}
