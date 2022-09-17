using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uyglama120.Repository
{
   public interface IEmployeesRepository
    {
        Task<IEnumerable<Employees>> GetEmployees();
        //tüm verileri çekmesi oluşturduk
        Task<Employees> GetEmployee(int Id);
        Task<Employees> AddEmployees(Employees employee);
        Task<Employees> UpdateEmployees(Employees employee);
        Task<Employees> DeleteEmployees(int Id);
    }
}
