using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
                pnErrorMessage.Visible = true;
                HtmlGenericControl ctrl = new HtmlGenericControl("span");
                ctrl.InnerText = value;
                pnErrorMessage.Controls.Add(ctrl);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnErrorMessage.Visible = false;
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
                Response.Redirect("profile.aspx?Id=" + graduation.Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}