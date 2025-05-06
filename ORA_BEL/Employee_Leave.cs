using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORA_BEL 
{
    [Serializable]
    public class Employee_Leave : IDisposable
    {
        public Nullable<decimal> ROW_NO { get; set; }
        public string CODEMPID { get; set; }
        public Nullable<System.DateTime> DTEWORK { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string CODLEAVE { get; set; }
        public string TYPLEAVE { get; set; }
        public string STALEAVE { get; set; }
        public string CODCOMP { get; set; }
        public string TYPPAYROLL { get; set; }
        public string CODSHIFT { get; set; }
        public string FLGATTEN { get; set; }
        public string TIMSTRT { get; set; }
        public string TIMEND { get; set; }
        public Nullable<decimal> QTYMIN { get; set; }
        public Nullable<decimal> QTYDAY { get; set; }
        public Nullable<decimal> QTYLVDED { get; set; }
        public string AMTLVDED { get; set; }
        public string NUMLEREQ { get; set; }
        public string DESLEREQ { get; set; }
        public Nullable<decimal> DTEYREPAY { get; set; }
        public Nullable<decimal> DTEMTHPAY { get; set; }
        public Nullable<decimal> NUMPERIOD { get; set; }
        public Nullable<decimal> DTEYRERET { get; set; }
        public Nullable<decimal> DTEMTHRET { get; set; }
        public Nullable<decimal> NUMPRDRET { get; set; }
        public string CODUSER { get; set; }
        public string NAMETHAI { get; set; }
        public string NAMEENG { get; set; }
        public string NICKNAME { get; set; }
        public string POST { get; set; }
        public string DEPARTMENT { get; set; }
        public string JOBGRADE { get; set; }
        public Nullable<System.DateTime> STRATDATE { get; set; }
        public string STAEMP { get; set; }
        public Nullable<System.DateTime> RESIGNDATE { get; set; }
        public string TELOFF { get; set; }
        public string NUMTEL { get; set; }
        public string FLOOR { get; set; }
        public string NUMOFFID { get; set; }
        public string NAMEBANK { get; set; }
        public string NUMBANK { get; set; }
        public string MOBILE { get; set; }
        public string EMAIL { get; set; }
        public string COMPANY_CODE { get; set; }
        public string COMPANY_NAME { get; set; }

        public Nullable<int> Label { get; set; }

        public string Description { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}