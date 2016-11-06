using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityGradeManager.Entities;
using UniversityGradeManager.Exceptions;

namespace UniversityGradeManager.DAL
{
    public class GraduationDAO : DAO
    {

        public List<Graduation> FindAllWithoutRelations()
        {
            List<Graduation> graduations = new List<Graduation>();
            Graduation graduation;

            string query = "SELECT Id, Name FROM Graduation";
            SqlCommand cmd = new SqlCommand(query, Conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                graduation = new Graduation();
                graduation.Id = Convert.ToInt32(reader["Id"].ToString());
                graduation.Name = reader["Name"].ToString();
                graduations.Add(graduation);
            }

            return graduations;
        }

        public Graduation FindByIdWithoutRelations(int id)
        {
            Graduation graduation = null;

            string query = "SELECT TOP 1 Id, Name FROM Graduation WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@id", id));

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                graduation = new Graduation();
                graduation.Id = Convert.ToInt32(reader["Id"].ToString());
                graduation.Name = reader["Name"].ToString();
            }
            else
            {
                throw new EntityNotFoundException("Curso não encontrado");
            }

            return graduation;
        }

        public void Insert(Graduation graduation)
        {
            string query = "INSERT INTO Graduation (Name) OUTPUT INSERTED.ID VALUES (@name)";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@name", graduation.Name));
            graduation.Id = (int)cmd.ExecuteScalar();
        }

        public void Update(Graduation graduation)
        {
            string query = "UPDATE Graduation SET Name = @name WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@name", graduation.Name));
            cmd.Parameters.Add(new SqlParameter("@id", graduation.Id));
            cmd.ExecuteNonQuery();
        }
    }
}