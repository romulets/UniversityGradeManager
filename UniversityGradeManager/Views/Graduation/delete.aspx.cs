using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                int id = -1;
                int.TryParse(Request.Params["Id"], out id);

                using (GraduationDAO dao = new GraduationDAO())
                    Graduation = dao.FindByIdWithoutRelations(id);
            }
            catch (EntityNotFoundException ex)
            {
                throw new HttpException(404, ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {

            try
            {
                using (DeleteDAO dao = new DeleteDAO())
                    dao.Delete(Graduation);
                Server.Transfer("list.aspx", true);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

    }
}