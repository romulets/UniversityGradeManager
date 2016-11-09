using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityGradeManager.DAL;
using UniversityGradeManager.Exceptions;

namespace UniversityGradeManager.Views.Period
{
    public partial class profile : System.Web.UI.Page
    {
        [Bindable(true)]
        public Entities.Period Period { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                int graduationId = -1;
                int periodNumber = -1;
                int.TryParse(Request.Params["Graduation"], out graduationId);
                int.TryParse(Request.Params["Period"], out periodNumber);

                using (PeriodDao dao = new PeriodDao())
                    Period = dao.FindByPkWithDisciplines(graduationId, periodNumber);
            }
            catch (EntityNotFoundException ex)
            {
                throw new HttpException(404, ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ctrlPeriod.DataBind();
        }
    }
}