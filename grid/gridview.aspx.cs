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
    public partial class gridview : System.Web.UI.Page
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
                st = "select*from tabledemo";
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
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            griddata();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            griddata();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            con.ConnectionString = "Data Source=tamizh\\SQLEXPRESS;Integrated Security=True;Initial Catalog=shipment;";
            con.Open();
            string st = "";
            TextBox txtregisterid = GridView1.Rows[e.RowIndex].FindControl("textbox1") as TextBox;
            TextBox txtcity = GridView1.Rows[e.RowIndex].FindControl("textbox2") as TextBox;
            TextBox txtname = GridView1.Rows[e.RowIndex].FindControl("textbox3") as TextBox;
            TextBox txtvehicleno = GridView1.Rows[e.RowIndex].FindControl("textbox4") as TextBox;

            st = "update tabledemo set city='"+txtcity.Text+ "',name='" + txtname.Text + "',vehicle_no='" + txtvehicleno.Text + "' where Register_Id=" + txtregisterid.Text + "";
            cmd = new SqlCommand(st,con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            griddata();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < GridView1.Rows.Count; i++)
            {
                Response.Write(GridView1.Rows[i].Cells[3].Text);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow item in GridView1.Rows)
            {
                var check = item.FindControl("CheckBox1") as CheckBox;

                if (check.Checked == true)
                {                  
                    Response.Write(item.Cells[3].Text);                  
                }
            }
        }
    }
}