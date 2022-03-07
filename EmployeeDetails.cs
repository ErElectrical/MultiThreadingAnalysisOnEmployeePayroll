using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollUsingMultiThreading
{
    public class EmployeeDetails
    {
        public  int EmployeeId { get; set; }
        public  string EmployeeName { get; set; }
        public  string Phonenumber { get; set; }
        public  string Address { get; set; }

        public  string Department { get; set; }

        public  string gender { get; set; }

        public  double basicPay { get; set; }

        public  double Deducations { get; set; }

        public  double TaxPay { get; set; }

        public  double Tax { get; set; }

        public  double NetPay { get; set; }

        public  DateTime stratdate { get; set; }

        public  string state { get; set; }

        public  string Country { get; set; }

        public EmployeeDetails(int EmployeeId,string EmployeeName,string Phonenumber,string Address,string Department,string gender,
            double basicPay,double Deducations,double TaxPay,double Tax, double NetPay, DateTime stratdate, string state, string Country)
        {
            this.EmployeeId = EmployeeId;
            this.EmployeeName = EmployeeName;
            this.Phonenumber = Phonenumber;
            this.Address = Address;
            this.Department = Department;
            this.gender = gender;
            this.basicPay = basicPay;
            this.Deducations = Deducations;
            this.TaxPay = TaxPay;
            this.Tax = Tax;
            this.NetPay = NetPay;
            this.stratdate = stratdate;
            this.state = state;
            this.Country = Country;
        }

    }
}
