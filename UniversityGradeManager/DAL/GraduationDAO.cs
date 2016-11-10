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

        public Graduation FindByPkWithPeriodsAndDisciplines(int id)
        {
            Graduation graduation = null;
            Period period = null;
            Discipline discipline = null;
            int periodNumber;
            string query = "SELECT Period.Number as Period_Number, " +
                         "Graduation.Id as Graduation_Id, Graduation.Name as Graduation_Name, " +
                         "Discipline.Code as Discipline_Code, Discipline.Name as Discipline_Name, Discipline.TheorycClassesCount as Discipline_TheorycClassesCount, " +
                         "Discipline.PractiseClassesCount as Discipline_PractiseClassesCount, Discipline.NumberOfCredits as Discipline_NumberOfCredits, " +
                         "Discipline.Workload as Discipline_Workload, Discipline.ClockHours as Discipline_ClockHours " +
                         "FROM Graduation " +
                         "LEFT JOIN Period ON Period.Graduation_Id = Graduation.Id " +
                         "LEFT JOIN Discipline ON Discipline.Period_Graduation_Id = Period.Graduation_Id AND Discipline.Period_Number = Period.Number " +
                         "WHERE Graduation.Id = @id ORDER BY Period.Number ASC, Discipline.Code ASC";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                period = null;
                discipline = null;

                if (graduation == null)
                    graduation = EntityHydratorHelper.HydrateGraduation(reader);

                periodNumber = -1;
                if (int.TryParse(reader["Period_Number"].ToString(), out periodNumber))
                {
                    period = graduation.Periods.SingleOrDefault(p => p.Number == periodNumber);

                    if (period == null)
                    {
                        period = EntityHydratorHelper.HydratePeriod(reader);
                        period.Graduation = graduation;
                        graduation.Periods.Add(period);
                    }

                    if (reader["Discipline_Code"].ToString().Length > 0)
                    {
                        discipline = EntityHydratorHelper.HydrateDiscipline(reader);
                        discipline.Period = period;
                        period.Discplines.Add(discipline);
                    }

                }


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