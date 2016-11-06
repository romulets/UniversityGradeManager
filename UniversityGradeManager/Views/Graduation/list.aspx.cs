using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityGradeManager.DAL;

namespace UniversityGradeManager.Views.Graduation
{
    public partial class list : System.Web.UI.Page
    {

        public List<Entities.Graduation> Graduations { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            using (GraduationDAO dao = new GraduationDAO())
                Graduations = dao.FindAllWithoutRelations();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}