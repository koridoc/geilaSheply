using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{
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


 

   
}
