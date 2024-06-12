using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace grid
{
    public partial class autogrid : System.Web.UI.Page
    {

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // GridView1.DataBind();
            }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            for(int i=0;i<=GridView1.Rows.Count-1;i++)
            {
                Response.Write(GridView1.Rows[1].Cells[2].Text + "<br/>");
            }  
           // Response.Write(GridView1.Rows.Count);
            //Response.Write(GridView1.Rows[0].Cells[3].Text);
        }
    }
}