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