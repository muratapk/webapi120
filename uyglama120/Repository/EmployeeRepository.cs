using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uyglama120.DataContext;

namespace uyglama120.Repository
{
    public class EmployeeRepository : IEmployeesRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;  
        }
        public async Task<Employees> AddEmployees(Employees employee)
        {
            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employees> DeleteEmployees(int Id)
        {
            var result = await _context.Employees.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if(result==null)
            {
                return null;
            }
            else
            {
                _context.Employees.Remove(result);
               await _context.SaveChangesAsync();
                return result;
            }
        }

        public async Task<Employees> GetEmployee(int Id)
        {
            return await _context.Employees.Where(a => a.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employees>> GetEmployees()
        {
           return await _context.Employees.ToListAsync();
        }

        public async Task<Employees> UpdateEmployees(Employees employee)
        {
            var result = await _context.Employees.Where(a => a.Id ==employee.Id).FirstOrDefaultAsync();
            if (result == null)
            {
                return null;
            }
            else
            {
                result.Name = employee.Name;
                result.City = employee.City;
                              
                await _context.SaveChangesAsync();
                return result;
            }
        }
    }
}
