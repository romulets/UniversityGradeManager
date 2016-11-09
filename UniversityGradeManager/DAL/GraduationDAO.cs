using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityGradeManager.Entities;
using UniversityGradeManager.Exceptions;
using UniversityGradeManager.Helpers;

namespace UniversityGradeManager.DAL
{
    public class GraduationDAO : DAO
    {

        public List<Graduation> FindAllWithoutRelations()
        {
            List<Graduation> graduations = new List<Graduation>();
            Graduation graduation;

            string query = "SELECT Id as Graduation_Id, Name as Graduation_Name FROM Graduation";
            SqlCommand cmd = new SqlCommand(query, Conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                graduation = EntityHydratorHelper.HydrateGraduation(reader);
                graduations.Add(graduation);
            }

            return graduations;
        }

        public Graduation FindByPkWithoutRelations(int id)
        {
            Graduation graduation = null;

            string query = "SELECT TOP 1 Id as Graduation_Id, Name as Graduation_Name FROM Graduation WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@id", id));

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                graduation = EntityHydratorHelper.HydrateGraduation(reader);
            else
                throw new EntityNotFoundException("Curso não encontrado");

            return graduation;
        }

        public Graduation FindByPkWithPeriods(int id)
        {
            Graduation graduation = null;
            int periodNumber;

            string query = "SELECT Graduation.Id as Graduation_Id, Graduation.Name as Graduation_Name, " +
                           "Period.Number as Period_Number FROM Graduation " +
                           "LEFT JOIN Period ON Graduation.Id = Period.Graduation_Id " +
                           "WHERE Graduation.Id = @id";

            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@id", id));

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (graduation == null)
                    graduation = EntityHydratorHelper.HydrateGraduation(reader);

                periodNumber = -1;
                if (int.TryParse(reader["Period_Number"].ToString(), out periodNumber))
                    graduation.Periods.Add(EntityHydratorHelper.HydratePeriod(reader));
            }


            if (graduation == null)
                throw new EntityNotFoundException("Curso não encontrado");

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