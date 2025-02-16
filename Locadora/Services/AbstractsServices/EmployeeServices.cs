
using Locadora.Data;
using Locadora.Models.Abstracts;

namespace Locadora.Services.AbstractsServices;

public abstract class EmployeeServices{
    public abstract void CreateEmployee(Employee employee);
    public abstract IEnumerable<Employee> GetAllEmployees();
    public abstract Employee? GetEmployeeById(int Id);
    public abstract Employee? GetEmployeeByName(string Name);
    public abstract Employee? PutEmployee(int Id, Employee employee);
    public abstract Employee? DeleteEmployee(int Id);
}