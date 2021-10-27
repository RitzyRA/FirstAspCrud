using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp2.Models
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        bool DeleteById(int? id);
        void Create(string name);
        Department GetById(int id);
        Department GetByName(string name);
        void Update(int updateableId, string updatedName);
    }
}
