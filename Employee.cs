using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlingInC_
{
    [Serializable]
    internal class Employee
    {
        public  int Id;
        public string Name;
        public Employee(int Id,string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
