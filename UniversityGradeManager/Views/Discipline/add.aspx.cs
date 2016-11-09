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
            ErrorMessage = "Not implemented.";
        }
    }
}