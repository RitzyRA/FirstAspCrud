using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp2.Models
{
    public class EmployeeDepartmentRepository : IEmployeeDepartmentRepository
    {
        private static List<EmployeeDepartmentViewModel> _list;
        private static IEmployeeRepository _employees;
        private static IDepartmentRepository _departments;
        public EmployeeDepartmentRepository(IEmployeeRepository employees, IDepartmentRepository departments)
        {
            _employees = employees;
            _departments = departments;
            _list = (from e in _employees.GetAll()
                           join d in _departments.GetAll() on e.DepId equals d.DepId
                           select new EmployeeDepartmentViewModel()
                           {
                               Id = e.Id,
                               Name = e.Name,
                               DepName = d.Name
                           }).ToList();
        }

        public IEnumerable<EmployeeDepartmentViewModel> GetAll()
        {
            return _list;
        }

        public bool DeleteById(int? id)
        {
            _employees.DeleteById(id);
            var ed = _list.First(ed => ed.Id == id);
            return _list.Remove(ed);
        }
        public void Create(string name, string depName)
        {
            try
            {
                _departments.GetByName(depName);
            }
            catch(InvalidOperationException)
            {
                _departments.Create(depName);
            }
            var deps = _departments.GetAll();
            int depIdx = 0;
            foreach (var dep in deps)
            {
                if (dep.Name == depName)
                    depIdx = dep.DepId;
            }
            _employees.Create(name, depIdx);
            var max = int.MinValue;
            foreach (var item in _list)
            {
                if (item.Id > max)
                    max = item.Id;
            }
            _list.Add(new EmployeeDepartmentViewModel() { Id = max + 1, Name = name, DepName = depName });
        }
        public EmployeeDepartmentViewModel GetById(int id)
        {
            return _list.First(e => e.Id == id);
        }
        public void Update(int updateableId, string updatedName, string updatedDepName)
        {
            try
            {
                _departments.GetByName(updatedDepName);
            }
            catch (InvalidOperationException)
            {
                _departments.Create(updatedDepName);
            }
            var deps = _departments.GetAll();
            int depIdx = 0;
            foreach (var dep in deps)
            {
                if (dep.Name == updatedDepName)
                    depIdx = dep.DepId;
            }
            _employees.Update(updateableId, updatedName, depIdx);
            var ed = _list.First(ed => ed.Id == updateableId);
            ed.Name = updatedName;
            ed.DepName = updatedDepName;
        }
    }
}
