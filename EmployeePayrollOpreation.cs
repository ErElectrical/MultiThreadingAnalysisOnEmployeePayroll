using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace EmployeePayrollUsingMultiThreading
{
    public class EmployeePayrollOpreation
    {
        public static string ConnectionString = @"DataServer=DESKTOP-2G853OJ;Initial Catalog=Employee_Payroll_Normalisation;Integrated Security=True";


        public List<EmployeeDetails> employeePayrollDetailList = new List<EmployeeDetails>();

        public void addEmployeeToPayroll(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee Being Added : " + employeeData.EmployeeName);
                this.addEmployeePayroll(employeeData);
                Console.WriteLine("Employee added successfully" + employeeData.EmployeeId);
            });
            Console.WriteLine(this.employeePayrollDetailList.ToString());
        }

        public void addEmployeeToPayrollWithThread(List<EmployeeDetails> employeePayrollDataList)
        {
            SqlConnection connection = new SqlConnection(EmployeePayrollOpreation.ConnectionString);
            EmployeeDetails emp = new EmployeeDetails();
            employeePayrollDataList.ForEach(employeeData => 
            {
                Task thread = new Task(() =>
               { 
                   Console.WriteLine("Employee being added : ",employeeData.EmployeeName);
                   this.addEmployeePayroll(employeeData);
                   Console.WriteLine("Employee Added successfully : ", employeeData.EmployeeName);

               });
                thread.Start();

            });
            connection.Open();
            var p = new DynamicParameters();
            p.Add("@EmployeeId", emp.EmployeeId);
            p.Add("@EmployeeName", emp.EmployeeName);
            p.Add("@Phonenumber", emp.Phonenumber);
            p.Add("@Address", emp.Address);
            p.Add("@Department", emp.Department);
            p.Add("@gender", emp.gender);
            p.Add("@basicPay", emp.basicPay);
            p.Add("@Deducations", emp.Deducations);
            p.Add("@TaxPay", emp.TaxPay);
            p.Add("@Tax", emp.Tax);
            p.Add("@NetPay", emp.NetPay);
            p.Add("@stratdate", emp.stratdate);
            p.Add("@state", emp.state);
            p.Add("@Country", emp.Country);
            Task thread2 = new Task(() =>
            {
                SqlCommand cmd = new SqlCommand("spInsertData", connection);
                cmd.CommandType =  System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(p);
                cmd.ExecuteNonQuery();

            });
            thread2.Start();
            connection.Close();
            Console.WriteLine(this.employeePayrollDetailList.ToString());
        }

        public void addEmployeeToPayrollWiththreadUsingSynchronizarion(List<EmployeeDetails> employeePayrollDataList)
        {
            SqlConnection connection = new SqlConnection(EmployeePayrollOpreation.ConnectionString);
            EmployeeDetails emp = new EmployeeDetails();
            employeePayrollDataList.ForEach(employeeData =>
            {
                lock (this)
                {
                    Task thread = new Task(() =>
                    {
                        Console.WriteLine("Employee being added : ", employeeData.EmployeeName);
                        this.addEmployeePayroll(employeeData);
                        Console.WriteLine("Employee Added successfully : ", employeeData.EmployeeName);

                    });
                    thread.Start();
                }
            });
        
            connection.Open();
            var p = new DynamicParameters();
            p.Add("@EmployeeId", emp.EmployeeId);
            p.Add("@EmployeeName", emp.EmployeeName);
            p.Add("@Phonenumber", emp.Phonenumber);
            p.Add("@Address", emp.Address);
            p.Add("@Department", emp.Department);
            p.Add("@gender", emp.gender);
            p.Add("@basicPay", emp.basicPay);
            p.Add("@Deducations", emp.Deducations);
            p.Add("@TaxPay", emp.TaxPay);
            p.Add("@Tax", emp.Tax);
            p.Add("@NetPay", emp.NetPay);
            p.Add("@stratdate", emp.stratdate);
            p.Add("@state", emp.state);
            p.Add("@Country", emp.Country);
            lock (this)
            {


                Task thread2 = new Task(() =>
                {
                    SqlCommand cmd = new SqlCommand("spInsertData", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(p);
                    cmd.ExecuteNonQuery();

                });
                thread2.Start();
            }
            connection.Close();
            Console.WriteLine(this.employeePayrollDetailList.ToString());

        }
     
        private void addEmployeePayroll(EmployeeDetails employeeData)
        {
            employeePayrollDetailList.Add(employeeData);
        }
    }
}
