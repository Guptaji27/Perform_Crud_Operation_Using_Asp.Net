using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace CRUD_Using_Ado.Net
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        protected void OnSearch(object sender, EventArgs e)
        {
            this.BindGrid();
            this.MethodClear();
        }

        protected void OnInsert(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            txtCustomerName.Text = string.Empty;
            string customerId = txtCustomerId.Text;
            txtCustomerId.Text = string.Empty;
            string contactName = txtContactName.Text;
            txtContactName.Text = string.Empty;
            string country = txtCountry.Text;
            txtCountry.Text = string.Empty;
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Customers_InsertCustomers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@ContactName", contactName);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
            this.MethodClear();
        }

        protected void OnEdit(object sender, EventArgs e)
        {
            GridViewRow gvRow = (sender as LinkButton).NamingContainer as GridViewRow;
            string customerName = gvRow.Cells[0].Text;
            int customerId = int.Parse(gvRow.Cells[1].Text);
            string contactName = gvRow.Cells[2].Text;
            string country = (gvRow.Cells[3].FindControl("lblCountry") as Label).Text;
            txtCustomerName.Text = customerName;
            txtCustomerId.Text = customerId.ToString().Trim();
            txtContactName.Text = contactName;
            txtCountry.Text = country;

            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            btnCancel.Visible = true;
            btnSearch.Visible = true;
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text;
            txtCustomerName.Text = string.Empty;
            string customerId = txtCustomerId.Text;
            txtCustomerId.Text = string.Empty;
            string contactName = txtContactName.Text;
            txtContactName.Text = string.Empty;
            string country = txtCountry.Text;
            txtCountry.Text = string.Empty;
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Customers_UpdateCustomers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    cmd.Parameters.AddWithValue("@ContactName", contactName);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
            this.MethodClear();
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            this.MethodClear();
        }

        protected void OnDelete(object sender, EventArgs e)
        {
            GridViewRow gvRow = (sender as LinkButton).NamingContainer as GridViewRow;
            int customerId = int.Parse(gvRow.Cells[1].Text);
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Customers_DeleteCustomers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
            this.MethodClear();
        }
        #endregion
        #region Private 
        private void BindGrid()
        {
            string customerName = txtCustomerNameSearch.Text;
            txtCustomerNameSearch.Text = string.Empty;
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Customers_GetCustomersByCustomerName", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(customerName))
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", DBNull.Value);
                    }
                    gvCustomers.DataSource = cmd.ExecuteReader();
                    gvCustomers.DataBind();
                    con.Close();
                    btnUpdate.Visible = false;
                }
            }
        }

        private void MethodClear()
        {
            txtCustomerName.Text = string.Empty;
            txtCustomerId.Text = string.Empty;
            txtContactName.Text = string.Empty;
            txtCountry.Text = string.Empty;

            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }
        #endregion
    }
}