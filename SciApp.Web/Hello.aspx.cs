using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SciHospital.WebApp
{
    public partial class MyForm : System.Web.UI.Page,IRoutablePage
    {
        public RequestContext RequestContext { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSay_OnClick(object sender, EventArgs e)
        {
            lblMessage.Text = $"Hello at {DateTime.Now}";
        }

    }
}