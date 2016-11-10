using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityGradeManager.DAL;
using UniversityGradeManager.Exceptions;

namespace UniversityGradeManager.Views.Discipline
{
    public partial class profile : System.Web.UI.Page
    {

        public Entities.Discipline Discipline { get; set; }

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

        }
    }
}