using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UniversityGradeManager.DAL;
using UniversityGradeManager.Exceptions;

namespace UniversityGradeManager.Views.Graduation
{
    public partial class delete : System.Web.UI.Page
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
                int.TryParse(Request.Params["Id"], out id);

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

        protected void btnYes_Click(object sender, EventArgs e)
        {

            try
            {
                using (DeleteDAO dao = new DeleteDAO())
                    dao.Delete(Graduation);
                Response.Redirect("list.aspx", true);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

    }
}