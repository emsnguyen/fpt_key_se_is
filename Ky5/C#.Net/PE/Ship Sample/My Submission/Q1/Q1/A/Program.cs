using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q1.A
{
    class Person
    {
        protected string name;
        protected int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Display()
        {
            return "name: " + name + ", age: " + age;
        }

    }
    class Student : Person
    {
        double marks;

        public Student(string name, int age, double marks)
            : base(name, age)
        {
            this.marks = marks;
        }

        public new string Display()
        {
            return base.Display() + ", marks: " + marks;
        }

        public void Check(double lowestMarks)
        {
            if (marks < lowestMarks)
                throw new Exception(Display() + " is failed!");
        }
    }


    class Program
    {
        static void Main1(string[] args)
        {
            Student[] ls = new Student[3];
            ls[0] = new Student("A", 20, 6.5);
            ls[1] = new Student("B", 19, 7.5);
            ls[2] = new Student("C", 20, 5);

            foreach (Student s in ls)
                try
                {
                    s.Check(6);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            Console.ReadKey();

        }
    }
}
