using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityGradeManager.DAL;
using UniversityGradeManager.Exceptions;

namespace UniversityGradeManager.Views.Graduation
{
    public partial class fullgrade : System.Web.UI.Page
    {

        [Bindable(true)]
        public Entities.Graduation Graduation { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                int id = -1;
                int.TryParse(Request.Params["Id"], out id);

                using (GraduationDAO dao = new GraduationDAO())
                    Graduation = dao.FindByPkWithPeriodsAndDisciplines(id);
            }
            catch (EntityNotFoundException ex)
            {
                throw new HttpException(404, ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ctrlGraduation.DataBind();
        }
    }
}