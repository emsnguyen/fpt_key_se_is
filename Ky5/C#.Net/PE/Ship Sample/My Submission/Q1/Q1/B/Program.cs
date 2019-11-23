using System;

namespace Q1.B
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
        public delegate void MarksHandler(string msg);
        public event MarksHandler LowMarks;


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
                LowMarks(Display() + " is failed!");

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student[] ls = new Student[3];
            ls[0] = new Student("A", 20, 6.5);
            ls[1] = new Student("B", 19, 7.5);
            ls[2] = new Student("C", 20, 5);

            foreach (Student s in ls)
            {
                s.LowMarks += new Student.MarksHandler(s_LowMarks);
                s.Check(6);

            }
            Console.ReadKey();
        }

        static void s_LowMarks(string msg)
        {
            Console.WriteLine(msg);
        }
    }

}
