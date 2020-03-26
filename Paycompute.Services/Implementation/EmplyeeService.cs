using Paycompute.Entity;
using Paycompute.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paycompute.Services.Implementation
{
    public class EmplyeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _Context;
        public EmplyeeService(ApplicationDbContext context)
        {
            _Context = context;
        }
        public async Task CreateAsync(Employee newEmployee)
        {
            await _Context.Employees.AddAsync(newEmployee);
            await _Context.SaveChangesAsync();

        }

        public async Task Delete(int employeeId)
        {
            var employee = GetById(employeeId);
            _Context.Remove(employee);
            await _Context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll() => _Context.Employees;

        public Employee GetById(int employeeId) =>
       _Context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();


        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            throw new NotImplementedException();
        }

        public decimal UnionFees(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _Context.Update(employee);
            await _Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employee = GetById(id);
            _Context.Update(employee);
            await _Context.SaveChangesAsync();
        }


    }
}
