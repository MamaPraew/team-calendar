using ORA_BEL;
using ORA_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORA_BLL
{
    public class Emp_leave_info : IDisposable
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

        ~Emp_leave_info()
        {
            this.Dispose(false);
        }

        #endregion

        public List<Employee_Leave> GetListEmpLeave(string dept, string emp)
        {
            List<Employee_Leave> lstWhIn = null;
            try
            {


                ProcParam procPara = new ProcParam(3) { ProcedureName = "SP_EMPLOYEE_LEAVE" };

                procPara.AddParamInput(0, "P_DEP", dept);
                procPara.AddParamInput(1, "P_EMP", emp);
                procPara.AddParamRefCursor(2, "SYS_REF");
                
                

                OraDataReader.Instance.OraReader = GlobalDB.Instance.DataAc.ExecuteDataReader(procPara);

                //this.executionTime = GlobalDB.Instance.DataAc.ExecuteTime;

                if (OraDataReader.Instance.OraReader.HasRows)
                {
                    lstWhIn = new List<Employee_Leave>();

                    OraDataReader.Instance.OraReader.FetchSize = OraDataReader.Instance.OraReader.RowSize * 100;

                    while (OraDataReader.Instance.OraReader.Read())
                    {
                        Employee_Leave whIn = new Employee_Leave
                        {
                            CODEMPID = OraDataReader.Instance.GetString("CODEMPID")
                        };

                        if (!OraDataReader.Instance.IsDBNull("DTEWORK"))
                            whIn.DTEWORK = OraDataReader.Instance.GetDateTime("DTEWORK");

                        if (!OraDataReader.Instance.IsDBNull("StartTime"))
                            whIn.StartTime = OraDataReader.Instance.GetDateTime("StartTime");

                        if (!OraDataReader.Instance.IsDBNull("EndTime"))
                            whIn.EndTime = OraDataReader.Instance.GetDateTime("EndTime");

                        whIn.CODLEAVE = OraDataReader.Instance.GetString("CODLEAVE");
                        whIn.TYPLEAVE = OraDataReader.Instance.GetString("TYPLEAVE");
                        whIn.STALEAVE = OraDataReader.Instance.GetString("STALEAVE");
                        whIn.CODCOMP = OraDataReader.Instance.GetString("CODCOMP");

                        //if (!OraDataReader.Instance.IsDBNull("RECEIVE_DT"))
                        //    whIn.CODCOMP = OraDataReader.Instance.GetDateTime("RECEIVE_DT");

                        whIn.TYPPAYROLL = OraDataReader.Instance.GetString("TYPPAYROLL");
                        whIn.CODSHIFT = OraDataReader.Instance.GetString("CODSHIFT");
                        whIn.FLGATTEN = OraDataReader.Instance.GetString("FLGATTEN");
                        whIn.TIMSTRT = OraDataReader.Instance.GetString("TIMSTRT");
                        whIn.TIMEND = OraDataReader.Instance.GetString("TIMEND");

                        if (!OraDataReader.Instance.IsDBNull("QTYMIN"))
                            whIn.QTYMIN = OraDataReader.Instance.GetDecimal("QTYMIN");

                        whIn.QTYDAY = OraDataReader.Instance.GetInteger("QTYDAY");

                        if (!OraDataReader.Instance.IsDBNull("QTYLVDED"))
                            whIn.QTYLVDED = OraDataReader.Instance.GetInteger("QTYLVDED");

                        whIn.AMTLVDED = OraDataReader.Instance.GetString("AMTLVDED");
                        whIn.NUMLEREQ = OraDataReader.Instance.GetString("QTY_UNIT");
                        whIn.DESLEREQ = OraDataReader.Instance.GetString("DESLEREQ");

                        if (!OraDataReader.Instance.IsDBNull("DTEYREPAY"))
                            whIn.DTEYREPAY = OraDataReader.Instance.GetDecimal("DTEYREPAY");


                        if (!OraDataReader.Instance.IsDBNull("DTEMTHPAY"))
                            whIn.DTEMTHPAY = OraDataReader.Instance.GetDecimal("DTEMTHPAY");
                        if (!OraDataReader.Instance.IsDBNull("NUMPERIOD"))
                            whIn.NUMPERIOD = OraDataReader.Instance.GetDecimal("NUMPERIOD");
                        if (!OraDataReader.Instance.IsDBNull("DTEYRERET"))
                            whIn.DTEYRERET = OraDataReader.Instance.GetDecimal("DTEYRERET");
                        if (!OraDataReader.Instance.IsDBNull("DTEMTHRET"))
                            whIn.DTEMTHRET = OraDataReader.Instance.GetDecimal("DTEMTHRET");
                        if (!OraDataReader.Instance.IsDBNull("NUMPRDRET"))
                            whIn.NUMPRDRET = OraDataReader.Instance.GetDecimal("NUMPRDRET");

                        whIn.CODUSER = OraDataReader.Instance.GetString("CODUSER");
                        whIn.NAMETHAI = OraDataReader.Instance.GetString("NAMETHAI");
                        whIn.NAMEENG = OraDataReader.Instance.GetString("NAMEENG");
                        whIn.NICKNAME = OraDataReader.Instance.GetString("NICKNAME");
                        whIn.POST = OraDataReader.Instance.GetString("POST");
                        whIn.DEPARTMENT = OraDataReader.Instance.GetString("DEPARTMENT");
                        whIn.JOBGRADE = OraDataReader.Instance.GetString("JOBGRADE");

                        if (!OraDataReader.Instance.IsDBNull("STRATDATE"))
                            whIn.STRATDATE = OraDataReader.Instance.GetDateTime("STRATDATE");

                        whIn.STAEMP = OraDataReader.Instance.GetString("STAEMP");

                        if (!OraDataReader.Instance.IsDBNull("RESIGNDATE"))
                            whIn.RESIGNDATE = OraDataReader.Instance.GetDateTime("RESIGNDATE");

                        whIn.TELOFF = OraDataReader.Instance.GetString("TELOFF");
                        whIn.NUMTEL = OraDataReader.Instance.GetString("NUMTEL");
                        whIn.FLOOR = OraDataReader.Instance.GetString("FLOOR");
                        whIn.NUMOFFID = OraDataReader.Instance.GetString("NUMOFFID");
                        whIn.NAMEBANK = OraDataReader.Instance.GetString("NAMEBANK");
                        whIn.NUMBANK = OraDataReader.Instance.GetString("NUMBANK");
                        whIn.MOBILE = OraDataReader.Instance.GetString("MOBILE");
                        whIn.EMAIL = OraDataReader.Instance.GetString("EMAIL");
                        whIn.COMPANY_CODE = OraDataReader.Instance.GetString("COMPANY_CODE");
                        whIn.COMPANY_NAME = OraDataReader.Instance.GetString("COMPANY_NAME");

                        whIn.Description = OraDataReader.Instance.GetString("Description");

                        if (!OraDataReader.Instance.IsDBNull("Label"))
                            whIn.Label = OraDataReader.Instance.GetInteger("Label");



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