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
    public class DisciplineDao : DAO
    {

        public Discipline FindByPk(string code, int graduationId)
        {
            Discipline discipline = null;
            string query = "SELECT TOP 1 Period.Number as Period_Number, " +
                           "Graduation.Id as Graduation_Id, Graduation.Name as Graduation_Name, " +
                           "Discipline.Code as Discipline_Code, Discipline.Name as Discipline_Name, Discipline.TheorycClassesCount as Discipline_TheorycClassesCount, " +
                           "Discipline.PractiseClassesCount as Discipline_PractiseClassesCount, Discipline.NumberOfCredits as Discipline_NumberOfCredits, " +
                           "Discipline.Workload as Discipline_Workload, Discipline.ClockHours as Discipline_ClockHours " +
                           "FROM Discipline " +
                           "INNER JOIN Period ON Period.Number = Discipline.Period_Number AND Period.Graduation_id = Discipline.Period_Graduation_Id " +
                           "INNER JOIN Graduation ON Graduation.Id = Period.Graduation_Id " +
                           "WHERE Graduation.Id = @id AND Discipline.Code = @code";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@id", graduationId));
            cmd.Parameters.Add(new SqlParameter("@code", code));

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                discipline = EntityHydratorHelper.HydrateDiscipline(reader);
                discipline.Period = EntityHydratorHelper.HydratePeriod(reader);
                discipline.Period.Graduation = EntityHydratorHelper.HydrateGraduation(reader);
            }
            else
                throw new EntityNotFoundException("Disciplina não encontrada");

            return discipline;
        }

        public void Insert(Discipline discipline)
        {
            string query = "INSERT INTO Discipline (Code, Period_Graduation_Id, Period_Number, Name, TheorycClassesCount, " +
                "PractiseClassesCount, NumberOfCredits, Workload, ClockHours) VALUES (@code, @periodGraduationId, @periodNumber, " +
                "@name, @theorycClassesCount, @practiseClassesCount, @numberOfCredits, @Workload, @ClockHours)";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@code", discipline.Code));
            cmd.Parameters.Add(new SqlParameter("@periodGraduationId", discipline.Period.Graduation.Id));
            cmd.Parameters.Add(new SqlParameter("@periodNumber", discipline.Period.Number));
            cmd.Parameters.Add(new SqlParameter("@name", discipline.Name));
            cmd.Parameters.Add(new SqlParameter("@theorycClassesCount", discipline.TheorycClassesCount));
            cmd.Parameters.Add(new SqlParameter("@practiseClassesCount", discipline.PractiseClassesCount));
            cmd.Parameters.Add(new SqlParameter("@numberOfCredits", discipline.NumberOfCredits));
            cmd.Parameters.Add(new SqlParameter("@Workload", discipline.Workload));
            cmd.Parameters.Add(new SqlParameter("@ClockHours", discipline.ClockHours));
            cmd.ExecuteNonQuery();
        }

        public void Update(Discipline discipline)
        {
            string query = "Update Discipline SET Period_Number = @periodNumber, Name = @name, TheorycClassesCount = @theorycClassesCount, " +
                "PractiseClassesCount = @practiseClassesCount, NumberOfCredits = @numberOfCredits, Workload = @Workload, " +
                "ClockHours = @ClockHours WHERE Code = @code AND Period_Graduation_Id = @periodGraduationId";
            SqlCommand cmd = new SqlCommand(query, Conn);
            cmd.Parameters.Add(new SqlParameter("@code", discipline.Code));
            cmd.Parameters.Add(new SqlParameter("@periodGraduationId", discipline.Period.Graduation.Id));
            cmd.Parameters.Add(new SqlParameter("@periodNumber", discipline.Period.Number));
            cmd.Parameters.Add(new SqlParameter("@name", discipline.Name));
            cmd.Parameters.Add(new SqlParameter("@theorycClassesCount", discipline.TheorycClassesCount));
            cmd.Parameters.Add(new SqlParameter("@practiseClassesCount", discipline.PractiseClassesCount));
            cmd.Parameters.Add(new SqlParameter("@numberOfCredits", discipline.NumberOfCredits));
            cmd.Parameters.Add(new SqlParameter("@Workload", discipline.Workload));
            cmd.Parameters.Add(new SqlParameter("@ClockHours", discipline.ClockHours));
            cmd.ExecuteNonQuery();
        }

    }
}