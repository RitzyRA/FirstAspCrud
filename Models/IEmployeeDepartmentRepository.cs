using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp2.Models
{
    public interface IEmployeeDepartmentRepository
    {
        IEnumerable<EmployeeDepartmentViewModel> GetAll();
        bool DeleteById(int? id);
        void Create(string name, string depName);
        EmployeeDepartmentViewModel GetById(int id);
        void Update(int updateableId, string updatedName, string updatedDepName);
    }
}
