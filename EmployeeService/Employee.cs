﻿using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace EmployeeService
{
    [MessageContract(IsWrapped = true,
        WrapperName = "EmployeeRequestObject",
        WrapperNamespace = "http://MyCompany.com/Employee")]
    public class EmployeeRequest
    {
        [MessageHeader(Namespace = "http://MyCompany.com/Employee")]
        public string LicenseKey { get; set; }

        [MessageBodyMember(Namespace = "http://MyCompany.com/Employee")]
        public int EmployeeID { get; set; }
    }

    [MessageContract(IsWrapped = true,
         WrapperName = "EmployeeInfoObject",
         WrapperNamespace = "http://MyCompany.com/Employee")]
    public class EmployeeInfo
    {
        public EmployeeInfo() { }
        public EmployeeInfo(Employee employee)
        {
            this.ID = employee.ID;
            this.Name = employee.Name;
            //this.Gender = employee.Gender;
            this.DOB = employee.DateOfBirth;
            this.Type = employee.Type;
            if (this.Type == EmployeeType.FullTime)
                this.AnnualSalary = ((FullTimeEmployee)employee).AnnualSalary;
            else
            {
                this.HourlyPay = ((PartTimeEmployee)employee).HourlyPay;
                this.HoursWorked = ((PartTimeEmployee)employee).HoursWorked;
            }
        }

        [MessageBodyMember(Order = 1, Namespace = "http://MyCompany.com/Employee")]
        public int ID { get; set; }

        [MessageBodyMember(Order = 2, Namespace = "http://MyCompany.com/Employee")]
        public string Name { get; set; }

        [MessageBodyMember(Order = 3, Namespace = "http://MyCompany.com/Employee")]
        public string Gender { get; set; }

        [MessageBodyMember(Order = 4, Namespace = "http://MyCompany.com/Employee")]
        public DateTime DOB { get; set; }

        [MessageBodyMember(Order = 5, Namespace = "http://MyCompany.com/Employee")]
        public EmployeeType Type { get; set; }

        [MessageBodyMember(Order = 6, Namespace = "http://MyCompany.com/Employee")]
        public int AnnualSalary { get; set; }

        [MessageBodyMember(Order = 7, Namespace = "http://MyCompany.com/Employee")]
        public int HourlyPay { get; set; }

        [MessageBodyMember(Order = 8, Namespace = "http://MyCompany.com/Employee")]
        public int HoursWorked { get; set; }
    }

    [KnownType(typeof(FullTimeEmployee))]
    [KnownType(typeof(PartTimeEmployee))]
    [DataContract(Namespace = "http://MyCompany.com/Employee")]
    public class Employee : IExtensibleDataObject
    {
        private int _ID;
        private string _Name;
        private string _Gender;
        private DateTime _dateOfBirth;

        [DataMember(Order = 1)]
        public int ID { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        //[DataMember(Order = 3)]
        //public string Gender { get; set; }

        [DataMember(Order = 4)]
        public DateTime DateOfBirth { get; set; }

        [DataMember(Order = 5)]
        public EmployeeType Type { get; set; }

        [DataMember(Order = 6)]
        public string City { get; set; }
        public ExtensionDataObject ExtensionData { get; set; }
    }

    public enum EmployeeType
    {
        FullTime = 1,
        PartTime = 2
    }
}
