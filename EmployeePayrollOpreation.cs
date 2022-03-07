using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollUsingMultiThreading
{
    public class EmployeePayrollOpreation
    {
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
            employeePayrollDataList.ForEach(employeeData => 
            {
                Task thread = new Task(() =>
               { 
                   Console.WriteLine("Employee being added : ",employeeData.EmployeeName);
                   this.addEmployeePayroll(employeeData);
                   Console.WriteLine("Employee Added successfully : ", employeeData.EmployeeName);

               });
            });
            Console.WriteLine(this.employeePayrollDetailList.ToString());
        }

        private void addEmployeePayroll(EmployeeDetails employeeData)
        {
            employeePayrollDetailList.Add(employeeData);
        }
    }
}
