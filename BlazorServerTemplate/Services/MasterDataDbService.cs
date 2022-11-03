using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BlazorServerTemplate.Data;
using BlazorServerTemplate.Models.MasterDataDbOld;

namespace BlazorServerTemplate
{
    public class MasterDataDbService
    {
        MasterDataDbContextOld Context
        {
            get
            {
                return this.context;
            }
        }

        private readonly MasterDataDbContextOld context;

        public MasterDataDbService(MasterDataDbContextOld context, IConfiguration config)
        {
            this.context = context;
//            this.context.Database.SetCommandTimeout(int.Parse(config["CommandTimeout"]));
        }

/*
        public IEnumerable<Employee> GetEmployeeNames()
        {
            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

            var command = new CommandDefinition( // get a reasonable set of active and recently inactive emps plus those in the Aderant tables
                 @"
SELECT RTRIM(E1.ClockNumber) AS EmployeeCode, E1.UserID AS UserName, ISNULL(E2.EmployeeName, E1.CommaName) AS EmployeeName, E1.SpaceName 
FROM v_Everyone E1
LEFT JOIN OPENQUERY(CMSDB, 'SELECT DISTINCT Employee_CODE AS EmployeeCode, EMPLOYEE_NAME AS EmployeeName FROM CMSNET.dbo.HBM_PERSNL WHERE INACTIVE = ''N'';') E2 ON E2.EmployeeCode = E1.ClockNumber
WHERE ISNULL(ClockNumber, '') != '' AND ISNULL(EndDate, GETDATE()) > DATEADD(MONTH, -2, GETDATE()) AND NormalUser = 1 AND DATEDIFF(D,StartDate, GETDATE()) >= 0
UNION
SELECT RTRIM(E1.EmployeeCode), E2.UserID, E1.EmployeeName, ISNULL(E2.SpaceName, E1.EmployeeName)
FROM OPENQUERY(CMSDB, 'WITH CTE1 AS (SELECT DISTINCT Employee_CODE AS EmployeeCode, EMPLOYEE_NAME AS EmployeeName, EMPL_UNO AS EMPL_UNO1 FROM CMSNET.dbo.HBM_PERSNL WHERE INACTIVE = ''N''),
    CTE2 AS (SELECT DISTINCT EMPL_UNO FROM CMSNET.dbo.GLT_JRNL WHERE PERIOD > 201706 
        UNION SELECT DISTINCT EMPL_UNO FROM CMSNET.dbo.APT_INVPMT_JE WHERE PERIOD > 202001)
    SELECT * FROM CTE1 JOIN CTE2 ON CTE2.EMPL_UNO = CTE1.EMPL_UNO1;') E1
LEFT JOIN v_Everyone E2 ON E2.ClockNumber = E1.EmployeeCode 
ORDER BY EmployeeName",
                //                @"
                //SELECT RTRIM(E1.ClockNumber) AS EmployeeCode, E1.UserID AS UserName, ISNULL(E2.EmployeeName, E1.CommaName) AS EmployeeName, E1.SpaceName 
                //FROM v_Everyone E1
                //LEFT JOIN OPENQUERY(CMSDB, 'SELECT DISTINCT Employee_CODE AS EmployeeCode, EMPLOYEE_NAME AS EmployeeName FROM CMSNET.dbo.HBM_PERSNL WHERE INACTIVE = ''N''') E2 ON E2.EmployeeCode = E1.ClockNumber
                //WHERE ISNULL(ClockNumber, '') != '' AND ISNULL(EndDate, GETDATE()) > DATEADD(MONTH, -2, GETDATE()) AND NormalUser = 1 AND DATEDIFF(D,StartDate, GETDATE()) >= 0
                //UNION
                //SELECT RTRIM(E1.EmployeeCode), E2.UserID, E1.EmployeeName, ISNULL(E2.SpaceName, E1.EmployeeName)
                //FROM OPENQUERY(CMSDB, 'SELECT DISTINCT Employee_CODE AS EmployeeCode, EMPLOYEE_NAME AS EmployeeName FROM CMSNET.dbo.HBM_PERSNL WHERE INACTIVE = ''N''
                //    AND (EMPL_UNO IN (SELECT EMPL_UNO FROM CMSNET.dbo.GLT_JRNL WHERE PERIOD > 201706)
                //		OR EMPL_UNO IN (SELECT EMPL_UNO FROM CMSNET.dbo.APT_INVPMT_JE WHERE PERIOD > 202001))') E1
                //LEFT JOIN v_Everyone E2 ON E2.ClockNumber = E1.EmployeeCode 
                //ORDER BY EmployeeName",
                //@"SELECT ClockNumber AS EmployeeCode, UserID AS UserName, SpaceName AS EmployeeName FROM v_Everyone WHERE ISNULL(ClockNumber, '') != '' 
                //    AND ISNULL(EndDate, GETDATE()) > DATEADD(MONTH, -2, GETDATE()) AND NormalUser = 1 AND DATEDIFF(D,StartDate, GETDATE()) >= 0 ORDER BY 1;",
                null,
                null,
                commandTimeout
            );

            return connection.Query<Employee>(command);
            //return await DapperDbContextExtensions.QueryAsync<Employee>(context, default,
            //    "SELECT ClockNumber AS EmployeeCode, UserID AS UserName, CommaName AS EmployeeName FROM v_Employee WHERE ISNULL(ClockNumber, '') != '' ORDER BY 1");
        }
*/
/*
        public IEnumerable<Department> GetDepartmentNames()
        {
            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

            var command = new CommandDefinition(
                "SELECT RTRIM(AcctCode) AS DeptCode, DeptName FROM Department WHERE [Enabled] = 1 ORDER BY DeptName;",
                null,
                null,
                commandTimeout
            );

            return connection.Query<Department>(command);
        }
*/

/*
        public IEnumerable<Office> GetOfficeNames()
        {
            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

            var command = new CommandDefinition(
                @"SELECT O1.* FROM OPENQUERY(CMSDB, 'SELECT DISTINCT RTRIM(OFFC_CODE) AS OfficeCode, OFFC_DESC AS OfficeName FROM CMSNET.dbo.HBL_OFFICE WHERE INACTIVE = ''N''') O1
                LEFT JOIN TSMDD.dbo.Office O2 ON O2.LMSID = O1.OfficeCode 
                WHERE ISNULL(O2.Deactive, 0) = 0
                ORDER BY OfficeName;",
                null,
                null,
                commandTimeout
            );

            return connection.Query<Office>(command);
        }
*/
/*
        public IEnumerable<Account> GetAccountNames()
        {
            var connection = context.Database.GetDbConnection();
            var commandTimeout = context.Database.GetCommandTimeout();

            var command = new CommandDefinition(
                @"SELECT * FROM OPENQUERY(CMSDB, 'SELECT DISTINCT RTRIM(ACCT_CODE) AS AccountCode, ACCT_DESC AS AccountName FROM CMSNET.dbo.GLM_CHART WHERE INACTIVE = ''N'' AND ISNUMERIC(ACCT_CODE) = 1') 
                ORDER BY AccountName;",
                null,
                null,
                commandTimeout
            );

            return connection.Query<Account>(command);
        }
*/
    }
}
