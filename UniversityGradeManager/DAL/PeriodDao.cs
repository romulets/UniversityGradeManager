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
    public class PeriodDao : DAO
    {
        public Period FindByPkWithoutDisciplines(Graduation graduation, int periodNumber)
        {
            return FindByPkWithoutDisciplines(graduation.Id, periodNumber);
        }

        public Period FindByPkWithoutDisciplines(int graduationId, int periodNumber)
        {
            Period period = null;

            string query = "SELECT TOP 1 Period.Number as Period_Number, Graduation.Id as Graduation_Id, Graduation.Name as Graduation_Name FROM Period " +
                           "INNER JOIN Graduation ON Graduation.Id = Period.Graduation_id " +
                           "WHERE Period.Graduation_id = @graduation AND Period.Number = @period";

            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@graduation", graduationId));
            cmd.Parameters.Add(new SqlParameter("@period", periodNumber));
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                period = EntityHydratorHelper.HydratePeriod(reader);
                period.Graduation = EntityHydratorHelper.HydrateGraduation(reader);
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

            string query = "SELECT Period.Number as Period_Number, " +
                           "Graduation.Id as Graduation_Id, Graduation.Name as Graduation_Name, " +
                           "Discipline.Code as Discipline_Code, Discipline.Name as Discipline_Name, Discipline.TheorycClassesCount as Discipline_TheorycClassesCount, " +
                           "Discipline.PractiseClassesCount as Discipline_PractiseClassesCount, Discipline.NumberOfCredits as Discipline_NumberOfCredits, " +
                           "Discipline.Workload as Discipline_Workload, Discipline.ClockHours as Discipline_ClockHours " +
                           "FROM Period " +
                           "INNER JOIN Graduation ON Graduation.Id = Period.Graduation_id " +
                           "LEFT JOIN Discipline ON Discipline.Period_Number = Period.Number AND Discipline.Period_Graduation_Id = Period.Graduation_Id " +
                           "WHERE Period.Graduation_id = @graduation AND Period.Number = @period";

            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@graduation", graduationId));
            cmd.Parameters.Add(new SqlParameter("@period", periodNumber));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (period == null)
                {
                    period = EntityHydratorHelper.HydratePeriod(reader);
                    period.Graduation = EntityHydratorHelper.HydrateGraduation(reader);
                }

                if (reader["Discipline_Code"].ToString().Length > 0)
                {
                    discipline = EntityHydratorHelper.HydrateDiscipline(reader);
                    discipline.Period = period;
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