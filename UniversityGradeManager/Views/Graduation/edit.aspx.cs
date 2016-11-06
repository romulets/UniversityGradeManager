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
    public partial class edit : System.Web.UI.Page
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
            if (!IsPostBack)
                txtName.Text = Graduation.Name;

            lblErrorMessage.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length == 0)
            {
                ErrorMessage = "Campo nome é obrigatório";
                return;
            }

            Graduation.Name = txtName.Text.Trim();

            try
            {
                using (GraduationDAO dao = new GraduationDAO())
                    dao.Update(Graduation);
                Server.Transfer("profile.aspx?Id=" + Graduation.Id, true);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}