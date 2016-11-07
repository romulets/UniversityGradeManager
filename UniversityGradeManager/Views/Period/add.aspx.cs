using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UniversityGradeManager.DAL;
using UniversityGradeManager.Exceptions;

namespace UniversityGradeManager.Views.Period
{
    public partial class add : System.Web.UI.Page
    {
        public Entities.Graduation Graduation { get; set; }

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
                int id = -1;
                int.TryParse(Request.Params["Graduation"], out id);

                using (GraduationDAO dao = new GraduationDAO())
                    Graduation = dao.FindByPkWithoutRelations(id);
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
                ValidForm();

                Entities.Period period = new Entities.Period();
                period.Number = int.Parse(txtNumber.Text.Trim());
                period.Graduation = Graduation;

                using (PeriodDao dao = new PeriodDao())
                    dao.Insert(period);

                Response.Redirect("../Graduation/profile.aspx?Id=" + Graduation.Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private void ValidForm()
        {
            int number = -1;

            if (txtNumber.Text.Trim().Length == 0)
                throw new Exception("Campo número é obrigatório");

            if (!int.TryParse(txtNumber.Text.Trim(), out number))
                throw new Exception("Campo número deve ser um número inteiro e maior que zero");

            if (number < 1)
                throw new Exception("Campo número deve ser um número inteiro e maior que zero");

            using (PeriodDao dao = new PeriodDao())
            {
                try
                {
                    dao.FindByPkWithoutDisciplines(Graduation, number);
                    throw new Exception("Esse período já existe!");
                }
                catch (EntityNotFoundException) { /* Period not found, so it can be added */ }
            }
        }

    }
}