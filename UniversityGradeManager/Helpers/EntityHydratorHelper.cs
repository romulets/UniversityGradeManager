using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityGradeManager.Entities;

namespace UniversityGradeManager.Helpers
{
    public class EntityHydratorHelper
    {

        public static Period HydratePeriod(SqlDataReader reader)
        {
            Period period = new Period();
            period.Number = Convert.ToInt32(reader["Period_Number"].ToString());
            return period;
        }

        public static Graduation HydrateGraduation(SqlDataReader reader)
        {
            Graduation graduation = new Graduation();
            graduation.Id = Convert.ToInt32(reader["Graduation_Id"].ToString());
            graduation.Name = reader["Graduation_Name"].ToString();
            return graduation;
        }

        public static Discipline HydrateDiscipline(SqlDataReader reader)
        {
            Discipline discipline = new Discipline();
            discipline.Code = reader["Discipline_Code"].ToString();
            discipline.Name = reader["Discipline_Name"].ToString();
            discipline.TheorycClassesCount = Convert.ToInt32(reader["Discipline_TheorycClassesCount"].ToString());
            discipline.PractiseClassesCount = Convert.ToInt32(reader["Discipline_PractiseClassesCount"].ToString());
            discipline.NumberOfCredits = Convert.ToInt32(reader["Discipline_NumberOfCredits"].ToString());
            discipline.Workload = Convert.ToInt32(reader["Discipline_Workload"].ToString());
            discipline.ClockHours = Convert.ToInt32(reader["Discipline_ClockHours"].ToString());
            return discipline;
        }

    }
}