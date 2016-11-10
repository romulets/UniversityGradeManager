using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityGradeManager.DAL;
using UniversityGradeManager.Entities;
using UniversityGradeManager.Exceptions;

namespace UniversityGradeManager.Helpers
{
    public class ValidatorHelper
    {

        public static void Validate(Discipline discipline)
        {
            if (discipline.Code.Trim().Length == 0)
                throw new Exception("O campo código não pode ficar vazio");

            if (discipline.Period == null)
                throw new Exception("A disciplina deve obrigatóriamente ter um período");

            if (discipline.Period.Graduation == null)
                throw new Exception("O período deve obrigatóriamente ter um curso");

            if (discipline.Name.Trim().Length == 0)
                throw new Exception("O campo nome não pode ficar vazio");

            ValidatePositive(discipline.TheorycClassesCount, "quantidade de aulas teoricas");
            ValidatePositive(discipline.PractiseClassesCount, "quantidade de aulas práticas");
            ValidatePositive(discipline.NumberOfCredits, "quantidade créditos");
            ValidatePositive(discipline.Workload, "horas aula");
            ValidatePositive(discipline.ClockHours, "horas relógio");

            try
            {
                using (DisciplineDao dao = new DisciplineDao())
                    dao.FindByPk(discipline.Code, discipline.Period.Graduation.Id);

                throw new Exception("Já existe uma disciplina com esse código nesse curso");
            }
            catch (EntityNotFoundException e) { /* Entity not found, keep swimming! */}

        }

        private static void ValidatePositive(int field, string fieldName)
        {
            if (field < 0)
                throw new Exception(string.Format("O campo {0} não pode ser menor que 0", fieldName));
        }

    }
}