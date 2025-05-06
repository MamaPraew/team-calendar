using ORA_BEL;
using ORA_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORA_BLL
{
    public class empInfoBLL : IDisposable
    {

        private bool IsDisposed = false;

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool Disposing)
        {
            if (!IsDisposed)
            {
                if (Disposing)
                {
                    //this.CloseConnection();
                }
            }

            IsDisposed = true;
        }

        ~empInfoBLL()
        {
            this.Dispose(false);
        }

        #endregion

        public List<empInfo> GeEmpInfoByEmpID( string emp_id)
        {
            List<empInfo> lstWhIn = null;
            try
            {

                string qry = "";

                qry = "SELECT CODEMPID, NAMETHAI, NAMEENG, NICKNAME, POST, DEPARTMENT, JOBGRADE, STRATDATE, STAEMP, RESIGNDATE, TELOFF, NUMTEL, FLOOR, NUMOFFID, NAMEBANK, NUMBANK, MOBILE, EMAIL, DTECREATE, T1DTEUPD, T2DTEUPD, T3DTEUPD, T4DTEUPD, COMPANY_CODE, COMPANY_NAME FROM v_employee where CODEMPID = '" + emp_id + "'";

               // ProcParam procPara = new ProcParam(0) { ProcedureName = qry };

                //procPara.AddParamInput(0, "P_DEP", dept);
                //procPara.AddParamInput(1, "P_EMP", emp);
                //procPara.AddParamRefCursor(2, "SYS_REF");



                OraDataReader.Instance.OraReader = GlobalDB.Instance.DataAc.ExecuteDataReader(qry);

                //this.executionTime = GlobalDB.Instance.DataAc.ExecuteTime;

                if (OraDataReader.Instance.OraReader.HasRows)
                {
                    lstWhIn = new List<empInfo>();

                    OraDataReader.Instance.OraReader.FetchSize = OraDataReader.Instance.OraReader.RowSize * 100;

                    while (OraDataReader.Instance.OraReader.Read())
                    {
                        //empInfo whIn = new empInfo
                        //{
                        //    CODEMPID = OraDataReader.Instance.GetString("CODEMPID")
                        //};

                        empInfo whIn = new empInfo();

                        whIn.CODEMPID = OraDataReader.Instance.GetString("CODEMPID");

                        if (!OraDataReader.Instance.IsDBNull("STRATDATE"))
                            whIn.STRATDATE = OraDataReader.Instance.GetDateTime("STRATDATE");

                        //if (!OraDataReader.Instance.IsDBNull("StartTime"))
                        //    whIn.StartTime = OraDataReader.Instance.GetDateTime("StartTime");

                        //if (!OraDataReader.Instance.IsDBNull("EndTime"))
                        //    whIn.EndTime = OraDataReader.Instance.GetDateTime("EndTime");

                        whIn.NAMETHAI = OraDataReader.Instance.GetString("NAMETHAI");
                        whIn.NAMEENG = OraDataReader.Instance.GetString("NAMEENG");
                        whIn.NICKNAME = OraDataReader.Instance.GetString("NICKNAME");
                        whIn.POST = OraDataReader.Instance.GetString("POST");

                        //if (!OraDataReader.Instance.IsDBNull("RECEIVE_DT"))
                        //    whIn.CODCOMP = OraDataReader.Instance.GetDateTime("RECEIVE_DT");

                        whIn.DEPARTMENT = OraDataReader.Instance.GetString("DEPARTMENT");
                        whIn.JOBGRADE = OraDataReader.Instance.GetString("JOBGRADE");
                        whIn.STAEMP = OraDataReader.Instance.GetString("STAEMP");
                        whIn.TELOFF = OraDataReader.Instance.GetString("TELOFF");
                        whIn.NUMTEL = OraDataReader.Instance.GetString("NUMTEL");

                        //if (!OraDataReader.Instance.IsDBNull("QTYMIN"))
                        //    whIn.QTYMIN = OraDataReader.Instance.GetDecimal("QTYMIN");

                        //whIn.QTYDAY = OraDataReader.Instance.GetInteger("QTYDAY");

                        //if (!OraDataReader.Instance.IsDBNull("QTYLVDED"))
                        //    whIn.QTYLVDED = OraDataReader.Instance.GetInteger("QTYLVDED");

                        whIn.FLOOR = OraDataReader.Instance.GetString("FLOOR");
                        whIn.NUMOFFID = OraDataReader.Instance.GetString("NUMOFFID");
                        whIn.NAMEBANK = OraDataReader.Instance.GetString("NAMEBANK");

 

                        whIn.NUMBANK = OraDataReader.Instance.GetString("NUMBANK");
                        whIn.MOBILE = OraDataReader.Instance.GetString("MOBILE");
                        whIn.EMAIL = OraDataReader.Instance.GetString("EMAIL");
                        whIn.COMPANY_CODE = OraDataReader.Instance.GetString("COMPANY_CODE");
                        whIn.COMPANY_NAME = OraDataReader.Instance.GetString("COMPANY_NAME");
                        whIn.emp_img  = OraDataReader.Instance.GetString("emp_img");





                        lstWhIn.Add(whIn);
                    }

                }

                // always call Close when done reading.
                OraDataReader.Instance.Close();

                if (GlobalDB.Instance.DataAc.LastException != null)
                    throw GlobalDB.Instance.DataAc.LastException;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstWhIn;
        }


        public List<empInfo> GeEmpInfoByDep(string dept)
        {
            List<empInfo> lstWhIn = null;
            try
            {

                string qry = "";


                ProcParam procPara = new ProcParam(2) { ProcedureName = "SP_EMP_INFO" };

                procPara.AddParamInput(0, "P_dept", dept);
                procPara.AddParamRefCursor(1, "SYS_REF");



                OraDataReader.Instance.OraReader = GlobalDB.Instance.DataAc.ExecuteDataReader(procPara);

                //this.executionTime = GlobalDB.Instance.DataAc.ExecuteTime;

                if (OraDataReader.Instance.OraReader.HasRows)
                {
                    lstWhIn = new List<empInfo>();

                    OraDataReader.Instance.OraReader.FetchSize = OraDataReader.Instance.OraReader.RowSize * 100;

                    while (OraDataReader.Instance.OraReader.Read())
                    {
                        //empInfo whIn = new empInfo
                        //{
                        //    CODEMPID = OraDataReader.Instance.GetString("CODEMPID")
                        //};

                        empInfo whIn = new empInfo();

                        whIn.CODEMPID = OraDataReader.Instance.GetString("CODEMPID");

                        if (!OraDataReader.Instance.IsDBNull("STRATDATE"))
                            whIn.STRATDATE = OraDataReader.Instance.GetDateTime("STRATDATE");

                        //if (!OraDataReader.Instance.IsDBNull("StartTime"))
                        //    whIn.StartTime = OraDataReader.Instance.GetDateTime("StartTime");

                        //if (!OraDataReader.Instance.IsDBNull("EndTime"))
                        //    whIn.EndTime = OraDataReader.Instance.GetDateTime("EndTime");
                        whIn.Nname = OraDataReader.Instance.GetString("Nname");
                        whIn.NAMETHAI = OraDataReader.Instance.GetString("NAMETHAI");
                        whIn.NAMEENG = OraDataReader.Instance.GetString("NAMEENG");
                        whIn.NICKNAME = OraDataReader.Instance.GetString("NICKNAME");
                        whIn.POST = OraDataReader.Instance.GetString("POST");

                        //if (!OraDataReader.Instance.IsDBNull("RECEIVE_DT"))
                        //    whIn.CODCOMP = OraDataReader.Instance.GetDateTime("RECEIVE_DT");

                        whIn.DEPARTMENT = OraDataReader.Instance.GetString("DEPARTMENT");
                        whIn.JOBGRADE = OraDataReader.Instance.GetString("JOBGRADE");
                        whIn.STAEMP = OraDataReader.Instance.GetString("STAEMP");
                        whIn.TELOFF = OraDataReader.Instance.GetString("TELOFF");
                        whIn.NUMTEL = OraDataReader.Instance.GetString("NUMTEL");

                        //if (!OraDataReader.Instance.IsDBNull("QTYMIN"))
                        //    whIn.QTYMIN = OraDataReader.Instance.GetDecimal("QTYMIN");

                        //whIn.QTYDAY = OraDataReader.Instance.GetInteger("QTYDAY");

                        //if (!OraDataReader.Instance.IsDBNull("QTYLVDED"))
                        //    whIn.QTYLVDED = OraDataReader.Instance.GetInteger("QTYLVDED");

                        whIn.FLOOR = OraDataReader.Instance.GetString("FLOOR");
                        whIn.NUMOFFID = OraDataReader.Instance.GetString("NUMOFFID");
                        whIn.NAMEBANK = OraDataReader.Instance.GetString("NAMEBANK");



                        whIn.NUMBANK = OraDataReader.Instance.GetString("NUMBANK");
                        whIn.MOBILE = OraDataReader.Instance.GetString("MOBILE");
                        whIn.EMAIL = OraDataReader.Instance.GetString("EMAIL");
                        whIn.COMPANY_CODE = OraDataReader.Instance.GetString("COMPANY_CODE");
                        whIn.COMPANY_NAME = OraDataReader.Instance.GetString("COMPANY_NAME");





                        lstWhIn.Add(whIn);
                    }

                }

                // always call Close when done reading.
                OraDataReader.Instance.Close();

                if (GlobalDB.Instance.DataAc.LastException != null)
                    throw GlobalDB.Instance.DataAc.LastException;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstWhIn;
        }

    }
}