using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeePayrollUsingMultiThreading;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace EmployeePayrollTestCases
{
    [TestClass]
    public class UnitTest1
    {
        public static string ConnectionString = @"DataServer=DESKTOP-2G853OJ;Initial Catalog=Employee_Payroll_Normalisation;Integrated Security=True";
        SqlConnection connection = new SqlConnection("connectionString");

        [TestMethod]
        public void Given10Employee_WhenAddedTolist_shouldMathchEmployeeEntries()
        {
            EmployeeDetails emp = new EmployeeDetails();
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            employeeDetails.Add(new EmployeeDetails(EmployeeId: 12, EmployeeName: "Mark hownk", Phonenumber: "132234432", Address: "john gali,california", Department: "Advertisment", gender: "male", basicPay: 12000.00, Deducations: 120.00, TaxPay: 270.90, Tax: 560.00, NetPay: 11700.00, stratdate: new System.DateTime(2012,12,12),state: "jk", Country: "America"));
            employeeDetails.Add(new EmployeeDetails(EmployeeId: 13, EmployeeName: "Mark john", Phonenumber: "132282992", Address: "john gali,skoda", Department: "Ui/Ux team", gender: "male", basicPay: 12000.00, Deducations: 120.00, TaxPay: 270.90, Tax: 560.00, NetPay: 11700.00, stratdate: new System.DateTime(2019, 8, 25), state: "jack", Country: "uk"));
            employeeDetails.Add(new EmployeeDetails(EmployeeId: 14, EmployeeName: "sang hownk", Phonenumber: "132234032", Address: "batura gali,california", Department: "account", gender: "female", basicPay: 15200.00, Deducations: 210.00, TaxPay: 270.90, Tax: 590.00, NetPay: 13700.00, stratdate: new System.DateTime(2020, 10, 12), state: "loss", Country: "spain"));
            employeeDetails.Add(new EmployeeDetails(EmployeeId: 15, EmployeeName: "jack kuwan", Phonenumber: "902392132", Address: "kachodi gali,sankhol", Department: "Advertisment", gender: "male", basicPay: 12000.00, Deducations: 120.00, TaxPay: 270.90, Tax: 560.00, NetPay: 11700.00, stratdate: new System.DateTime(2012, 12, 12), state: "jk", Country: "lawn"));
            employeeDetails.Add(new EmployeeDetails(EmployeeId: 16, EmployeeName: "lisa dayan", Phonenumber: "9025782132", Address: "jalebi gali,gaam", Department: "developer", gender: "female", basicPay: 17000.00, Deducations: 320.00, TaxPay: 1270.90, Tax: 560.00, NetPay: 15700.00, stratdate: new System.DateTime(2012, 9, 11), state: "kuwat", Country: "france"));
            employeeDetails.Add(new EmployeeDetails(EmployeeId: 17, EmployeeName: "mock lee", Phonenumber: "902398972132", Address: "dosa gali,somya", Department: "Advertisment", gender: "male", basicPay: 19000.00, Deducations: 420.00, TaxPay: 970.90, Tax: 560.00, NetPay: 17600.00, stratdate: new System.DateTime(2012, 12, 12), state: "jk", Country: "lawn"));
            EmployeePayrollOpreation opreation = new EmployeePayrollOpreation();
            DateTime beforeinsertion = DateTime.Now;
            opreation.addEmployeeToPayroll(employeeDetails);
            DateTime afterinsertion = DateTime.Now;
            Console.WriteLine("Time Taken in insertion without threading in case of list is : ",( afterinsertion - beforeinsertion));

            using(this.connection)
            {
               
                SqlCommand cmd = new SqlCommand("spInsertData", this.connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@Phonenumber", emp.Phonenumber);
                cmd.Parameters.AddWithValue("@Address", emp.Address);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@gender", emp.gender);
                cmd.Parameters.AddWithValue("@basicPay", emp.basicPay);
                cmd.Parameters.AddWithValue("@Deducations", emp.Deducations);
                cmd.Parameters.AddWithValue("@TaxPay", emp.TaxPay);
                cmd.Parameters.AddWithValue("@Tax", emp.Tax);
                cmd.Parameters.AddWithValue("@NetPay", emp.NetPay);
                cmd.Parameters.AddWithValue("@stratdate", emp.stratdate);
                cmd.Parameters.AddWithValue("@state", emp.state);
                cmd.Parameters.AddWithValue("@Country", emp.Country);

                connection.Open();
                DateTime bforeinsert = DateTime.Now;
                cmd.ExecuteNonQuery();
                DateTime afterinsert = DateTime.Now;
                connection.Close();
                Console.WriteLine("Time taken without thread in case of database insertion", (afterinsert - bforeinsert));


);



















            }






        }


    }
}