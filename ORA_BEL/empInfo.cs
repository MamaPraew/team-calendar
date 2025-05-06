using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORA_BEL
{
    public class empInfo : IDisposable
    {

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string CODEMPID { get; set; }

        public string EMP_NO { get; set; }
        public string NAMETHAI { get; set; }
        public string NAMEENG { get; set; }

        public string Nname { get; set; }

        public string NICKNAME { get; set; }
        public string POST { get; set; }
        public string DEPARTMENT { get; set; }
        public string JOBGRADE { get; set; }
        public Nullable<System.DateTime> STRATDATE { get; set; }
        public string STAEMP { get; set; }
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
        public string Description { get; set; }

        public string emp_img { get; set; }
        
    }
}