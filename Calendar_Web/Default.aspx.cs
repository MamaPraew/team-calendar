using ORA_BEL;
using ORA_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calendar_Web
{
    public partial class Default : System.Web.UI.Page
    {

        public static void Show(string message)
        {
            string cleanMessage = message.Replace("'", "\'");
            string script = string.Format("alert('{0}');", cleanMessage);
            if (HttpContext.Current.CurrentHandler is Page page && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
            }
        }

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Request.Cookies["userid"] != null)
                {

                    Session["emp_no"] = Request.Cookies["userid"].Value;
                    Response.Redirect("emp_calendar.aspx");

                }
                else
                {
                    //Session["emp_no"] = null;
                    //Response.Redirect("Default.aspx");
                }

                

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string sUser = "";
            string sPwdType = "";
            string sPwd = "";
            sPwd = this.password.Value.ToString();
            string dbPwd = "";
            sUser = this.username.Value.ToString().ToUpper();

            using (SqlConnection _con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString))
            {
                string queryStatement = "spGetUserPassword";

                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {

                    _cmd.CommandType = CommandType.StoredProcedure;
                    //_cmd.Parameters.AddWithValue("@sUser", sUser);
                    _cmd.Parameters.Add(new SqlParameter("@emp_no", sUser));

                    DataTable customerTable = new DataTable("TBuser");
                    SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                    _con.Open();
                    _dap.Fill(customerTable);

                    if (customerTable.Rows.Count > 0)
                    {

                        DataRow row = customerTable.Rows[0];

                        foreach (DataRow dr in customerTable.Rows)
                        {
                            //TextBox1.Text = dr["ImagePath"].ToString();
                            sPwdType = dr["password_type"].ToString();

                        }

                        if(sPwdType == "Bypass Password")
                        {
                            //return;
                            Session["emp_no"] = sUser;

                            List<empInfo> lst = new List<empInfo>();
                            using (empInfoBLL empInfo = new empInfoBLL())
                            {
                                lst = empInfo.GeEmpInfoByEmpID(sUser);
                                if (lst != null)
                                {

                                    var qry = (from z in lst
                                                   // where e.DEPARTMENT == empNo
                                               select z).ToList<empInfo>();

                                    lst = qry;
                                    Session["emp_login_dept"] = lst.FirstOrDefault().DEPARTMENT.Substring(0, 9);
                                }
                            }

                            



                            Response.Redirect("emp_calendar.aspx");
                        }
                       
                        string hashedPwd = row.Field<string>("password");
                        string emp_no = row.Field<string>("emp_no").Trim();

                        bool isPasswordMatched = BCrypt.Net.BCrypt.Verify(sPwd, hashedPwd);

                       // Console.WriteLine($"Password Match: {isPasswordMatched}");

                        if (isPasswordMatched)
                        {
                            // Console.Write("Password match!");


                            if (chkRemember.Checked == true)
                            {
                                Response.Cookies["userid"].Value = sUser;
                                Response.Cookies["pwd"].Value = sPwd;
                                Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                                Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);
                            }
                            else
                            {
                                Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);
                                Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);
                            }


                            Session["emp_no"] = emp_no;
                            Response.Redirect("emp_calendar.aspx");
                        }
                        else
                        {
                            // Console.Write("Password did not match!");
                            Show("Password did not match!");
                        }
                    }
                    else
                    {
                        //Console.Write("User not found!");
                        Show("User not found!");

                    }

                    _con.Close();
                }
            }
        }
    }
}