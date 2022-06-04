using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{
    public class MainModel
    {
        public Universities SetUniversity;
        public Abiturients SetAbiturient;
        public AlgGeilaSheply AlgGeilaSheply;

        private GenerateUniversities _generateUniversities;
        private GeneratorAbiturient _generatorAbiturient;

        public MainModel()
        {
            _generateUniversities = new GenerateUniversities();
            _generatorAbiturient = new GeneratorAbiturient();
        }
    }

    

}