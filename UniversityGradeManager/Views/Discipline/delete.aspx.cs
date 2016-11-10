using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UniversityGradeManager.DAL;
using UniversityGradeManager.Exceptions;

namespace UniversityGradeManager.Views.Discipline
{
    public partial class delete : System.Web.UI.Page
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
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                using (DeleteDAO dao = new DeleteDAO())
                    dao.Delete(Discipline);
                Response.Redirect(string.Format("../Period/profile.aspx?Graduation={0}&Period={1}", Discipline.Period.Graduation.Id, Discipline.Period.Number));
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}