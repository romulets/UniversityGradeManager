using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UniversityGradeManager.Views.Template.GraduationGrade
{
    public partial class Graduation : System.Web.UI.UserControl
    {
        public Entities.Graduation Entity { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}