using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp2.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        bool DeleteById(int? id);
        void Create(string name);
        Employee GetById(int id);
        void Update(int updateableId, string updatedName);
    }
}
