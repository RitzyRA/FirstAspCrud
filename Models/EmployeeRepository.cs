using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp2.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> _employees;
        public EmployeeRepository()
        {
            _employees = new List<Employee>(){
                new Employee() { Id = 1, Name = "Jonas", DepId = 1},
                new Employee() { Id = 2, Name = "Antanas", DepId = 3},
                new Employee() { Id = 3, Name = "Petras", DepId = 2}
            };
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public bool DeleteById(int? id)
        {
            var e = _employees.First(e => e.Id == id);
            return _employees.Remove(e);
        }
        public void Create(string name, int? depId)
        {
            var max = int.MinValue;
            foreach (var item in _employees)
            {
                if (item.Id > max)
                    max = item.Id;
            }
            _employees.Add(new Employee() { Id = max + 1, Name = name, DepId = (int)depId });
        }
        public Employee GetById(int id)
        {
            return _employees.First(e => e.Id == id);
        }
        public void Update(int updateableId, string updatedName, int? updatedDepId)
        {
            var e = _employees.First(e => e.Id == updateableId);
            e.Name = updatedName;
            e.DepId = (int)updatedDepId;
        }
    }
}
