using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UniversityGradeManager.DAL;
using UniversityGradeManager.Exceptions;
using UniversityGradeManager.Helpers;

namespace UniversityGradeManager.Views.Discipline
{
    public partial class add : System.Web.UI.Page
    {
        public Entities.Period Period { get; set; }

        public string ErrorMessage
        {
            set
            {
                pnErrorMessage.Visible = true;
                HtmlGenericControl ctrl = new HtmlGenericControl("span");
                ctrl.InnerText = value;
                pnErrorMessage.Controls.Add(ctrl);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                int graduationId = -1;
                int periodNumber = -1;
                int.TryParse(Request.Params["Graduation"], out graduationId);
                int.TryParse(Request.Params["Period"], out periodNumber);

                using (PeriodDao dao = new PeriodDao())
                    Period = dao.FindByPkWithoutDisciplines(graduationId, periodNumber);
            }
            catch (EntityNotFoundException ex)
            {
                throw new HttpException(404, ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnErrorMessage.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.Discipline discipline = ExtractDisciplineFromForm();
                using (DisciplineDao dao = new DisciplineDao())
                    dao.Insert(discipline);

                Response.Redirect(string.Format("../Period/profile.aspx?Graduation={0}&Period={1}", Period.Graduation.Id, Period.Number));
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected Entities.Discipline ExtractDisciplineFromForm()
        {
            Entities.Discipline discipline = new Entities.Discipline();
            discipline.Period = Period;
            discipline.Code = txtCode.Text;
            discipline.Name = txtName.Text;
            discipline.TheorycClassesCount = GetInt(txtTheorycClassesCount, "Quantidade de Aulas Teoricas");
            discipline.PractiseClassesCount = GetInt(txtPractiseClassesCount, "Quantidade de Aulas Práticas");
            discipline.NumberOfCredits = GetInt(txtNumberOfCredits, "Quantidade Créditos");
            discipline.Workload = GetInt(txtWorkload, "Horas Aula");
            discipline.ClockHours = GetInt(txtClockHours, "Horas Relógio");
            ValidatorHelper.Validate(discipline);
            return discipline;
        }

        private int GetInt(TextBox field, string fieldName)
        {
            int value = -1;
            if (!int.TryParse(field.Text, out value))
                throw new Exception(string.Format("O campo {0} deve ser numérico", fieldName));
            return value;
        }
    }
}