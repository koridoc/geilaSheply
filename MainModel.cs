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
            SetUniversity = _generateUniversities.GetUniversities();

            _generatorAbiturient = new GeneratorAbiturient(SetUniversity);
            SetAbiturient = _generatorAbiturient.GetAbiturients(50);


            AlgGeilaSheply = new AlgGeilaSheply(SetAbiturient, SetUniversity);
            AlgGeilaSheply.Run();
            AlgGeilaSheply.GetType();
        }
    }

    

}