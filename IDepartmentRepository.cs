using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    internal interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();

        public void InsertDepartment(string newDepartmentName);
    }
}
