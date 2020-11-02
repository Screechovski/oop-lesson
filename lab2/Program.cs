﻿using System;
using System.Reflection;

namespace lab2
{
    public class StudentsGroup /* 1 создать класс согласно (табл .1) */
    {
        public string Name; /* 2 указать не менее 5 полей */
        public DateTime EnterYear;
        public int StudentCount;
        public string Faculty;
        public int LearningLevel;
        public int LearningYearsLength;
        public bool Magistracy;
        static Random randomValue; /* 3 описать статическое поле randomValue */

        public StudentsGroup(string gName, DateTime gYear, int gSrudentsCount, string gFaculty, int gLearningLevel, int gLearningLength) /* 5 создать конструктор для инициализации всех полей */
        {
            Name = gName;
            EnterYear = gYear;
            StudentCount = gSrudentsCount;
            Faculty = gFaculty;
            LearningLevel = gLearningLevel;
            LearningYearsLength = gLearningLength;
            Magistracy = LearningYearsLength == 2;
        }

        public StudentsGroup() /* 4 создать конструктор без параметров */
        {
            Name = "Default" + new DateTime().Year;
            EnterYear = new DateTime();
            StudentCount = 10;
            Faculty = new DateTime() + "-HJK";
            LearningLevel = 1;
            LearningYearsLength = 4;
            Magistracy = false;
        }

        static StudentsGroup() /* 6 статический конструктор для инициализации randomValue*/
        {
            randomValue = new Random();
        }

        public void printFields(bool printValueFields)
        {
            Type type = base.GetType();
            FieldInfo[] fields = type.GetFields();
            PropertyInfo[] fieldsVal = type.GetProperties();
            foreach (var val in fields)
            {
                Console.Write(val);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StudentsGroup student1 = new StudentsGroup("17-TVI-3", new DateTime(2017, 7, 1, 8, 30, 0), 15, "STK", 2, 4);
            StudentsGroup student2 = new StudentsGroup(); /* 7 создание 3 обьектов на основе конструкторов */

            student1.printFields(false);
            student2.printFields(false);

            Console.Read();
        }
    }
}
