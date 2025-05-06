using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace Calendar_Web
{
    public class LDAPAuthenticate
    {

        #region Declare
        private string _LDAP_ONE = ConfigurationManager.AppSettings["LDAP_ONE"];
        private string _LDAP_CHA = ConfigurationManager.AppSettings["LDAP_CHA"];
        private string _LDAP_GTV = ConfigurationManager.AppSettings["LDAP_GTV"];
        private string _LDAP_ATM = ConfigurationManager.AppSettings["LDAP_ATM"];
        private string _LDAP_GHC = ConfigurationManager.AppSettings["LDAP_GHC"];

        const string _MyApps = "Calendar_Web";

        public string MyErrorHandler
        {
            get; set;
        }
        public string MyUID
        {
            get; set;
        }
        public string MyTelephoneNumber
        {
            get; set;
        }
        public string MyDepartmentCode
        {
            get; set;
        }
        public string MyDepartmentNumber
        {
            get; set;
        }
        public string MyDepartmentName
        {
            get; set;
        }
        public string MyEmail
        {
            get; set;
        }
        public string MyFullName
        {
            get; set;
        }
        public string MyLocation
        {
            get; set;
        }
        public string MyDivision
        {
            get; set;
        }
        public string MyManager
        {
            get; set;
        }
        public string MyManagerName
        {
            get; set;
        }
        public string MyManagerUID
        {
            get; set;
        }
        public string MyManagerEmail
        {
            get; set;
        }
        public string MyManagerTelephoneNumber
        {
            get; set;
        }

        public string MysAMAccountName
        {
            get; set;
        }

        public string MyPostalCode
        {
            get; set;
        }
        public DataSet MyStaff
        {
            get; set;
        }


        public string department
        {
            get; set;
        }

        public string postalCode
        {
            get; set;
        }
        public string CN
        {
            get; set;
        }
        public string sAMAccountName
        {
            get; set;
        }
        public string telephoneNumber
        {
            get; set;
        }
        public string userAccountControl
        {
            get; set;
        }

        public string MyEmailAddress
        {
            get; set;
        }
        #endregion

        #region Method


        public DataTable Authenticated(string GlobalID, string OneEpassword)
        {
            DataTable dtOne = new DataTable();
            DataTable dtCha = new DataTable();
            DataTable dtGtv = new DataTable();
            DataTable dtAtm = new DataTable();
            DataTable dtGhc = new DataTable();
            DataTable table = PersonalTable();

            DirectoryEntry rootOneE = new DirectoryEntry(_LDAP_ONE, "CN=itdevauth,OU=ONEUsers,DC=one31,DC=net", "ONEEP@ssw0rd", AuthenticationTypes.ServerBind);
            DirectoryEntry rootCha = new DirectoryEntry(_LDAP_CHA, "CN=itdevauth,OU=IT,OU=Change2561,DC=change2561,DC=com", "ONEEP@ssw0rd", AuthenticationTypes.ServerBind);
            DirectoryEntry rootGtv = new DirectoryEntry(_LDAP_GTV, "CN=itdevauth,OU=MIS,OU=GMM-TV,DC=gmm-tv,DC=com", "ONEEP@ssw0rd", AuthenticationTypes.ServerBind);
            DirectoryEntry rootAtm = new DirectoryEntry(_LDAP_ATM, "CN=itdevauth,OU=IT,OU=MIS,OU=Atimemedia,DC=atimemedia,DC=com", "ONEEP@ssw0rd", AuthenticationTypes.ServerBind);
            DirectoryEntry rootGhc = new DirectoryEntry(_LDAP_GHC, "CN=itauth,OU=IT,OU=GMMChannelholding,DC=gmmchannelholding,DC=com", "P@ssw0rd", AuthenticationTypes.ServerBind);

           // DirectoryEntry rootOneEE = new DirectoryEntry(_LDAP_ONE, "CN=Praewnapa Bootkosa,OU=ONEUsers,DC=one31,DC=net", "Praew@1515", AuthenticationTypes.ServerBind);

            try
            {

                string domOneE = "10.31.1.20:389";
                //string userAD = "praewnapaboo";
                //string passAD = "Praew@1515";

                //string userAD = "praewnapa.boo";
                //string passAD = "GCHDP@ssw0rd";

                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domOneE, "OU=ONEUsers,DC=one31,DC=net", "itdevauth", "ONEEP@ssw0rd")) //No need to add LDAP:// with the domain
                {
                    // validate the credentials
                    bool isValid = pc.ValidateCredentials(GlobalID, OneEpassword, ContextOptions.Negotiate);



                    //NetworkCredential credential = new NetworkCredential(GlobalID, OneEpassword);

                    if (isValid)
                    {
                        //User credentials validated

                        if (verify(GlobalID, rootOneE).Rows.Count != 0)
                        {
                            dtOne = verify(GlobalID, rootOneE);
                            table = dtOne;
                        }
                        else
                        {
                            DataTable dt = PersonalTable();
                            table = dt;
                        }
                    }
                    else
                    {
                        //Not authenticated

                        DataTable dt = PersonalTable();
                        table = dt;
                    }
                }



                //if (verify(GlobalID, rootOneE).Rows.Count != 0)
                //{
                //    dtOne = verify(GlobalID, rootOneE);
                //    table = dtOne;
                //}
                //else
                //{
                //    DataTable dt = PersonalTable();
                //    table = dt;
                //}



                //if(rootCha.Name == null)
                //{
                //    Console.WriteLine("xxxxx");
                //}

                ////dtOne = verify(GlobalID, rootOneE);
                ////dtCha = verify(GlobalID, rootCha);

                ////dtAtm = verify(GlobalID, rootAtm);

                ////dtGhc = verify(GlobalID, rootGhc);

                //if (dtOne.Rows.Count != 0)
                //{
                //    table = dtOne;
                //}
                //else if (dtCha.Rows.Count != 0)
                //{
                //    table = dtCha;
                //}
                //else if (dtGtv.Rows.Count != 0)
                //{
                //    table = dtGtv;
                //}
                //else if (dtAtm.Rows.Count != 0)
                //{
                //    table = dtAtm;
                //}
                //else if (dtGhc.Rows.Count != 0)
                //{
                //    table = dtGhc;
                //}
                //else
                //{
                //    DataTable dt = PersonalTable();
                //    table = dt;
                //}


            }
            catch (Exception ex)
            {

                throw ex;
            }
            return table;
        }

        public DataTable verify(string GlobalID, DirectoryEntry root)
        {

            DataTable table = PersonalTable();
            DataTable dt = PersonalTable();

            try
            {
                DirectorySearcher searcher = new DirectorySearcher(root);
                searcher.SearchScope = SearchScope.Subtree;
                searcher.Filter = "sAMAccountName=" + GlobalID;

                SearchResult resultEmployee = searcher.FindOne();

                if (resultEmployee == null)
                {
                    DataTable dt2 = PersonalTable();
                    return dt2;
                }
                else
                {

                    ResultPropertyCollection myResultPropColl = resultEmployee.Properties;


                    if (myResultPropColl.Count != 0)
                    {
                        MyErrorHandler = "";

                        DataRow newRow = dt.NewRow();

                        foreach (DataColumn col in table.Columns)
                        {
                            foreach (Object myCollection in myResultPropColl[col.ColumnName])
                            {
                                PersonalProperty(col.ColumnName, myCollection.ToString());



                                newRow[col.ColumnName] = myCollection.ToString();

                            }
                        }

                        dt.Rows.Add(newRow);

                        return dt;
                    }
                    else
                    {
                        MyErrorHandler = "Not found '" + GlobalID + "'";
                        DataTable dt2 = PersonalTable();
                        return dt2;
                    }

                }





            }
            catch (Exception ex)
            {

                throw ex;
            }
        }





        private void PersonalProperty(string keyName, string valueName)
        {
            switch (keyName.ToString())
            {
                case "PostalCode":
                    MyUID = valueName;
                    break;
                case "telephonenumber":
                    MyTelephoneNumber = valueName;
                    break;
                case "findepartmentcode":
                    MyDepartmentCode = valueName;
                    break;
                case "departmentnumber":
                    MyDepartmentNumber = valueName;
                    break;
                case "departmentname":
                    MyDepartmentName = valueName;
                    break;
                case "EmailAddress":
                    MyEmailAddress = valueName;
                    break;
                case "cn":
                    MyFullName = valueName;
                    break;
                case "l":
                    MyLocation = valueName;
                    break;
                case "division":
                    MyDivision = valueName;
                    break;
                case "manager":
                    MyManager = valueName;
                    break;
                case "sAMAccountName":
                    MysAMAccountName = valueName;
                    break;



            }
        }
        private DataTable PersonalTable()
        {
            DataTable table = new DataTable("PersonalTable");
            table.Columns.Add("PostalCode");
            // table.Columns.Add("telephonenumber");
            // table.Columns.Add("findepartmentcode");
            // table.Columns.Add("departmentnumber");
            // table.Columns.Add("departmentname");
            table.Columns.Add("EmailAddress");
            table.Columns.Add("cn");
            //table.Columns.Add("l");
            //table.Columns.Add("division");
            //table.Columns.Add("manager");
            table.Columns.Add("sAMAccountName");
            return table;
        }
        #endregion

    }
}