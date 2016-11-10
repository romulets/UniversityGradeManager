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
    public partial class edit : System.Web.UI.Page
    {
        public Entities.Discipline Discipline { get; set; }

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

        public void Page_Init(object sender, EventArgs e)
        {
            try
            {
                int graduationId = -1;
                string disciplineCode;
                int.TryParse(Request.Params["Graduation"], out graduationId);
                disciplineCode = Request.Params["Discipline"] ?? string.Empty;

                using (DisciplineDao dao = new DisciplineDao())
                    Discipline = dao.FindByPk(disciplineCode, graduationId);
            }
            catch (EntityNotFoundException ex)
            {
                throw new HttpException(404, ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnErrorMessage.Visible = false;

            if (!IsPostBack)
            {
                txtName.Text = Discipline.Name;
                txtTheorycClassesCount.Text = Discipline.TheorycClassesCount.ToString();
                txtPractiseClassesCount.Text = Discipline.PractiseClassesCount.ToString();
                txtNumberOfCredits.Text = Discipline.NumberOfCredits.ToString();
                txtWorkload.Text = Discipline.Workload.ToString();
                txtClockHours.Text = Discipline.ClockHours.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.Discipline discipline = ExtractDisciplineFromForm();
                using (DisciplineDao dao = new DisciplineDao())
                    dao.Update(discipline);

                Response.Redirect(string.Format("profile.aspx?Graduation={0}&Discipline={1}", Discipline.Period.Graduation.Id, Discipline.Code));
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected Entities.Discipline ExtractDisciplineFromForm()
        {
            Discipline.Name = txtName.Text;
            Discipline.TheorycClassesCount = GetInt(txtTheorycClassesCount, "Quantidade de Aulas Teoricas");
            Discipline.PractiseClassesCount = GetInt(txtPractiseClassesCount, "Quantidade de Aulas Práticas");
            Discipline.NumberOfCredits = GetInt(txtNumberOfCredits, "Quantidade de Créditos");
            Discipline.Workload = GetInt(txtWorkload, "Horas Aula");
            Discipline.ClockHours = GetInt(txtClockHours, "Horas Relógio");
            ValidatorHelper.Validate(Discipline, Discipline.Code, Discipline.Period.Graduation.Id);
            return Discipline;
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