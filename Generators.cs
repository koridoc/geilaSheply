﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geilaSheply
{
    //public class Generators
    //{
    //    private GeneratorAbiturient _generatorAbiturient;

    //    public Generators()
    //    {
    //        _generatorAbiturient = new GeneratorAbiturient();
    //    }

    //}

    public class GeneratorAbiturient
    {
        private List<string> _firstName;
        private List<string> _lastName;
        private Random _rand;
        private Universities _avaibleUniversities;

        public Abiturients GetAbiturients(int count) 
        {
            Abiturients abiturients = new Abiturients();

            for(int i = 0; i < count; i++) 
            {
                abiturients.AddAbiturient(GetAbiturient());
            }

            return abiturients;
        }

   

        public Abiturient GetAbiturient() 
        {
            string fullName = _getRandomFullName();
            ExamResult examResult = _getRandomExamResult();
            Abiturient abiturient = new Abiturient(fullName, examResult);

            _addPriorityUniversities(abiturient);
            return abiturient;
        }
        public GeneratorAbiturient(Universities universities)
        {
            _avaibleUniversities = universities;
            _firstName = new List<string>()
            {
                 "Александр"
                ,"Борис"
                ,"Виталий"
                ,"Геннадий"
                ,"Дмитрий"
                ,"Евгений"
                ,"Жанна"
                ,"Зинаида"
                ,"Инокентий"
                ,"Константин"
                ,"Лилия"
                ,"Михаил"
                ,"Никита"
                ,"Ольга"
                ,"Петр"
                ,"Ростислав"
                ,"Семен"
                ,"Татьяна"
                ,"Ульяна"
                ,"Федор"
                ,"Христофор" 
                //TODO: Добавить еще имен
                };

            _lastName = new List<string>()
            {
                //Фамилии несклоняемые 
                //потому что мне впадлу делать правильное окончание для женского имени
                 "Олексеенко"
                ,"Иваненко"
                ,"Штефан"
                ,"Шпиц"
                ,"Семиноженко"
                ,"Головачук"
                ,"Кононенко"
                ,"Зубарь"
                ,"Акопян"
                ,"Маргарян"
                ,"Сопрано"
                ,"Моргун"
                ,"Мотлич"
                ,"Обыденник"
                ,"Бондаренко"
                ,"Шарий"
                ,"Бойко"
                ,"Прокопенко"
            };
            _rand = new Random();
        }

        private void _addPriorityUniversities(Abiturient abiturient) {
            List<University> listUniversities = _avaibleUniversities.getListUniversities();

            listUniversities = listUniversities.OrderBy((item) => _rand.Next()).Skip(_rand.Next(3)).ToList();

            foreach( var university in listUniversities) 
            {
                abiturient.AddUniversityForAdmission(university);
            }


        }
        private ExamResult _getRandomExamResult()
        {
            int _math = _rand.Next(39,95);
            int _russianLang = _rand.Next(25, 95);
            int _physics = _rand.Next(30, 95);
            int _informatics = _rand.Next(40, 95);
            return new ExamResult(_math, _russianLang, _physics, _informatics);
        }

        private string _getRandomFullName()
        {
            int indexFirstName = _rand.Next(_firstName.Count());
            int indexLastName = _rand.Next(_lastName.Count());
            return _firstName[indexFirstName] + " " + _lastName[indexLastName];
        }

        
    }

    public class GenerateUniversities 
    {
        public Universities GetUniversities() 
        {
            Universities universities = new Universities();

            var abiturientComparerInformatics = new AbiturientComparer(Comaprators.InformaticsMathRussianLang);
            var abiturientComparerPhysics = new AbiturientComparer(Comaprators.PhysicsMathRussianLang);

            universities.Add(
                new University("УГАТУ",
                    new RulesForAdmission(5,
                        new ExamResult(40, 30, 0, 45), abiturientComparerInformatics)
                )
            );

            universities.Add(
                new University("УГНТУ",
                    new RulesForAdmission(10,
                        new ExamResult(40, 30, 35, 0), abiturientComparerPhysics)
                )
            );

            universities.Add(
                new University("КФУ",
                    new RulesForAdmission(15,
                        new ExamResult(40, 30, 0, 45), abiturientComparerInformatics)
                )
            );

            universities.Add(
                new University("БГУ",
                    new RulesForAdmission(5,
                        new ExamResult(40, 30, 35, 0), abiturientComparerPhysics)
                )
            );

            universities.Add(
                new University("ТГУ",
                    new RulesForAdmission(5,
                        new ExamResult(40, 30, 0, 45), abiturientComparerInformatics)
                )
            );

            universities.Shuflle();

            return universities;
        }
    }
}
