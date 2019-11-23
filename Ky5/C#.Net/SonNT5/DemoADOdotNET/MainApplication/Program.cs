using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MainApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentDAO db = new StudentDAO();
            List<Student> students = db.getAll();
            foreach(Student s in students)
            {
                Console.WriteLine(
                    s.id + "\t" + s.name + "\t" + s.dob + "\t"+
                    (s.gender?"Male":"Female") + "\t" + s.address
                    );
            }
            Console.WriteLine("--------------------------------------");
            Student win = db.get(1);

            Console.WriteLine(
                    win.id + "\t" + win.name + "\t" + win.dob + "\t" +
                    (win.gender ? "Male" : "Female") + "\t" + win.address
                    );
            Console.WriteLine("--------------------------------------");

            DataTable table = db.getTable();
            foreach(DataRow r in table.Rows)
            {
                Console.WriteLine(
                    r["id"].ToString() + "\t" + r["name"].ToString() + "\t" + r["dob"].ToString() + "\t" +
                    r["gender"].ToString() + "\t" + r["address"].ToString()
                    );
            }

            Console.WriteLine("--------------------------------------");
            Student new_guy = new Student()
            { id = 4, name = "Mr A", dob = DateTime.Now, gender = true, address = "Hoa Lac" };
            db.insert(new_guy);
            table = db.getTable();
            foreach (DataRow r in table.Rows)
            {
                Console.WriteLine(
                    r["id"].ToString() + "\t" + r["name"].ToString() + "\t" + r["dob"].ToString() + "\t" +
                    r["gender"].ToString() + "\t" + r["address"].ToString()
                    );
            }


            Console.ReadKey();
        }
    }
}
