using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityGradeManager.Entities;

namespace UniversityGradeManager.DAL
{
    public class DeleteDAO : DAO
    {
        public void Delete(Graduation graduation)
        {
            try
            {
                BeginTrans();

                string query = "DELETE FROM Discipline WHERE Period_Graduation_Id = @id";
                SqlCommand cmd = new SqlCommand(query, Conn, Trans);
                cmd.Parameters.Add(new SqlParameter("@id", graduation.Id));
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Period WHERE Graduation_Id = @id";
                cmd = new SqlCommand(query, Conn, Trans);
                cmd.Parameters.Add(new SqlParameter("@id", graduation.Id));
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Graduation WHERE Id = @id";
                cmd = new SqlCommand(query, Conn, Trans);
                cmd.Parameters.Add(new SqlParameter("@id", graduation.Id));
                cmd.ExecuteNonQuery();

                CommitTrans();
            }
            catch (Exception e)
            {
                RollbackTrans();
                throw e;
            }
        }

        public void Delete(Period period)
        {
            try
            {
                BeginTrans();

                string query = "DELETE FROM Discipline WHERE Period_Graduation_Id = @id AND Period_Number = @number";
                SqlCommand cmd = new SqlCommand(query, Conn, Trans);
                cmd.Parameters.Add(new SqlParameter("@id", period.Graduation.Id));
                cmd.Parameters.Add(new SqlParameter("@number", period.Number));
                cmd.ExecuteNonQuery();

                query = "DELETE FROM Period WHERE Graduation_Id = @id AND Number = @number";
                cmd = new SqlCommand(query, Conn, Trans);
                cmd.Parameters.Add(new SqlParameter("@id", period.Graduation.Id));
                cmd.Parameters.Add(new SqlParameter("@number", period.Number));
                cmd.ExecuteNonQuery();

                CommitTrans();
            }
            catch (Exception e)
            {
                RollbackTrans();
                throw e;
            }
        }

        public void Delete(Discipline discipline)
        {
            try
            {
                BeginTrans();

                string query = "DELETE FROM Discipline WHERE Period_Graduation_Id = @id AND Period_Number = @number AND Code = @code";
                SqlCommand cmd = new SqlCommand(query, Conn, Trans);
                cmd.Parameters.Add(new SqlParameter("@id", discipline.Period.Graduation.Id));
                cmd.Parameters.Add(new SqlParameter("@number", discipline.Period.Number));
                cmd.Parameters.Add(new SqlParameter("@code", discipline.Code));
                cmd.ExecuteNonQuery();

                CommitTrans();
            }
            catch (Exception e)
            {
                RollbackTrans();
                throw e;
            }
        }
    }
}