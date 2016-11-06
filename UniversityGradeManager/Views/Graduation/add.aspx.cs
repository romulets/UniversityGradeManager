using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityGradeManager.DAL;

namespace UniversityGradeManager.Views.Graduation
{
    public partial class add : System.Web.UI.Page
    {

        public string ErrorMessage
        {
            set
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length == 0)
            {
                ErrorMessage = "Campo nome é obrigatório";
                return;
            }

            Entities.Graduation graduation = new Entities.Graduation();
            graduation.Name = txtName.Text.Trim();

            try
            {
                using (GraduationDAO dao = new GraduationDAO())
                    dao.Insert(graduation);
                Server.Transfer("profile.aspx?Id=" + graduation.Id, true);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}