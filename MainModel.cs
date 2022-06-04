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

        public MainModel()
        {
            SetUniversity = new Universities();
            SetAbiturient = new Abiturients();


            AlgGeilaSheply = new AlgGeilaSheply(SetAbiturient, SetUniversity);
        }
    }

    public class Generators
    {
        private GeneratorAbiturient _generatorAbiturient;

        public Generators()
        {
            _generatorAbiturient = new GeneratorAbiturient();
        }

    }

    public class GeneratorAbiturient
    {
        private List<string> _firstName;
        private List<string> _lastName;
        private Random _rand;


        private ExamResult _getRandomExamResult()
        {
            
            return new ExamResult();
        }

        private string _getRandomFullName()
        {
            int indexFirstName = _rand.Next(_firstName.Count());
            int indexLastName  = _rand.Next(_lastName.Count());
            return _firstName[indexFirstName] + " " + _lastName[indexLastName];
        }

        public GeneratorNameAbiturient()
        {
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

            _lastName  = new List<string>() 
            {
                //Фамилии несклоняемые 
                //потому что мне впадлу делать правильное окончание для женского имени
                 "Олексененко"
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
        }
    }

}