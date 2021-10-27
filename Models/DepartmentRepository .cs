using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp2.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private static List<Department> _departments;
        public DepartmentRepository()
        {
            _departments = new List<Department>(){
                new Department() { DepId = 1, Name = "IT"},
                new Department() { DepId = 2, Name = "Marketing"},
                new Department() { DepId = 3, Name = "Accounting"}
            };
        }

        public IEnumerable<Department> GetAll()
        {
            return _departments;
        }

        public bool DeleteById(int? id)
        {
            var d = _departments.First(d => d.DepId == id);
            return _departments.Remove(d);
        }
        public void Create(string name)
        {
            _departments.Add(new Department() { DepId = _departments.Count + 1, Name = name });
        }
        public Department GetById(int id)
        {
            return _departments.First(d => d.DepId == id);
        }
        public Department GetByName(string name)
        {
            return _departments.First(d => d.Name == name);
        }
        public void Update(int updateableId, string updatedName)
        {
            var e = _departments.First(e => e.DepId == updateableId);
            e.Name = updatedName;
        }
    }
}
