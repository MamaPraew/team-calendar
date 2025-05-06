using ORA_BEL;
using ORA_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calendar_Web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        private List<empInfo> lstEMP;
        private string getEmpInfo(string empNo)
        {
            string sEmpNo = "";


            try
            {

                using (empInfoBLL empInfo = new empInfoBLL())
                {
                    lstEMP = empInfo.GeEmpInfoByEmpID(empNo);
                    if (lstEMP != null)
                    {

                        var qry = (from e in lstEMP
                                   //where e.CODEMPID == empNo
                                   select e).ToList<empInfo>();

                        sEmpNo = qry.FirstOrDefault().NICKNAME;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return sEmpNo;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if (rememberme.Checked == true)
                //{
                //    Response.Cookies["userid"].Value = textbox1.Text;
                //    Response.Cookies["pwd"].Value = textbox2.Text;
                //    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                //    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);
                //}
                //else
                //{
                //    Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);
                //    Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);
                //}
                //Response.Redirect("user.aspx");

                if (Request.Cookies["userid"] != null || Session["emp_no"] != null)
                {
                    string empNo = "";

                    if(Request.Cookies["userid"] != null)
                    {
                        empNo = Request.Cookies["userid"].Value;
                    }
                    else
                    {
                        empNo = Session["emp_no"].ToString();
                    }

                    this.lblNickName.Text = getEmpInfo(empNo);
                    this.lblEmpNo.Text = empNo;
                }
                else
                {
                    this.lblNickName.Text = "";
                    this.lblEmpNo.Text = "";
                }
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            //Request.Cookies["userid"].Value = null;
            Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("Default.aspx");
        }
    }
}