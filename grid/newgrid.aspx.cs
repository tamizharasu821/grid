using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace grid
{
    public partial class newgrid : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlDataAdapter ad = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                griddata();
            }
        }
        public void griddata()
        {
            try
            {
                con.ConnectionString = "Data Source=tamizh\\SQLEXPRESS;Integrated Security=True;Initial Catalog=shipment;";
                con.Open();
                string st = "";
                st = "select*from salary_details";
                ad = new SqlDataAdapter(st, con);
                ds.Clear();
                ad.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }


       /* protected void CheckBox1_CheckedChanged1(object sender, EventArgs e)
        {
            Response.Write(GridView1.Rows.Count);
            *//*for (int i = 0; i < GridView1.Rows.Count - 1; i++)
            {
                Response.Write(GridView1.Rows[i].Cells[2].Text);
            }*//*
        }*/

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count - 1; i++)
            {
                Response.Write(GridView1.Rows[i].Cells[2].Text);
                

            }
        }
    }
}