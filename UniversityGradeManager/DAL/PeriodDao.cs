using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityGradeManager.Entities;
using UniversityGradeManager.Exceptions;

namespace UniversityGradeManager.DAL
{
    public class PeriodDao : DAO
    {
        public Period FindByPkWithoutDisciplines(Graduation graduation, int periodNumber)
        {
            return FindByPkWithoutDisciplines(graduation.Id, periodNumber);
        }

        public Period FindByPkWithoutDisciplines(int graduationId, int periodNumber)
        {
            Period period = null;

            string query = "SELECT TOP 1 Period.Number, Graduation.Id as Graduation_Id, Graduation.Name as Graduation_Name FROM Period " +
                           "INNER JOIN Graduation ON Graduation.Id = Period.Graduation_id " +
                           "WHERE Period.Graduation_id = @graduation AND Period.Number = @period";

            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@graduation", graduationId));
            cmd.Parameters.Add(new SqlParameter("@period", periodNumber));
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                period = new Period();
                period.Number = Convert.ToInt32(reader["Number"].ToString());

                period.Graduation = new Graduation();
                period.Graduation.Id = Convert.ToInt32(reader["Graduation_Id"].ToString());
                period.Graduation.Name = reader["Graduation_Name"].ToString();
            }
            else
            {
                throw new EntityNotFoundException("Período não encontrado");
            }

            return period;
        }

        public Period FindByPkWithDisciplines(int graduationId, int periodNumber)
        {
            Period period = null;
            Discipline discipline;

            string query = "SELECT TOP 1 Period.Number, " +
                           "Graduation.Id as Graduation_Id, Graduation.Name as Graduation_Name, " +
                           "Period.Code as Period_Code, Period.Name as Period_Name, Period.TheorycClassesCount as Period_TheorycClassesCount, " +
                           "Period.PractiseClassesCount as Period_PractiseClassesCount, Period.NumberOfCredits as Period_NumberOfCredits, " +
                           "Period.Workload as Period_Workload, Period.ClockHours as Period_ClockHours" +
                           "FROM Period " +
                           "INNER JOIN Graduation ON Graduation.Id = Period.Graduation_id " +
                           "LEFT JOIN Discipline ON Discipline.Period_Number = Period.Number AND Discipline.Period_Discipline_Id = Period.Discipline_Id " +
                           "WHERE Period.Graduation_id = @graduation AND Period.Number = @period";

            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@graduation", graduationId));
            cmd.Parameters.Add(new SqlParameter("@period", periodNumber));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (period == null)
                {
                    period = new Period();
                    period.Number = Convert.ToInt32(reader["Number"].ToString());

                    period.Graduation = new Graduation();
                    period.Graduation.Id = Convert.ToInt32(reader["Graduation_Id"].ToString());
                    period.Graduation.Name = reader["Graduation_Name"].ToString();
                }

                if (reader["Period_Code"].ToString().Length > 0)
                {
                    discipline = new Discipline();
                    discipline.Period = period;
                    discipline.Code = reader["Period_Code"].ToString();
                    discipline.Name = reader["Period_Name"].ToString();
                    discipline.TheorycClassesCount = Convert.ToInt32(reader["Period_TheorycClassesCount"].ToString());
                    discipline.PractiseClassesCount = Convert.ToInt32(reader["Period_PractiseClassesCount"].ToString());
                    discipline.NumberOfCredits = Convert.ToInt32(reader["Period_NumberOfCredits"].ToString());
                    discipline.Workload = Convert.ToInt32(reader["Period_Workload"].ToString());
                    discipline.ClockHours = Convert.ToInt32(reader["Period_ClockHours"].ToString());
                    period.Discplines.Add(discipline);
                }

            }

            if (period == null)
            {
                throw new EntityNotFoundException("Período não encontrado");
            }

            return period;
        }

        public void Insert(Period period)
        {
            string query = "INSERT INTO Period (Graduation_id, Number) VALUES (@graduation, @number)";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@graduation", period.Graduation.Id));
            cmd.Parameters.Add(new SqlParameter("@number", period.Number));
            cmd.ExecuteNonQuery();
        }
    }
}