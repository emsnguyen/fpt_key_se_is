using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

namespace DAL
{
    public class StudentDAO : BaseDAO<Student>
    {
        public override Student get(int id)
        {
            Student s = null;
            try
            {
                string sql = "SELECT [id],[name],[dob],[gender],[address] FROM [Student] WHERE [id] = @ID ";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add(new SqlParameter("@ID", id));
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    s = new Student()
                    {
                        id = Convert.ToInt32(reader["id"]),
                        name = reader["name"].ToString(),
                        dob = Convert.ToDateTime(reader["dob"]),
                        gender = Convert.ToBoolean(reader["gender"]),
                        address = reader["address"].ToString()
                    };
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
            return s;
        }

        public override List<Student> getAll()
        {
            List<Student> students = new List<Student>();
            try { 
                string sql = "SELECT [id],[name],[dob],[gender],[address] FROM [Student]";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    Student s = new Student()
                    {
                        id = Convert.ToInt32(reader["id"]),
                        name = reader["name"].ToString(),
                        dob = Convert.ToDateTime(reader["dob"]),
                        gender = Convert.ToBoolean(reader["gender"]),
                        address = reader["address"].ToString()
                    };
                    students.Add(s);
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
            return students;

        }

        public override DataTable getTable()
        {
            DataTable table = new DataTable();
            string sql = "SELECT [id],[name],[dob],[gender],[address] FROM [Student]";
            SqlCommand command = new SqlCommand(sql, connection);
            //adding parameter if needed
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table;
        }

        public override void insert(Student entity)
        {
            String sql = "INSERT INTO [Student] ([id] ,[name],[dob],[gender] ,[address])  VALUES (@ID,@NAME ,@DOB,@GENDER,@ADDRESS)";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add(new SqlParameter("@ID",entity.id));
            command.Parameters.Add(new SqlParameter("@NAME", entity.name));
            command.Parameters.Add(new SqlParameter("@DOB", entity.dob));
            command.Parameters.Add(new SqlParameter("@GENDER", entity.gender));
            command.Parameters.Add(new SqlParameter("@ADDRESS", entity.address));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
