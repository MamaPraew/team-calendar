using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.Bootstrap;
using ORA_BEL;
using ORA_BLL;


namespace Calendar_Web
{
    public partial class emp_calendar : System.Web.UI.Page
    {

        private List<empInfo> lstEMP;
        private List<Employee_Leave> lstLeave;
        private List<Employee_Leave> lstLeaveAll;
        private List<empInfo> lstEMPAll;
        private string sMode = "";
        private List<empInfo> LstEmpInfo(string deptno)
        {
            List<empInfo> lst = new List<empInfo>();


            try
            {

                using (empInfoBLL empInfo = new empInfoBLL())
                {
                    lstEMP = empInfo.GeEmpInfoByDep(deptno);
                    if (lstEMP != null)
                    {

                        var qry = (from e in lstEMP
                                  // where e.DEPARTMENT == empNo
                                   select e).ToList<empInfo>();

                        lst = qry;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return lst;
        }      
        private List<Employee_Leave> lstEmpLeaveAll(string deptno,string empno)
        {
            
            List<Employee_Leave> lst = new List<Employee_Leave>();


            try
            {

                using (Emp_leave_info empInfo = new Emp_leave_info())
                {

                   

                    lstLeaveAll = empInfo.GetListEmpLeave(deptno, empno);

                    

                    if (lstLeaveAll != null)
                    {

                        var qry = (from e in lstLeaveAll
                                       //where e.DTEWORK >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
                                   select e).ToList<Employee_Leave>();

                        lst = qry;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return lst;
        }
        protected void FillEmpCombo(string deptNo)
        {

            //Show("FillEmpCombo" + " - " + deptNo);


            if (string.IsNullOrEmpty(deptNo)) return;

            //  using (var context = new WorldCitiesContext())
            //{

            //var country = lstEmp.SingleOrDefault(c => c.CountryName == countryName);


            //sMode = "combobox";




            //cmbEmp.Value = lstEmp.FirstOrDefault().CODEMPID;
            // }



            if (deptNo == "All")
            {

                List<empInfo> lstEmpAll = new List<empInfo>();
                lstEmpAll = LstEmpUnder(Session["emp_no"].ToString(),null, Session["emp_login_dept"].ToString());
                cmbEmp.DataSource = lstEmpAll;
                cmbEmp.DataBind();

                //Session["SelDept"] = null;
                //Session["Selempno"] = null;

                //string uDept = sDept(Session["emp_no"].ToString()).TrimEnd(',');

                //Session["SelDept"] = uDept;
                //Session["Selempno"] = null;

            }
            else
            {

                List<empInfo> lstEmp = new List<empInfo>();
                lstEmp = LstEmpInfo(deptNo);
                cmbEmp.DataSource = lstEmp;
                cmbEmp.DataBind();
            }




            cmbEmp.Items.Insert(0, new DevExpress.Web.Bootstrap.BootstrapListEditItem("All Employee", "All"));

            //string sEmp = "";
            //this.BootstrapScheduler1.AppointmentDataSource = lstEmpLeaveAll(deptNo, sEmp);



          
        }
        private string sDept(string sUser)
        {
            string sDept = "";

            using (SqlConnection _con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString))
            {
                string queryStatement = "sp_CalendarDept";

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
                            if(dr["sap_no"].ToString() != "All")
                            sDept = dr["sap_no"].ToString() + "," + sDept;


                        }


                    }
                }
            }
            return sDept;
        }
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {

            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName].ToString(), null);
                    else
                        continue;
                }
            }
            return obj;
        }
        private List<empInfo> LstEmpUnder(string empno,string dept,string dep_all)
        {
            List<empInfo> lst = new List<empInfo>();


            try
            {

               

                using (SqlConnection _con = new SqlConnection(WebConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString))
                {
                    string queryStatement = "sp_CalendarEmp";

                    using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                    {

                        _cmd.CommandType = CommandType.StoredProcedure;
                        //_cmd.Parameters.AddWithValue("@sUser", sUser);
                        _cmd.Parameters.Add(new SqlParameter("@emp_no", empno));
                        _cmd.Parameters.Add(new SqlParameter("@p_department", dept));
                        _cmd.Parameters.Add(new SqlParameter("@p_department_all", dep_all));

                        DataTable customerTable = new DataTable("TBuser");
                        SqlDataAdapter _dap = new SqlDataAdapter(_cmd);

                        _con.Open();
                        _dap.Fill(customerTable);

                        if (customerTable.Rows.Count > 0)
                        {

                            DataRow row = customerTable.Rows[0];

                            //foreach (DataRow dr in customerTable.Rows)
                            //{
                            //    //TextBox1.Text = dr["ImagePath"].ToString();
                            //    sDept = dr["sap_no"].ToString() + "," + sDept;


                            //}

                            lst = ConvertDataTable<empInfo>(customerTable);


                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return lst;
        }
        private List<Employee_Leave> lstEmpLeave(string deptno, string empno)
        {
            List<Employee_Leave> lst = new List<Employee_Leave>();


            try
            {

                using (Emp_leave_info empInfo = new Emp_leave_info())
                {
                    lstLeave = empInfo.GetListEmpLeave(deptno, empno);
                    if (lstLeave != null)
                    {

                        var qry = (from e in lstLeave
                                   where e.DTEWORK >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
                                   select e).ToList<Employee_Leave>();

                        lst = qry;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return lst;
        }
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

                string emp_no = "";
               

                if (Request.Cookies["userid"] != null)
                {
                    emp_no = Request.Cookies["userid"].Value;
                    Session["emp_no"] = emp_no;

                    


                }
                else
                {

                    if(Session["emp_no"] == null)
                    {

                        Session.Clear();
                        Session.Abandon();

                        Response.Redirect("Default.aspx");
                        

                    }
                    else
                    {
                        emp_no = Session["emp_no"].ToString();

                       

                    }
                   // emp_no = "OTD01050";


                    
                }





                string uDept = sDept(emp_no).TrimEnd(',');

                Session["SelDept"] = uDept;
                Session["Selempno"] = null;

                sMode = "pageload";

                

                this.cmbEmp.DataBind();

                cmbEmp.Items.Insert(0, new DevExpress.Web.Bootstrap.BootstrapListEditItem("All Employee", "All"));

                //this.BootstrapScheduler1.AppointmentDataSource = lstEmpLeave(uDept, null);

                // this.BootstrapScheduler1.DataBind();

            }


            
          

        }

        protected void CallbackPanel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (!string.IsNullOrEmpty(e.Parameter))
            {
                string sDept = "";
                string sEmp = "";

                if(e.Parameter == "All")
                {
                    //ObjectDataSource2.SelectParameters.Add("emp", null);
                    //ObjectDataSource1.SelectParameters.Add("emp", null);
                    //Selempno
                    sEmp = "";
                }
                else
                {
                    //ObjectDataSource2.SelectParameters.Add("emp", null);
                    //ObjectDataSource1.SelectParameters.Add("emp", e.Parameter);
                    sEmp = e.Parameter;
                }

                //Session["SelDept"] = hfSelDep["hfSelDep"];
                Session["Selempno"] = sEmp;//hfSelEmp["hfSelEmp"];

                //ObjectDataSource1.SelectParameters.Add("dept", Session["SelDept"].ToString());
                //ObjectDataSource1.SelectParameters.Add("emp", Session["Selempno"].ToString());

                sMode = "callback";

                

                //this.BootstrapScheduler1.AppointmentDataSource = lstEmpLeaveAll(hfSelDep["hfSelDep"].ToString(), sEmp);
                BootstrapScheduler1.DataBind();
            }

        }

        protected void cmbEmp_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            FillEmpCombo(e.Parameter);

            sMode = "callback";

            

            if(e.Parameter == "All")
            {
                string uDept = sDept(Session["emp_no"].ToString()).TrimEnd(',');
                Session["SelDept"] = uDept;
            }
            else
            {
                Session["SelDept"] = e.Parameter;
            }
           
            Session["Selempno"] = null;

            this.BootstrapScheduler1.DataBind();

            // Show("cmbEmp_Callback - FillEmpCombo");
        }

        protected void BootstrapScheduler1_Init(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, 1, 9, 0, 0);
            BootstrapScheduler1.Start = startDate;
        }

        protected void cmbEmp_Init(object sender, EventArgs e)
        {
            //cmbEmp.Items.Insert(0, new DevExpress.Web.Bootstrap.BootstrapListEditItem("Select All", ""));
        }

        protected void cmbEmp_Load(object sender, EventArgs e)
        {
            //cmbEmp.Items.Insert(0, new DevExpress.Web.Bootstrap.BootstrapListEditItem("Select All", null));
        }

        protected void BootstrapScheduler1_DataBinding(object sender, EventArgs e)
        {
            //BootstrapScheduler1.AppointmentDataSource = 
        }

        protected void cmbEmp_DataBinding(object sender, EventArgs e)
        {


            // Show(sMode);

            cmbEmp.Items.Insert(0, new DevExpress.Web.Bootstrap.BootstrapListEditItem("All Employee", "All"));

            if (sMode == "pageload")
            {
                lstEMPAll = new List<empInfo>();
                lstEMPAll = LstEmpUnder(Session["emp_no"].ToString(),null, Session["emp_login_dept"].ToString());
                this.cmbEmp.DataSource = lstEMPAll;
            }
            
        }

        protected void cmdDept_Init(object sender, EventArgs e)
        {
            
        }

        protected void cmdDept_Load(object sender, EventArgs e)
        {
            
        }
    }
}