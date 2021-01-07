using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DatabaseProject
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }


        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
        public DataTable SelectAllEmp()
        {
            string query = "SELECT * FROM Employee;";
            return dbMan.ExecuteReader(query);
        }


        public int InsertProject(string Pname, int pnumber, string Plocation, int Dnum)
        {
            string query = "INSERT INTO Project (Pname, Pnumber, Plocation, Dnum)" +
                            "Values ('" + Pname + "'," + pnumber + ",'" + Plocation + "'," + Dnum + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable SelectDepNum()
        {
            string query = "SELECT Dnumber, Dname FROM Department;";


            return dbMan.ExecuteReader(query);

        }
        public int InsertSeller(int SellerID, string Fname, string Lname, int PhoneNumber, string Address,string  Email, int Rating, int Profit, int Income)
        {
            string query = " insert into Sellers(SellerID, Fname, Lname, PhoneNumber, Address, Email, Rating, Profit, Income)" +
                            "VALUES(" + SellerID+ ",'" + Fname + "','" + Lname + "'," + PhoneNumber + ",'" + Address + "','" + Email + "'," + Rating + "," + Profit + "," + Income + ");";
            return dbMan.ExecuteNonQuery(query);

        }
        public DataTable SelectDepName()
        {
            string query = "SELECT Dname FROM Department;";


            return dbMan.ExecuteReader(query);


        }
        public DataTable SelectDepLoc()
        {
            string query = "SELECT DISTINCT Dlocation FROM Dept_Locations;";
            return dbMan.ExecuteReader(query);
        }


        public DataTable SelectProjLoc()
        {
            string query = "SELECT DISTINCT Plocation FROM Project;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectProject(string location)
        {
            string query = "SELECT Pname,Dname FROM Department D, Project P, Dept_Locations L"
             + " where P.Dnum=D.Dnumber and L.Dnumber=D.Dnumber and L.Dlocation='" + location + "';";

            return dbMan.ExecuteReader(query);
        }

        //TODO:
        //Get SSN and address for all employees with salary less than 40000.
        //FunctionName "returnType" SelectAllEmployeesWithSalaryLessThan(?)
        //Make Sure to show only SSN and Address Not all columns


        public DataTable SelectAllEmployeesWithSalaryLessThan(int salaryRef)
        {
            string query = "SELECT SSN,Address FROM Employee "
            + " where Salary <'" + salaryRef + "';";

            return dbMan.ExecuteReader(query);
        }





        //TODO:
        //Get all female employees who work in "Administration" department
        //FunctionName "returnType" GetAllGenderWorkingInDepartment(?,?)
        //Make sure to get their Names and maybe SSN only

        public DataTable SelectAllGenderAndDep(string gender, string depname)
        {
            string query = "SELECT Fname,SSN FROM Employee E , Department D"
            + " where D.Dnumber=E.Dno and Dname='" + depname + "' and Sex='" + gender + "';";

            return dbMan.ExecuteReader(query);
        }


        //TODO:
        //Get departments names for all departments located at "Houston" (1 mark)
        //FunctionName: "returnType" GetDepartmentNamesAtLocation(?)
        //Just Get the Names
        public DataTable GetDepartmentNamesAtLocation(String depLocation)
        {

            string query = "SELECT Dname FROM Dept_Locations L, Department D "
            + " where D.Dnumber=L.Dnumber and Dlocation= '" + depLocation + "';";

            return dbMan.ExecuteReader(query);
        }


        //TODO:
        //Insert a new department. (1 mark)
        //Make sure all the required fields are given and if any important Field missing, give the user appropriate message
        public int InsertNewDepartment(string Dname, int Dnumber, int mgr_SSN, DateTime Mgr_start_date)
        {
            string query = " INSERT INTO DEPARTMENT(Dname,Dnumber,Mgr_SSN,Mgr_Start_Date)" +
                            "VALUES('" + Dname + "'," + Dnumber + "," + mgr_SSN + ",'" + Mgr_start_date + "');";
            return dbMan.ExecuteNonQuery(query);

        }


        //(To be delivered next lab)
        //
        //TODO:
        //5-Get employees names and salaries for all employees 
        //who work in a project located at "Stafford" or in "Houston" 
        //and work less than 35 hours. (1 marks)

        public DataTable GetEmployeesFromProjLocation()
        {
            string query = "SELECT DISTINCT Fname, Minit, Lname, Salary FROM Employee E,Project P,Works_On W "
                 + "where Pnumber=Pno and W.Essn=E.SSN and E.Dno=P.Dnum and (P.Plocation='Stafford' or P.Plocation='Houston' )and W.Hours<35;";


            return dbMan.ExecuteReader(query);

        }








        //6- Allow user to update salary of an employee of a certain SSN. (1 mark)
        public int UpdateSalary(int SSN, int salary)
        {
            string query = "UPDATE Employee Set Salary=" + salary + " " +
                " where SSN=" + SSN + ";";
            return dbMan.ExecuteNonQuery(query);

        }

        //7-Get the last names of department managers and their salaries. (1 mark)

        public DataTable GetNameAndSalaryOfDEPManager(string Depname)
        {
            string query = "SELECT Lname, Salary FROM Employee, Department" +
                " where  Dname='" + Depname + "' and SSN=Mgr_SSN;";
            return dbMan.ExecuteReader(query);
        }




        //8-Get Name and SSN for all employees working in "Research" department or working on projects controlled by "Research" department. (2 marks)
        public DataTable GetNameAndSSNOfEmployee()
        {
            string query = "(SELECT DISTINCT Fname,Minit Lname, SSN FROM Employee, Department" +
                " where Dno=Dnumber and Dname='Research')" +
                "UNION" + "(SELECT DISTINCT Fname,Minit Lname, SSN FROM Employee, Department,Project,Works_On "
                + "where Dnum=Dnumber and Pno=Pnumber and Dno=Dnumber and Dname='Research');";
            return dbMan.ExecuteReader(query);
        }

        //9-Get maximum, minimum and average salary for employees(1 mark)

        public DataTable Max_Min_Avg_ofemployeesSalary()
        {
            string query = "Select Max(Salary) as MaximumSalary,Min(Salary) as MinimumSalary ,Avg(Salary) AverageOfSalaries FROM Employee;";
            return dbMan.ExecuteReader(query);
        }

    }
}