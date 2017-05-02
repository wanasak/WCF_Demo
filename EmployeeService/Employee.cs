using System;
using System.Runtime.Serialization;

namespace EmployeeService
{
    [DataContract]
    public class Employee
    {
        private int _ID;
        private string _Name;
        private string _Gender;
        private DateTime _dateOfBirth;

        [DataMember(Order = 1)]
        public int ID { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public string Gender { get; set; }

        [DataMember(Order = 4)]
        public DateTime DateOfBirth { get; set; }
    }
}
