﻿using System;

namespace lab1
{
    public class StudentsGroup
    {
        public string Name;
        public DateTime EnterYear;
        public int StudentCount;
        public string Faculty;
        public int LearningLevel;
        public int LearningYearsLength;
        public bool Magistracy;

        public void InitFields(string gName, DateTime gYear, int gSrudentsCount, string gFaculty, int gLearningLevel, int gLearningLength)
        {
            Name = gName;
            EnterYear = gYear;
            StudentCount = gSrudentsCount;
            Faculty = gFaculty;
            LearningLevel = gLearningLevel;
            LearningYearsLength = gLearningLength;
            Magistracy = LearningYearsLength == 2;
        }

        public void PrintFields()
        {
            Console.WriteLine(
                $"Name: {this.Name} \n" +
                $"EnterYear: {this.EnterYear} \n" +
                $"StudentCount: {this.StudentCount} \n" +
                $"Faculty: {this.Faculty} \n" +
                $"LearningLevel: {this.LearningLevel} \n" +
                $"LearningYearsLength: {this.LearningYearsLength} \n" +
                $"Magistracy: {this.Magistracy}"
            );
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StudentsGroup studenGroup1 = new StudentsGroup();            

            studenGroup1.InitFields("Group name", new DateTime(2019, 09, 01), 12, "Faculty name", 1, 4);
            studenGroup1.PrintFields();

            Console.Read();
        }
    }
}